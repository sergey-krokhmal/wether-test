using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using System.Timers;
using WeatherEntities;
using WeatherEntities.Model;
using System.Data.Entity;
using AngleSharp.Dom.Html;
using System.Threading;
using System.Net;
using AngleSharp.Parser.Html;
using System.Text;
using System.Text.RegularExpressions;

namespace WeatherGrabber
{
    class Program
    {
        /// <summary>
        /// Класс данных о городе с сайта погоды
        /// </summary>
        class PlaceTemperature
        {
            public string CityName { get; set; }
            public string Temperature { get; set; }
            public string CityUrlCode { get; set; }
        }

        /// <summary>
        /// Класс представляющий данные о прокси сервере
        /// </summary>
        class ProxyInfo
        {
            public string Host { get; set; }
            public int Port { get; set; }
        }

        private static IList<ProxyInfo> proxies = new List<ProxyInfo>()
        {
            new ProxyInfo() {Host = "89.175.162.186", Port = 8080 },
            new ProxyInfo() {Host = "195.93.144.147", Port = 8080 },
            new ProxyInfo() {Host = "62.182.207.26", Port = 53281 },
            new ProxyInfo() {Host = "78.140.6.68", Port = 53281 },
            new ProxyInfo() {Host = "91.143.35.115", Port = 8080 },
            new ProxyInfo() {Host = "37.235.65.76", Port = 8080 },
            new ProxyInfo() {Host = "178.205.101.112", Port = 8080 },
            new ProxyInfo() {Host = "85.234.126.107", Port = 55555 },
            new ProxyInfo() {Host = "176.214.80.153", Port = 8080 },
            new ProxyInfo() {Host = "188.128.1.37", Port = 8080 },
            new ProxyInfo() {Host = "87.241.232.232", Port = 8080 },
            new ProxyInfo() {Host = "109.195.66.153", Port = 3128 },
            new ProxyInfo() {Host = "87.249.205.103", Port = 8080 },
            new ProxyInfo() {Host = "77.37.166.116", Port = 8080 },
            new ProxyInfo() {Host = "31.131.67.76", Port = 8080 },
            new ProxyInfo() {Host = "145.255.28.218", Port = 53281 },
            new ProxyInfo() {Host = "85.202.233.46", Port = 53281 },
            new ProxyInfo() {Host = "78.25.98.230", Port = 8080 },
            new ProxyInfo() {Host = "109.173.9.44", Port = 8080 },
            new ProxyInfo() {Host = "91.240.209.25", Port = 8081 },
            new ProxyInfo() {Host = "95.31.17.30", Port = 8080 },
            new ProxyInfo() {Host = "89.104.108.178", Port = 3128 },
            new ProxyInfo() {Host = "82.147.103.97", Port = 8080 },
            new ProxyInfo() {Host = "176.117.36.155", Port = 53281 },
            new ProxyInfo() {Host = "92.51.123.190", Port = 8080 },
        };

		static void Main(string[] args)
		{
            Console.WriteLine("Init Weather Grabber...");
            Console.WriteLine("Start");
            Console.WriteLine("(Press any key to stop)");
            try
            {
                // Выполнить первый парсинг погоды
                WeatherGrabbing();
                // Настроить таймер на периодическое выполнение парсинга
                System.Timers.Timer timer = new System.Timers.Timer(3*60*60*1000);
                timer.Elapsed += TimerTick;
                timer.AutoReset = true;
                timer.Enabled = true;
                // Запуск таймера
                timer.Start();
                Console.ReadKey();
                Console.WriteLine("Stop");
                Console.WriteLine("(Press any key to exit)");
                timer.Stop();
                timer.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка:", ex.Message);
            }
            Console.ReadKey();
        }

        // Метод, выполняемый по итерации таймера
        private static void TimerTick(Object source, ElapsedEventArgs e)
        {
            try
            {
                WeatherGrabbing();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка:", ex.Message);
            }
        }

