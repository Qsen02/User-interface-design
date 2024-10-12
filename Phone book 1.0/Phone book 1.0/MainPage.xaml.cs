using Phone_Book_1._0;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Phone_book_1._0
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.boxContacts.ItemsSource = App.contact;
        }
        private void AddPageHandler(object sender, RoutedEventArgs args) {
            this.Frame.Navigate(typeof(AddPage));
        }
        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            if (args.Parameter is Contacts)
            {
                App.contact.Add(args.Parameter as Contacts);
            }
        }
    }
}
