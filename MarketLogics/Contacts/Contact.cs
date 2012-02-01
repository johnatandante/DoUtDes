using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MarketLogics.Contacts
{
    public class Contact 
    {
        public decimal PhoneId;
        public string ContactName;

        public Contact(decimal phoneId, string contactName)
        {
            PhoneId = phoneId;
            ContactName = contactName;

        }

    }
}
