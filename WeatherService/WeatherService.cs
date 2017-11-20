using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.Entity;
using System.Data.Entity;
using WeatherEntities;
using WeatherEntities.Model;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        public IList<CityInfo> GetCityList()
        {
            WeatherContext wc = new WeatherContext();
            IList<CityInfo> cityList = new List<CityInfo>();
            foreach(City c in wc.Cities)
            {
                cityList.Add(new CityInfo() {Id = c.Id, Name = c.Name, Url_Code = c.Url_Code });
            }
            return cityList;
        }

        public WeatherInfo GetWeather(int id_city, DateTime date)
        {
            WeatherContext wc = new WeatherContext();
            IQueryable<Weather> weathers = wc.Weathers.Where(w => (w.Id_City == id_city && w.Date == date));
            if (weathers.Count() > 0)
            {
                Weather weather = weathers.First();
                return new WeatherInfo() { Date = date, Weather_Type = weather.Wether_Type, Temperature_Day = weather.Temperature_Day, Temperature_Night = weather.Temperature_Night };
            }
            else
            {
                return null;
            }
        }
    }
}
