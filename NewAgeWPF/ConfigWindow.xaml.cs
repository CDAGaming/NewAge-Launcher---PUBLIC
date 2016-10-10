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
using System.Collections;

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
            Settings.Default.ResolutionTag = false;

            // SoundQuality Load
            SoundQuality_ComboBox.ItemsSource = new List<string> { "Low Quality", "Medium Quality", "High Quality" };
            Resolution_ComboBox.SelectedValue = Settings.Default.SoundQualitySelected;

            // Resolution Load
            Resolution_ComboBox.ItemsSource = new List<string> { "1024x768", "1366x768", "1280x800", "1280x1024", "1920x1080", "1440x900", "1600x900" };
            Resolution_ComboBox.SelectedValue = Settings.Default.ResolutionSelected;
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
            IEnumerable<int> SoundQualityValues = Enumerable.Range(1, 2);
            IEnumerable<int> ResolutionValue1 = Enumerable.Range(320, 1600); //320 - 1920
            IEnumerable<int> ResolutionValue2 = Enumerable.Range(480, 800); //480 - 1280

            //=================SoundOutputQualitySaving========================\\
            
            if (Settings.Default.SoundQualityTag == true)
            {
                foreach (int Value in SoundQualityValues)
                {
                    if (lines_read.Contains("SET Sound_OutputQuality" + " " + '"' + Value + '"'))
                    {
                        lines_read = lines_read.Replace("SET Sound_OutputQuality" + " " + '"' + Value + '"', "SET Sound_OutputQuality" + " " + '"' + Settings.Default.SoundQualityValue + '"');
                        File.WriteAllText(Configexe, lines_read);
                    }
                }
            }

            //================================================================\\

            //==============ResolutionSaving=================\\

            if (Settings.Default.ResolutionTag == true)
            {
                foreach (int Value1 in ResolutionValue1)
                {
                    foreach (int Value2 in ResolutionValue2)
                    {
                        if (lines_read.Contains("SET gxResolution" + " " + '"' + Value1 + "x" + Value2 + '"'))
                        {
                            lines_read = lines_read.Replace("SET gxResolution" + " " + '"' + Value1 + "x" + Value2 + '"', "SET gxResolution" + " " + '"' + Settings.Default.ResolutionValue1 + "x" + Settings.Default.ResolutionValue2 + '"');
                            File.WriteAllText(Configexe, lines_read);
                        }
                    }
                }
            }

            MessageBox.Show("Configuration Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Settings.Default.Save();
            Close();
        }

        private void Resolution_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = Convert.ToString(Resolution_ComboBox.SelectedValue);

            if (selection == "1024x768")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1024";
                Settings.Default.ResolutionValue2 = "768";
                Settings.Default.ResolutionSelected = "1024x768";
                Settings.Default.Save();
            }
            else if (selection == "1366x768")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1366";
                Settings.Default.ResolutionValue2 = "768";
                Settings.Default.ResolutionSelected = "1366x768";
                Settings.Default.Save();
            }
            else if (selection == "1280x800")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1280";
                Settings.Default.ResolutionValue2 = "800";
                Settings.Default.ResolutionSelected = "1280x800";
                Settings.Default.Save();
            }
            else if (selection == "1280x1024")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1280";
                Settings.Default.ResolutionValue2 = "1024";
                Settings.Default.ResolutionSelected = "1280x1024";
                Settings.Default.Save();
            }
            else if (selection == "1920x1080")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1920";
                Settings.Default.ResolutionValue2 = "1080";
                Settings.Default.ResolutionSelected = "1920x1080";
                Settings.Default.Save();
            }
            else if (selection == "1440x900")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1440";
                Settings.Default.ResolutionValue2 = "900";
                Settings.Default.ResolutionSelected = "1440x900";
                Settings.Default.Save();
            }
            else if (selection == "1600x900")
            {
                Settings.Default.ResolutionTag = true;
                Settings.Default.ResolutionValue1 = "1600";
                Settings.Default.ResolutionValue2 = "900";
                Settings.Default.ResolutionSelected = "1600x900";
                Settings.Default.Save();
            }
            Settings.Default.Save();
        }

        private void SoundQuality_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = Convert.ToString(SoundQuality_ComboBox.SelectedValue);

            if (selection == "High Quality")
            {
                Settings.Default.SoundQualityTag = true;
                Settings.Default.SoundQualityValue = "3";
                Settings.Default.SoundQualitySelected = "High Quality";
                Settings.Default.Save();
            }
            else if (selection == "Medium Quality")
            {
                Settings.Default.SoundQualityTag = true;
                Settings.Default.SoundQualityValue = "2";
                Settings.Default.SoundQualitySelected = "Medium Quality";
                Settings.Default.Save();
            }
            else if (selection == "Low Quality")
            {
                Settings.Default.SoundQualityTag = true;
                Settings.Default.SoundQualityValue = "1";
                Settings.Default.SoundQualitySelected = "Low Quality";
                Settings.Default.Save();
            }
        }
    }
}
