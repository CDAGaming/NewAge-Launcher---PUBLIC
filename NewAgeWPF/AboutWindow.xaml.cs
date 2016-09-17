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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Drawing;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : MetroWindow
    {

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        System.Drawing.FontFamily ff;
        Font font;

        public AboutWindow()
        {
            InitializeComponent();
        }

        private void loadFont()
        {
            byte[] fontArray = Properties.Resources.Montserrat_Regular;
            int dataLength = Properties.Resources.Montserrat_Regular.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, System.Drawing.FontStyle.Regular);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loadFont();
            //Set Version Label
            Version CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            VersionID.Content = CurrentVersion;

            //=======THEME CONFIG (FROM MAINFORM)=======\\

            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Settings.Default.Theme), ThemeManager.GetAppTheme(Settings.Default.Scheme));

            //===========================================\\
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
            UpdatesPage UpdatePG = new UpdatesPage();
            UpdatePG.ShowDialog();
        }

        private void FacebookIMG_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/fb_hover.png");
            var bitmap = new BitmapImage(uri);
            FacebookIMG.Source = bitmap;
            FacebookIMG.Cursor = Cursors.Hand;
        }

        private void FacebookIMG_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/fb.png");
            var bitmap = new BitmapImage(uri);
            FacebookIMG.Source = bitmap;
            FacebookIMG.Cursor = Cursors.Arrow;
        }

        private void FacebookIMG_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.facebook.com/wownewage/?ref=ts&fref=ts");
            WindowState = WindowState.Minimized;
        }

        private void YoutubeIMG_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/yt_hover.png");
            var bitmap = new BitmapImage(uri);
            YoutubeIMG.Source = bitmap;
            YoutubeIMG.Cursor = Cursors.Hand;
        }

        private void YoutubeIMG_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/yt.png");
            var bitmap = new BitmapImage(uri);
            YoutubeIMG.Source = bitmap;
            YoutubeIMG.Cursor = Cursors.Arrow;
        }

        private void YoutubeIMG_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCB8QTlT6sMMLXrox5Q_rGEg");
            WindowState = WindowState.Minimized;
        }
    }
}
