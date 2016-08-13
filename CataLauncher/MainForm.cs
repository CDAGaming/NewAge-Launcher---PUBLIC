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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using NewAgeLauncher.Properties;
using System.Drawing.Text;


//using IWshRuntimeLibrary;

namespace NewAgeLauncher
{
    public partial class MainForm : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        Stopwatch sw = new Stopwatch();
        WebClient client;

        public MainForm()
        {
            InitializeComponent();

            if(Settings.Default.TransparencyToggle == false)
            {
                Opacity = 1.00;
            }
            else
            {
                Opacity = 1.00;
            }

        }

        private void loadFont()
        {
            byte[] fontArray = Resources.DroidSans;
            int dataLength = Resources.DroidSans.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);

        }

        private void AllocFont(Font f, Control c, float size, Boolean bold)
        {
            if (bold)
            {
                FontStyle fontStyle = FontStyle.Bold;
                c.Font = new Font(ff, size, fontStyle);
            }
            else
            {
                FontStyle fontStyle = FontStyle.Regular;
                c.Font = new Font(ff, size, fontStyle);
            }

        }

        // CREATE SHORTCUT

        /*  private void appShortcutToDesktop(string linkName)
          {
              string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

              using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
              {
                  string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                  writer.WriteLine("[InternetShortcut]");
                  writer.WriteLine("URL=file:///" + app);
                  writer.WriteLine("IconIndex=0");
                  string icon = app.Replace('\\', '/');
                  writer.WriteLine("IconFile=" + icon);
                  writer.Flush();
              }
          }
          */

        private void exitPictureBox_MouseEnter(object sender, EventArgs e)
        {
            exitPictureBox.Image = Resources.ExitButton;
        }

        private void MinimizePictureBox_MouseEnter(object sender, EventArgs e)
        {
            MinimizePictureBox.Image = Resources.MinimizeButton;
        }

        private void exitPictureBox_MouseLeave(object sender, EventArgs e)
        {
            exitPictureBox.Image = Resources.ExitButtonNoHover;
        }

        private void MinimizePictureBox_MouseLeave(object sender, EventArgs e)
        {
            MinimizePictureBox.Image = Resources.MinimizeButtonNoHover;
        }

        private void exitPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizePictureBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // ===================
        private void playButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            playButtonPictureBox.Image = Resources_US.Play_Hovor;
            Cursor = Cursors.Hand;
        }

        private void playButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            playButtonPictureBox.Image = Resources_US.Play_NoHovor2;
            Cursor = Cursors.Arrow;
        }

        private void playButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            playButtonPictureBox.Image = Resources_US.Play_Hovor;
        }

        private void playButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            playButtonPictureBox.Image = Resources_US.Play_Hovor;
        }
        // ===================

        // ===================

        private void settingsButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("mouse enter");
            settingsButtonPictureBox.Image = Resources_US.Settings_Hovor;
            Cursor = Cursors.Hand;
        }

        private void settingsButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            settingsButtonPictureBox.Image = Resources_US.Settings_NoHovor;
            Cursor = Cursors.Arrow;
        }

        private void settingsButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            settingsButtonPictureBox.Image = Resources_US.Settings_Hovor;
        }

        private void settingsButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            settingsButtonPictureBox.Image = Resources_US.Settings_Hovor;
        }

        // ===================

        // ===================
        private void donateButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("mouse enter");
            donateButtonPictureBox.Image = Resources_US.Donate_Hovor;
            Cursor = Cursors.Hand;
        }

        private void donateButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            donateButtonPictureBox.Image = Resources_US.Donate_NoHovor;
            Cursor = Cursors.Arrow;
        }

        private void donateButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            donateButtonPictureBox.Image = Resources_US.Donate_Hovor;
        }

        private void donateButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            donateButtonPictureBox.Image = Resources_US.Donate_Hovor;
        }
        // ===================

        // ===================
        private void aboutUsButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            aboutUsButtonPictureBox.Image = Resources_US.AboutUs_Hovor;
            Cursor = Cursors.Hand;
        }

        private void aboutUsButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            aboutUsButtonPictureBox.Image = Resources_US.AboutUs_NoHovor;
            Cursor = Cursors.Arrow;
        }

        private void aboutUsButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            aboutUsButtonPictureBox.Image = Resources_US.AboutUs_Hovor;
        }

        private void aboutUsButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            aboutUsButtonPictureBox.Image = Resources_US.AboutUs_Hovor;
        }
        // ===================

        // ===================
        private void forumButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            forumButtonPictureBox.Image = Resources_US.Forum_Hovor;
            Cursor = Cursors.Hand;
        }

        private void forumButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            forumButtonPictureBox.Image = Resources_US.Forum_NoHovor;
            Cursor = Cursors.Arrow;
        }

        private void forumButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            forumButtonPictureBox.Image = Resources_US.Forum_Hovor;
        }

        private void forumButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            forumButtonPictureBox.Image = Resources_US.Forum_Hovor;
        }
        // ===================

        private void exitPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            exitPictureBox.Image = Resources.ExitButtonPress;
        }

        private void exitPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            exitPictureBox.Image = Resources.ExitButton;
        }

        private void MinimizePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MinimizePictureBox.Image = Resources.MinimizeButtonPress;
        }

        private void MinimizePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            MinimizePictureBox.Image = Resources.MinimizeButton;
        }

        private void playButtonPictureBox_Click(object sender, EventArgs e)
        {


            string wowExe = WoW.ExecutableLocation;

            if (!string.IsNullOrEmpty(wowExe) && File.Exists(wowExe))
            {
                Process.Start(wowExe);

                WindowState = FormWindowState.Minimized;
            }
            else
            {
                File.Copy(Settings.Default.WowLocation + "\\data\\wow.mpq", Settings.Default.WowLocation + "\\wow_mod.exe");
                MessageBox.Show(this, "Could not find WoW_mod.exe! Launcher just restored a backup of wow_mod.exe", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private delegate void UpdateProgress(int percent, long bytesReceived, long totalBytesReceive, double time);
        private delegate void MakeVisibleInvisible(bool visible);

        private readonly string tempPath = Path.GetTempFileName();

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Detect if Launguage Change is needed
            // Duplicate Code

            /*
            if (Settings.Default.LaunguageSet == true)
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/bin/Launguage Changer.exe");
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                // N/A
            }
            */

            // Transparency Toggle(SettingsForm.cs)

            if (Settings.Default.TransparencyToggle == false)
            {
                Opacity = 1.00;
            }
            if (Settings.Default.TransparencyToggle == true)
            {
                Opacity = .90;
            }

            // LOAD FONT
            loadFont();
            AllocFont(font, this.News_Item1_Title, 12, true);
            AllocFont(font, this.News_Item2_Title, 12, true);
            AllocFont(font, this.News_Item3_Title, 12, true);
            AllocFont(font, this.News_Item4_Title, 12, true);
            AllocFont(font, this.News_Item5_Title, 12, true);
            AllocFont(font, this.News_Item6_Title, 12, true);

            AllocFont(font, this.Item1_Description, 9, false);
            AllocFont(font, this.Item2_Description, 9, false);
            AllocFont(font, this.Item3_Description, 9, false);
            AllocFont(font, this.Item4_Description, 9, false);
            AllocFont(font, this.Item5_Description, 9, false);
            AllocFont(font, this.Item6_Description, 9, false);

            AllocFont(font, this.downloadProgressLabel, 14, false);
            //AllocFont(font, this.downloadSpeedLabel, 14, false);

            AllocFont(font, this.updatesLabel, 16, false);




            /* string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
             if (!System.IO.File.Exists(Path.Combine(desktopPath, "Launcher.lnk")))
             {
                 string startMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                 File.Copy(Path.Combine(Directory, @"Programs\Launcher\Launcher.lnk"), )//CREATE DESKTOP SHORTCUT
             }
             */

            //========================================= GET TITLE FROM DATABASE SECTION ================================================
            MySqlConnection conn;
            int i = 0;
            int count = 6; //NUMBER OF NEWS DISPLAYED ON LAUNCHER 
            string MyConString = "server=wownewage.com;uid=launcher;pwd=FiYeSO;database=website;";
            conn = new MySqlConnection(MyConString);
            conn.Open();
            MySqlCommand getTitle = new MySqlCommand("SELECT headline FROM articles ORDER BY id DESC LIMIT 6;", conn);
            //MySqlCommand getRow = new MySqlCommand("SELECT COUNT(*) FROM articles", conn); //USELESS FOR NOW BUT CAN BE USED IN FUTURE
            //count = (int)getRow.ExecuteScalar(); //SAME AS BEFORE
            string[] titleContent = new string[count];
            MySqlDataReader title_row = getTitle.ExecuteReader();
            while (title_row.Read())
            {
                string title = title_row["headline"].ToString();
                //MessageBox.Show(title.Substring(12, title.Length-2-12)); //ENABLE FOR DEBUG
                titleContent[i] = title.Substring(12, title.Length - 2 - 12);
                i++;
            }
            conn.Close();

            //========================================= GET CONTENT FROM DATABASE SECTION ================================================
            conn.Open();
            i = 0; // RESET i value for re-use it 
            MySqlCommand getContent = new MySqlCommand("SELECT content FROM articles ORDER BY id DESC LIMIT 6;", conn);
            //MySqlCommand getRow = new MySqlCommand("SELECT COUNT(*) FROM articles", conn); //USELESS FOR NOW BUT CAN BE USED IN FUTURE
            //count = (int)getRow.ExecuteScalar(); //SAME AS BEFORE
            string[] contentContent = new string[count];
            MySqlDataReader content_row = getContent.ExecuteReader();
            while (content_row.Read())
            {
                string content = content_row["content"].ToString();
                //MessageBox.Show(content.Substring(12, content.Length-2-12)); //ENABLE FOR DEBUG
                contentContent[i] = content.Substring(3, content.Length - 7).Replace("<p>", " ").Replace("</p>", "").Replace("nbsp", "\n");
                i++;
            }

            conn.Close();

            //========================================= GET IMG LINK FROM DATABASE SECTION ================================================
            conn.Open();
            i = 0; // RESET i value for re-use it 
            MySqlCommand getImgLink = new MySqlCommand("SELECT imgLink FROM articles ORDER BY id DESC LIMIT 6;", conn);
            //MySqlCommand getRow = new MySqlCommand("SELECT COUNT(*) FROM articles", conn); //USELESS FOR NOW BUT CAN BE USED IN FUTURE
            //count = (int)getRow.ExecuteScalar(); //SAME AS BEFORE
            string[] ImgLinkContent = new string[count];
            MySqlDataReader ImgLink_row = getImgLink.ExecuteReader();
            while (ImgLink_row.Read())
            {
                string ImgLink = ImgLink_row["imgLink"].ToString();
                //MessageBox.Show(content.Substring(12, content.Length-2-12)); //ENABLE FOR DEBUG
                ImgLinkContent[i] = ImgLink;
                i++;
            }

            conn.Close();

            //SET TITLE AND CONTENT SECTION
            News_Item1_Title.Text = titleContent[0];
            Item1_Description.Text = contentContent[0];
            UpdateBox1.ImageLocation = ImgLinkContent[0];

            News_Item2_Title.Text = titleContent[1];
            Item2_Description.Text = contentContent[1];
            UpdateBox2.ImageLocation = ImgLinkContent[1];

            News_Item3_Title.Text = titleContent[2];
            Item3_Description.Text = contentContent[2];
            UpdateBox3.ImageLocation = ImgLinkContent[2];

            News_Item4_Title.Text = titleContent[3];
            Item4_Description.Text = contentContent[3];
            UpdateBox4.ImageLocation = ImgLinkContent[3];

            News_Item5_Title.Text = titleContent[4];
            Item5_Description.Text = contentContent[4];
            UpdateBox5.ImageLocation = ImgLinkContent[4];

            News_Item6_Title.Text = titleContent[5];
            Item6_Description.Text = contentContent[5];
            UpdateBox6.ImageLocation = ImgLinkContent[5];

            // END UPDATES SECTION =====================================

            /*
            int btnCtr = 0;

                if (!string.IsNullOrEmpty(Settings.Default.WebsiteUrl))
                {

                    CataButton btn = new CataButton();
                    btn.Size = new Size(97, 39);
                    btn.Name = "webButton";
                    btn.ButtonText = "Website";
                    btn.Location = new Point((97 * btnCtr) + 25, 469);
                    btn.Click += (s, args) => Process.Start(Settings.Default.WebsiteUrl);

                    Controls.Add(btn);

                    btn.BringToFront();

                    btnCtr++;

                }

                if (!string.IsNullOrEmpty(Settings.Default.ForumsUrl))
                {

                    CataButton btn = new CataButton();
                    btn.Size = new Size(97, 39);
                    btn.Name = "frmButton";
                    btn.ButtonText = "Forums";
                    btn.Location = new Point((97 * btnCtr) + 25, 469);
                    btn.Click += (s, args) => Process.Start(Settings.Default.ForumsUrl);

                    Controls.Add(btn);

                    btn.BringToFront();

                    btnCtr++;

                }

                if (!string.IsNullOrEmpty(Settings.Default.VoteUrl))
                {

                    CataButton btn = new CataButton();
                    btn.Size = new Size(97, 39);
                    btn.Name = "voteBtn";
                    btn.ButtonText = "Vote";
                    btn.Location = new Point((97 * btnCtr) + 25, 469);
                    btn.Click += (s, args) => Process.Start(Settings.Default.VoteUrl);

                    Controls.Add(btn);

                    btn.BringToFront();

                    btnCtr++;

                }

                if (!string.IsNullOrEmpty(Settings.Default.DonateUrl))
                {

                    CataButton btn = new CataButton();
                    btn.Size = new Size(97, 39);
                    btn.Name = "donateBtn";
                    btn.ButtonText = "Donate";
                    btn.Location = new Point((97 * btnCtr) + 25, 469);
                    btn.Click += (s, args) => Process.Start(Settings.Default.DonateUrl);

                    Controls.Add(btn);

                    btn.BringToFront();

                }
                */

            if (string.IsNullOrEmpty(Settings.Default.WowLocation) || !Directory.Exists(Settings.Default.WowLocation))
            {

                if (!string.IsNullOrEmpty(WoW.Directory))
                {
                    Settings.Default.WowLocation = WoW.Directory;
                    Settings.Default.Save();
                }
                else
                {
                    using (SettingsForm form = new SettingsForm())
                        form.ShowDialog();
                }

            }

            TransparencyKey = Color.Lime;

            downloadBar1.BarState = DownloadBar.DownloadBarState.Setup;

            checkServerStatusBackgroundWorker.RunWorkerAsync();

            try
            {

                string path = WoW.RealmListLocation;

                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {

                        writer.WriteLine(Settings.Default.realmlist);
                        writer.Flush();

                        writer.Close();

                    }
                }

                if (Settings.Default.patchDownloadURL != String.Empty)
                    startDownloadBackgroundWorker.RunWorkerAsync();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NewAge Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startDownloadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // WebClient client = new WebClient();
            using (client = new WebClient())
            {

                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    client.DownloadFileAsync(new Uri(Settings.Default.patchDownloadURL), tempPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            //================

            // downloadSpeedLabel.Text = text_speed;

            //===============
            this.Invoke(new UpdateProgress(UpdateProgressbar), new object[] { e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive, sw.Elapsed.TotalSeconds });
        }

        private void UpdateProgressbar(int percent, long bytesReceived, long totalBytesToReceive, double time)
        {
            string received = String.Empty;
            string total = String.Empty;

            if (int.Parse(bytesReceived.ToString()) >= 1073741824)
                received = String.Format("{0:0.00}gb", double.Parse(bytesReceived.ToString()) / 1024 / 1024 / 1024);

            else if (int.Parse(bytesReceived.ToString()) >= 1048576)
                received = String.Format("{0:0.00}mb", double.Parse(bytesReceived.ToString()) / 1024 / 1024);

            else
                received = String.Format("{0:0.00}kb", double.Parse(bytesReceived.ToString()) / 1024);


            if (int.Parse(totalBytesToReceive.ToString()) >= 1073741824)
                total = String.Format("{0:0.00}gb", double.Parse(totalBytesToReceive.ToString()) / 1024 / 1024 / 1024);

            else if (int.Parse(totalBytesToReceive.ToString()) >= 1048576)
                total = String.Format("{0:0.00}mb", double.Parse(totalBytesToReceive.ToString()) / 1024 / 1024);

            else
                total = String.Format("{0:0.00}kb", double.Parse(totalBytesToReceive.ToString()) / 1024);

            string progress = String.Format("Downloading: {0} / {1}", received, total);

            string speed;

            if ((int)(bytesReceived / 1024d / time) > 1000)
            {
                speed = String.Format("{0} MB/s", (bytesReceived / 1024d / 1024d / time).ToString("0.00"));
            }
            else
            {
                speed = String.Format("{0} KB/s", (bytesReceived / 1024d / time).ToString("0.00"));
            }

            //MessageBox.Show(speed);

            downloadSpeedLabel.Text = speed;
            //downloadSpeedLabel.Refresh();
            //MessageBox.Show("received bytes: " + (bytesReceived + " Elapsed seconds: " + sw.Elapsed.TotalSeconds + " speed: " + bytesReceived/time));

            downloadProgressLabel.Text = progress;

            downloadBar1.Value = percent;
        }

        private Queue<PatchFileInfo> patchQueue = new Queue<PatchFileInfo>();

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            //sw.Reset();

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


                            string path = Path.Combine(loc, ex[1]);

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
                                downloadPatches.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadPatches_DownloadProgressChanged);


                                PatchFileInfo pfi = new PatchFileInfo(ex[0], path);

                                object obj = pfi;

                                downloadBar1.Invoke((MethodInvoker)delegate
                                {
                                    downloadBar1.BarState = DownloadBar.DownloadBarState.Playable;
                                });


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
                    this.Invoke(new MakeVisibleInvisible(DownloadCompleted), new object[] { false });
                else
                    this.Invoke(new MakeVisibleInvisible(DownloadCompleted), new object[] { true });

            }
        }

        private void downloadPatches_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            if (patchQueue.Count != 0)
            {
                PatchFileInfo pfi = patchQueue.Dequeue();

                WebClient downloadPatches = new WebClient();

                downloadPatches.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadPatches_DownloadFileCompleted);
                downloadPatches.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadPatches_DownloadProgressChanged);

                downloadPatches.DownloadFileAsync(new Uri(pfi.url), pfi.file);

            }
            else
                this.Invoke(new MakeVisibleInvisible(DownloadCompleted), new object[] { false });
        }

        private void DownloadCompleted(bool visible)
        {
            if (visible)
            {
                downloadProgressLabel.Visible = true;
                downloadSpeedLabel.Visible = true;
                downloadBar1.BarState = DownloadBar.DownloadBarState.Available;
                playButtonPictureBox.Enabled = false;
                playButtonPictureBox.Image = Resources_US.Play_NoHovor2;
            }
            else
            {
                sw.Reset();
                downloadProgressLabel.Visible = false;
                downloadSpeedLabel.Visible = false;
                downloadBar1.BarState = DownloadBar.DownloadBarState.Playable;
                playButtonPictureBox.Enabled = true;
                playButtonPictureBox.Image = Resources_US.Play_NoHovor2;
            }
        }

        private void downloadPatches_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke(new UpdateProgress(UpdateProgressbar), new object[] { e.ProgressPercentage, (int)e.BytesReceived, (int)e.TotalBytesToReceive, (int)sw.Elapsed.TotalSeconds });
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

        private void checkServerStatusBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool status = false;

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(Settings.Default.server, Settings.Default.port);

                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }

            statusLabel.Invoke((MethodInvoker)delegate
            {
                if (status)
                {
                    statusLabel.ForeColor = Color.LimeGreen;
                    statusLabel.Text = "Online";
                }
                else
                {
                    statusLabel.ForeColor = Color.IndianRed;
                    statusLabel.Text = "Offline";
                }
            });
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void menuBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm sForm = new SettingsForm())
            {
                sForm.ShowDialog();
            }
        }

        private void UpdateBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void settingsButtonPictureBox_Click(object sender, EventArgs e)
        {
            using (SettingsForm sForm = new SettingsForm())
            {
                sForm.ShowDialog();
            }
        }

        private void menuBar1_Load(object sender, EventArgs e)
        {

        }

        private void updatesLabel_Click(object sender, EventArgs e)
        {

        }

        private void downloadBar1_Load(object sender, EventArgs e)
        {

        }

        private void forumButtonPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("http://community.wownewage.com");
        }

        private void donateButtonPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("http://wownewage.com/donate");
        }

        private void aboutUsButtonPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("http://wownewage.com/");
        }

        private void donateButtonPictureBox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void UpdateBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void UpdateBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void UpdateBox4_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void UpdateBox5_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        private void UpdateBox6_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wownewage.com");
        }

        //Create Resizability

        // Resizable Border Code

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
    }
}