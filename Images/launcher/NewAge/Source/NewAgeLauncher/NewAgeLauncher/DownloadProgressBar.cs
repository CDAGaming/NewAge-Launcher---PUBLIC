using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewAgeLauncher
{
    public partial class DownloadProgressBar : UserControl
    {
        public DownloadProgressBar()
        {
            InitializeComponent();
        }

        public enum ProgressBarColor
        {
            Green,
            Blue,
            Red,
            Yellow
        }

        protected double percent = 0.0f;

        [Category("Behavior")]
        [DefaultValue(true)]
        public double Value
        {
            get
            {
                return percent;
            }

            set
            {

                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;

                percent = value;

                progressBarPictureBox.Size = new Size((int)((value / 100) * this.Width), this.Height);

                this.Invalidate();
            }
        }

        public void DownloadColor(ProgressBarColor color)
        {
            switch (color)
            {
                case ProgressBarColor.Green:

                    progressBarPictureBox.BackgroundImage = Properties.Resources.DownloadProgressBarGreen;

                    break;
            }
        }

    }
}
