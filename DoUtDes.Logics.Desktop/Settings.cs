using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using DoUtDes.Logics.Enums;

namespace DoUtDes.Logics.Phone {

	public class Settings : XmlDocument {

		public static string HashKey = "";	// please encrypt with phone unique id

		public const string SettingsFile = "Settings.xml";

		public static string Configuredkey = "Configured_Key";
		public static string Lastaccesskey = "LastAccess_Key";
		public static string Userskey = "Users_Key";
		public static string Shareskey = "Shares_Key";
		public static string Activities = "Activities_Key";

		public static Settings Instance = new Settings();

		public Settings() {

			if (IsFirstRun()) {
				SetupFirstRun();

			} else {
				Load(SettingsFile);

			}

		}

		protected void SetupFirstRun()
        {
            var time = DateTime.UtcNow.ToString("{YYYY-MM-DD hh:mm:ss}");

            // var settings = IsolatedStorageSettings.ApplicationSettings;
            Clean();
            
			AddSection(SettingName.Users);
            // CreateConfigurationDir(settings[Userskey] as string);
            // CreateConfigurationFile("Users", settings[Userskey] as string);

			AddSection(SettingName.Shares);
            // CreateConfigurationDir(settings[Shareskey] as string);

			AddSection(SettingName.Activity);
            // CreateConfigurationDir(settings[Activities] as string);
            // CreateConfigurationFile("Activities", settings[Activities] as string);

			AddSection(Lastaccesskey, time);
            // settings.Add(Configuredkey, true);

			// settings[Lastaccesskey] = time;

			Save(SettingsFile);
        }

		protected void AddSection(string key, string value) {
			throw new NotImplementedException();
		}

		protected void AddSection(SettingName settingName)
		{
		    var node = CreateElement(settingName.ToString());
			FirstChild.AppendChild(node);

		}

		protected void RemoveSection(string settingName) {
			throw new NotImplementedException();
		}

        // private static void Clean(IsolatedStorageSettings settings)
		protected void Clean()
        {
			//Remove(Configuredkey);
			//Remove(Lastaccesskey);
			//Remove(Userskey);
			//Remove(Shareskey);
			//Remove(Activities);

			RemoveAll();
			Save(SettingsFile);

        }

        private void CreateConfigurationFile(string item, string path)
        {
			//var store = IsolatedStorageFile.GetUserStoreForApplication();		
			//var fullPath = string.Format("/{0}/{1}.xml", path, item);
			//var stream = store.OpenFile(fullPath, FileMode.OpenOrCreate);

			//var document = new XDocument();
			//document.AddFirst( new XElement(item));    

			//var allXml = document.ToString();
			//byte[] buffer = Encoding.UTF8.GetBytes(allXml.ToCharArray());

			//stream.Write(buffer, 0, buffer.Length);
			//stream.Close();			

			if (!File.Exists(SettingsFile)) {				
				File.Create(SettingsFile);
			}

        }

        private static bool IsFirstRun()
        {
            return !Settings.Instance.Contains(Configuredkey);

        }

		private bool Contains(string key) {
			throw new NotImplementedException();
		}

        public bool CheckSetting(SettingName settingName)
        {
            bool ret = true;
            try
            {
                // var settings = IsolatedStorageSettings.ApplicationSettings;
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
