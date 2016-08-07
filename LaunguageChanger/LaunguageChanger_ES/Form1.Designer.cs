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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleForm));
            this.LaunguageTitleLabel = new System.Windows.Forms.Label();
            this.Startlbl = new System.Windows.Forms.Label();
            this.Progresslbl = new System.Windows.Forms.ProgressBar();
            this.LabelStep1 = new System.Windows.Forms.Label();
            this.LabelStep2 = new System.Windows.Forms.Label();
            this.LabelStep3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LaunguageTitleLabel
            // 
            resources.ApplyResources(this.LaunguageTitleLabel, "LaunguageTitleLabel");
            this.LaunguageTitleLabel.Name = "LaunguageTitleLabel";
            // 
            // Startlbl
            // 
            resources.ApplyResources(this.Startlbl, "Startlbl");
            this.Startlbl.Name = "Startlbl";
            this.Startlbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // Progresslbl
            // 
            resources.ApplyResources(this.Progresslbl, "Progresslbl");
            this.Progresslbl.Name = "Progresslbl";
            // 
            // LabelStep1
            // 
            resources.ApplyResources(this.LabelStep1, "LabelStep1");
            this.LabelStep1.ForeColor = System.Drawing.Color.Red;
            this.LabelStep1.Name = "LabelStep1";
            // 
            // LabelStep2
            // 
            resources.ApplyResources(this.LabelStep2, "LabelStep2");
            this.LabelStep2.ForeColor = System.Drawing.Color.Red;
            this.LabelStep2.Name = "LabelStep2";
            // 
            // LabelStep3
            // 
            resources.ApplyResources(this.LabelStep3, "LabelStep3");
            this.LabelStep3.ForeColor = System.Drawing.Color.Red;
            this.LabelStep3.Name = "LabelStep3";
            // 
            // TitleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelStep3);
            this.Controls.Add(this.LabelStep2);
            this.Controls.Add(this.LabelStep1);
            this.Controls.Add(this.Progresslbl);
            this.Controls.Add(this.Startlbl);
            this.Controls.Add(this.LaunguageTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TitleForm";
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
    }
}

