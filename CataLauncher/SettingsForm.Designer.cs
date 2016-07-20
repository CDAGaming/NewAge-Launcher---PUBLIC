namespace NewAgeLauncher
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.canc_button = new System.Windows.Forms.PictureBox();
            this.save_button = new System.Windows.Forms.PictureBox();
            this.browse_button = new System.Windows.Forms.PictureBox();
            this.wowLocationTextBox = new System.Windows.Forms.TextBox();
            this.wowLocationLabel = new System.Windows.Forms.Label();
            this.MinimizePictureBox = new System.Windows.Forms.PictureBox();
            this.exitPictureBox = new System.Windows.Forms.PictureBox();
            this.menuBar1 = new NewAgeLauncher.MenuBar();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canc_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.Controls.Add(this.canc_button);
            this.mainPanel.Controls.Add(this.save_button);
            this.mainPanel.Controls.Add(this.browse_button);
            this.mainPanel.Controls.Add(this.wowLocationTextBox);
            this.mainPanel.Controls.Add(this.wowLocationLabel);
            this.mainPanel.Controls.Add(this.MinimizePictureBox);
            this.mainPanel.Controls.Add(this.exitPictureBox);
            this.mainPanel.Controls.Add(this.menuBar1);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(665, 184);
            this.mainPanel.TabIndex = 22;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // canc_button
            // 
            this.canc_button.Image = global::NewAgeLauncher.Properties.Resources.cancel;
            this.canc_button.Location = new System.Drawing.Point(12, 137);
            this.canc_button.Name = "canc_button";
            this.canc_button.Size = new System.Drawing.Size(98, 35);
            this.canc_button.TabIndex = 28;
            this.canc_button.TabStop = false;
            this.canc_button.Click += new System.EventHandler(this.canc_button_Click);
            // 
            // save_button
            // 
            this.save_button.Image = global::NewAgeLauncher.Properties.Resources.save;
            this.save_button.Location = new System.Drawing.Point(555, 137);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(98, 35);
            this.save_button.TabIndex = 27;
            this.save_button.TabStop = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // browse_button
            // 
            this.browse_button.Image = global::NewAgeLauncher.Properties.Resources.browse;
            this.browse_button.Location = new System.Drawing.Point(505, 71);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(96, 19);
            this.browse_button.TabIndex = 26;
            this.browse_button.TabStop = false;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // wowLocationTextBox
            // 
            this.wowLocationTextBox.Location = new System.Drawing.Point(206, 71);
            this.wowLocationTextBox.Name = "wowLocationTextBox";
            this.wowLocationTextBox.ReadOnly = true;
            this.wowLocationTextBox.Size = new System.Drawing.Size(292, 20);
            this.wowLocationTextBox.TabIndex = 23;
            // 
            // wowLocationLabel
            // 
            this.wowLocationLabel.AutoSize = true;
            this.wowLocationLabel.BackColor = System.Drawing.Color.Transparent;
            this.wowLocationLabel.ForeColor = System.Drawing.Color.White;
            this.wowLocationLabel.Location = new System.Drawing.Point(119, 71);
            this.wowLocationLabel.Name = "wowLocationLabel";
            this.wowLocationLabel.Size = new System.Drawing.Size(80, 13);
            this.wowLocationLabel.TabIndex = 22;
            this.wowLocationLabel.Text = "WoW Directory";
            // 
            // MinimizePictureBox
            // 
            this.MinimizePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizePictureBox.Image = global::NewAgeLauncher.Properties.Resources.MinimizeButtonNoHover;
            this.MinimizePictureBox.Location = new System.Drawing.Point(619, 5);
            this.MinimizePictureBox.Name = "MinimizePictureBox";
            this.MinimizePictureBox.Size = new System.Drawing.Size(19, 19);
            this.MinimizePictureBox.TabIndex = 21;
            this.MinimizePictureBox.TabStop = false;
            this.MinimizePictureBox.Click += new System.EventHandler(this.MinimizePictureBox_Click);
            this.MinimizePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizePictureBox_MouseDown);
            this.MinimizePictureBox.MouseEnter += new System.EventHandler(this.MinimizePictureBox_MouseEnter);
            this.MinimizePictureBox.MouseLeave += new System.EventHandler(this.MinimizePictureBox_MouseLeave);
            this.MinimizePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizePictureBox_MouseUp);
            // 
            // exitPictureBox
            // 
            this.exitPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPictureBox.Image = global::NewAgeLauncher.Properties.Resources.ExitButtonNoHover;
            this.exitPictureBox.Location = new System.Drawing.Point(642, 5);
            this.exitPictureBox.Name = "exitPictureBox";
            this.exitPictureBox.Size = new System.Drawing.Size(19, 19);
            this.exitPictureBox.TabIndex = 20;
            this.exitPictureBox.TabStop = false;
            this.exitPictureBox.Click += new System.EventHandler(this.exitPictureBox_Click);
            this.exitPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitPictureBox_MouseDown);
            this.exitPictureBox.MouseEnter += new System.EventHandler(this.exitPictureBox_MouseEnter);
            this.exitPictureBox.MouseLeave += new System.EventHandler(this.exitPictureBox_MouseLeave);
            this.exitPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.exitPictureBox_MouseUp);
            // 
            // menuBar1
            // 
            this.menuBar1.ButtonColor = System.Drawing.Color.White;
            this.menuBar1.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.MenuBarText = "Settings";
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(662, 32);
            this.menuBar1.TabIndex = 19;
            this.menuBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuBar1_MouseDown);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(665, 184);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(665, 184);
            this.MinimumSize = new System.Drawing.Size(665, 184);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canc_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MenuBar menuBar1;
        private System.Windows.Forms.PictureBox MinimizePictureBox;
        private System.Windows.Forms.PictureBox exitPictureBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label wowLocationLabel;
        private System.Windows.Forms.TextBox wowLocationTextBox;
        private System.Windows.Forms.PictureBox browse_button;
        private System.Windows.Forms.PictureBox save_button;
        private System.Windows.Forms.PictureBox canc_button;
    }
}