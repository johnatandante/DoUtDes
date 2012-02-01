using System;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Collections.Generic;
using System.Windows.Input;

namespace DoUtDes
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static string PanoramaMarketItem = "PanoramaMarket";
        public static string AboutItem = "About";


        public List<MenuItem> MenuItems = new List<MenuItem>() { 
                                            new MenuItem() { Titolo = "Market", TargetUri = new Uri(string.Format("/{0}.xaml", PanoramaMarketItem), UriKind.RelativeOrAbsolute) }, 
                                             new MenuItem() { Titolo = "About", TargetUri = new Uri(string.Format("/{0}.xaml", PanoramaMarketItem), UriKind.RelativeOrAbsolute) }, 
                                        };

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }


        private void MenuAppTap(object sender, GestureEventArgs e)
        {
            if(sender is MenuItem)
                NavigationService.Navigate(((MenuItem)sender).TargetUri);


        }
    }
}