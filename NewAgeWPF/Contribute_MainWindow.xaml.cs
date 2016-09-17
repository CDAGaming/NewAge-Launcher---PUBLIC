using MahApps.Metro.Controls;
using NewAgeWPF.Properties;
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
using System.Diagnostics;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for Contribute_MainWindow.xaml
    /// </summary>
    public partial class Contribute_MainWindow : MetroWindow
    {
        public Contribute_MainWindow()
        {
            InitializeComponent();
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Settings.Default.DonateURL);
        }

        private void VoteButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Settings.Default.VoteURL);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //=======THEME CONFIG (FROM MAINFORM)=======\\

            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Settings.Default.Theme), ThemeManager.GetAppTheme(Settings.Default.Scheme));

            //===========================================\\
        }
    }
}
