using System;
using System.Collections.Generic;
using System.Linq;
using WeatherEntities;
using WeatherEntities.Model;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        /// <summary>
        /// Метод получения доступных городов
        /// </summary>
        /// <returns>Список информации о городах</returns>
        public IList<CityInfo> GetCityList()
        {
            WeatherContext wc = new WeatherContext();           // Получить контекст БД
            IList<CityInfo> cityList = new List<CityInfo>();    // Список информации о городах
            // Получить список городов из коллекции городов БД
            foreach(City c in wc.Cities)
            {
                cityList.Add(new CityInfo() {Id = c.Id, Name = c.Name, Url_Code = c.Url_Code });
            }
            return cityList;
        }

        /// <summary>
        /// Получить информацию о погоде для города
        /// </summary>
        /// <param name="id_city">Id города</param>
        /// <param name="date">Дата</param>
        /// <returns>Информация о погоде в городе, если ее нет, но null</returns>
        public WeatherInfo GetWeather(int id_city, DateTime date)
        {
            WeatherContext wc = new WeatherContext();   // Получить контекст БД
            // Получить коллекцию городов из БД для города id_city и для Даты date
            IQueryable<Weather> weathers = wc.Weathers.Where(w => (w.Id_City == id_city && w.Date == date));
            // Получить информацию о погоде в городе
            if (weathers.Count() > 0)
            {
                Weather weather = weathers.OrderByDescending(w => w.Id).First();
                return new WeatherInfo() { Date = date, Weather_Type = weather.Wether_Type, Temperature_Day = weather.Temperature_Day, Temperature_Night = weather.Temperature_Night };
            }
            else
            {
                return null;
            }
        }
    }
}
