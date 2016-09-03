using MahApps.Metro.Controls;
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
using NewAgeWPF.Properties;
using System.Diagnostics;
using System.IO;
using MahApps.Metro;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : MetroWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Set Version Label
            VersionID.Content = Settings.Default.CurrentVersion;

            //=======THEME CONFIG (FROM MAINFORM)=======\\

            //Red Theme
            if (Settings.Default.Theme == "Red")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Red"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Green Theme
            if (Settings.Default.Theme == "Green")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Green"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Blue Theme
            if (Settings.Default.Theme == "Blue")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Purple Theme
            if (Settings.Default.Theme == "Purple")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Purple"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Orange Theme
            if (Settings.Default.Theme == "Orange")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Orange"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Lime Theme
            if (Settings.Default.Theme == "Lime")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Lime"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Emerald Theme
            if (Settings.Default.Theme == "Emerald")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Emerald"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Teal Theme
            if (Settings.Default.Theme == "Teal")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Teal"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Cyan Theme
            if (Settings.Default.Theme == "Cyan")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Cyan"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Cobalt Theme
            if (Settings.Default.Theme == "Cobalt")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Cobalt"), ThemeManager.GetAppTheme("BaseLight"));
            }
            //Indigo Theme
            if (Settings.Default.Theme == "Indigo")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Indigo"), ThemeManager.GetAppTheme("BaseLight"));
            }
        }

        private void Licenselbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LICENSE.txt"))
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "LICENSE.txt");
            }
            else
            {
                MessageBox.Show("LICENCE.txt doesn't Exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Changeslbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UpdatesPage UpdatePG = new NewAgeWPF.UpdatesPage();
            UpdatePG.ShowDialog();
        }
    }
}
