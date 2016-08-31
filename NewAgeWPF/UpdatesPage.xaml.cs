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
using System.Reflection;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for UpdatesPage.xaml
    /// </summary>
    public partial class UpdatesPage : MetroWindow
    {
        public UpdatesPage()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.UpdateAvailable == true)
            {
                WelcomeLabel.Content = Settings.Default.UpdateMessage;

                ContinueorRestartButton.IsEnabled = true;
                ContinueorRestartButton.Opacity = 1.0;
                ContinueorRestartButton.Content = "Update";
                ContinueorRestartButton.Click += new RoutedEventHandler(ContinueorRestartButton_Click1);

                Postpone_Button.IsEnabled = true;
                Postpone_Button.Opacity = 1.0;
                Postpone_Button.Content = "Postpone";
                Postpone_Button.Click += new RoutedEventHandler(Postpone_Button_Click);
            }
            else if (Settings.Default.UpdateAvailable == false)
            {
                WelcomeLabel.Content = "Welcome - No Update Available" + "(" + Settings.Default.CurrentVersion + ")";

                ContinueorRestartButton.IsEnabled = true;
                ContinueorRestartButton.Opacity = 1.0;
                ContinueorRestartButton.Content = "Continue";
                ContinueorRestartButton.Click += new RoutedEventHandler(ContinueorRestartButton_Click2);

                Postpone_Button.IsEnabled = false;
                Postpone_Button.Opacity = 0.0;
                Postpone_Button.Content = "";
            }
            Changes_HTML.Navigate(new Uri("http://www.wownewage.com/Launcher_Changes.html"));
        }

        private void ContinueorRestartButton_Click2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Postpone_Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.UpdatePostPoned = true;
            Settings.Default.Save();

            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();

        }

        private void ContinueorRestartButton_Click1(object sender, RoutedEventArgs e)
        {
            Settings.Default.UpdateAccepted = true;
            Settings.Default.Save();

            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
