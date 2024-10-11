using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Primes_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void GenerateNumebrsHandler(object sender, EventArgs args)
        {
            List<int> primes = new List<int>();
            int limit = int.Parse(this.primeLimit.Text);
            for (int k = 2; k < limit; k++)
            {
                bool prime = true;
                for (int j = 2; j < k; j++)
                {
                    if (k % j == 0) {
                        prime = false;
                     }
                }
                if (prime) { 
                    primes.Add(k); 
                }
            }
            this.primeNumbers.ItemsSource = primes;
        }
    }
}
