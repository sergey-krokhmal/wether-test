using System;
using System.Collections.Generic;
using System.Linq;

using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;
using System.Timers;
using WeatherEntities;
using WeatherEntities.Model;
using System.Data.Entity;
using AngleSharp.Dom.Html;
using System.Globalization;
using System.Threading;
using System.Net.Http;

namespace WeatherGrabber
{
	class Program
	{
		class PlaceTemperature
		{
			public string CityName { get; set; }
			public string Temperature { get; set; }
            public string CityUrlCode { get; set; }
		}
		static void Main(string[] args)
		{
            Console.WriteLine("Init Weather Grabber...");
            Console.WriteLine("Start");
            WeatherGrabbing();
            System.Timers.Timer timer = new System.Timers.Timer(5*60*1000);
            timer.Elapsed += TimerTick;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
            Console.ReadKey();
            Console.WriteLine("Stop");
            timer.Stop();
            timer.Dispose();
            Console.ReadKey();
        }

        private static void TimerTick(Object source, ElapsedEventArgs e)
        {
            WeatherGrabbing();
        }

        private static void WeatherGrabbing()
        {
            Console.WriteLine("Grabbing start at {0}", DateTime.Now.ToShortTimeString());
            var config = Configuration.Default.WithDefaultLoader().SetCulture("RU-ru").WithCookies();
            var address = "https://yandex.ru/pogoda/bryansk/choose";
            IBrowsingContext ib = BrowsingContext.New(config);
            Task<IDocument> document = ib.OpenNewAsync(address);
            IDocument b = document.Result;
            IHtmlCollection<IElement> cells = b.QuerySelectorAll(".place-list .place-list__item");
            IList<PlaceTemperature> temperatureList = new List<PlaceTemperature>();
            string tempClassName = "place-list__item-temp";
            string cityClassName = "place-list__item-name";
            foreach (IElement cell in cells)
            {
                var temperature = cell.GetElementsByClassName(tempClassName).First().TextContent.Replace("−", "-");
                var city = cell.GetElementsByClassName(cityClassName).First();
                var cityName = city.TextContent;
                var cityUrlCode = ((IHtmlAnchorElement)city).Href.Replace("https://yandex.ru/pogoda/", "");
                temperatureList.Add(new PlaceTemperature() { CityName = cityName, Temperature = temperature, CityUrlCode = cityUrlCode});

            }
            document.Dispose();

            WeatherContext wc = new WeatherContext();
            DbSet<City> cities = wc.Cities;
            foreach (PlaceTemperature pt in temperatureList)
            {
                if (!cities.Any(c => c.Name == pt.CityName))
                {
                    cities.Add(new City() { Name = pt.CityName, Url_Code = pt.CityUrlCode});
                    Console.WriteLine("Add new city: {0}", pt.CityName);
                }
            }
            wc.SaveChanges();
            int i = 0;
            foreach (City c in cities)
            {
                Thread.Sleep(4000);
                
                Task<IDocument> document2 = ib.OpenAsync("https://yandex.ru/pogoda/"+c.Url_Code);
                IDocument b2 = document2.Result;
                var tomorowWeather = b2.QuerySelectorAll(".forecast-briefly__days .forecast-briefly__day").First();
                var dateParsed = DateTime.Parse(tomorowWeather.QuerySelectorAll(".time.forecast-briefly__date").First().Attributes["datetime"].Value);
                var tempDay = Decimal.Parse(tomorowWeather.QuerySelectorAll(".temp.forecast-briefly__temp.forecast-briefly__temp_day .temp__value").First().TextContent.Replace("−", "-"));
                var tempNight = Decimal.Parse(tomorowWeather.QuerySelectorAll(".temp.forecast-briefly__temp.forecast-briefly__temp_night .temp__value").First().TextContent.Replace("−", "-"));
                var weatherType = tomorowWeather.QuerySelectorAll(".forecast-briefly__condition").First().TextContent;
                wc.Weathers.Add(new Weather() { Date = dateParsed.Date, Id_City = c.Id, Temperature_Day = tempDay, Temperature_Night = tempNight, Wether_Type = weatherType });
            }
            wc.SaveChanges();
            Console.WriteLine("Grabbing finished at {0}", DateTime.Now.ToShortTimeString());
            Console.WriteLine(Environment.NewLine);
        }

    }
}
