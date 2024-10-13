using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Syndication;

namespace RSS_reader_1._0
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Items> items=new ObservableCollection<Items>();    
        public MainPage()
        {
            this.InitializeComponent();
            RSS.ItemsSource= items;
        }

        private void DownloadHandler(object sender, RoutedEventArgs args) {
            Download();
        }
        private async void Download() {
            try
            {
                var uri = new Uri(URI.Text);
                var client = new SyndicationClient();
                var feed = await client.RetrieveFeedAsync(uri);

                if (feed != null)
                {
                    foreach (var item in feed.Items)
                    {
                        items.Add(new Items
                        {
                            Title = item.Title.Text,
                            Link = item.Id,
                            PublishedDate = item.PublishedDate.ToString()
                        });
                    }
                }
            }
            catch (Exception err) {
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
