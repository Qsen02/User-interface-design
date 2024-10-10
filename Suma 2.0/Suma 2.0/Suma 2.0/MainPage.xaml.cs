using System;
using Xamarin.Forms;

namespace Suma_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
                float A = float.Parse(this.boxA.Text);
                float B = float.Parse(this.boxB.Text);
                float Sum = A + B;
                this.Sum.Text = Sum.ToString();
        }
    }
}
