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
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using NewAgeWPF.Properties;

namespace NewAgeWPF
{
    public class WoW
    {
        public static string Directory
        {
            get
            {
                if (!string.IsNullOrEmpty(Settings.Default.WoWLocation))
                    return Settings.Default.WoWLocation;

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
                //ENGB Realmlist Config
                if (File.Exists(Path.Combine(Directory, @"Data\enGB\realmlist.wtf")))
                {
                    string pathGB = (Path.Combine(Directory, @"Data\enGB\realmlist.wtf"));
                    FileAttributes attributesGB = File.GetAttributes(pathGB);

                    // If File is Set as Read-Only, Do this:

                    if ((attributesGB & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        attributesGB = RemoveAttribute_ENGB(attributesGB, FileAttributes.ReadOnly);
                        File.SetAttributes(pathGB, attributesGB);
                    }

                    return Path.Combine(Directory, @"Data\enGB\realmlist.wtf");
                }

                else if (File.Exists(Path.Combine(Directory, @"Data\enUS\realmlist.wtf")))
                {
                    string pathUS = (Path.Combine(Directory, @"Data\enUS\realmlist.wtf"));
                    FileAttributes attributesUS = File.GetAttributes(pathUS);

                    // If File is Set to Read-Only, Do This:
                    if ((attributesUS & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        attributesUS = RemoveAttribute_ENUS(attributesUS, FileAttributes.ReadOnly);
                        File.SetAttributes(pathUS, attributesUS);
                    }

                    return Path.Combine(Directory, @"Data\enUS\realmlist.wtf");
                }

                else
                    return null;

            }
        }

        public static FileAttributes RemoveAttribute_ENGB(FileAttributes attributesGB, FileAttributes Remove_ENGB)
        {
            return attributesGB & ~Remove_ENGB;
        }

        public static FileAttributes RemoveAttribute_ENUS(FileAttributes attributesUS, FileAttributes Remove_ENUS)
        {
            return attributesUS & ~Remove_ENUS;
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
