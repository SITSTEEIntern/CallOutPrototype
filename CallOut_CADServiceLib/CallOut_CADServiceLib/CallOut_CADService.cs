using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; //for read from file
using System.Diagnostics; //for debug
using System.ServiceModel;// for WCF to happen
using System.Runtime.Serialization;//datacontract

namespace CallOut_CADServiceLib
{
    /// <summary>
    /// Call-Out Service Library
    /// </summary>
    [ServiceContract(
    Name = "CallOut_CADService",
    Namespace = "CallOut_CADServiceLib",
    SessionMode = SessionMode.Required,
    CallbackContract = typeof(IMessageServiceCallback))]

    public interface IMessageServiceInbound
    {
        //Gateway Join in the service
        [OperationContract]
        void CADJoin();
        [OperationContract]
        void CADLeave();

        //Gateway Join in the service
        [OperationContract]
        void GatewayJoin();
        [OperationContract]
        void GatewayLeave();

        //*CAD Incident Message*
        //Call by CAD 
        [OperationContract(IsOneWay = true)]
        void SendCADIncidentMsg(CADIncidentMessage CADincidentmsg);

        //*CAD Incident Acknowlegement*
        //Call by Gateway
        [OperationContract(IsOneWay = true)]
        void AckCADIncidentMsg(CADIncidentAck CADincidentack);

        //*CAD Incident Coding Status Broadcast*
        //Call by Gateway
        [OperationContract(IsOneWay = true)]
        void BroadcastIncidentCodingStatus(CADIncidentCodingStatus incidentcodingstatus);

        //*CAD Incident Coding Status Query*
        //Call by CAD
        [OperationContract(IsOneWay = true)]
        void IncidentCodingStatusQuery(string querycodingID);

        //*CAD Incident Coding Status Query Response*
        //Call by Gateway
        [OperationContract(IsOneWay = true)]
        void IncidentCodingStatusResponse(CADIncidentAck codingstatusresponse);

    }

    public interface IMessageServiceCallback
    {
        //Receive at Gateway the information from CAD and thus trigger to pass to Console
        [OperationContract(IsOneWay = true)]
        void RcvCADIncidentMsg(CADIncidentMessage CADincidentMsg);

        //Receive Ack from gateway and update according at the CAD
        [OperationContract(IsOneWay = true)]
        void UpdateCADIncidentAck(CADIncidentAck CADincidentack);

        //keep update once there is a respond from the console to gateway
        [OperationContract(IsOneWay = true)]
        void UpdateIncidentCodingStatus(CADIncidentCodingStatus incidentcodingstatus);

        //Retrieve Incident Coding Status base on Query
        [OperationContract(IsOneWay = true)]
        void IncidentCodingStatus(string querycodingID);

        //Update according at the CAD from thr adhoc Incident Coding Query
        [OperationContract(IsOneWay = true)]
        void RcvIncidentCodingStatusResponse(CADIncidentAck codingstatusresponse);

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

    public class CallOut_CADService : IMessageServiceInbound
    {
        //List of callback channel in order find the link back
        private static List<IMessageServiceCallback> _CADCallbackList = new List<IMessageServiceCallback>();
        private static List<IMessageServiceCallback> _GatewayCallbackList = new List<IMessageServiceCallback>();

        // Default Constructor
        public CallOut_CADService()
        {}

        /*
         * CAD join and leave in order to place a channel path here
         */
        public void CADJoin()
        {
            // Subscribe the user to the conversation
            IMessageServiceCallback connectedCAD = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();

            if (!_CADCallbackList.Contains(connectedCAD))
            {
                _CADCallbackList.Add(connectedCAD);//Note the callback list is just a list of channels.
            }
        }

        public void CADLeave()
        {
            //Unsubscribe the user to the conversation
            IMessageServiceCallback connectedCAD = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>();

            if (_CADCallbackList.Contains(connectedCAD))
            {
                _CADCallbackList.Remove(connectedCAD);//Note the callback list is just a list of channels.

            }
        }

        /*
         * Gateway join and leave in order to place a channel path here
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

        //The passing of CAD Incident Message from CAD to Gateway
        public void SendCADIncidentMsg(CADIncidentMessage CADincidentmsg)
        {
            _GatewayCallbackList.ForEach(
                delegate(IMessageServiceCallback gatewaycallback)
                {
                    gatewaycallback.RcvCADIncidentMsg(CADincidentmsg);
                });
        }

        public void AckCADIncidentMsg(CADIncidentAck CADincidentack)
        {
            _CADCallbackList.ForEach(
                delegate(IMessageServiceCallback cadcallback)
                {
                    cadcallback.UpdateCADIncidentAck(CADincidentack);
                });
        }


        public void BroadcastIncidentCodingStatus(CADIncidentCodingStatus incidentcodingstatus)
        {
            _CADCallbackList.ForEach(
                delegate(IMessageServiceCallback cadcallback)
                {
                    cadcallback.UpdateIncidentCodingStatus(incidentcodingstatus);
                });
        }


        public void IncidentCodingStatusQuery(string querycodingID)
        {
            _GatewayCallbackList.ForEach(
                delegate(IMessageServiceCallback gatewaycallback)
                {
                    gatewaycallback.IncidentCodingStatus(querycodingID);
                });
        }

        public void IncidentCodingStatusResponse(CADIncidentAck codingstatusresponse)
        {
            _CADCallbackList.ForEach(
                delegate(IMessageServiceCallback cadcallback)
                {
                    cadcallback.RcvIncidentCodingStatusResponse(codingstatusresponse);
                });
        }

    }

    //Custon Class Object

    [DataContract]
    public class IncidentLocation
    {
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
    public class IncidentUnits
    {
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
    public class CADIncidentMessage
    {
        [DataMember]
        public string IncidentNo { get; set; }
        [DataMember]
        public string IncidentTitle { get; set; }
        [DataMember]
        public IncidentLocation IncidentLocation { get; set; }
        [DataMember]
        public string IncidentType { get; set; }
        [DataMember]
        public int IncidentAlarm { get; set; }
        [DataMember]
        public int IncidentPriority { get; set; }
        [DataMember]
        public DateTime DispatchDateTime { get; set; }
        [DataMember]
        public List<IncidentUnits> DispatchUnits { get; set; }
    }

    [DataContract]
    public class Tracking
    {
        [DataMember]
        public string Station { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public List<string> Unit { get; set; }
    }

    [DataContract]
    public class CADIncidentAck
    {
        [DataMember]
        public string CodingID { get; set; }
        [DataMember]
        public List<Tracking> AckTracking { get; set; }
        [DataMember]
        public DateTime AckTimeStamp { get; set; }
        [DataMember]
        public int AckNo { get; set; }
        [DataMember]
        public int AckTotal { get; set; }
    }

    [DataContract]
    public class CADIncidentCodingStatus
    {
        [DataMember]
        public string CodingID { get; set; }
        [DataMember]
        public Tracking AckTracking { get; set; }
        [DataMember]
        public string AckFrom { get; set; }
        [DataMember]
        public string AckStatus { get; set; }
        [DataMember]
        public DateTime AckTimeStamp { get; set; }
        [DataMember]
        public int AckNo { get; set; }
        [DataMember]
        public int AckTotal { get; set; }
    }

}