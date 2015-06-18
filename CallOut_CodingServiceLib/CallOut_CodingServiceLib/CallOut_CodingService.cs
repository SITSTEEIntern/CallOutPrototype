using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; //for read from file
using System.Diagnostics; //for debug
using System.ServiceModel;// for WCF to happen
using System.Runtime.Serialization;//datacontract

namespace CallOut_CodingServiceLib
{
    /// <summary>
    /// Call-Out Service Library
    /// </summary>
    [ServiceContract(
    Name = "CallOut_CodingService",
    Namespace = "CallOut_CodingServiceLib",
    SessionMode = SessionMode.Required,
    CallbackContract = typeof(IMessageServiceCallback))]

    public interface IMessageServiceInbound
    {
        //Pass Station Name to Gateway and Console
        [OperationContract]
        List<StationStatus> GetStationStatus();
        [OperationContract(IsOneWay = true)]
        void UpdateStationStatus(string status, string station, string timestamp);
        [OperationContract]
        List<string> GetConnectedConsole();

        //For CodeID and TestID
        [OperationContract]
        string GetCodingID();
        [OperationContract]
        string GetTestID();
        [OperationContract]
        string GetConnectedConsoleNo();

        //Gateway Join in the service
        [OperationContract]
        void GatewayJoin();
        [OperationContract]
        void GatewayLeave();

        //Allow Console add and remove its channel in the service
        [OperationContract]
        void ConsoleJoin(string userName);
        [OperationContract]
        void ConsoleLeave(string userName);

        //*Coding Incident Message*
        //Send test message from Gateway to Console 
        //(in a form of object same as how Gateway pass CAD message to Console)
        [OperationContract(IsOneWay = true)]
        void BroadcastTestMsg(CodingIncidentMessage codingIncidentMsg);
        [OperationContract(IsOneWay = true)]
        void TargetMsg(List<string> addressList, CodingIncidentMessage codingIncidentMsg);

        //*Coding Ack Message*
        //Reply coding ack msg back to gateway
        [OperationContract(IsOneWay = true)]
        void AckCodingIncidentMsg(CodingAckMessage codingAckMsg);

    }

    public interface IMessageServiceCallback
    {
        //[OperationContract(IsOneWay = true)]
        //void NotifyCurrentConnList(string userName, List<string> SubscriberList);

        [OperationContract(IsOneWay = true)]
        void ConsoleDisplayMsg(CodingIncidentMessage codingIncidentMsg);

        //Callback to trigger changes to Connection Status List
        [OperationContract(IsOneWay = true)]
        void EditConnStatus(string Name, string Status);

        ////Send Coding Message failed due to console not connected
        [OperationContract(IsOneWay = true)]
        void NotifyConsoleNotConnected(string station, CodingIncidentMessage codingIncidentMsg);

        //Receive Coding Ack Message from Console and update
        [OperationContract(IsOneWay = true)]
        void RcvCodingAckMsg(CodingAckMessage codingAckMsg);

    }

    /// <summary>
    /// Call Out Service behaviour
    /// </summary>
    /// <remarks>
    /// Single is the default concurrency mode, but it never hurts to be explicit.
    /// Note the single threading model still functions properly with use of one way methods for callbacks 
    /// since they are marked as one way on the contract.
    /// </remarks>
    [ServiceBehavior(
            ConcurrencyMode = ConcurrencyMode.Single,
            InstanceContextMode = InstanceContextMode.PerCall)]

    public class CallOut_CodingService : IMessageServiceInbound
    {   
        //List of callback channel in order find the link back
        private static List<IMessageServiceCallback> _ConsoleCallbackList = new List<IMessageServiceCallback>();
        private static List<IMessageServiceCallback> _GatewayCallbackList = new List<IMessageServiceCallback>();

        private static List<string> _ConnectedConsoleList = new List<string>();
        private static Dictionary<string, IMessageServiceCallback> _ConnectedConsoleDict =
        new Dictionary<string, IMessageServiceCallback>();// Default Constructor

        //List for connection status 
        private static List<StationStatus> StationIDList = new List<StationStatus>();

        //Number of connected console
        private static int _ConnectedConsoleNo = 0;

        //Keep track of CodingID and TestID in service to control
        private static int _CodingNo = 1;
        private static int _TestNo = 1;

        // Default Constructor
        public CallOut_CodingService()
        {

            //read from file to store the station name (only run one time for the first server)
            if (StationIDList.Count == 0)
            {
                string[] lineOfContents = File.ReadAllLines(@"configFile.txt");
                foreach (var name in lineOfContents)
                {
                    StationIDList.Add(new StationStatus("Offline", name, ""));
                }
            }
        }

