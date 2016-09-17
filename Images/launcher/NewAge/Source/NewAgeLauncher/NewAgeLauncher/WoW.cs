using Microsoft.Win32;
using NewAgeLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAgeLauncher
{
    class WoW
    {
        public static string Directory
        {

            get
            {

                if (!string.IsNullOrEmpty(Settings.Default.WowLocation))
                    return Settings.Default.WowLocation;

                RegistryKey wow = Registry.LocalMachine;

                if (Environment.Is64BitOperatingSystem)
                {
                    wow = wow.OpenSubKey(@"SOFTWARE\Wow6432Node\Blizzard Entertainment\World of Warcraft");
                }
                else
                {
                    wow = wow.OpenSubKey(@"SOFTWARE\Blizzard Entertainment\World of Warcraft");
                }

                if (wow == null)
                    return null;

                return (string)wow.GetValue("InstallPath");

            }

        }

        public static string ExecutableLocation
        {

            get
            {

                if (!string.IsNullOrEmpty(Directory))
                    return Path.Combine(Directory, "Wow.exe");

                return null;

            }

        }

        public static string RealmListLocation
        {
            get
            {

                if (string.IsNullOrEmpty(Directory))
                    return null;

                return Path.Combine(Directory, @"Data\enUS\realmlist.wtf");

            }
        }

        public static string DataDirectory
        {

            get
            {

                if (string.IsNullOrEmpty(Directory))
                    return null;

                return Path.Combine(Directory, "data");

            }

        }
    }
}
