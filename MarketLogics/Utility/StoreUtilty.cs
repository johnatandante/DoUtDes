using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Xml.Linq;

namespace MarketLogics.Utility
{
    public enum SettingName {
        Shares,
        Users,
        Activity,
    }

    public class StoreUtilty
    {
        public static string Configuredkey = "Configured_Key";
        public static string Lastaccesskey = "LastAccess_Key";
        public static string Userskey = "Users_Key";
        public static string Shareskey = "Shares_Key";
        public static string Activities = "Activities_Key";

        public static void SetupFirstRun()
        {

            var time = DateTime.UtcNow.ToString("{YYYY-MM-DD hh:mm:ss}");

            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (IsFirstRun())
            {
                Clean(settings);

                settings.Add(Userskey, "Users");
                CreateConfigurationDir(settings[Userskey] as string);
                CreateConfigurationFile("Users", settings[Userskey] as string);

                settings.Add(Shareskey, "Shares");
                CreateConfigurationDir(settings[Shareskey] as string);

                settings.Add(Activities, "Activities");
                CreateConfigurationDir(settings[Activities] as string);
                CreateConfigurationFile("Activities", settings[Activities] as string);

                settings.Add(Lastaccesskey, time);
                // settings.Add(Configuredkey, true);

            } else
            {
                settings[Lastaccesskey] = time;

            }
            
            settings.Save();
        }

        private static void Clean(IsolatedStorageSettings settings)
        {
             settings.Remove(Configuredkey);
             settings.Remove(Lastaccesskey);
             settings.Remove(Userskey);
             settings.Remove(Shareskey);
             settings.Remove(Activities);

        }

        private static void CreateConfigurationFile(string item, string path)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            var fullPath = string.Format("/{0}/{1}.xml", path, item);
            var stream = store.OpenFile(fullPath, FileMode.OpenOrCreate);

            var document = new XDocument();
            document.AddFirst( new XElement(item));    

            var allXml = document.ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(allXml.ToCharArray());

            stream.Write(buffer, 0, buffer.Length);
            stream.Close();

        }

        /// <summary>
        /// Create a root configuration dir
        /// </summary>
        private static void CreateConfigurationDir(string path)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            store.CreateDirectory("/" + path);

        }

        private static bool IsFirstRun()
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            return !settings.Contains(Configuredkey);

        }

        public static bool CheckSetting(SettingName settingName)
        {
            bool ret = true;
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
