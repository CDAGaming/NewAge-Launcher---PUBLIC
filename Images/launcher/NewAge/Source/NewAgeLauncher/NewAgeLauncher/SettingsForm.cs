using NewAgeLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            wowLocationTextBox.Text = Settings.Default.WowLocation;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void okButton_Click(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void browseButton_Load(object sender, EventArgs e)
        {

        }

        private void browseButton_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    wowLocationTextBox.Text = fbd.SelectedPath;
                }

            }

        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            Settings.Default.WowLocation = wowLocationTextBox.Text;
            Settings.Default.Save();

            this.Close();

        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wowLocationTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
