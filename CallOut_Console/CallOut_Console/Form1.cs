using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; //for debug
using System.ComponentModel; //for bindinglist, inotify
using System.Timers; //Timer

// Location of the proxy.
using CallOut_Console.ServiceReference1;

namespace CallOut_Console
{
    // Specify for the callback to NOT use the current synchronization context
    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public partial class Form1 : Form, ServiceReference1.CallOut_CodingServiceCallback
    {
        //Declaration
        private SynchronizationContext _uiSyncContext = null;
        private ServiceReference1.CallOut_CodingServiceClient _CallOut_CodingService = null;

        //For toggle of button
        private bool _isConnected = false;

        //For binding of list to datagirdview
        private BindingList<ConsoleLog> _ConsoleLogList = new BindingList<ConsoleLog>();
        private BindingList<UnitsStatus> _UnitsStatusList = new BindingList<UnitsStatus>();

        //Holding current codingID (May had potential issue of overwrite need to change later)
        private string _currCodingID = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Capture the UI synchronization context
            _uiSyncContext = SynchronizationContext.Current;

            // The client callback interface must be hosted for the server to invoke the callback
            // Open a connection to the message service via the proxy (qualifier ServiceReference1 needed due to name clash)
            _CallOut_CodingService = new ServiceReference1.CallOut_CodingServiceClient(new InstanceContext(this), "WSDualHttpBinding_CallOut_CodingService");
            _CallOut_CodingService.Open();

            // Initial eventhandlers
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            //Set Setting panel on the front
            InitConsoleLogDataGrid();
            InitUnitsDataGrid();
            this.panelDisplay.Visible = false;

            // Load combobox
            this.cbID.Text = "-Select your ID-";
            foreach (StationStatus station in _CallOut_CodingService.GetStationStatus())
            {
                this.cbID.Items.Add(station.Station);
            }

            //hide accept and reject button
            this.btnAck.Visible = false;
            this.btnReject.Visible = false;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Terminate the connection to the service.
            if (_isConnected)
            {
                _CallOut_CodingService.Close();
            }

        }

        #region Display Panel

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                // Let the service know that this user is leaving
                _CallOut_CodingService.ConsoleLeave(this.cbID.Text);

