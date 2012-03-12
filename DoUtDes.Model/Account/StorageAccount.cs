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
using System.Collections.Generic;
using DoUtDes.Model.Enums;

namespace DoUtDes.Model.Account
{
    public class StorageAccount
    {

        private static Dictionary<AccountType, Uri> AccountIcon = new Dictionary<AccountType, Uri>()  {
                { AccountType.Facebook , new Uri("http://s-static.ak.facebook.com/rsrc.php/yi/r/q9U99v3_saj.ico") },
                { AccountType.Dropbox , new Uri("http://www.dropbox.com/static/22169/images/favicon.ico") },
        };

        public static Uri GetIconUri(AccountType account)
        {
            Uri uri = null;
            if (AccountIcon.TryGetValue(account, out uri))
                return uri;

            return new Uri("http://www.smartcontrol.biz/immagini/social.png");

        }


    }
}
