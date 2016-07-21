/* 
    NewAge Launcher
    Copyright (C) 2016 Jestus

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NewAgeLauncher.Properties;
using Microsoft.Win32;

namespace NewAgeLauncher
{
    public class WoW
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
                    return Path.Combine(Directory, "wow_mod.exe");

                return null;

            }

        }

        public static string RealmListLocation
        {
            get
            {

                if (File.Exists(Path.Combine(Directory, @"Data\enGB\realmlist.wtf")))
                    return Path.Combine(Directory, @"Data\enGB\realmlist.wtf");
                else if (File.Exists(Path.Combine(Directory, @"Data\enUS\realmlist.wtf")))
                    return Path.Combine(Directory, @"Data\enUS\realmlist.wtf");
                else
                    return null;

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
