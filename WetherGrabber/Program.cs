using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;
using System.Collections;

namespace WetherGrabber
{
	class Program
	{
		class PlaceTemperature
		{
			public string PlaceName { get; set; }
			public string Temperature { get; set; }
		}
		static void Main(string[] args)
		{
			var config = Configuration.Default.WithDefaultLoader().SetCulture("RU-ru");
			var address = "https://yandex.ru/pogoda/bryansk/choose";
			IBrowsingContext ib = BrowsingContext.New(config);
			Task<IDocument> document = ib.OpenAsync(address);
			IDocument b = document.Result;
			IHtmlCollection<IElement> cells = b.QuerySelectorAll(".place-list .place-list__item");
			IList<PlaceTemperature> temperatureList = new List<PlaceTemperature>();
			string tempClassName = "place-list__item-temp";
			string cityClassName = "place-list__item-name";
			foreach(IElement cell in cells)
			{
				var temperature = cell.GetElementsByClassName(tempClassName).First().TextContent.Replace("−","-");
				var cityName = cell.GetElementsByClassName(cityClassName).First().TextContent;
				temperatureList.Add(new PlaceTemperature() { PlaceName = cityName, Temperature = temperature });
			}
			Console.OutputEncoding = Encoding.Unicode;
			foreach(PlaceTemperature pt in temperatureList)
			{
				Console.WriteLine("{0} - {1}", pt.PlaceName, pt.Temperature);
			}
			Console.ReadKey();
		}
	}
}
