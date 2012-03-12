using System.Collections.Generic;
using System.Windows;
using DoUtDes.Model.Account;
using Microsoft.Phone.Controls;
using DoUtDes.Logics.Phone;

namespace DoUtDes
{
    public partial class PanoramaMarket : PhoneApplicationPage
    {

        protected MainLogic Logic = new MainLogic();

        public PanoramaMarket()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {

        }

    }
}