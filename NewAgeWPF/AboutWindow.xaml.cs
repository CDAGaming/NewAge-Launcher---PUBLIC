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

            //Set Theme based off MainWindow.xaml.cs


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
    }
}
