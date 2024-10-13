using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using AngleSharp.Html.Parser;

namespace HTML_downloader_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void GetHTMLHandler(object sender, EventArgs args)
        {
            // Get Html
            string html = await Download(new Uri(URL.Text));

            // Angle Sharp Html to Text Parser
            var temp = new HtmlParser().ParseDocument(html);
            string text = temp.Body.TextContent;

            // Plain Text
            HTML.Text = text;
        }
        // Download Handler
        async Task<string> Download(Uri link)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(link);
        }
    }

}
