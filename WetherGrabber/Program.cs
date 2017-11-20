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
using System.Net;
using AngleSharp.Parser.Html;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

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

        class ProxyInfo
        {
            public string Host { get; set; }
            public int Port { get; set; }
        }

        private static IList<ProxyInfo> proxies = new List<ProxyInfo>()
        {
            new ProxyInfo() {Host = "167.114.255.85", Port = 3128 },
            new ProxyInfo() {Host = "149.202.30.89", Port = 3128 },
            new ProxyInfo() {Host = "194.60.237.195", Port = 53281 },
            new ProxyInfo() {Host = "82.114.125.106", Port = 8080 },
            new ProxyInfo() {Host = "92.50.146.210", Port = 8080 },
            new ProxyInfo() {Host = "89.22.132.57", Port = 8080 },
            new ProxyInfo() {Host = "80.90.121.234", Port = 8080 },
            new ProxyInfo() {Host = "178.205.101.112", Port = 8080 },
            new ProxyInfo() {Host = "95.31.17.30", Port = 8080 },
            new ProxyInfo() {Host = "37.123.221.222", Port = 8080 },
            //new ProxyInfo() {Host = "195.218.144.150", Port = 8080 },
            new ProxyInfo() {Host = "94.28.8.135", Port = 8087 },
            new ProxyInfo() {Host = "217.197.4.10", Port = 8081 },
            new ProxyInfo() {Host = "46.0.192.177", Port = 8081 },
            new ProxyInfo() {Host = "178.76.254.182", Port = 88 },
            new ProxyInfo() {Host = "178.49.140.252", Port = 8080 },
            new ProxyInfo() {Host = "91.143.35.115", Port = 8080 },
            new ProxyInfo() {Host = "176.214.80.153", Port = 8080 },
            new ProxyInfo() {Host = "195.68.150.118", Port = 8080 },
            new ProxyInfo() {Host = "91.219.165.47", Port = 8080 },
            new ProxyInfo() {Host = "217.150.200.152", Port = 8081 },
            new ProxyInfo() {Host = "89.22.52.3", Port = 53281 },
            new ProxyInfo() {Host = "79.120.53.158", Port = 8080 },
            new ProxyInfo() {Host = "109.167.129.14", Port = 888 },
            new ProxyInfo() {Host = "188.126.59.211", Port = 53281 },
            new ProxyInfo() {Host = "185.61.254.53", Port = 53281 },
            new ProxyInfo() {Host = "5.228.115.27", Port = 8081 }
        };

		static void Main(string[] args)
		{
            Console.WriteLine("Init Weather Grabber...");
            Console.WriteLine("Start");
            WeatherGrabbing();
            System.Timers.Timer timer = new System.Timers.Timer(3*60*60*1000);
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
            //var config = Configuration.Default.WithDefaultLoader().SetCulture("RU-ru").WithCookies();
            var address = "https://yandex.ru/pogoda/bryansk/choose";
            //IBrowsingContext ib = BrowsingContext.New(config);
            //Task<IDocument> document = ib.OpenNewAsync(address);

            WebClient client = new WebClient();
            WebProxy wp;
            client.Encoding = Encoding.UTF8;
            string str = client.DownloadString(new Uri(address));

            var parser = new HtmlParser();
            var document = parser.Parse(str);
            
            IHtmlCollection<IElement> cells = document.QuerySelectorAll(".place-list .place-list__item");
            IList<PlaceTemperature> temperatureList = new List<PlaceTemperature>();
            string tempClassName = "place-list__item-temp";
            string cityClassName = "place-list__item-name";
            foreach (IElement cell in cells)
            {
                var temperature = cell.GetElementsByClassName(tempClassName).First().TextContent.Replace("−", "-");
                var city = cell.GetElementsByClassName(cityClassName).First();
                var cityName = city.TextContent;
                var cityUrlCode = ((IHtmlAnchorElement)city).Href.Replace("about:///pogoda/", "");
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
            int i = 1;
            int connectTry = 0;
            bool downloadGood;
            Weather weather;
            DbSet<Weather> weathers = wc.Weathers;
            IElement tomorowWeather = null;
            foreach (City c in cities)
            {
                Thread.Sleep(2000);
                downloadGood = false;
                client.Encoding = Encoding.UTF8;
                while (!downloadGood)
                {
                    if (connectTry > 90)
                    {
                        return;
                    }
                    try
                    {
                        wp = new WebProxy(proxies[i].Host, proxies[i].Port);
                        client.Proxy = wp;
                        str = client.DownloadString(new Uri("https://yandex.ru/pogoda/"+c.Url_Code));
                        document = parser.Parse(str);
                        tomorowWeather = document.QuerySelectorAll(".forecast-briefly__days .forecast-briefly__day").First();
                        downloadGood = true;
                        connectTry = 0;
                    }
                    catch
                    {
                        connectTry++;
                    }
                    i++;
                    if (i > 25)
                    {
                        i = 0;
                    }
                }

                Regex rgx = new Regex("\\+\\d{4}");
                
                string result = rgx.Replace(document.QuerySelectorAll(".forecast-briefly__days .forecast-briefly__day").Where(d => d.Attributes["data-bem"].Value.Contains("\"dayIndex\":2")).First().QuerySelector(".time.forecast-briefly__date").Attributes["datetime"].Value, "");
                var dateParsed = DateTime.Parse(result);
                var tempDay = Decimal.Parse(tomorowWeather.QuerySelectorAll(".temp.forecast-briefly__temp.forecast-briefly__temp_day .temp__value").First().TextContent.Replace("−", "-"));
                var tempNight = Decimal.Parse(tomorowWeather.QuerySelectorAll(".temp.forecast-briefly__temp.forecast-briefly__temp_night .temp__value").First().TextContent.Replace("−", "-"));
                var weatherType = tomorowWeather.QuerySelectorAll(".forecast-briefly__condition").First().TextContent;
                if (wc.Weathers.Any(w => (w.Id_City == c.Id)) == true)
                {
                    weather = wc.Weathers.Where(w => (w.Id_City == c.Id && w.Date == dateParsed)).First();
                    weather.Temperature_Day = tempDay;
                    weather.Temperature_Night = tempNight;
                    weather.Wether_Type = weatherType;
                }
                else
                {
                    wc.Weathers.Add(new Weather() { Date = dateParsed.Date, Id_City = c.Id, Temperature_Day = tempDay, Temperature_Night = tempNight, Wether_Type = weatherType });
                }
            }
            wc.SaveChanges();
            Console.WriteLine("Grabbing finished at {0}", DateTime.Now.ToShortTimeString());
            Console.WriteLine(Environment.NewLine);
        }

    }
}
