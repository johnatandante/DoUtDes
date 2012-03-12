using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using DoUtDes.Model.Account;
using DoUtDes.Model;

namespace DoUtDes.AccountsView
{
    public partial class EditStorageAccount : PhoneApplicationPage
    {
        public EditStorageAccount()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ItemsToEdit.ItemsSource = new List<Object>() { Status.Current.ItemView };
        }
    }
}