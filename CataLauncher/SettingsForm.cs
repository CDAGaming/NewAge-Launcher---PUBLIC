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
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NewAgeLauncher.Properties;
using System.Diagnostics;

namespace NewAgeLauncher
{
    public partial class SettingsForm : Form
    {

        public SettingsForm()
        {
            InitializeComponent();

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

            TransparencyKey = Color.Lime;

            if(Settings.Default.LanguageChangeTag == false)
            {
                Language_Checkbox.Checked = false;
            }
            if (Settings.Default.FontAdditionTag == false)
            {
                Font_Checkbox.Checked = false;
            }

            wowLocationTextBox.Text = Settings.Default.WowLocation;
            Transparent_Checkbox.Checked = Settings.Default.TransparencyToggle;
            WoWCache_CheckBox.Checked = Settings.Default.WoWCacheToggle;
            Language_Checkbox.Checked = Settings.Default.LanguageChangeTag;
            Font_Checkbox.Checked = Settings.Default.FontAdditionTag;
        }

        private void exitPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            exitPictureBox.Image = Properties.Resources.ExitButtonPress;
        }

        private void exitPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            exitPictureBox.Image = Properties.Resources.ExitButton;
        }

        private void MinimizePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MinimizePictureBox.Image = Properties.Resources.MinimizeButtonPress;
        }

        private void MinimizePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            MinimizePictureBox.Image = Properties.Resources.MinimizeButton;
        }

        private void exitPictureBox_MouseEnter(object sender, EventArgs e)
        {
            exitPictureBox.Image = Properties.Resources.ExitButton;
        }

        private void MinimizePictureBox_MouseEnter(object sender, EventArgs e)
        {
            MinimizePictureBox.Image = Properties.Resources.MinimizeButton;
        }

        private void exitPictureBox_MouseLeave(object sender, EventArgs e)
        {
            exitPictureBox.Image = Properties.Resources.ExitButtonNoHover;
        }

        private void MinimizePictureBox_MouseLeave(object sender, EventArgs e)
        {
            MinimizePictureBox.Image = Properties.Resources.MinimizeButtonNoHover;
        }

        private void exitPictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizePictureBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void menuBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void browseButton_Load(object sender, EventArgs e)
        {

        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    wowLocationTextBox.Text = fbd.SelectedPath;
                }

            }
        }

        private void canc_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {


            // WoW Location Saving

            Settings.Default.WowLocation = wowLocationTextBox.Text;

            // Transparency Checkbox

            if (Transparent_Checkbox.Checked == true)
            {
                Settings.Default.TransparencyToggle = true;
            }
            if (Transparent_Checkbox.Checked == false)
            {
                Settings.Default.TransparencyToggle = false;
            }

            // WoW Cache CheckBox

            if (WoWCache_CheckBox.Checked)
            {
                Settings.Default.WoWCacheToggle = true;
            }
            else
            {
                Settings.Default.WoWCacheToggle = false;
            }

            // Language Change CheckBox

            if (Language_Checkbox.Checked)
            {
                Settings.Default.LanguageChangeTag = true;
            }
            else
            {
                Settings.Default.LanguageChangeTag = false;
            }

            //Font Installation CheckBox

            if (Font_Checkbox.Checked)
            {
                Settings.Default.FontAdditionTag = true;
            }
            else
            {
                Settings.Default.FontAdditionTag = false;
            }


            Settings.Default.Save();

            // Check if Fonts need to be installed and Installs Them
            if (Settings.Default.FontAdditionTag == true)
            {
                DialogResult dr1 = new DialogResult();
                dr1 = MessageBox.Show("Please accept the Following Font Windows by Clicking Install, Or Click Cancel to Stop Font Install", "IMPORTANT", MessageBoxButtons.OKCancel);
                if (dr1 == DialogResult.OK)
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/bin/etc/Fonts/DroidSans.ttf");
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/bin/etc/Fonts/DroidSans-Bold.ttf");
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/bin/etc/Fonts/GODOFWAR.ttf");
                    Settings.Default.Save();
                }
                if (dr1 == DialogResult.Cancel)
                {
                    Settings.Default.FontAdditionTag = false;
                    Settings.Default.Save();
                }

            }

            // Checks if The User Asks to Change Launguage
            // If so, Language Changer.exe is Launched

            if (Settings.Default.LanguageChangeTag == true)
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/bin/Launguage Changer.exe");
                WindowState = FormWindowState.Minimized;
                Application.Exit();
            }
            else
            {

            }

            Application.Restart();

        }
    }
}
