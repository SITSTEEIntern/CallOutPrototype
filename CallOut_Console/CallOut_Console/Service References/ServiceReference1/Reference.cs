﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CallOut_Console.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StationStatus", Namespace="http://schemas.datacontract.org/2004/07/CallOut_CodingServiceLib")]
    [System.SerializableAttribute()]
    public partial class StationStatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UpdateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Station {
            get {
                return this.StationField;
            }
            set {
                if ((object.ReferenceEquals(this.StationField, value) != true)) {
                    this.StationField = value;
                    this.RaisePropertyChanged("Station");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Update {
            get {
                return this.UpdateField;
            }
            set {
                if ((object.ReferenceEquals(this.UpdateField, value) != true)) {
                    this.UpdateField = value;
                    this.RaisePropertyChanged("Update");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CodingIncidentMessage", Namespace="http://schemas.datacontract.org/2004/07/CallOut_CodingServiceLib")]
    [System.SerializableAttribute()]
    public partial class CodingIncidentMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodingIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DispatchDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CallOut_Console.ServiceReference1.CodingUnits[] DispatchUnitsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IncidentAlarmField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CallOut_Console.ServiceReference1.CodingLocation IncidentLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IncidentNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IncidentPriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IncidentTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IncidentTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodingID {
            get {
                return this.CodingIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CodingIDField, value) != true)) {
                    this.CodingIDField = value;
                    this.RaisePropertyChanged("CodingID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DispatchDateTime {
            get {
                return this.DispatchDateTimeField;
            }
            set {
                if ((this.DispatchDateTimeField.Equals(value) != true)) {
                    this.DispatchDateTimeField = value;
                    this.RaisePropertyChanged("DispatchDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CallOut_Console.ServiceReference1.CodingUnits[] DispatchUnits {
            get {
                return this.DispatchUnitsField;
            }
            set {
                if ((object.ReferenceEquals(this.DispatchUnitsField, value) != true)) {
                    this.DispatchUnitsField = value;
                    this.RaisePropertyChanged("DispatchUnits");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IncidentAlarm {
            get {
                return this.IncidentAlarmField;
            }
            set {
                if ((this.IncidentAlarmField.Equals(value) != true)) {
                    this.IncidentAlarmField = value;
                    this.RaisePropertyChanged("IncidentAlarm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CallOut_Console.ServiceReference1.CodingLocation IncidentLocation {
            get {
                return this.IncidentLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.IncidentLocationField, value) != true)) {
                    this.IncidentLocationField = value;
                    this.RaisePropertyChanged("IncidentLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IncidentNo {
            get {
                return this.IncidentNoField;
            }
            set {
                if ((object.ReferenceEquals(this.IncidentNoField, value) != true)) {
                    this.IncidentNoField = value;
                    this.RaisePropertyChanged("IncidentNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IncidentPriority {
            get {
                return this.IncidentPriorityField;
            }
            set {
                if ((this.IncidentPriorityField.Equals(value) != true)) {
                    this.IncidentPriorityField = value;
                    this.RaisePropertyChanged("IncidentPriority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IncidentTitle {
            get {
                return this.IncidentTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.IncidentTitleField, value) != true)) {
                    this.IncidentTitleField = value;
                    this.RaisePropertyChanged("IncidentTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IncidentType {
            get {
                return this.IncidentTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.IncidentTypeField, value) != true)) {
                    this.IncidentTypeField = value;
                    this.RaisePropertyChanged("IncidentType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CodingLocation", Namespace="http://schemas.datacontract.org/2004/07/CallOut_CodingServiceLib")]
    [System.SerializableAttribute()]
    public partial class CodingLocation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country {
            get {
                return this.CountryField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryField, value) != true)) {
                    this.CountryField = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Unit {
            get {
                return this.UnitField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitField, value) != true)) {
                    this.UnitField = value;
                    this.RaisePropertyChanged("Unit");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CodingUnits", Namespace="http://schemas.datacontract.org/2004/07/CallOut_CodingServiceLib")]
    [System.SerializableAttribute()]
    public partial class CodingUnits : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CallsignField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitCurrentStationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitHomeStationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Callsign {
            get {
                return this.CallsignField;
            }
            set {
                if ((object.ReferenceEquals(this.CallsignField, value) != true)) {
                    this.CallsignField = value;
                    this.RaisePropertyChanged("Callsign");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FromStatus {
            get {
                return this.FromStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.FromStatusField, value) != true)) {
                    this.FromStatusField = value;
                    this.RaisePropertyChanged("FromStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnitCurrentStation {
            get {
                return this.UnitCurrentStationField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitCurrentStationField, value) != true)) {
                    this.UnitCurrentStationField = value;
                    this.RaisePropertyChanged("UnitCurrentStation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnitHomeStation {
            get {
                return this.UnitHomeStationField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitHomeStationField, value) != true)) {
                    this.UnitHomeStationField = value;
                    this.RaisePropertyChanged("UnitHomeStation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnitLocation {
            get {
                return this.UnitLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitLocationField, value) != true)) {
                    this.UnitLocationField = value;
                    this.RaisePropertyChanged("UnitLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnitType {
            get {
                return this.UnitTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitTypeField, value) != true)) {
                    this.UnitTypeField = value;
                    this.RaisePropertyChanged("UnitType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CodingAckMessage", Namespace="http://schemas.datacontract.org/2004/07/CallOut_CodingServiceLib")]
    [System.SerializableAttribute()]
    public partial class CodingAckMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AckStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AckTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AckUnitsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodingIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConsoleIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AckStatus {
            get {
                return this.AckStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.AckStatusField, value) != true)) {
                    this.AckStatusField = value;
                    this.RaisePropertyChanged("AckStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AckTimeStamp {
            get {
                return this.AckTimeStampField;
            }
            set {
                if ((object.ReferenceEquals(this.AckTimeStampField, value) != true)) {
                    this.AckTimeStampField = value;
                    this.RaisePropertyChanged("AckTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] AckUnits {
            get {
                return this.AckUnitsField;
            }
            set {
                if ((object.ReferenceEquals(this.AckUnitsField, value) != true)) {
                    this.AckUnitsField = value;
                    this.RaisePropertyChanged("AckUnits");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodingID {
            get {
                return this.CodingIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CodingIDField, value) != true)) {
                    this.CodingIDField = value;
                    this.RaisePropertyChanged("CodingID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ConsoleID {
            get {
                return this.ConsoleIDField;
            }
            set {
                if ((object.ReferenceEquals(this.ConsoleIDField, value) != true)) {
                    this.ConsoleIDField = value;
                    this.RaisePropertyChanged("ConsoleID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="CallOut_CodingServiceLib", ConfigurationName="ServiceReference1.CallOut_CodingService", CallbackContract=typeof(CallOut_Console.ServiceReference1.CallOut_CodingServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface CallOut_CodingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetStationStatus", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetStationStatusResponse")]
        CallOut_Console.ServiceReference1.StationStatus[] GetStationStatus();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetStationStatus", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetStationStatusResponse")]
        System.Threading.Tasks.Task<CallOut_Console.ServiceReference1.StationStatus[]> GetStationStatusAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/UpdateStationStatus")]
        void UpdateStationStatus(string status, string station, string timestamp);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/UpdateStationStatus")]
        System.Threading.Tasks.Task UpdateStationStatusAsync(string status, string station, string timestamp);
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsole", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsoleResponse")]
        string[] GetConnectedConsole();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsole", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsoleResponse")]
        System.Threading.Tasks.Task<string[]> GetConnectedConsoleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetCodingID", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetCodingIDResponse")]
        string GetCodingID();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetCodingID", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetCodingIDResponse")]
        System.Threading.Tasks.Task<string> GetCodingIDAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetTestID", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetTestIDResponse")]
        string GetTestID();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetTestID", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetTestIDResponse")]
        System.Threading.Tasks.Task<string> GetTestIDAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsoleNo", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsoleNoResponse")]
        string GetConnectedConsoleNo();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsoleNo", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GetConnectedConsoleNoResponse")]
        System.Threading.Tasks.Task<string> GetConnectedConsoleNoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GatewayJoin", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GatewayJoinResponse")]
        void GatewayJoin();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GatewayJoin", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GatewayJoinResponse")]
        System.Threading.Tasks.Task GatewayJoinAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GatewayLeave", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GatewayLeaveResponse")]
        void GatewayLeave();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/GatewayLeave", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/GatewayLeaveResponse")]
        System.Threading.Tasks.Task GatewayLeaveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleJoin", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleJoinResponse")]
        void ConsoleJoin(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleJoin", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleJoinResponse")]
        System.Threading.Tasks.Task ConsoleJoinAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleLeave", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleLeaveResponse")]
        void ConsoleLeave(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleLeave", ReplyAction="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleLeaveResponse")]
        System.Threading.Tasks.Task ConsoleLeaveAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/TargetMsg")]
        void TargetMsg(string[] addressList, CallOut_Console.ServiceReference1.CodingIncidentMessage codingIncidentMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/TargetMsg")]
        System.Threading.Tasks.Task TargetMsgAsync(string[] addressList, CallOut_Console.ServiceReference1.CodingIncidentMessage codingIncidentMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/AckCodingIncidentMsg")]
        void AckCodingIncidentMsg(CallOut_Console.ServiceReference1.CodingAckMessage codingAckMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/AckCodingIncidentMsg")]
        System.Threading.Tasks.Task AckCodingIncidentMsgAsync(CallOut_Console.ServiceReference1.CodingAckMessage codingAckMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/RequestConnStatus")]
        void RequestConnStatus();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/RequestConnStatus")]
        System.Threading.Tasks.Task RequestConnStatusAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/ReplyConnStatus")]
        void ReplyConnStatus(string station);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/ReplyConnStatus")]
        System.Threading.Tasks.Task ReplyConnStatusAsync(string station);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CallOut_CodingServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleDisplayMsg")]
        void ConsoleDisplayMsg(CallOut_Console.ServiceReference1.CodingIncidentMessage codingIncidentMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/EditConnStatus")]
        void EditConnStatus(string Name, string Status);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/NotifyConsoleNotConnected")]
        void NotifyConsoleNotConnected(string station, CallOut_Console.ServiceReference1.CodingIncidentMessage codingIncidentMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/RcvCodingAckMsg")]
        void RcvCodingAckMsg(CallOut_Console.ServiceReference1.CodingAckMessage codingAckMsg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/GatewayRcvConnStatus")]
        void GatewayRcvConnStatus(string station);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CallOut_CodingServiceLib/CallOut_CodingService/ConsoleRcvConnStatus")]
        void ConsoleRcvConnStatus();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CallOut_CodingServiceChannel : CallOut_Console.ServiceReference1.CallOut_CodingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CallOut_CodingServiceClient : System.ServiceModel.DuplexClientBase<CallOut_Console.ServiceReference1.CallOut_CodingService>, CallOut_Console.ServiceReference1.CallOut_CodingService {
        
        public CallOut_CodingServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CallOut_CodingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CallOut_CodingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CallOut_CodingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CallOut_CodingServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public CallOut_Console.ServiceReference1.StationStatus[] GetStationStatus() {
            return base.Channel.GetStationStatus();
        }
        
        public System.Threading.Tasks.Task<CallOut_Console.ServiceReference1.StationStatus[]> GetStationStatusAsync() {
            return base.Channel.GetStationStatusAsync();
        }
        
        public void UpdateStationStatus(string status, string station, string timestamp) {
            base.Channel.UpdateStationStatus(status, station, timestamp);
        }
        
        public System.Threading.Tasks.Task UpdateStationStatusAsync(string status, string station, string timestamp) {
            return base.Channel.UpdateStationStatusAsync(status, station, timestamp);
        }
        
        public string[] GetConnectedConsole() {
            return base.Channel.GetConnectedConsole();
        }
        
        public System.Threading.Tasks.Task<string[]> GetConnectedConsoleAsync() {
            return base.Channel.GetConnectedConsoleAsync();
        }
        
        public string GetCodingID() {
            return base.Channel.GetCodingID();
        }
        
        public System.Threading.Tasks.Task<string> GetCodingIDAsync() {
            return base.Channel.GetCodingIDAsync();
        }
        
        public string GetTestID() {
            return base.Channel.GetTestID();
        }
        
        public System.Threading.Tasks.Task<string> GetTestIDAsync() {
            return base.Channel.GetTestIDAsync();
        }
        
        public string GetConnectedConsoleNo() {
            return base.Channel.GetConnectedConsoleNo();
        }
        
        public System.Threading.Tasks.Task<string> GetConnectedConsoleNoAsync() {
            return base.Channel.GetConnectedConsoleNoAsync();
        }
        
        public void GatewayJoin() {
            base.Channel.GatewayJoin();
        }
        
        public System.Threading.Tasks.Task GatewayJoinAsync() {
            return base.Channel.GatewayJoinAsync();
        }
        
        public void GatewayLeave() {
            base.Channel.GatewayLeave();
        }
        
        public System.Threading.Tasks.Task GatewayLeaveAsync() {
            return base.Channel.GatewayLeaveAsync();
        }
        
        public void ConsoleJoin(string userName) {
            base.Channel.ConsoleJoin(userName);
        }
        
        public System.Threading.Tasks.Task ConsoleJoinAsync(string userName) {
            return base.Channel.ConsoleJoinAsync(userName);
        }
        
        public void ConsoleLeave(string userName) {
            base.Channel.ConsoleLeave(userName);
        }
        
        public System.Threading.Tasks.Task ConsoleLeaveAsync(string userName) {
            return base.Channel.ConsoleLeaveAsync(userName);
        }
        
        public void TargetMsg(string[] addressList, CallOut_Console.ServiceReference1.CodingIncidentMessage codingIncidentMsg) {
            base.Channel.TargetMsg(addressList, codingIncidentMsg);
        }
        
        public System.Threading.Tasks.Task TargetMsgAsync(string[] addressList, CallOut_Console.ServiceReference1.CodingIncidentMessage codingIncidentMsg) {
            return base.Channel.TargetMsgAsync(addressList, codingIncidentMsg);
        }
        
        public void AckCodingIncidentMsg(CallOut_Console.ServiceReference1.CodingAckMessage codingAckMsg) {
            base.Channel.AckCodingIncidentMsg(codingAckMsg);
        }
        
        public System.Threading.Tasks.Task AckCodingIncidentMsgAsync(CallOut_Console.ServiceReference1.CodingAckMessage codingAckMsg) {
            return base.Channel.AckCodingIncidentMsgAsync(codingAckMsg);
        }
        
        public void RequestConnStatus() {
            base.Channel.RequestConnStatus();
        }
        
        public System.Threading.Tasks.Task RequestConnStatusAsync() {
            return base.Channel.RequestConnStatusAsync();
        }
        
        public void ReplyConnStatus(string station) {
            base.Channel.ReplyConnStatus(station);
        }
        
        public System.Threading.Tasks.Task ReplyConnStatusAsync(string station) {
            return base.Channel.ReplyConnStatusAsync(station);
        }
    }
}
