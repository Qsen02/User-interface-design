using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Fibonacci_1._0
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<int> numbers = new ObservableCollection<int>();
        public MainPage()
        {
            this.InitializeComponent();
            this.boxNumbers.ItemsSource = numbers;
        }

        private async void OnClickHandler(object sender, RoutedEventArgs args) {
            try
            {
                int limit = int.Parse(this.boxLimit.Text);
                int a = 1, b = 1, c = a + b;
                numbers.Add(1);
                numbers.Add(1);
                while (c < limit)
                {
                    numbers.Add(c);
                    a = b;
                    b = c;
                    c = a + b;
                }
            }
            catch (Exception err) {
                ContentDialog modal = new ContentDialog
                {
                    Title = "Error",
                    Content = "Only integer numbers can be included!",
                    CloseButtonText = "OK"
                };
                await modal.ShowAsync();
                return;
            }
        }
    }
}
