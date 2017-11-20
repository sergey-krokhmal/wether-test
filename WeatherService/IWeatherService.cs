using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WeatherEntities.Model;

namespace WeatherService
{
    /// <summary>
    /// Интерфейс, предоставляющий методы получения информации о погоде для города
    /// </summary>
    [ServiceContract]
    public interface IWeatherService
    {
        /// <summary>
        /// Получить список городов
        /// </summary>
        [OperationContract]
        IList<CityInfo> GetCityList();

        /// <summary>
        /// Получить список информации о погоде
        /// </summary>
        /// <param name="id_city">Id города из БД</param>
        /// <param name="date">Дата погоды</param>
        [OperationContract]
        WeatherInfo GetWeather(int id_city, DateTime date);
    }

    /// <summary>
    /// Класс информации о городе
    /// </summary>
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

    /// <summary>
    /// Класс информации о погоде для города
    /// </summary>
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
