using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewAgeLauncher.Properties;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LaunguageChanger
{
    public partial class TitleForm : Form
    {
        // Creates New WebClient, & Sets New .exe FileName

        WebClient client = new WebClient();

        public TitleForm()
        {
            InitializeComponent();
        }

        private void DownloadFile(string url, string save)
        {
            using (var client = new WebClient())
            {
                
                Startlbl.Text = Properties.Settings.Default.CurrentLaunguage + "to" + Settings.Default.LaunguageSet;
                client.DownloadFileAsync(new Uri(Properties.Settings.Default.EnglishURL), Properties.Settings.Default.SaveString);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Changed);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);

            }
        }

        private void Changed(object sender, DownloadProgressChangedEventArgs e)
        {
            Progresslbl.Value = e.ProgressPercentage;
            LabelStep1.ForeColor = Color.Yellow;
            LabelStep1.Text = "Downloading" + e.ProgressPercentage;
            lblprogress.Text = "Progress: Downloaded " + (e.BytesReceived / 1024d / 1024d).ToString("0.00 MB") + " (" + e.BytesReceived + " bytes) of " + (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00 MB") + " (" + e.TotalBytesToReceive + " bytes) " + e.ProgressPercentage + "%";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                LabelStep1.ForeColor = Color.Red;
                LabelStep1.Text = "Downloading";

                LabelStep2.ForeColor = Color.Red;
                LabelStep2.Text = "Patching";

                LabelStep3.ForeColor = Color.Red;
                LabelStep3.Text = "Completed";
            }
            else if (e.Cancelled == false)
            {

            }

            LabelStep1.ForeColor = Color.Green;
            LabelStep1.Text = "Downloading(100/100)";
            LabelStep2.ForeColor = Color.Green;
            LabelStep2.Text = "Patching(2 / 2)";
            LabelStep3.ForeColor = Color.Green;
            LabelStep3.Text = "Completed";


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Kills All Running NewAge Launcher.exe Instances

            Process[] process = Process.GetProcessesByName("NewAge Launcher");
            process[0].Kill();

            // Moves Current NewAge Launcher.exe to /bin & Renames to .OLD, Based on Launguage Setting

            DownloadFile(Properties.Settings.Default.EnglishURL, AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe");
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe"))
            {
                if (Settings.Default.LaunguageSet == "English (Default)")
                {
                    File.Move(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe", AppDomain.CurrentDomain.BaseDirectory + "/bin/EN/NewAge Launcher.OLD");
                }
                if (Settings.Default.LaunguageSet == "Espanol (Spanish)")
                {
                    File.Move(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe", AppDomain.CurrentDomain.BaseDirectory + "/bin/ES/NewAge Launcher.OLD");
                }
                if (Settings.Default.LaunguageSet == "Français(French)")
                {
                    File.Move(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe", AppDomain.CurrentDomain.BaseDirectory + "/bin/FR/NewAge Launcher.OLD");
                }
            }
            else
            {

            }
            DownloadFile(Properties.Settings.Default.EnglishURL , Properties.Settings.Default.SaveString);
        }
    }
}
