using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace JSON_Reader_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void GetJokeHandler(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync(new Uri("https://api.chucknorris.io/jokes/random"));

            Root joke = JsonConvert.DeserializeObject<Root>(json);

            JOKE.Text = joke.Value;
        }
        private async void TellJokeHandler(object sender, EventArgs e)
        {
            string joke = JOKE.Text;
            if (joke != "")
            {
                await TextToSpeech.SpeakAsync(joke);
            }
        }
    }
}