        /*
         * Return the List of station, status, last updated time
         */
        public List<StationStatus> GetStationStatus()
        {
            return StationIDList;
        }

        /*
         * Update the Station status list when there is changes, 
         * in order to have updated information when a new gateway is created.
         */
        public void UpdateStationStatus(string status, string station, string timestamp)
        {
            foreach(StationStatus stationID in StationIDList)
            {
                if (stationID.Station.Equals(station))
                {
                    stationID.Status = status;
                    stationID.Update = timestamp;
                }
            }
        }

        public List<string> GetConnectedConsole()
        {
            return _ConnectedConsoleList;
        }

        /*
         * Return the number of connected console
         */
        public string GetConnectedConsoleNo()
        {
            return _ConnectedConsoleNo.ToString();
        }

        /*
         * Return the CodingID
         */
        public string GetCodingID()
        {
            string tmpcodeid = _CodingNo.ToString();
            _CodingNo++;
            return "COD-" + tmpcodeid;
        }

        /*
         * Return the TestID
         */
        public string GetTestID()
        {
            string tmptestid = _TestNo.ToString();
            _TestNo++;
            return "TEST-" + tmptestid;
        }

        /*
         * Server join and leave in order to place a channel path here
         */
        public void GatewayJoin()
        {
            // Subscribe the user to the conversation
            IMessageServiceCallback connectedGateway = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();

            if (!_GatewayCallbackList.Contains(connectedGateway))
            {
                _GatewayCallbackList.Add(connectedGateway);//Note the callback list is just a list of channels.
            }
        }

        public void GatewayLeave()
        {
            //Unsubscribe the user to the conversation
            IMessageServiceCallback connectedGateway = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();

            if (_GatewayCallbackList.Contains(connectedGateway))
            {
                _GatewayCallbackList.Remove(connectedGateway);//Note the callback list is just a list of channels.

            }
        }

        //Sub to server to receive msg from server
        public void ConsoleJoin(string userName)
        {
            // Add the connected console channel into the list
            IMessageServiceCallback connectedConsole = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();

            if (!_ConsoleCallbackList.Contains(connectedConsole))
            {
                _ConsoleCallbackList.Add(connectedConsole);//Note the callback list is just a list of channels.
                _ConnectedConsoleList.Add(userName);
                _ConnectedConsoleDict.Add(userName, connectedConsole);//Bind the username to the callback channel ID
                _ConnectedConsoleNo++;

                //Update the station status (for case if mutiple gateway existed)
                foreach (StationStatus station in StationIDList)
                {
                    if (station.Station.Equals(userName))
                    {
                        station.Status = "Online";
                    }
                }

                //Handle case where 2 client log in as same ID
            }

            _GatewayCallbackList.ForEach(
                delegate(IMessageServiceCallback gatewaycallback)
                {
                    gatewaycallback.EditConnStatus(userName, "Online");
                });

        }

        public void ConsoleLeave(string userName)
        {
            // Unsubscribe the user from the conversation.      
            //IMessageServiceCallback connectedConsole = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();
            IMessageServiceCallback connectedConsole = _ConnectedConsoleDict[userName];

            if (_ConsoleCallbackList.Contains(connectedConsole))
            {
                _ConsoleCallbackList.Remove(connectedConsole);
                _ConnectedConsoleDict.Remove(userName);
                _ConnectedConsoleList.Remove(userName);
                _ConnectedConsoleNo--;
                Debug.WriteLine(_ConnectedConsoleDict.Count().ToString());

                //Update the station status
                foreach (StationStatus station in StationIDList)
                {
                    if (station.Station.Equals(userName))
                    {
                        station.Status = "Offline";
                    }
                }
            }

            _GatewayCallbackList.ForEach(
                delegate(IMessageServiceCallback gatewaycallback)
                {
                    gatewaycallback.EditConnStatus(userName, "Offline");
                });

        }

        public void BroadcastTestMsg(CodingIncidentMessage codingIncidentMsg)
        {
            foreach (string tmpAddr in _ConnectedConsoleList)
            {
                IMessageServiceCallback tmpCallback = _ConnectedConsoleDict[tmpAddr];
                tmpCallback.ConsoleDisplayMsg(codingIncidentMsg);
            }
        }

