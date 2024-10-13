using AngleSharp.Html.Parser;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HTML_downloader_1._0
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void GetHTMLHandler(object sender, RoutedEventArgs args) {
            try
            {
                string html = await Download(new Uri(URL.Text));
                var temp = new HtmlParser().ParseDocument(html);
                string text = temp.Body.TextContent;
                HTML.Text = text;
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

        private async Task<string> Download(Uri link)
        {
            try
            {
                HttpClient client = new HttpClient();
                return await client.GetStringAsync(link);
            }
            catch (Exception err) {
                ContentDialog modal = new ContentDialog
                {
                    Title = "Error",
                    Content = err.Message,
                    CloseButtonText = "OK"
                };
                await modal.ShowAsync();
                return "";
            }
        }
    }
}
