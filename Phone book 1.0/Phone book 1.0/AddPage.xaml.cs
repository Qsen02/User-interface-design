using Phone_book_1._0;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Phone_Book_1._0
{
    public sealed partial class AddPage : Page
    {
        public AddPage()
        {
            this.InitializeComponent();
        }

        private void AddContactHandler(object sender, RoutedEventArgs args)
        {
            var picture = new Uri(boxPicture.Text);
            var contact = new Contacts(picture, boxName.Text, boxPhone.Text);
            this.Frame.Navigate(typeof(MainPage), contact);
        }
    }
}