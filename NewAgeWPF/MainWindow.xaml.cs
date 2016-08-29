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
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewAgeWPF.Properties;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Collections.ObjectModel;
using MahApps.Metro;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;
using System.Drawing.Text;
using System.Security.Cryptography;
using Squirrel;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        /* INCOMPATIBLE CODE --- SEEK ALTERNATIVE
        System.Windows.Media.FontFamily ff;
        Font font;
        */

        Stopwatch sw = new Stopwatch();
        WebClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        /*
        private void loadFont()
        {
            byte[] fontArray = Properties.Resources.DroidSans;
            int dataLength = Properties.Resources.DroidSans.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, System.Drawing.FontStyle.Bold);
        }

        private void AllocFont(Font f, Control c, float size, Boolean bold)
        {
            if (bold)
            {
                System.Windows.FontStyle fontStyle = FontStyle;
                Application.Current.MainWindow.FontFamily = ff;
                Application.Current.MainWindow.FontSize = size;
                Application.Current.MainWindow.FontStyle = fontStyle;
            }
            else
            {
                System.Drawing.FontStyle fontstyle = new System.Drawing.FontStyle.Bold;

            }
        }
        */

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void PlayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Play_Hovor.png");
            var bitmap = new BitmapImage(uri);
            PlayButton.Source = bitmap;
            PlayButton.Cursor = Cursors.Hand;

        }

        private void PlayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Play_NoHovor.png");
            var bitmap = new BitmapImage(uri);
            PlayButton.Source = bitmap;
            PlayButton.Cursor = Cursors.Arrow;
        }

        private void SettingsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Settings_Hovor.png");
            var bitmap = new BitmapImage(uri);
            SettingsButton.Source = bitmap;
            SettingsButton.Cursor = Cursors.Hand;
        }

        private void SettingsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Settings_NoHovor.png");
            var bitmap = new BitmapImage(uri);
            SettingsButton.Source = bitmap;
            SettingsButton.Cursor = Cursors.Arrow;
        }

        private void DonateButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Donate_Hovor.png");
            var bitmap = new BitmapImage(uri);
            DonateButton.Source = bitmap;
            DonateButton.Cursor = Cursors.Hand;
        }

        private void DonateButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Donate_NoHovor.png");
            var bitmap = new BitmapImage(uri);
            DonateButton.Source = bitmap;
            DonateButton.Cursor = Cursors.Arrow;
        }

        private delegate void UpdateProgress(int percent, long bytesReceived, long totalBytesReceive, double time);
        private delegate void MakeVisibleInvisible(bool visible);

        private readonly string tempPath = System.IO.Path.GetTempFileName();

        public object PrivateFontCollection { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Check if WowLocation Exists
            if (string.IsNullOrEmpty(Settings.Default.WoWLocation) || !Directory.Exists(Settings.Default.WoWLocation))
            {
                if (!string.IsNullOrEmpty(WoW.Directory))
                {
                    Settings.Default.WoWLocation = WoW.Directory;
                    Settings.Default.Save();
                }
                else
                {
                    SettingsWindow settings = new SettingsWindow();
                    settings.ShowDialog();
                }
            }

            // Transparency Check - Not Ready Yet
            if (Settings.Default.TransparencyToggle == true)
            {

            }
            else
            {

            }

            // Populate ComboBox
            Theme.ItemsSource = new List<string> { "Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald", "Teal", "Cyan", "Cobalt", "Indigo", "Violet", "Pink", "Magenta", "Crimson", "Amber", "Yellow", "Brown", "Olive", "Steel", "Muave", "Taupe", "Sienna" };

            //=============THEME STARTUP CONFIGURATION=============\\

            // Red Theme
            if (Settings.Default.Theme == "Red")
            {
                Theme.SelectedValue = "Red";
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Red"), ThemeManager.GetAppTheme("BaseLight"));
            }
            // Green Theme
            if (Settings.Default.Theme == "Green")
            {
                Theme.SelectedValue = "Green";
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Green"), ThemeManager.GetAppTheme("BaseLight"));
            }
            // Blue Theme
            if (Settings.Default.Theme == "Blue")
            {
                Theme.SelectedValue = "Blue";
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseLight"));
            }
            // Purple Theme
            if (Settings.Default.Theme == "Purple")
            {
                Theme.SelectedValue = "Purple";
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Purple"), ThemeManager.GetAppTheme("BaseLight"));
            }

            //========================================= GET TITLE FROM DATABASE SECTION ================================================\\

            MySqlConnection conn;
            int i = 0;
            int count = 6; //NUMBER OF NEWS DISPLAYED ON LAUNCHER
            string MyConString = "server=wownewage.com;uid=launcher;pwd=FiYeSO;database=website;";
            conn = new MySqlConnection(MyConString);
            conn.Open();
            MySqlCommand getTitle = new MySqlCommand("SELECT headline FROM articles ORDER BY id DESC LIMIT 6;", conn);
            string[] titleContent = new string[count];
            MySqlDataReader title_row = getTitle.ExecuteReader();
            while (title_row.Read())
            {
                string title = title_row["headline"].ToString();
                titleContent[i] = title.Substring(12, title.Length - 2 - 12);
                i++;
            }
            conn.Close();

            //========================================= GET CONTENT FROM DATABASE SECTION ================================================\\
            conn.Open();
            i = 0; // RESET i Value for Re-Usage
            MySqlCommand getContent = new MySqlCommand("SELECT content FROM articles ORDER BY id DESC LIMIT 6;", conn);
            string[] contentContent = new string[count];
            MySqlDataReader content_row = getContent.ExecuteReader();

            while (content_row.Read())
            {
                string content = content_row["content"].ToString();
                contentContent[i] = content.Substring(3, content.Length - 7).Replace("<p>", " ").Replace("</p>", "").Replace("nbsp", "\n").Replace(";", "").Replace("&", "");
                i++;
            }

            conn.Close();

            //========================================= GET IMG LINK FROM DATABASE SECTION ================================================\\

            conn.Open();
            i = 0; // RESET i Value for ReUsage
            MySqlCommand getImgLink = new MySqlCommand("SELECT imgLink FROM articles ORDER BY id DESC LIMIT 6;", conn);
            string[] ImgLinkContent = new string[count];
            MySqlDataReader ImgLink_row = getImgLink.ExecuteReader();
            while (ImgLink_row.Read())
            {
                string ImgLink = ImgLink_row["imgLink"].ToString();
                ImgLinkContent[i] = ImgLink;
                i++;
            }

            conn.Close();

            //SET TITLE AND CONTENT SECTION

            // Image1 Code

            if (string.IsNullOrEmpty(ImgLinkContent[0]))
            {
                UpdateBox1.Opacity = 0.0;
            }
            else
            {
                BitmapImage img1 = new BitmapImage();
                img1.BeginInit();
                img1.UriSource = new Uri(ImgLinkContent[0]);
                img1.EndInit();

                UpdateBox1.Source = img1;
            }

            // Item1 Code

            News_Item1_Title.Content = titleContent[0];
            Item1_Description.Text = contentContent[0];

            // Image2 Code

            if (string.IsNullOrEmpty(ImgLinkContent[1]))
            {
                UpdateBox2.Opacity = 0.0;
            }
            else
            {
                BitmapImage img2 = new BitmapImage();
                img2.BeginInit();
                img2.UriSource = new Uri(ImgLinkContent[1]);
                img2.EndInit();

                UpdateBox2.Source = img2;
            }

            // Item2 Code

            News_Item2_Title.Content = titleContent[1];
            Item2_Description.Text = contentContent[1];

            // Image3 Code

            if (string.IsNullOrEmpty(ImgLinkContent[2]))
            {
                UpdateBox3.Opacity = 0.0;
            }
            else
            {
                BitmapImage img3 = new BitmapImage();
                img3.BeginInit();
                img3.UriSource = new Uri(ImgLinkContent[2]);
                img3.EndInit();

                UpdateBox3.Source = img3;
            }

            // Item3 Code

            News_Item3_Title.Content = titleContent[2];
            Item3_Description.Text = contentContent[2];

            // Image4 Code

            if (string.IsNullOrEmpty(ImgLinkContent[3]))
            {
                UpdateBox4.Opacity = 0.0;
            }
            else
            {
                BitmapImage img4 = new BitmapImage();
                img4.BeginInit();
                img4.UriSource = new Uri(ImgLinkContent[3]);
                img4.EndInit();

                UpdateBox4.Source = img4;
            }

            // Item4 Code

            News_Item4_Title.Content = titleContent[3];
            Item4_Description.Text = contentContent[3];

            // Image5 Code

            if (string.IsNullOrEmpty(ImgLinkContent[4]))
            {
                UpdateBox5.Opacity = 0.0;
            }
            else
            {
                BitmapImage img5 = new BitmapImage();
                img5.BeginInit();
                img5.UriSource = new Uri(ImgLinkContent[4]);
                img5.EndInit();

                UpdateBox5.Source = img5;
            }

            // Item5 Code

            News_Item5_Title.Content = titleContent[4];
            Item5_Description.Text = contentContent[4];

            // Image6 Code

            if (string.IsNullOrEmpty(ImgLinkContent[5]))
            {
                UpdateBox6.Opacity = 0.0;
            }
            else
            {
                BitmapImage img6 = new BitmapImage();
                img6.BeginInit();
                img6.UriSource = new Uri(ImgLinkContent[5]);
                img6.EndInit();

                UpdateBox6.Source = img6;
            }

            // Item6 Code

            News_Item6_Title.Content = titleContent[5];
            Item6_Description.Text = contentContent[5];

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();

            BackgroundWorker bw_downloader = new BackgroundWorker();
            bw_downloader.DoWork += new DoWorkEventHandler(bw_downloader_DoWork);

            try
            {
                string path = WoW.RealmListLocation;

                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(Settings.Default.Realmlist);
                        writer.Flush();

                        writer.Close();
                    }
                }
                if (Settings.Default.PatchDownloadURL != String.Empty)
                    bw_downloader.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NewAge Launcher", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool status = false;

            using (TcpClient client = new TcpClient())
            {

                // Checks if it can Connect to Core, Based on Server Address & Port

                try
                {
                    client.Connect(Settings.Default.Server, Settings.Default.Port);

                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }

                if (status)
                {
                    Statuslbl.Foreground = System.Windows.Media.Brushes.Red;
                    Statuslbl.Content = "Online";
                }
                else
                {
                    Statuslbl.Foreground = System.Windows.Media.Brushes.Green;
                    Statuslbl.Content = "Offline";
                }
            }

        }

        private void bw_downloader_DoWork(object sender, DoWorkEventArgs e)
        {
            using (client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanges);

                //Start Stopwatch for Download Speed
                sw.Start();
                Uri patchuri = new Uri(Settings.Default.PatchDownloadURL);

                try
                {
                    //Start Downloading File(s)
                    client.DownloadFileAsync(patchuri, tempPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void client_DownloadProgressChanges(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new UpdateProgress(UpdateProgressBar), new object[] { e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive, sw.Elapsed.TotalSeconds });
        }

        private class PatchFileInfo
        {
            public string url { get; set; }
            public string file { get; set; }
            public string md5hash { get; set; }

            public PatchFileInfo(string URL, string File)
            {
                url = URL;
                file = File;
            }
        }

        private void UpdateProgressBar(int percent, long bytesReceived, long totalBytesToReceive, double time)
        {
            string received = String.Empty;
            string total = String.Empty;

            //BytesReceived Config

            if (int.Parse(bytesReceived.ToString()) >= 1073741824)
                received = String.Format("{0:0.00}GB", double.Parse(bytesReceived.ToString()) / 1024 / 1024 / 1024);

            else if (int.Parse(bytesReceived.ToString()) >= 1048576)
                received = String.Format("{0:0.00}MB", double.Parse(bytesReceived.ToString()) / 1024 / 1024);

            else
                received = String.Format("{0:0.00}KB", double.Parse(bytesReceived.ToString()) / 1024);

            //TotalBytes(Receive Config)

            if (int.Parse(totalBytesToReceive.ToString()) >= 1073741824)
                total = String.Format("{0:0.00}GB", double.Parse(totalBytesToReceive.ToString()) / 1024 / 1024 / 1024);

            else if (int.Parse(totalBytesToReceive.ToString()) >= 1048576)
                total = String.Format("{0:0.00}MB", double.Parse(totalBytesToReceive.ToString()) / 1024 / 1024);

            else
                total = String.Format("{0:0.00}KB", double.Parse(totalBytesToReceive.ToString()) / 1024);

            string progress = String.Format("Downloading: {0} / {1}", received, total);

            string speed;

            if ((int)(bytesReceived / 1024d / time) > 1000)
            {
                speed = String.Format("{0} MB/S", (bytesReceived / 1024d / 1024d / time).ToString("0.00"));
            }
            else
            {
                speed = String.Format("{0} KB/S", (bytesReceived / 1024d / time).ToString("0.00"));
            }

            Downloader_ProgressBar.Value = percent;
            TextBlock_Speed.Text = speed;
            Textblock_Status.Text = progress;

        }

        private Queue<PatchFileInfo> patchQueue = new Queue<PatchFileInfo>();

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {
                bool anyDownloads = false;

                string loc = WoW.DataDirectory;

                if (!string.IsNullOrEmpty(loc) && Directory.Exists(loc))
                {
                    using (StreamReader reader = new StreamReader(tempPath))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] ex = line.Split(' ');
                            string path = System.IO.Path.Combine(loc, ex[1]);

                            bool proceed = true;

                            if (File.Exists(path))
                            {
                                //Compare MD5 Hashes

                                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    using (MD5 md5 = new MD5CryptoServiceProvider())
                                    {
                                        byte[] retVal = md5.ComputeHash(fs);

                                        fs.Close();

                                        StringBuilder sb = new StringBuilder();

                                        foreach (byte b in retVal)
                                        {
                                            sb.Append(string.Format("{0:X2}", b));
                                        }

                                        if (ex[2] == sb.ToString())
                                        {
                                            proceed = false;
                                        }

                                    }
                                }
                            }

                            if (proceed)
                            {
                                WebClient downloadPatches = new WebClient();

                                downloadPatches.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadPatches_DownloadFileCompleted);
                                downloadPatches.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanges);

                                PatchFileInfo pfi = new PatchFileInfo(ex[0], path);

                                object obj = pfi;

                                if (!anyDownloads)
                                    downloadPatches.DownloadFileAsync(new Uri(ex[0]), path, obj);
                                else
                                    patchQueue.Enqueue(pfi);

                                anyDownloads = true;
                            }
                        }
                    }
                }

                if (!anyDownloads)
                    Dispatcher.Invoke(new MakeVisibleInvisible(DownloadCompleted), new object[] { false });
                else
                    Dispatcher.Invoke(new MakeVisibleInvisible(DownloadCompleted), new object[] { true });

            }
        }

        private void downloadPatches_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (patchQueue.Count != 0)
            {
                PatchFileInfo pfi = patchQueue.Dequeue();

                WebClient downloadPatches = new WebClient();

                downloadPatches.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadPatches_DownloadFileCompleted);
                downloadPatches.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanges);

                downloadPatches.DownloadFileAsync(new Uri(pfi.url), (pfi.file));
            }
            else
            {
                Dispatcher.Invoke(new MakeVisibleInvisible(DownloadCompleted), new object[] { false });
            }
        }

        private void DownloadCompleted(bool visible)
        {
            if (visible)
            {
                Textblock_Status.Opacity = 1.0;
                TextBlock_Speed.Opacity = 1.0;
                Downloader_ProgressBar.IsEnabled = true;
                Downloader_ProgressBar.Opacity = 1.0;
                PlayButton.IsEnabled = false;
            }
            else
            {
                sw.Reset();
                Textblock_Status.Opacity = 0.0;
                TextBlock_Speed.Opacity = 0.0;
                Downloader_ProgressBar.IsEnabled = false;
                Downloader_ProgressBar.Opacity = 0.0;
                PlayButton.IsEnabled = true;
            }
        }

        private void AboutUsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/AboutUs_Hovor.png");
            var bitmap = new BitmapImage(uri);
            AboutUsButton.Source = bitmap;
        }

        private void AboutUsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/AboutUs_NoHovor.png");
            var bitmap = new BitmapImage(uri);
            AboutUsButton.Source = bitmap;
        }

        private void ForumButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Forum_Hovor.png");
            var bitmap = new BitmapImage(uri);
            ForumButton.Source = bitmap;
        }

        private void ForumButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/Forum_NoHovor.png");
            var bitmap = new BitmapImage(uri);
            ForumButton.Source = bitmap;
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutus = new AboutWindow();
            aboutus.ShowDialog();
        }

        private void SettingsButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SettingsWindow settingswindow = new SettingsWindow();
            settingswindow.ShowDialog();
        }

        //===========THEME CONFIGURATION===========\\

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tuple<AppTheme, Accent> appstyle = ThemeManager.DetectAppStyle(Application.Current);
            Tuple<AppTheme, Accent> appstyle_settings = ThemeManager.DetectAppStyle(Application.Current);
            var selectedvalue = Theme.SelectedValue;
            string selection = Convert.ToString(selectedvalue);

            // Change Theme to Red

            if (selection == "Red")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Red"), ThemeManager.GetAppTheme("BaseLight"));
                Settings.Default.Theme = "Red";
                Settings.Default.Save();
            }

            // Change Theme to Green

            if (selection == "Green")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Green"), ThemeManager.GetAppTheme("BaseLight"));
                Settings.Default.Theme = "Green";
                Settings.Default.Save();
            }

            // Change Theme to Blue

            if (selection == "Blue")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseLight"));
                Settings.Default.Theme = "Blue";
                Settings.Default.Save();
            }

            // Change Theme to Purple

            if (selection == "Purple")
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Purple"), ThemeManager.GetAppTheme("BaseLight"));
                Settings.Default.Theme = "Purple";
                Settings.Default.Save();
            }

        }

        private void PlayButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string wowExe = WoW.ExecutableLocation;

            if (Settings.Default.WoWCacheToggle == true)
            {
                if (File.Exists(Settings.Default.WoWLocation + "/Cache"))
                {
                    //MessageBox.Show("Removing Cache Success");
                    File.Delete(Settings.Default.WoWLocation + "/Cache");
                }
            }

            if (!string.IsNullOrEmpty(wowExe) && File.Exists(wowExe))
            {
                Process.Start(wowExe);
                WindowState = WindowState.Minimized;
            }
            else
            {
                File.Copy(Settings.Default.WoWLocation + "\\data\\wow.mpq", Settings.Default.WoWLocation + "\\wow_mod.exe");
                MessageBox.Show(this, "Could not find WoW_mod.exe! Launcher just restored a backup of wow_mod.exe", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LogoImage_MouseEnter(object sender, MouseEventArgs e)
        {
            LogoImage.Cursor = Cursors.Hand;
        }

        private void LogoImage_MouseLeave(object sender, MouseEventArgs e)
        {
            LogoImage.Cursor = Cursors.Arrow;
        }

        private void DonateButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://wownewage.com/donate");
        }

        private void AboutUsButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutWindow aboutus = new AboutWindow();
            aboutus.ShowDialog();
        }

        private void ForumButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://community.wownewage.com");
        }
    }
}
