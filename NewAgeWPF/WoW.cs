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

                return null;
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

        public static string ConfigLocation
        {
            get
            {
                if (File.Exists(Path.Combine(Directory, @"WTF\Config.wtf")))
                {
                    return Path.Combine(Directory, @"WTF\Config.wtf");
                }

                else
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
                //ENUS Realmlist Config
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
                //DEDE Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\deDE\realmlist.wtf")))
                {
                    string pathDE = (Path.Combine(Directory, @"Data\deDE\realmlist.wtf"));
                    FileAttributes attributesDE = File.GetAttributes(pathDE);

                    // If File is Set to Read-Only, Do This:
                    if ((attributesDE & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        attributesDE = RemoveAttribute_DEDE(attributesDE, FileAttributes.ReadOnly);
                        File.SetAttributes(pathDE, attributesDE);
                    }
                    return Path.Combine(Directory, @"Data\deDE\realmlist.wtf");

                }
                //ESES Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\esES\realmlist.wtf")))
                {
                    string pathES = (Path.Combine(Directory, @"Data\esES\realmlist.wtf"));
                    FileAttributes attributesES = File.GetAttributes(pathES);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\esES\realmlist.wtf");
                }
                //esMX Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\esMX\realmlist.wtf")))
                {
                    string pathMX = (Path.Combine(Directory, @"Data\esMX\realmlist.wtf"));
                    FileAttributes attributesMX = File.GetAttributes(pathMX);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\esMX\realmlist.wtf");
                }
                //frFR Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\frFR\realmlist.wtf")))
                {
                    string pathFR = (Path.Combine(Directory, @"Data\frFR\realmlist.wtf"));
                    FileAttributes attributesFR = File.GetAttributes(pathFR);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\frFR\realmlist.wtf");
                }
                //koKR Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\koKR\realmlist.wtf")))
                {
                    string pathKR = (Path.Combine(Directory, @"Data\koKR\realmlist.wtf"));
                    FileAttributes attributesKR = File.GetAttributes(pathKR);

                    // If File is set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\koKR\realmlist.wtf");
                }
                //ptBR Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\ptBR\realmlist.wtf")))
                {
                    string pathBR = (Path.Combine(Directory, @"Data\ptBR\realmlist.wtf"));
                    FileAttributes attributesBR = File.GetAttributes(pathBR);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\ptBR\realmlist.wtf");
                }
                //ruRU Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\ruRU\realmlist.wtf")))
                {
                    string pathRU = (Path.Combine(Directory, @"Data\ruRU\realmlist.wtf"));
                    FileAttributes attributesRU = File.GetAttributes(pathRU);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\ruRU\realmlist.wtf");
                }
                //zhCN Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\zhCN\realmlist.wtf")))
                {
                    string pathCN = (Path.Combine(Directory, @"Data\zhCN\realmlist.wtf"));
                    FileAttributes attributesCN = File.GetAttributes(pathCN);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\zhCN\realmlist.wtf");
                }
                //zhTW Realmlist Config
                else if (File.Exists(Path.Combine(Directory, @"Data\zhTW\realmlist.wtf")))
                {
                    string pathTW = (Path.Combine(Directory, @"Data\zhTW\realmlist.wtf"));
                    FileAttributes attributesTW = File.GetAttributes(pathTW);

                    // If File is Set to Read-Only, Do This:
                    return Path.Combine(Directory, @"Data\zhTW\realmlist.wtf");
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

        public static FileAttributes RemoveAttribute_DEDE(FileAttributes attributesDE, FileAttributes Remove_DEDE)
        {
            return attributesDE & ~Remove_DEDE;
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
