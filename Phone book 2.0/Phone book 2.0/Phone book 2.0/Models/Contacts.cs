using System;

namespace Phone_Book_2._0.Model
{
    public class Contacts
    {
        public Uri picture { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public Contacts(Uri picture, string name, string phone)
        {
            this.picture = picture;
            this.name = name;
            this.phone = phone;
        }
    }
}