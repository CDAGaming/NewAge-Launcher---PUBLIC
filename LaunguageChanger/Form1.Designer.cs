namespace LaunguageChanger
{
    partial class TitleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LaunguageTitleLabel = new System.Windows.Forms.Label();
            this.Startlbl = new System.Windows.Forms.Label();
            this.Progresslbl = new System.Windows.Forms.ProgressBar();
            this.LabelStep1 = new System.Windows.Forms.Label();
            this.LabelStep2 = new System.Windows.Forms.Label();
            this.LabelStep3 = new System.Windows.Forms.Label();
            this.lblprogress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LaunguageTitleLabel
            // 
            this.LaunguageTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LaunguageTitleLabel.Location = new System.Drawing.Point(85, 9);
            this.LaunguageTitleLabel.Name = "LaunguageTitleLabel";
            this.LaunguageTitleLabel.Size = new System.Drawing.Size(215, 17);
            this.LaunguageTitleLabel.TabIndex = 0;
            this.LaunguageTitleLabel.Text = "Changing Launguage";
            this.LaunguageTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Startlbl
            // 
            this.Startlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Startlbl.Location = new System.Drawing.Point(24, 35);
            this.Startlbl.Name = "Startlbl";
            this.Startlbl.Size = new System.Drawing.Size(346, 17);
            this.Startlbl.TabIndex = 1;
            this.Startlbl.Text = "(Launguage A) to (Launguage B)";
            this.Startlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Startlbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // Progresslbl
            // 
            this.Progresslbl.Location = new System.Drawing.Point(24, 91);
            this.Progresslbl.Name = "Progresslbl";
            this.Progresslbl.Size = new System.Drawing.Size(346, 31);
            this.Progresslbl.TabIndex = 2;
            // 
            // LabelStep1
            // 
            this.LabelStep1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LabelStep1.ForeColor = System.Drawing.Color.Red;
            this.LabelStep1.Location = new System.Drawing.Point(12, 125);
            this.LabelStep1.Name = "LabelStep1";
            this.LabelStep1.Size = new System.Drawing.Size(128, 27);
            this.LabelStep1.TabIndex = 3;
            this.LabelStep1.Text = "Downloading";
            this.LabelStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelStep2
            // 
            this.LabelStep2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LabelStep2.ForeColor = System.Drawing.Color.Red;
            this.LabelStep2.Location = new System.Drawing.Point(133, 125);
            this.LabelStep2.Name = "LabelStep2";
            this.LabelStep2.Size = new System.Drawing.Size(127, 27);
            this.LabelStep2.TabIndex = 4;
            this.LabelStep2.Text = "Patching";
            this.LabelStep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelStep3
            // 
            this.LabelStep3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LabelStep3.ForeColor = System.Drawing.Color.Red;
            this.LabelStep3.Location = new System.Drawing.Point(254, 125);
            this.LabelStep3.Name = "LabelStep3";
            this.LabelStep3.Size = new System.Drawing.Size(127, 27);
            this.LabelStep3.TabIndex = 5;
            this.LabelStep3.Text = "Completed";
            this.LabelStep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblprogress
            // 
            this.lblprogress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblprogress.Location = new System.Drawing.Point(21, 71);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(346, 17);
            this.lblprogress.TabIndex = 6;
            this.lblprogress.Text = "(Launguage A) to (Launguage B)";
            this.lblprogress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 178);
            this.Controls.Add(this.lblprogress);
            this.Controls.Add(this.LabelStep3);
            this.Controls.Add(this.LabelStep2);
            this.Controls.Add(this.LabelStep1);
            this.Controls.Add(this.Progresslbl);
            this.Controls.Add(this.Startlbl);
            this.Controls.Add(this.LaunguageTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TitleForm";
            this.Text = "Launguage Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LaunguageTitleLabel;
        private System.Windows.Forms.Label Startlbl;
        private System.Windows.Forms.ProgressBar Progresslbl;
        private System.Windows.Forms.Label LabelStep1;
        private System.Windows.Forms.Label LabelStep2;
        private System.Windows.Forms.Label LabelStep3;
        private System.Windows.Forms.Label lblprogress;
    }
}