        // Метод парсинга
        private static void WeatherGrabbing()
        {
            Console.WriteLine("Grabbing start at {0}", DateTime.Now.ToShortTimeString());
            string address = "https://yandex.ru/pogoda/bryansk/choose";
            string addressCity = "https://yandex.ru/pogoda/";
            string strToReplaceAbout = "about:///pogoda/";
            string tempClassName = "place-list__item-temp";
            string cityClassName = "place-list__item-name";
            string cityClassElement = ".place-list .place-list__item";


            WebClient client = new WebClient(); //Веб-клиент
            WebProxy wp;                        // Прокси
            client.Encoding = Encoding.UTF8;    // Установить кодировку
            string str = client.DownloadString(new Uri(address));   // Получить страницу с городами

            var parser = new HtmlParser();      // HTML парсер
            var document = parser.Parse(str);   // Спарсить страничку
            
            IHtmlCollection<IElement> cells = document.QuerySelectorAll(cityClassElement);  // Получить коллекцию элементов с городами
            IList<PlaceTemperature> temperatureList = new List<PlaceTemperature>();         // Список информации о городах со странички
            foreach (IElement cell in cells)
            {
                var temperature = cell.GetElementsByClassName(tempClassName).First().TextContent.Replace("−", "-"); // Температура в городе
                var city = cell.GetElementsByClassName(cityClassName).First();  // Элемент города в DOM
                var cityName = city.TextContent;    // Название города
                var cityUrlCode = ((IHtmlAnchorElement)city).Href.Replace(strToReplaceAbout, "");   // Часть url для построения ссылки на погоду в городе
                temperatureList.Add(new PlaceTemperature() { CityName = cityName, Temperature = temperature, CityUrlCode = cityUrlCode});   // Добавить информацию о городе

            }
            document.Dispose();

            WeatherContext wc = new WeatherContext();   // Контекст БД
            DbSet<City> cities = wc.Cities;             // Коллекция городов
            // Добавить в БД города
            foreach (PlaceTemperature pt in temperatureList)
            {
                if (!cities.Any(c => c.Name == pt.CityName))
                {
                    cities.Add(new City() { Name = pt.CityName, Url_Code = pt.CityUrlCode});
                    Console.WriteLine("Add new city: {0}", pt.CityName);
                }
            }
            // Сохранить измениния
            wc.SaveChanges();
            
            int i = 16;         // Индекс прокси
            int connectTry = 0; // Количество неудачных парсингов подряд
            bool downloadGood;  // Скачивание странички удалось
            Weather weather = new Weather();        // Объект погоды EF
            DbSet<Weather> weathers = wc.Weathers;  // Список объектов погоды
            IElement tomorowWeather = null;         // Элемент погоды DOM на завтра
            Regex rgx = new Regex("\\+\\d{4}");     // Выражение для удаления подстроки +0000 в дате
            string tomorowDayClass = ".forecast-briefly__days .forecast-briefly__day";  // Селектор для погоды на завтра
            string tomorowDateClass = ".time.forecast-briefly__date";                   // Селектор для даты
            string tomorowTempDay = ".temp.forecast-briefly__temp.forecast-briefly__temp_day .temp__value";     // Селектор для температуры днем
            string tomorowTempNight = ".temp.forecast-briefly__temp.forecast-briefly__temp_night .temp__value"; // Селектор для температуры ночью
            string tomorowWeatherType = ".forecast-briefly__condition"; //Селектор для типа погоды

            // Для всех городов в БД
            foreach (City c in cities)
            {
                Thread.Sleep(2000);     // Ждать, для предотвращения блокировки
                downloadGood = false;   // Изначально скачивание не удалось
                while (!downloadGood)   // Если скачивание по текущему городу не удалось
                {
                    // Если количество неудачных парсингов подряд достигло 60, то выдать ошибку
                    if (connectTry > 60)
                    {
                        throw new Exception("Yandex blocked proxy IPs, try parse later");
                    }
                    try
                    {
                        wp = new WebProxy(proxies[i].Host, proxies[i].Port);            // Получить следующий прокси
                        client.Proxy = wp;                                              // Установить его для веб-клиента
                        str = client.DownloadString(new Uri(addressCity + c.Url_Code)); // Скачать страницу погоды для города
                        document = parser.Parse(str);                                   // Парситть страницу
                        tomorowWeather = document.QuerySelectorAll(tomorowDayClass).First();    // Получить элемент погоды на завтра
                        downloadGood = true;    // Скачивание удалось
                        connectTry = 0;         // Сброс счетчика неудачных парсингов
                    }
                    catch
                    {
                        connectTry++;
                    }
                    i++;    // Инкремент индекса прокси
                    if (i > proxies.Count)  // Закольцевать индекс прокси
                    {
                        i = 0;
                    }
                }
                
                // Спарсить дату на завтра
                string result = rgx.Replace(document.QuerySelectorAll(tomorowDayClass).Where(d => d.Attributes["data-bem"].Value.Contains("\"dayIndex\":2")).First().QuerySelector(tomorowDateClass).Attributes["datetime"].Value, "");
                var dateParsed = DateTime.Parse(result);
                // Спарить температура днём и ночью на завтра
                var tempDay = Decimal.Parse(tomorowWeather.QuerySelectorAll(tomorowTempDay).First().TextContent.Replace("−", "-"));
                var tempNight = Decimal.Parse(tomorowWeather.QuerySelectorAll(tomorowTempNight).First().TextContent.Replace("−", "-"));
                // Спарсить вид погоды
                var weatherType = tomorowWeather.QuerySelectorAll(tomorowWeatherType).First().TextContent;
                // Добавить в коллекцию EF новый объект информации о погоде
                wc.Weathers.Add(new Weather() { Date = dateParsed.Date, Id_City = c.Id, Temperature_Day = tempDay, Temperature_Night = tempNight, Wether_Type = weatherType });
            }
            // Сохранить изменения в БД
            wc.SaveChanges();
            Console.WriteLine("Grabbing finished at {0}", DateTime.Now.ToShortTimeString());
            Console.WriteLine(Environment.NewLine);
        }

    }
}
