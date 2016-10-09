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
using MahApps.Metro;
using MahApps.Metro.Controls;
using NewAgeWPF.Properties;
using System.Diagnostics;
using System.IO;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : MetroWindow
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //=======THEME CONFIG (FROM MAINFORM)=======\\

            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Settings.Default.Theme), ThemeManager.GetAppTheme(Settings.Default.Scheme));

            //===========================================\\

            //Clear Values for ReEntry
            Settings.Default.SoundQualityTag = false;

            // SoundQuality Load
            SoundQuality_ScrollBar.Value = Settings.Default.SoundQualityValue;
            
        }

        private void SaveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SaveButton.Cursor = Cursors.Hand;
        }

        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            SaveButton.Cursor = Cursors.Arrow;
        }

        private void SaveButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Config.wtf File Config + Value Configurations
            string Configexe = WoW.ConfigLocation;
            string lines_read = File.ReadAllText(Configexe);

            //=================SoundOutputQuality Saving=======================\\
            if (lines_read.Contains("SET Sound_OutputQuality" + " " + '"' + "1" + '"') && Settings.Default.SoundQualityTag == true)
            {
                lines_read = lines_read.Replace("SET Sound_OutputQuality" + " " + '"' + "1" + '"', "SET Sound_OutputQuality" + " " + '"' + Settings.Default.SoundQualityValue + '"');
                File.WriteAllText(Configexe, lines_read);
            }
            else if (lines_read.Contains("SET Sound_OutputQuality" + " " + '"' + "2" + '"') && Settings.Default.SoundQualityTag == true)
            {
                lines_read = lines_read.Replace("SET Sound_OutputQuality" + " " + '"' + "2" + '"', "SET Sound_OutputQuality" + " " + '"' + Settings.Default.SoundQualityValue + '"');
                File.WriteAllText(Configexe, lines_read);
            }
            else if (lines_read.Contains("SET Sound_OutputQuality" + " " + '"' + "3" + '"') && Settings.Default.SoundQualityTag == true)
            {
                lines_read = lines_read.Replace("SET Sound_OutputQuality" + " " + '"' + "3" + '"', "SET Sound_OutputQuality" + " " + '"' + Settings.Default.SoundQualityValue + '"');
                File.WriteAllText(Configexe, lines_read);
            }
            Settings.Default.Save();
            Close();
        }

        private void SoundQuality_ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SoundQuality_ScrollBar.Value == 1)
            {
                SoundQuality.Content = "Low Quality";

                Settings.Default.SoundQualityTag = true;
                Settings.Default.SoundQualityValue = 1;
            }
            else if (SoundQuality_ScrollBar.Value == 2)
            {
                SoundQuality.Content = "Medium Quality";

                Settings.Default.SoundQualityTag = true;
                Settings.Default.SoundQualityValue = 2;
            }
            else if (SoundQuality_ScrollBar.Value == 3)
            {
                SoundQuality.Content = "High Quality";

                Settings.Default.SoundQualityTag = true;
                Settings.Default.SoundQualityValue = 3;
            }
            Settings.Default.Save();
        }
    }
}
