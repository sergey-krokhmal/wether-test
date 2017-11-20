﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherClient.WeatherServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WeatherServiceReference.IWeatherService")]
    public interface IWeatherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherService/GetCityList", ReplyAction="http://tempuri.org/IWeatherService/GetCityListResponse")]
        WeatherService.CityInfo[] GetCityList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherService/GetCityList", ReplyAction="http://tempuri.org/IWeatherService/GetCityListResponse")]
        System.Threading.Tasks.Task<WeatherService.CityInfo[]> GetCityListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherService/GetWeather", ReplyAction="http://tempuri.org/IWeatherService/GetWeatherResponse")]
        WeatherService.WeatherInfo GetWeather(int id_city, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherService/GetWeather", ReplyAction="http://tempuri.org/IWeatherService/GetWeatherResponse")]
        System.Threading.Tasks.Task<WeatherService.WeatherInfo> GetWeatherAsync(int id_city, System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWeatherServiceChannel : WeatherClient.WeatherServiceReference.IWeatherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherServiceClient : System.ServiceModel.ClientBase<WeatherClient.WeatherServiceReference.IWeatherService>, WeatherClient.WeatherServiceReference.IWeatherService {
        
        public WeatherServiceClient() {
        }
        
        public WeatherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WeatherService.CityInfo[] GetCityList() {
            return base.Channel.GetCityList();
        }
        
        public System.Threading.Tasks.Task<WeatherService.CityInfo[]> GetCityListAsync() {
            return base.Channel.GetCityListAsync();
        }
        
        public WeatherService.WeatherInfo GetWeather(int id_city, System.DateTime date) {
            return base.Channel.GetWeather(id_city, date);
        }
        
        public System.Threading.Tasks.Task<WeatherService.WeatherInfo> GetWeatherAsync(int id_city, System.DateTime date) {
            return base.Channel.GetWeatherAsync(id_city, date);
        }
    }
}
