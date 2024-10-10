using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Suma_1._0
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void OnClickEventHandler(object sender, RoutedEventArgs e) {
            try
            {
                float A = float.Parse(this.boxA.Text);
                float B = float.Parse(this.boxB.Text);
                float Sum = A + B;
                this.Sum.Text = Sum.ToString();
            }
            catch (Exception err)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Only numbers can be included!",
                    CloseButtonText = "OK"

                };
               await errorDialog.ShowAsync();
            }
        }
    }
}
