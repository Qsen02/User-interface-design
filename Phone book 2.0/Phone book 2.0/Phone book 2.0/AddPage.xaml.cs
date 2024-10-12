using System;
using Xamarin.Forms;
using Phone_book_2._0;
using Phone_Book_2._0.Model;

namespace Phone_Book_2._0
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void AddContactHandler(object sender, System.EventArgs args)
        {
            var contact = new Contacts
            (
                picture: new Uri(this.Picture.Text),
                name: this.Name.Text,
                phone: this.Phone.Text
            );

            Navigation.PushModalAsync(new MainPage(contact));
        }
    }
}