                //Toggle button display
                _isConnected = false;
                this.btnConnect.Text = "Connect";
                this.cbID.Enabled = true;
            }
            else 
            {
                //contact the service.
                _CallOut_CodingService.ConsoleJoin(this.cbID.Text);

                //Change title of application
                this.Text = "Call Out Console [" + this.cbID.Text + "]";

                //Toggle button display
                _isConnected = true;
                this.btnConnect.Text = "Disconnect";
                this.cbID.Enabled = false;
            }
        }

        private void btnAck_Click(object sender, EventArgs e)
        {
            //Create a console log entry
            CreateConsoleLogEntry("Acknowledged");

            //Send Coding ack message back to gateway
            SendAckCodingIncidentMsg("Acknowledged");

            //disable ack and reject button
            this.btnAck.Visible = false;
            this.btnReject.Visible = false;

            this.lblTestStatus.Text = "Acknowledged";
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            //Create a console log entry
            CreateConsoleLogEntry("Rejected");

            //Send Coding ack message back to gateway
            SendAckCodingIncidentMsg("Rejected");

            //disable ack and reject button
            this.btnAck.Visible = false;
            this.btnReject.Visible = false;

            this.lblTestStatus.Text = "Rejected";

        }

        private void SendAckCodingIncidentMsg(string status)
        {
            CodingAckMessage codingackmsg = new CodingAckMessage();
            codingackmsg.ConsoleID = this.cbID.Text;
            codingackmsg.CodingID = _currCodingID;
            codingackmsg.AckStatus = status;
            DateTime currentdt = DateTime.Now;
            codingackmsg.AckTimeStamp = String.Format("{0:g}", currentdt);
            List<string> dispatchUnits = new List<string>();
            foreach (UnitsStatus unitstatus in _UnitsStatusList)
            {
                dispatchUnits.Add(unitstatus.CallSign);
            }
            codingackmsg.AckUnits = dispatchUnits.ToArray();
            _CallOut_CodingService.AckCodingIncidentMsg(codingackmsg);
        }

        private void UpdateDetails(CodingIncidentMessage codingIncidentMsg)
        {
            //Update the Display panel details
            this.lblTitle.Text = codingIncidentMsg.IncidentTitle;
            this.lblNumber.Text = codingIncidentMsg.IncidentNo;
            this.lblName.Text = codingIncidentMsg.IncidentLocation.Name;
            this.lblAddress.Text = codingIncidentMsg.IncidentLocation.Address;
            this.lblState.Text = codingIncidentMsg.IncidentLocation.State;
            this.lblCity.Text = codingIncidentMsg.IncidentLocation.City;
            this.lblCountry.Text = codingIncidentMsg.IncidentLocation.Country;
            this.lblType.Text = codingIncidentMsg.IncidentType;
            this.lblPriority.Text = codingIncidentMsg.IncidentPriority.ToString();
            this.lblAlarm.Text = codingIncidentMsg.IncidentAlarm.ToString();

            this.lblTestStatus.Text = "";

            //Clear and add new unit into the list
            _UnitsStatusList.Clear();

            foreach (CodingUnits unit in codingIncidentMsg.DispatchUnits)
            {
                if (unit.UnitCurrentStation.Equals(this.cbID.Text))
                {
                    UnitsStatus unitstatus = new UnitsStatus();
                    unitstatus.CallSign = unit.Callsign;
                    unitstatus.UnitType = unit.UnitType;
                    _UnitsStatusList.Add(unitstatus);
                }

                //For test message data
                if (unit.UnitCurrentStation.Equals(""))
                {
                    UnitsStatus unitstatus = new UnitsStatus();
                    unitstatus.CallSign = unit.Callsign;
                    unitstatus.UnitType = unit.UnitType;
                    _UnitsStatusList.Add(unitstatus);
                }
            }

            //Update current codingID
            _currCodingID = codingIncidentMsg.CodingID;

            //Start timer for 10 sec to auto reject
            System.Timers.Timer AutoRejectTimer = new System.Timers.Timer();
            AutoRejectTimer.Interval = 10000; //10 sec
            AutoRejectTimer.Elapsed += delegate { Timeout(codingIncidentMsg.IncidentNo); };
            AutoRejectTimer.AutoReset = false;
            AutoRejectTimer.Start();

        }

        public void Timeout(string incidentNo)
        {
            //Already ack or reject 10 sec do nth
            if (this.lblTestStatus.Text.Equals(""))
            {
                //Cross thread
                SendOrPostCallback callback =
                    delegate(object state)
                    {
                        //Create a console log entry
                        CreateConsoleLogEntry("Rejected");

                        //Send Coding ack message back to gateway
                        SendAckCodingIncidentMsg("Rejected");

                        //disable ack and reject button
                        this.btnAck.Visible = false;
                        this.btnReject.Visible = false;

                        this.lblTestStatus.Text = "Rejected";
                    };

                _uiSyncContext.Post(callback, "Message Timeout");
            }

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.panelDisplay.Visible = false;
            this.panelSetting.Visible = true;
        }

        #region Initialise Dispatch Units Data Grid View

        public void InitUnitsDataGrid()
        {
            //Initialize the datagridview
            this.dgvUnits.AutoGenerateColumns = false;
            this.dgvUnits.CellBorderStyle = DataGridViewCellBorderStyle.None;

            DataGridViewCheckBoxColumn targetColumn = new DataGridViewCheckBoxColumn();
            targetColumn.DataPropertyName = "Target";
            targetColumn.Name = "Target";
            targetColumn.HeaderText = "";
            targetColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            targetColumn.ThreeState = false;

            DataGridViewTextBoxColumn callsignColumn = new DataGridViewTextBoxColumn();
            callsignColumn.DataPropertyName = "CallSign";
            callsignColumn.HeaderText = "Call Sign";
            callsignColumn.ReadOnly = true;
            callsignColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn unittypeColumn = new DataGridViewTextBoxColumn();
            unittypeColumn.DataPropertyName = "UnitType";
            unittypeColumn.HeaderText = "Unit Type";
            unittypeColumn.ReadOnly = true;
            unittypeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvUnits.Columns.Add(targetColumn);
            this.dgvUnits.Columns.Add(callsignColumn);
            this.dgvUnits.Columns.Add(unittypeColumn);

            _UnitsStatusList.Clear();

            this.dgvUnits.DataSource = _UnitsStatusList;
        }

        #endregion

        #endregion

        #region Settings Panel

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.panelSetting.Visible = false;
            this.panelDisplay.Visible = true;
        }

        private void CreateConsoleLogEntry(string status)
        {
            ConsoleLog consolelog = new ConsoleLog();
            consolelog.CodingID = _currCodingID;
            DateTime currentdt = DateTime.Now;
            consolelog.AckTimeStamp = String.Format("{0:g}", currentdt);
            consolelog.AckFrom = "Gateway"; //Static?
            consolelog.AckStatus = status;

            _ConsoleLogList.Add(consolelog);
        }

        #region Initialise Console Log Data Grid View

        public void InitConsoleLogDataGrid()
        {
            //Initialize the datagridview
            this.dgvConsoleLog.AutoGenerateColumns = false;
            this.dgvConsoleLog.CellBorderStyle = DataGridViewCellBorderStyle.None;

            DataGridViewTextBoxColumn codingIDColumn = new DataGridViewTextBoxColumn();
            codingIDColumn.DataPropertyName = "CodingID";
            codingIDColumn.HeaderText = "CodingID";
            codingIDColumn.ReadOnly = true;
            codingIDColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn acktimeColumn = new DataGridViewTextBoxColumn();
            acktimeColumn.DataPropertyName = "AckTimeStamp";
            acktimeColumn.HeaderText = "ackTimeStamp";
            acktimeColumn.ReadOnly = true;
            acktimeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn ackfromColumn = new DataGridViewTextBoxColumn();
            ackfromColumn.DataPropertyName = "AckFrom";
            ackfromColumn.HeaderText = "ackFrom";
            ackfromColumn.ReadOnly = true;
            ackfromColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn ackstatusColumn = new DataGridViewTextBoxColumn();
            ackstatusColumn.DataPropertyName = "AckStatus";
            ackstatusColumn.HeaderText = "ackStatus";
            ackstatusColumn.ReadOnly = true;
            ackstatusColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvConsoleLog.Columns.Add(codingIDColumn);
            this.dgvConsoleLog.Columns.Add(acktimeColumn);
            this.dgvConsoleLog.Columns.Add(ackfromColumn);
            this.dgvConsoleLog.Columns.Add(ackstatusColumn);

            _ConsoleLogList.Clear();

            this.dgvConsoleLog.DataSource = _ConsoleLogList;
        }

        #endregion

        #endregion

        #region CallOut_CodingServiceCallback Methods

        public void ConsoleDisplayMsg(CodingIncidentMessage codingIncidentMsg)
        {
            SendOrPostCallback callback =
                delegate(object state)
                {
                    this.UpdateDetails(codingIncidentMsg);
                    this.btnAck.Visible = true;
                    this.btnReject.Visible = true;
                };

            _uiSyncContext.Post(callback, "updatedetails");
        }

        public void ConsoleRcvConnStatus()
        {
            SendOrPostCallback callback =
                delegate(object state)
                {
                    _CallOut_CodingService.ReplyConnStatus(this.cbID.Text);
                };

            _uiSyncContext.Post(callback, "rcv conn status request");
        }

        #region Methods not for Console

        public void EditConnStatus(string Name, string Status)
        { }
        public void RcvCodingAckMsg(CodingAckMessage codingAckMsg) 
        { }
        public void NotifyConsoleNotConnected(string userName, CodingIncidentMessage codingIncidentMsg)
        {}
        public void GatewayRcvConnStatus(string station) 
        { }

        #endregion

        #endregion

    }

    public class ConsoleLog : INotifyPropertyChanged
    {
        private string _codingID;
        private string _acktimestamp;
        private string _ackfrom;
        private string _ackstatus;
        public event PropertyChangedEventHandler PropertyChanged;

        public string CodingID
        {
            get { return _codingID; }
            set
            {
                _codingID = value;
                this.NotifyPropertyChanged("CodingID");
            }
        }
        public string AckTimeStamp
        {
            get { return _acktimestamp; }
            set
            {
                _acktimestamp = value;
                this.NotifyPropertyChanged("AckTimeStamp");
            }
        }
        public string AckFrom
        {
            get { return _ackfrom; }
            set
            {
                _ackfrom = value;
                this.NotifyPropertyChanged("AckFrom");
            }
        }
        public string AckStatus
        {
            get { return _ackstatus; }
            set
            {
                _ackstatus = value;
                this.NotifyPropertyChanged("AckStatus");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class UnitsStatus : INotifyPropertyChanged
    {
        private string _callsign;
        private string _unittype;
        public event PropertyChangedEventHandler PropertyChanged;

        public string CallSign
        {
            get { return _callsign; }
            set
            {
                _callsign = value;
                this.NotifyPropertyChanged("CallSign");
            }
        }
        public string UnitType
        {
            get { return _unittype; }
            set
            {
                _unittype = value;
                this.NotifyPropertyChanged("UnitType");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}