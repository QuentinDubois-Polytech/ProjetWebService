﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationServerConsole.JCDecauxServiceProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDContract", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheConsole")]
    [System.SerializableAttribute()]
    public partial class JCDContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] citiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string commercial_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string country_codeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
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
        public string[] cities {
            get {
                return this.citiesField;
            }
            set {
                if ((object.ReferenceEquals(this.citiesField, value) != true)) {
                    this.citiesField = value;
                    this.RaisePropertyChanged("cities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string commercial_name {
            get {
                return this.commercial_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.commercial_nameField, value) != true)) {
                    this.commercial_nameField = value;
                    this.RaisePropertyChanged("commercial_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string country_code {
            get {
                return this.country_codeField;
            }
            set {
                if ((object.ReferenceEquals(this.country_codeField, value) != true)) {
                    this.country_codeField = value;
                    this.RaisePropertyChanged("country_code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDStation", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheConsole")]
    [System.SerializableAttribute()]
    public partial class JCDStation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contractNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ApplicationServerConsole.JCDecauxServiceProxy.Position positionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ApplicationServerConsole.JCDecauxServiceProxy.Totalstands totalStandsField;
        
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
        public string contractName {
            get {
                return this.contractNameField;
            }
            set {
                if ((object.ReferenceEquals(this.contractNameField, value) != true)) {
                    this.contractNameField = value;
                    this.RaisePropertyChanged("contractName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ApplicationServerConsole.JCDecauxServiceProxy.Position position {
            get {
                return this.positionField;
            }
            set {
                if ((object.ReferenceEquals(this.positionField, value) != true)) {
                    this.positionField = value;
                    this.RaisePropertyChanged("position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ApplicationServerConsole.JCDecauxServiceProxy.Totalstands totalStands {
            get {
                return this.totalStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.totalStandsField, value) != true)) {
                    this.totalStandsField = value;
                    this.RaisePropertyChanged("totalStands");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheConsole")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double longitudeField;
        
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
        public double latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Totalstands", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheConsole")]
    [System.SerializableAttribute()]
    public partial class Totalstands : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ApplicationServerConsole.JCDecauxServiceProxy.Availabilities availabilitiesField;
        
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
        public ApplicationServerConsole.JCDecauxServiceProxy.Availabilities availabilities {
            get {
                return this.availabilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.availabilitiesField, value) != true)) {
                    this.availabilitiesField = value;
                    this.RaisePropertyChanged("availabilities");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Availabilities", Namespace="http://schemas.datacontract.org/2004/07/ProxyCacheConsole")]
    [System.SerializableAttribute()]
    public partial class Availabilities : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int standsField;
        
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
        public int bikes {
            get {
                return this.bikesField;
            }
            set {
                if ((this.bikesField.Equals(value) != true)) {
                    this.bikesField = value;
                    this.RaisePropertyChanged("bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stands {
            get {
                return this.standsField;
            }
            set {
                if ((this.standsField.Equals(value) != true)) {
                    this.standsField = value;
                    this.RaisePropertyChanged("stands");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCDecauxServiceProxy.IJCDecauxServiceProxy")]
    public interface IJCDecauxServiceProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxServiceProxy/getContractsList", ReplyAction="http://tempuri.org/IJCDecauxServiceProxy/getContractsListResponse")]
        ApplicationServerConsole.JCDecauxServiceProxy.JCDContract[] getContractsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxServiceProxy/getContractsList", ReplyAction="http://tempuri.org/IJCDecauxServiceProxy/getContractsListResponse")]
        System.Threading.Tasks.Task<ApplicationServerConsole.JCDecauxServiceProxy.JCDContract[]> getContractsListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxServiceProxy/getStationsList", ReplyAction="http://tempuri.org/IJCDecauxServiceProxy/getStationsListResponse")]
        ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[] getStationsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxServiceProxy/getStationsList", ReplyAction="http://tempuri.org/IJCDecauxServiceProxy/getStationsListResponse")]
        System.Threading.Tasks.Task<ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[]> getStationsListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxServiceProxy/getStationsListWithContractName", ReplyAction="http://tempuri.org/IJCDecauxServiceProxy/getStationsListWithContractNameResponse")]
        ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[] getStationsListWithContractName(string contractName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJCDecauxServiceProxy/getStationsListWithContractName", ReplyAction="http://tempuri.org/IJCDecauxServiceProxy/getStationsListWithContractNameResponse")]
        System.Threading.Tasks.Task<ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[]> getStationsListWithContractNameAsync(string contractName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJCDecauxServiceProxyChannel : ApplicationServerConsole.JCDecauxServiceProxy.IJCDecauxServiceProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class JCDecauxServiceProxyClient : System.ServiceModel.ClientBase<ApplicationServerConsole.JCDecauxServiceProxy.IJCDecauxServiceProxy>, ApplicationServerConsole.JCDecauxServiceProxy.IJCDecauxServiceProxy {
        
        public JCDecauxServiceProxyClient() {
        }
        
        public JCDecauxServiceProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public JCDecauxServiceProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JCDecauxServiceProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JCDecauxServiceProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ApplicationServerConsole.JCDecauxServiceProxy.JCDContract[] getContractsList() {
            return base.Channel.getContractsList();
        }
        
        public System.Threading.Tasks.Task<ApplicationServerConsole.JCDecauxServiceProxy.JCDContract[]> getContractsListAsync() {
            return base.Channel.getContractsListAsync();
        }
        
        public ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[] getStationsList() {
            return base.Channel.getStationsList();
        }
        
        public System.Threading.Tasks.Task<ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[]> getStationsListAsync() {
            return base.Channel.getStationsListAsync();
        }
        
        public ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[] getStationsListWithContractName(string contractName) {
            return base.Channel.getStationsListWithContractName(contractName);
        }
        
        public System.Threading.Tasks.Task<ApplicationServerConsole.JCDecauxServiceProxy.JCDStation[]> getStationsListWithContractNameAsync(string contractName) {
            return base.Channel.getStationsListWithContractNameAsync(contractName);
        }
    }
}
