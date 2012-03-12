using System;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text;
using DoUtDes.Model.Enums;
using Microsoft.Phone.Info;
using System.Xml.Linq;
using DoUtDes.Model.Account;
using System.Collections.Generic;

namespace DoUtDes.Model.Settings {

    public class Settings
    {

		public static string HashKey = "h725";	// please encrypt with phone unique id

		//public const string SettingsFile = "Settings.xml";

		public static string Configuredkey = "Configured_Key";
		public static string Lastaccesskey = "LastAccess_Key";
		//public static string Userskey = "Users_Key";
		//public static string Shareskey = "Shares_Key";
		//public static string Activities = "Activities_Key";
        //public static string Activities = "Accounts_Key";

		public static Settings Instance = new Settings();

		public Settings() {

			if (IsFirstRun()) {
				SetupFirstRun();

			} else {
				Load();

			}

		}

        private void Load()
        {

        }

        private static bool IsFirstRun()
        {
            return !Contains(Configuredkey);
        }

		protected void SetupFirstRun()
        {
            var time = DateTime.UtcNow.ToString("{YYYY-MM-DD hh:mm:ss}");

            Clean();

            AddSection(Configuredkey, GetUniquePhoneId());

            AddSection(SettingName.Accounts);
			AddSection(SettingName.Shares);

			// AddSection(SettingName.Users);
			// AddSection(SettingName.Activity);

			AddSection(Lastaccesskey, time);

			Save();
        }

        public static string GetUniquePhoneId()
        {
            object deviceUniqueId;
            return DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out deviceUniqueId) ? 
                Convert.ToBase64String((byte[])deviceUniqueId) : string.Empty;
        }

        public static void Save()
        {
             IsolatedStorageSettings.ApplicationSettings.Save();
        }

		protected void AddSection(string key, string value) {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings[key] = value;
            
		}

		protected void AddSection(SettingName settingName)
		{
            CreateConfigurationDir(settingName.ToString() as string);
            CreateConfigurationFile(settingName.ToString(), settingName.ToString());
		}

        private void CreateConfigurationDir(string path)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            if(!store.DirectoryExists(path))
            {
                store.CreateDirectory(path);
            }

        }

		protected void RemoveSection(string settingName)
		{
            IsolatedStorageSettings.ApplicationSettings.Remove(settingName);
		}

        // private static void Clean(IsolatedStorageSettings settings)
		protected void Clean()
        {
			RemoveAll();
			Save();

        }

        private void RemoveAll()
        {
            Remove(Configuredkey);
            Remove(SettingName.Activity);
            Remove(SettingName.Shares);
            Remove(SettingName.Users);
            Remove(SettingName.Accounts);
        }

        private void Remove(SettingName section)
        {
            Remove(section.ToString());
        }

        private void Remove(string sectionName)
        {
            try
            {
                var store = IsolatedStorageFile.GetUserStoreForApplication();
                if (store.DirectoryExists(sectionName))
                    store.DeleteDirectory(sectionName);
            } catch(Exception)
            {
                Console.WriteLine("Non riesco a eliminare la dir ", sectionName);
            }

            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(sectionName))
                settings.Remove(sectionName);
        }

        private void CreateConfigurationFile(string item, string path = "")
        {
            if (path == string.Empty)
                path = item;

            var store = IsolatedStorageFile.GetUserStoreForApplication();
            var fullPath = string.Format("/{0}/{1}.xml", path, item);
            var stream = store.OpenFile(fullPath, FileMode.OpenOrCreate);

            var document = new XDocument();
            document.AddFirst(new XElement(item));

            var allXml = document.ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(allXml.ToCharArray());

            stream.Write(buffer, 0, buffer.Length);
            stream.Close();			

            //if (!File.Exists(SettingsFile)) {				
            //    File.Create(SettingsFile);
            //}

        }

		protected static bool Contains(string key) {
            return IsolatedStorageSettings.ApplicationSettings.Contains(key);
		}

        public bool CheckSetting(SettingName settingName)
        {
            var ret = true;
            try
            {
                var settings = IsolatedStorageSettings.ApplicationSettings;
                // txtInput is a TextBox defined in XAML.
                if (settings.Contains(settingName.ToString()))
                {

                    var store = IsolatedStorageFile.GetUserStoreForApplication();
                    switch (settingName)
                    {
                        case SettingName.Shares:
                            ret =  store.DirectoryExists("/Shares");
                            break;
                        case SettingName.Users:
                            ret = store.FileExists("/Users/Users.xml");
                            break;
                        case SettingName.Activity:
                            ret = store.FileExists("/Activity/Activity.xml");
                            break;
                        default:
                            throw new Exception("Setting not implemented " + settingName.ToString() + "!!!");
                    }

                }
                else
                {
                    ret = false;
                }

            } catch(Exception)
            {
                // insabbiamento
                ret = false;
            }

            return ret;
        }


    }

}
