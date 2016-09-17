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
    public partial class DownloadBar : UserControl
    {
        public DownloadBar()
        {
            InitializeComponent();
        }


        public enum DownloadBarState
        {
            Setup,
            Available,
            Playable
        }

        protected double percent = 0.0f;

        [Category("Download Bar Properties")]
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

                this.Invalidate();
            }
        }

        protected DownloadBarState dBarState = DownloadBarState.Setup;

        [Category("Download Bar Properties")]
        public DownloadBarState BarState
        {
            get
            {
                return dBarState;
            }
            set
            {
                dBarState = value;

                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            switch (dBarState)
            {
                case DownloadBarState.Setup:
                    g.DrawImage(Properties.Resources.dbar_setup, 0, 0);
                    g.DrawImage(Properties.Resources.red_progressbar, 5, 35, (int)((Value / 100) * this.Width), 10);
                    break;

                case DownloadBarState.Available:
                    g.DrawImage(Properties.Resources.dbar_available, 0, 0);
                    g.DrawImage(Properties.Resources.yellow_progressbar, 5, 35, (int)((Value / 100) * this.Width), 10);
                    break;

                case DownloadBarState.Playable:
                    g.DrawImage(Properties.Resources.dbar_playable, 0, 0);
                    g.DrawImage(Properties.Resources.DownloadProgressBarGreen, 5, 35, (int)((Value / 100) * this.Width), 10);
                    break;
            }
        }

        private void DownloadBar_Load(object sender, EventArgs e)
        {

        }
    }
}
