using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DoUtDes.Model.Enums;

namespace DoUtDes.Model.Account {
	public class AccountInfo : IAccount {

	    public string UniqueId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public AccountType Account { get; set; }
        public Uri AvatarIconUri { get; set; } 

        public string GetPassword(string hash, string publicKey)
        {
            throw new NotImplementedException();
        }

        protected void GetIconInfo()
        {
            //var filename = string.Empty;
            //Uri uri = new Uri("isostore:/" + filename);

            //// ShellTile
            //BitmapSource image = null;
            //using (Stream imageStream = new  MemoryStream())
            //{
            //    WriteableBitmap bitmap = new WriteableBitmap(image);
            //    //bitmap.SaveJpeg(..)
            //}

            ////using(MediaLibrary lib = new MediaLibrary())

        }


    }
}