        public void TargetMsg(List<string> addressList, CodingIncidentMessage codingIncidentMsg)
        {
            foreach (string station in addressList)
            {
                //If is in connected console 
                //else reply "failed" back to gateway
                //to prevent from search on an invalid key in the dictionary of connected console
                if (_ConnectedConsoleList.Contains(station))
                {
                    IMessageServiceCallback tmpCallback = _ConnectedConsoleDict[station];
                    tmpCallback.ConsoleDisplayMsg(codingIncidentMsg);
                }
                else
                {
                    _GatewayCallbackList.ForEach(
                    delegate(IMessageServiceCallback gatewaycallback)
                    {
                        gatewaycallback.NotifyConsoleNotConnected(station, codingIncidentMsg);
                    });
                }
            }
        }

        public void AckCodingIncidentMsg(CodingAckMessage codingAckMsg)
        {
            _GatewayCallbackList.ForEach(
                delegate(IMessageServiceCallback gatewaycallback)
                {
                    gatewaycallback.RcvCodingAckMsg(codingAckMsg);
                });
        }
    }

    //Custon Class Object

    [DataContract]
    public class CodingLocation
    {
        //public Location(string name, string address, string unit, string state, string city, string country)
        //{
        //    Name = name;
        //    Address = address;
        //    Unit = unit;
        //    State = state;
        //    City = city;
        //    Country = country;
        //}
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
    }

    [DataContract]
    public class CodingUnits
    {
        //public Units(string callsign, string utype, string fromstatus, string ulocation, string uhomestation, string ucurrentstaion)
        //{
        //    Callsign = callsign;
        //    UnitType = utype;
        //    FromStatus = fromstatus;
        //    UnitLocation = ulocation;
        //    UnitHomeStation = uhomestation;
        //    UnitCurrentStation = ucurrentstaion;
        //}
        [DataMember]
        public string Callsign { get; set; }
        [DataMember]
        public string UnitType { get; set; }
        [DataMember]
        public string FromStatus { get; set; }
        [DataMember]
        public string UnitLocation { get; set; }
        [DataMember]
        public string UnitHomeStation { get; set; }
        [DataMember]
        public string UnitCurrentStation { get; set; }
    }

    [DataContract]
    public class CodingIncidentMessage
    {

        [DataMember]
        public string CodingID { get; set; }
        [DataMember]
        public string IncidentNo { get; set; }
        [DataMember]
        public string IncidentTitle { get; set; }
        [DataMember]
        public CodingLocation IncidentLocation { get; set; }
        [DataMember]
        public string IncidentType { get; set; }
        [DataMember]
        public int IncidentAlarm { get; set; }
        [DataMember]
        public int IncidentPriority { get; set; }
        [DataMember]
        public DateTime DispatchDateTime { get; set; }
        [DataMember]
        public List<CodingUnits> DispatchUnits { get; set; }
    }

    [DataContract]
    public class CodingAckMessage
    {
        [DataMember]
        public string ConsoleID { get; set; }
        [DataMember]
        public string CodingID { get; set; }
        [DataMember]
        public string AckStatus { get; set; }
        [DataMember]
        public string AckTimeStamp { get; set; }
        [DataMember]
        public List<string> AckUnits { get; set; }
    }

    //Object for binding to the list

    //[DataContract]
    //public class CodingStatus
    //{
    //    [DataMember]
    //    public string IncidentID { get; set; }
    //    [DataMember]
    //    public string CodingID { get; set; }
    //    [DataMember]
    //    public string Received { get; set; }
    //    [DataMember]
    //    public string Updated { get; set; }
    //    [DataMember]
    //    public string Pending { get; set; }
    //    [DataMember]
    //    public string Acknowledged { get; set; }
    //    [DataMember]
    //    public string Rejected { get; set; }
    //    [DataMember]
    //    public string Failed { get; set; }
    //}

    //[DataContract]
    //public class MessageStatus
    //{
    //    [DataMember]
    //    public string CodingID { get; set; }
    //    [DataMember]
    //    public string AckTimeStamp { get; set; }
    //    [DataMember]
    //    public string AckFrom { get; set; }
    //    [DataMember]
    //    public string AckStatus { get; set; }
    //    [DataMember]
    //    public string AckNo { get; set; }
    //    [DataMember]
    //    public string AckTotal { get; set; }
    //}

    [DataContract]
    public class StationStatus
    {
        public StationStatus(string status, string station, string update)
        {
            Status = status;
            Station = station;
            Update = update;
        }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Station { get; set; }
        [DataMember]
        public string Update { get; set; }
    }
}