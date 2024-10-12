using System;

namespace Phone_book_1._0
{
    public class Contacts
    {
        public Uri picture { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public Contacts(Uri _picture,string _name,string _phone) { 
            this.picture= _picture;
            this.name= _name;
            this.phone= _phone;
        }
    }
}
