﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.2027
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FxtService.Proxy.FxtAPI {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FxtAPI.IFxtAPI")]
    public interface IFxtAPI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFxtAPI/Cross", ReplyAction="http://tempuri.org/IFxtAPI/CrossResponse")]
        string Cross(int projectId, int cityId, int codeType, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFxtAPI/GetProvince", ReplyAction="http://tempuri.org/IFxtAPI/GetProvinceResponse")]
        string GetProvince();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFxtAPI/GetCity", ReplyAction="http://tempuri.org/IFxtAPI/GetCityResponse")]
        string GetCity(int provinceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFxtAPI/GetArea", ReplyAction="http://tempuri.org/IFxtAPI/GetAreaResponse")]
        string GetArea(int cityId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFxtAPIChannel : FxtService.Proxy.FxtAPI.IFxtAPI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FxtAPIClient : System.ServiceModel.ClientBase<FxtService.Proxy.FxtAPI.IFxtAPI>, FxtService.Proxy.FxtAPI.IFxtAPI {
        
        public FxtAPIClient() {
        }
        
        public FxtAPIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FxtAPIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FxtAPIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FxtAPIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Cross(int projectId, int cityId, int codeType, string date) {
            return base.Channel.Cross(projectId, cityId, codeType, date);
        }
        
        public string GetProvince() {
            return base.Channel.GetProvince();
        }
        
        public string GetCity(int provinceId) {
            return base.Channel.GetCity(provinceId);
        }
        
        public string GetArea(int cityId) {
            return base.Channel.GetArea(cityId);
        }
    }
}