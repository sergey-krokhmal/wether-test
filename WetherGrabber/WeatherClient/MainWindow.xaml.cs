using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            WeatherServiceClient wsc = new WeatherServiceClient();
            IList<CityInfo> cList = wsc.GetCityList();
            cbSelectCity.ItemsSource = cList;
            cbSelectCity.DisplayMemberPath = "Name";
            cbSelectCity.SelectedValuePath = "Id";
            cbSelectCity.SelectedIndex = 0;
        }

        private void bShowWeather_Click(object sender, RoutedEventArgs e)
        {
            WeatherServiceClient wsc = new WeatherServiceClient();
            DateTime date = DateTime.Now;
            int Id = int.Parse(cbSelectCity.SelectedValue.ToString());
            WeatherInfo wi = wsc.GetWeather(Id, date.Date.AddDays(1));
            tbWeatherType.Text = wi.Weather_Type;
            tbDayTemp.Text = wi.Temperature_Day.ToString("+0;-0");
            tbNightTemp.Text = wi.Temperature_Night.ToString("+0;-0");
        }
    }
}
