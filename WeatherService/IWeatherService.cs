using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WeatherEntities.Model;

namespace WeatherService
{
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        IList<CityInfo> GetCityList();

        [OperationContract]
        WeatherInfo GetWeather(int id_city, DateTime date);
    }

    [DataContract]
    public class CityInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url_Code { get; set; }
    }

    [DataContract]
    public class WeatherInfo
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Weather_Type { get; set; }

        [DataMember]
        public decimal Temperature_Day { get; set; }

        [DataMember]
        public decimal Temperature_Night { get; set; }
    }
}
