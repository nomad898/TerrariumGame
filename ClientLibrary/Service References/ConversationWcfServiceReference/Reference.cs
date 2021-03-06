﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientLibrary.ConversationWcfServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ConversationWcfServiceReference.IConversationWcfService")]
    public interface IConversationWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConversationWcfService/Get", ReplyAction="http://tempuri.org/IConversationWcfService/GetResponse")]
        TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract[] Get();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConversationWcfService/Get", ReplyAction="http://tempuri.org/IConversationWcfService/GetResponse")]
        System.Threading.Tasks.Task<TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract[]> GetAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConversationWcfService/Create", ReplyAction="http://tempuri.org/IConversationWcfService/CreateResponse")]
        void Create(TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract conversation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConversationWcfService/Create", ReplyAction="http://tempuri.org/IConversationWcfService/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract conversation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConversationWcfService/CreateConversation", ReplyAction="http://tempuri.org/IConversationWcfService/CreateConversationResponse")]
        void CreateConversation(string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConversationWcfService/CreateConversation", ReplyAction="http://tempuri.org/IConversationWcfService/CreateConversationResponse")]
        System.Threading.Tasks.Task CreateConversationAsync(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConversationWcfServiceChannel : ClientLibrary.ConversationWcfServiceReference.IConversationWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConversationWcfServiceClient : System.ServiceModel.ClientBase<ClientLibrary.ConversationWcfServiceReference.IConversationWcfService>, ClientLibrary.ConversationWcfServiceReference.IConversationWcfService {
        
        public ConversationWcfServiceClient() {
        }
        
        public ConversationWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConversationWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConversationWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConversationWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract[] Get() {
            return base.Channel.Get();
        }
        
        public System.Threading.Tasks.Task<TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract[]> GetAsync() {
            return base.Channel.GetAsync();
        }
        
        public void Create(TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract conversation) {
            base.Channel.Create(conversation);
        }
        
        public System.Threading.Tasks.Task CreateAsync(TerrariumGame.WcfServiceApp.DataContracts.ConversationDataContract conversation) {
            return base.Channel.CreateAsync(conversation);
        }
        
        public void CreateConversation(string message) {
            base.Channel.CreateConversation(message);
        }
        
        public System.Threading.Tasks.Task CreateConversationAsync(string message) {
            return base.Channel.CreateConversationAsync(message);
        }
    }
}
