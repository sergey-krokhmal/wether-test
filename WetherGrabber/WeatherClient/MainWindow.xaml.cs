using System;
using System.Collections.Generic;
using System.Windows;
using WeatherClient.WeatherServiceReference;
using WeatherService;

namespace WeatherClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            WeatherServiceClient wsc = new WeatherServiceClient();  // Получить клиент сервиса получения погоды
            IList<CityInfo> cList = wsc.GetCityList();              // Получить список городов
            cbSelectCity.ItemsSource = cList;                       // Загрузить список городов в выпадающий список
            cbSelectCity.DisplayMemberPath = "Name";                // Значение для отображения
            cbSelectCity.SelectedValuePath = "Id";                  // Значение для передачи
            cbSelectCity.SelectedIndex = 0;
        }

        private void bShowWeather_Click(object sender, RoutedEventArgs e)
        {
            WeatherServiceClient wsc = new WeatherServiceClient();      // Получить клиент сервиса получения погоды
            DateTime date = DateTime.Now.Date.AddDays(1);               // Получить дату на завтра
            int Id = int.Parse(cbSelectCity.SelectedValue.ToString());  // Получить Id города для отображения погоды
            WeatherInfo wi;
            // Если есть информация о погоде на завтра, то вывести ее
            if ((wi = wsc.GetWeather(Id, date.Date)) != null)
            {
                tbDate.Text = date.ToShortDateString();
                tbWeatherType.Text = wi.Weather_Type;
                tbDayTemp.Text = wi.Temperature_Day.ToString("+0;-0");
                tbNightTemp.Text = wi.Temperature_Night.ToString("+0;-0");
            }
            // Иначе вывести ошибку
            else
            {
                tbDate.Text = "Данные о погоде на завтра отсутсвуют";
                tbWeatherType.Text = "Необходимо запустить WeatherGrabber";
            }
            // Вывести название города
            tbCityName.Text = cbSelectCity.Text;
        }
    }
}
