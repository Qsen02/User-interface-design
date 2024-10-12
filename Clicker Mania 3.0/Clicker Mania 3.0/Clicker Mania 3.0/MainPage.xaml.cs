using System;
using Xamarin.Forms;

namespace Clicker_Mania_3._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerTick);
        }
        private bool TimerTick() {
            int timer = int.Parse(Timer.Text);
            this.Timer.Text=(++timer).ToString();
            this.CPM.Text = (float.Parse(Clicks.Text) / float.Parse(Timer.Text) * 60).ToString("N2");
            return true;
        }
        private void ClickHandler(object sender,EventArgs args) { 
            int clicks=int.Parse(Clicks.Text);
            this.Clicks.Text=(++clicks).ToString();
        }
    }
}
