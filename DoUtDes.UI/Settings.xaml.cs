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
using DoUtDes.Logics.Phone;
using DoUtDes.Model;

namespace DoUtDes
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {
            var logic = new MainLogic();
            List<AccountInfo> accounts = logic.GetAccounts();
            AccountList.ItemsSource = accounts;

        }

        private void AccountList_Tap(object sender, GestureEventArgs e)
        {
            Status.Current.ItemView = ((ListBox)sender).SelectedItem;
            NavigationService.Navigate(new Uri("/AccountsView/StorageAccountEdit.xaml", UriKind.RelativeOrAbsolute));
            

        }

    }
}