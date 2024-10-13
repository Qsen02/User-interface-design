using Xamarin.Forms;
using Xamarin.Essentials;

namespace RSS_reader_2._0
{
    public class HyperlinkButton:TextCell
    {
        public static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkButton), null);

        public string Url {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
        public HyperlinkButton() {
            Tapped += HyperlinkButton_Tapped;
        }
        private void HyperlinkButton_Tapped(object sender, System.EventArgs args) {
            Command = new Command(async () => await Launcher.OpenAsync(Url));
        }
    }
}
