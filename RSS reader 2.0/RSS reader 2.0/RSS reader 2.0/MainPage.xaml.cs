using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RSS_reader_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void GetDataHandler(object sender, EventArgs args)
        {
            RSS.ItemsSource = new ObservableCollection<FeedItems>
            (
                new FeedReader().ReadFeed(URI.Text)
            );
        }
    }
}
