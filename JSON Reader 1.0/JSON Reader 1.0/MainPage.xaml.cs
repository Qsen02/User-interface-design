using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Media.SpeechSynthesis;

namespace JSON_Reader_1._0
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void GetJokeHandler(object sender,RoutedEventArgs args)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri("https://api.chucknorris.io/jokes/random"));

                var joke = JsonConvert.DeserializeObject<Root>(json);

                var html = new HtmlParser().ParseDocument(joke.Value);
                string text = html.Body.TextContent;

                Joke.Text = text;
            }
            catch (Exception err) {
                ContentDialog modal = new ContentDialog
                {
                    Title = "Error",
                    Content = err.Message,
                    CloseButtonText="OK"
                };
                await modal.ShowAsync();
            }
        }
        private async void TellJokeHandler(object sender, RoutedEventArgs args) {
            try
            {
                if (Joke.Text != "") {
                    var mediaElement = new MediaElement();
                    var synth = new SpeechSynthesizer();
                    var stream=await synth.SynthesizeTextToStreamAsync(Joke.Text);
                    mediaElement.SetSource(stream, stream.ContentType);
                    mediaElement.Play();
                }
            }
            catch (Exception err)
            {
                ContentDialog modal = new ContentDialog
                {
                    Title = "Error",
                    Content = err.Message,
                    CloseButtonText = "OK"
                };
                await modal.ShowAsync();
            }
        }
    }
}
