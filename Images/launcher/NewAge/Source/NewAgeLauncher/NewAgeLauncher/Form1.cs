using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using NewAgeLauncher.Properties;
using System.Net;
using System.Security.Cryptography;

namespace NewAgeLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MovePlacemnt_Home_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void MovePlacemnt_Home_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for Trying our Unofficial Demo, This was in no way a final project, and is only used as a demonstration, We hope you will Support our Development for the Future", "Demo ONLY", MessageBoxButtons.OK);

            // OPEN SETTINGS FORM IF WOW DIRECTORY IS NOT SETTED
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

            //========================================= GET TITLE FROM DATABASE SECTION ================================================
            MySqlConnection conn;
            int i = 0;
            int count = 6; //NUMBER OF NEWS DISPLAYED ON LAUNCHER 
            string MyConString = "server=wownewage.com;uid=launcher;" +
                      "pwd=FiYeSO;database=website;";
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
                contentContent[i] = content.Substring(3, content.Length - 7);
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

            TransparencyKey = Color.Lime;

            downloadBar1.BarState = DownloadBar.DownloadBarState.Setup;

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
            WebClient client = new WebClient();

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

            client.DownloadFileAsync(new Uri(Settings.Default.patchDownloadURL), tempPath);
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke(new UpdateProgress(UpdateProgressbar), new object[] { e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive });
        }

        private void UpdateProgressbar(int percent, long bytesReceived, long totalBytesToReceive)
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

            string progress = String.Format("Download Progress: {0} / {1}", received, total);

            downloadProgressLabel.Text = progress;

            downloadBar1.Value = percent;
        }

        private Queue<PatchFileInfo> patchQueue = new Queue<PatchFileInfo>();

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
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
                downloadBar1.BarState = DownloadBar.DownloadBarState.Available;
                //playButtonPictureBox.Enabled = false;
                //playButtonPictureBox.Image = Properties.Resources.PlayButtonDisabled; //immagine play button disabled per download non completato
            }
            else
            {
                downloadProgressLabel.Visible = false;
                downloadBar1.BarState = DownloadBar.DownloadBarState.Playable;
                //playButtonPictureBox.Enabled = true;
                //playButtonPictureBox.Image = Properties.Resources.PlayNoHover;
            }
        }

        private void downloadPatches_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke(new UpdateProgress(UpdateProgressbar), new object[] { e.ProgressPercentage, (int)e.BytesReceived, (int)e.TotalBytesToReceive });
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void play_button_Click(object sender, EventArgs e)
        {
            if (File.Exists(Settings.Default.WowLocation + "\\wow.exe"))
            {
                if(File.Exists(Settings.Default.WowLocation + "\\wow.exe.bck"))
                {
                    //non fare niente
                }
                else
                {
                    File.Copy(Settings.Default.WowLocation + "\\wow.exe", Settings.Default.WowLocation + "\\wow.exe.bck");
                }
                File.Delete(Settings.Default.WowLocation + "\\wow.exe");
            }

            File.Copy(Settings.Default.WowLocation + "\\data\\wow.mpq", Settings.Default.WowLocation + "\\wow.exe");

            string wowExe = WoW.ExecutableLocation;

            if (!string.IsNullOrEmpty(wowExe) && File.Exists(wowExe))
            {
                Process.Start(wowExe);

                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Could not find WoW.exe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private delegate void UpdateProgress(int percent, long bytesReceived, long totalBytesReceive);
        private delegate void MakeVisibleInvisible(bool visible);

        private readonly string tempPath = Path.GetTempFileName();

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (SettingsForm sForm = new SettingsForm())
            {
                sForm.ShowDialog();
            }
        }

        private void MovePlacemnt_Home_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 547;
                mouseY = MousePosition.Y - 17;

                SetDesktopLocation(mouseX, mouseY);
            }
        }
    }
}
