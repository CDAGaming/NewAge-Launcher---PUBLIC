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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Runtime.InteropServices;
using System.Drawing;
using NewAgeWPF.Properties;
using System.Diagnostics;
using MahApps.Metro;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SaveButton.Cursor = Cursors.Hand;
        }

        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            SaveButton.Cursor = Cursors.Arrow;
        }

        private void CancelButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CancelButton.Cursor = Cursors.Hand;
        }

        private void CancelButton_MouseLeave(object sender, MouseEventArgs e)
        {
            CancelButton.Cursor = Cursors.Arrow;
        }

        private void SaveButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Wow Location
            Settings.Default.WoWLocation = WoWLocationBox.Text;

            //Transparency Checkbox
            if (TransparencyCheckBox.IsChecked == true)
            {
                Settings.Default.TransparencyToggle = true;
            }
            if (TransparencyCheckBox.IsChecked == false)
            {
                Settings.Default.TransparencyToggle = false;
            }

            //Updates Checkbox
            if (Updates_Checkbox.IsChecked == true)
            {
                Settings.Default.CheckforUpdateTag = true;
            }
            if (Updates_Checkbox.IsChecked == false)
            {
                Settings.Default.CheckforUpdateTag = false;
            }

            //Clear Cache Checkbox
            if (ClearCache_Checkbox.IsChecked == true)
            {
                Settings.Default.WoWCacheToggle = true;
            }
            if (ClearCache_Checkbox.IsChecked == false)
            {
                Settings.Default.WoWCacheToggle = false;
            }

            //Language Change Checkbox
            if (LanguageChange_CheckBox.IsChecked == true)
            {
                Settings.Default.LanguageChangeTag = true;
            }
            if (LanguageChange_CheckBox.IsChecked == false)
            {
                Settings.Default.LanguageChangeTag = false;
            }

            Settings.Default.Save();
            Close();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //=======THEME CONFIG (FROM MAINFORM)=======\\

            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Settings.Default.Theme), ThemeManager.GetAppTheme(Settings.Default.Scheme));

            //===========================================\\

            if (Settings.Default.CheckforUpdateTag == true)
            {
                Updates_Checkbox.IsChecked = true;
            }

            if (Settings.Default.LanguageChangeTag == false)
            {
                LanguageChange_CheckBox.IsChecked = false;
            }
            
            WoWLocationBox.Text = Settings.Default.WoWLocation;
            TransparencyCheckBox.IsChecked = Settings.Default.TransparencyToggle;
            ClearCache_Checkbox.IsChecked = Settings.Default.WoWCacheToggle;
            LanguageChange_CheckBox.IsChecked = Settings.Default.LanguageChangeTag;
            Updates_Checkbox.IsChecked = Settings.Default.CheckforUpdateTag;
        }

        private void BrowseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            BrowseButton.Cursor = Cursors.Hand;
        }

        private void BrowseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            BrowseButton.Cursor = Cursors.Arrow;
        }

        private void BrowseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    WoWLocationBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void CancelButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
