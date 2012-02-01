using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using DoUtDes.UiElements;
using Microsoft.Phone.Controls;
using MarketLogics.Contacts;
using System.IO.IsolatedStorage;
using MarketLogics.Shares;
using MarketLogics.Resources;
using MarketLogics.Utility;
using System.Xml.Linq;
using System.Text;

namespace DoUtDes
{
    public partial class PanoramaMarket : PhoneApplicationPage
    {

        protected List<Contact> Contacts;
        protected List<ActivityShare> ActivityShares;
        protected List<Resource> ResourceList;
        protected IsolatedStorageFile Store;
        protected IsolatedStorageSettings Settings;

        public PanoramaMarket()
        {
            InitializeComponent();
            Store = IsolatedStorageFile.GetUserStoreForApplication();
            Settings = IsolatedStorageSettings.ApplicationSettings;
        }

        private void ReadShares()
        {
            ResourceList = new List<Resource>();
            try
            {
                var sp = ResourcesGrid.Children[0] as ListBox;

                var resources = Store.GetFileNames(string.Format("/{0}/*", Settings[StoreUtilty.Shareskey] as string));
                foreach (var resource in resources)
                {
                    var lastTimeAccess = Store.GetLastWriteTime(resource);
                    ResourceList.Add(new Resource() { DateCreation = lastTimeAccess, FilePath = resource });
                    var uiTb = new FileInfoItem {Title = resource, FileSize = "0M"};

                    
                    sp.Items.Add(uiTb);
                }

                var uiTb1 = new FileInfoItem {Title = "dummy resource", FileSize = "1M"};
                sp.Items.Insert(0, uiTb1);
                
            }
            catch (Exception)
            {
                // Insabbiamo
            }
        }

        private void ReadUsers()
        {
            Contacts = new List<Contact> { new Contact(1M, "Telefono di prova"), new Contact(2102873M, "telefono di Mac") };

            try
            {
                var sp = ContactsGrid.Children[0] as ListBox;

                var contactFileStream = Store.OpenFile(string.Format("/{0}/*", Settings[StoreUtilty.Configuredkey] as string), FileMode.Open);

                var elements = XElement.Load(contactFileStream);

                //foreach (var celement in elements)
                //{

                //    var ui = new UserInfoControl() { ContactName = string.Format("{0} {1}", celement("FirstName") as string, celement("LastName") as string) };


                //    var lastTimeAccess = Store.GetLastWriteTime(resource);
                //    ResourceList.Add(new Resource() { DateCreation = lastTimeAccess, FilePath = resource });
                //    var uiTb = new FileInfoItem { Title = resource, FileSize = "0M" };


                //    sp.Items.Add(uiTb);
                //}

                var uiTb1 = new FileInfoItem { Title = "dummy resource", FileSize = "1M" };
                sp.Items.Insert(0, uiTb1);

            }
            catch (Exception)
            {
                // Insabbiamo
            }


        }

        private void ReadResources()
        {
            try
            {
                var resources = System.IO.Directory.GetFiles("/Resources");
            } catch(Exception)
            {
                // Insabbiamo
            }
        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {
            ReadResources();
            ReadUsers();
            ReadShares();
        }

    }
}