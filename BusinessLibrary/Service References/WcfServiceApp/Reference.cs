﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLibrary.WcfServiceApp {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfServiceApp.IWcfConversationService")]
    public interface IWcfConversationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfConversationService/Sum", ReplyAction="http://tempuri.org/IWcfConversationService/SumResponse")]
        string Sum(int value, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfConversationService/Sum", ReplyAction="http://tempuri.org/IWcfConversationService/SumResponse")]
        System.Threading.Tasks.Task<string> SumAsync(int value, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfConversationService/Get", ReplyAction="http://tempuri.org/IWcfConversationService/GetResponse")]
        TerrariumGame.Dto.DTO.ConversationDto[] Get();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfConversationService/Get", ReplyAction="http://tempuri.org/IWcfConversationService/GetResponse")]
        System.Threading.Tasks.Task<TerrariumGame.Dto.DTO.ConversationDto[]> GetAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfConversationServiceChannel : BusinessLibrary.WcfServiceApp.IWcfConversationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfConversationServiceClient : System.ServiceModel.ClientBase<BusinessLibrary.WcfServiceApp.IWcfConversationService>, BusinessLibrary.WcfServiceApp.IWcfConversationService {
        
        public WcfConversationServiceClient() {
        }
        
        public WcfConversationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfConversationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfConversationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfConversationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Sum(int value, int b) {
            return base.Channel.Sum(value, b);
        }
        
        public System.Threading.Tasks.Task<string> SumAsync(int value, int b) {
            return base.Channel.SumAsync(value, b);
        }
        
        public TerrariumGame.Dto.DTO.ConversationDto[] Get() {
            return base.Channel.Get();
        }
        
        public System.Threading.Tasks.Task<TerrariumGame.Dto.DTO.ConversationDto[]> GetAsync() {
            return base.Channel.GetAsync();
        }
    }
}
