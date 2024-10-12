using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Clicker_Mania_2._0
{
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer=new DispatcherTimer();
        public MainPage()
        {
            this.InitializeComponent();
            timer.Interval=new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e) {
            int time = int.Parse(Timer.Text);
            Timer.Text = (++time).ToString();
            CPM.Text = (float.Parse(Clicks.Text) / float.Parse(Timer.Text) * 60).ToString("N2");
        }

        private void ClickHandler(object sender, RoutedEventArgs args)
        {
            int clicks=int.Parse(Clicks.Text);
            Clicks.Text=(++clicks).ToString();
        }
    }
}
