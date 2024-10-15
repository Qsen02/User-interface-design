using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Course_project
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<WeatherModel> curWeather=new ObservableCollection<WeatherModel>();
        public MainPage()
        {
            this.InitializeComponent();
            this.Weather.ItemsSource = curWeather;
        }
        private async void GetWeatherHandler(object sender, RoutedEventArgs args)
        {
            try
            {
                string location = this.Location.Text;
                if (string.IsNullOrEmpty(location)) {
                    throw new Exception("You must add City and Country separate with comma for location.");
                }
                HttpClient client = new HttpClient();
                var response = await client.GetAsync($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}?unitGroup=metric&key=WNMNLKKR9MDRMRCGDNW62GWGB&contentType=json");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Location don't exist!");
                }
                if (curWeather.Count > 0)
                {
                    curWeather.Clear();
                }
                string json = await response.Content.ReadAsStringAsync();
                WeatherModel localWeather = JsonConvert.DeserializeObject<WeatherModel>(json);
                curWeather.Add(localWeather);
            }
            catch (Exception err) {
                ContentDialog modal = new ContentDialog
                {
                Title="Error",
                Content = err.Message,
                CloseButtonText="OK"
            };
                await modal.ShowAsync();
                return;
            }
        }
    }
}
