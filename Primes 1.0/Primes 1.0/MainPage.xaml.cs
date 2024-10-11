using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Primes_1._0
{ 
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<int> numbers = new ObservableCollection<int>();
        public MainPage()
        {
            this.InitializeComponent();
            this.primeNumbers.ItemsSource = numbers;
        }
        private async void GenerateNumbersHandler(object sender, RoutedEventArgs args) {
            try
            {
                int limit = int.Parse(this.primeLimit.Text);
                for (int i = 2; i < limit; i++) {
                    bool isPrime = true;
                    for (int j = 2; j < i; j++) {
                        if (i % j == 0) { 
                        isPrime= false;
                        }                    
                    }
                    if (isPrime) {
                        numbers.Add(i);
                    }
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
            }
        }
    }
}
