using System;
using System.Collections;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Phone_Book_2._0.Model
{
    public static class ViewModel
    {
        public static ObservableCollection<Contacts> contacts = new ObservableCollection<Contacts>();

        static ViewModel()
        {
            BindingBase.EnableCollectionSynchronization(contacts, null, Callback);
        }

        private static void Callback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            lock (collection)
            {
                accessMethod?.Invoke();
            }
        }
    }
}