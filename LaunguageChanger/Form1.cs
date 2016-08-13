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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewAgeLauncher.Properties;
using System.Diagnostics;
// Required
using System.IO;
using System.Net;
using System.IO.Compression;

namespace LaunguageChanger
{
    public partial class TitleForm : Form
    {
        // Creates New WebClient

        WebClient client = new WebClient();

        public TitleForm()
        {
            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            // Saves Selected Launguage

            comboBox1.SelectedValue = Properties.Settings.Default.LaunguageChange;
            Properties.Settings.Default.Save();

            // Kills All Running NewAge Launcher.exe Instances

            Process[] process = Process.GetProcessesByName("NewAge Launcher");
            process[0].Kill();

            // Deletes Current New Age Files, except MySql.Data.dll

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe");
            }

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe.Config"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "NewAge Launcher.exe.Config");
            }

            // If Launcher is being Changed to English, Do the Following:

            if (Properties.Settings.Default.LaunguageChange == "English")
            {
                string ftpAdress_en = "ftp://wownewage.com/launcher/Launguage/EN/";
                string username_en = "Anthony";
                string password_en = "d6Zc35";
                string filename_en = "NewAge_Launcher.zip";
                string filedir_en = AppDomain.CurrentDomain.BaseDirectory + "/etc/EN/";
                string BaseDir_en = AppDomain.CurrentDomain.BaseDirectory;

                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAdress_en + filename_en);
                    request.Credentials = new NetworkCredential(username_en, password_en);
                    request.UseBinary = true;
                    request.Method = WebRequestMethods.Ftp.DownloadFile;

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    FileStream writer = new FileStream(filedir_en + filename_en, FileMode.Create);

                    long length = response.ContentLength;
                    int buffersize = 2048;
                    int readCount;
                    byte[] buffer = new byte[2048];

                    readCount = responseStream.Read(buffer, 0, buffersize);
                    while (readCount > 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        readCount = responseStream.Read(buffer, 0, buffersize);
                    }

                    responseStream.Close();
                    response.Close();
                    writer.Close();

                    // Sets Launcher Launguage Tag back to False to Prevent App Opening over & Over

                    if(Settings.Default.LanguageChangeTag == true)
                    {
                        Settings.Default.LanguageChangeTag = false;
                    }
                    if(Settings_ES.Default.LanguageChangeTag == true)
                    {
                        Settings_ES.Default.LanguageChangeTag = false;
                    }

                    // Saves All Current LAunguage Settings

                    Settings.Default.Save();
                    Settings_ES.Default.Save();

                    if (MessageBox.Show("Launguage is Now" + Properties.Settings.Default.LaunguageChange + ", Click OK to Finish Patching", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        string ZipPath = filedir_en + filename_en;
                        string ExtractPath = BaseDir_en;

                        try
                        {
                            ZipFile.ExtractToDirectory(ZipPath, ExtractPath);
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message, "Error");
                        }

                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }

                // If Launcher is being Changed to Espanol (Spanish), Do the Following:

                if (Properties.Settings.Default.LaunguageChange == "Espanol")
                {

                    string ftpAdress_ES = "ftp://wownewage.com/launcher/Launguage/ES/";
                    string username_ES = "Anthony";
                    string password_ES = "d6Zc35";
                    string filename_ES = "Lansador_de_NuevaEra.zip";
                    string filedir_ES = AppDomain.CurrentDomain.BaseDirectory + "/etc/ES/";
                    string BaseDir_ES = AppDomain.CurrentDomain.BaseDirectory;

                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAdress_ES + filename_ES);
                        request.Credentials = new NetworkCredential(username_ES, password_ES);
                        request.UseBinary = true;
                        request.Method = WebRequestMethods.Ftp.DownloadFile;

                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        FileStream writer = new FileStream(filedir_ES + filename_ES, FileMode.Create);

                        long length = response.ContentLength;
                        int buffersize = 2048;
                        int readCount;
                        byte[] buffer = new byte[2048];

                        readCount = responseStream.Read(buffer, 0, buffersize);
                        while (readCount > 0)
                        {
                            writer.Write(buffer, 0, readCount);
                            readCount = responseStream.Read(buffer, 0, buffersize);
                        }

                        responseStream.Close();
                        response.Close();
                        writer.Close();

                        // Sets Launcher Launguage Tag back to False to Prevent App Opening over & Over

                        if (Settings.Default.LanguageChangeTag == true)
                        {
                            Settings.Default.LanguageChangeTag = false;
                        }
                        if (Settings_ES.Default.LanguageChangeTag == true)
                        {
                            Settings_ES.Default.LanguageChangeTag = false;
                        }

                        // Saves All Current Launguage Settings

                        Settings.Default.Save();
                        Settings_ES.Default.Save();

                        if (MessageBox.Show("Launguage is Now" + Properties.Settings.Default.LaunguageChange + ", Click OK to Finish Patching", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            string ZipPath = filedir_ES + filename_ES;
                            string ExtractPath = BaseDir_ES;

                            try
                            {
                                ZipFile.ExtractToDirectory(ZipPath, ExtractPath);
                            }
                            catch(Exception ex2_ES)
                            {
                                MessageBox.Show(ex2_ES.Message, "Error");
                            }

                            Application.Exit();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
