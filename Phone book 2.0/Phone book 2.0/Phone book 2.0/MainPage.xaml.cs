using Phone_Book_2._0;
using Phone_Book_2._0.Model;
using System;
using Xamarin.Forms;

namespace Phone_book_2._0
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Contacts contact=null)
        {
            InitializeComponent();
            this.phoneContacts.ItemsSource = ViewModel.contacts;
            if (contact is Contacts) {
                ViewModel.contacts.Add(contact);            
            }
        }
        private void AddPageHandler(object sender, EventArgs args) {
            Navigation.PushModalAsync(new AddPage());
        } 
    }
}
