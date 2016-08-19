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
            this.WoWCache_CheckBox = new System.Windows.Forms.CheckBox();
            this.Transparent_Checkbox = new System.Windows.Forms.CheckBox();
            this.canc_button = new System.Windows.Forms.PictureBox();
            this.save_button = new System.Windows.Forms.PictureBox();
            this.browse_button = new System.Windows.Forms.PictureBox();
            this.wowLocationTextBox = new System.Windows.Forms.TextBox();
            this.wowLocationLabel = new System.Windows.Forms.Label();
            this.menuBar1 = new NewAgeLauncher.MenuBar();
            this.exitPictureBox = new System.Windows.Forms.PictureBox();
            this.MinimizePictureBox = new System.Windows.Forms.PictureBox();
            this.Language_Checkbox = new System.Windows.Forms.CheckBox();
            this.Font_Checkbox = new System.Windows.Forms.CheckBox();
            this.Buglbl = new System.Windows.Forms.Label();
            this.RequestaFeaturelbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canc_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WoWCache_CheckBox
            // 
            resources.ApplyResources(this.WoWCache_CheckBox, "WoWCache_CheckBox");
            this.WoWCache_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.WoWCache_CheckBox.Checked = true;
            this.WoWCache_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WoWCache_CheckBox.ForeColor = System.Drawing.Color.White;
            this.WoWCache_CheckBox.Name = "WoWCache_CheckBox";
            this.WoWCache_CheckBox.UseVisualStyleBackColor = false;
            // 
            // Transparent_Checkbox
            // 
            resources.ApplyResources(this.Transparent_Checkbox, "Transparent_Checkbox");
            this.Transparent_Checkbox.BackColor = System.Drawing.Color.Transparent;
            this.Transparent_Checkbox.ForeColor = System.Drawing.Color.White;
            this.Transparent_Checkbox.Name = "Transparent_Checkbox";
            this.Transparent_Checkbox.UseVisualStyleBackColor = false;
            // 
            // canc_button
            // 
            this.canc_button.BackColor = System.Drawing.Color.Transparent;
            this.canc_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.canc_button.Image = global::NewAgeLauncher.Resources_ES.Cancel;
            resources.ApplyResources(this.canc_button, "canc_button");
            this.canc_button.Name = "canc_button";
            this.canc_button.TabStop = false;
            this.canc_button.Click += new System.EventHandler(this.canc_button_Click);
            // 
            // save_button
            // 
            this.save_button.BackColor = System.Drawing.Color.Transparent;
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.Image = global::NewAgeLauncher.Resources_ES.Save;
            resources.ApplyResources(this.save_button, "save_button");
            this.save_button.Name = "save_button";
            this.save_button.TabStop = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // browse_button
            // 
            this.browse_button.BackColor = System.Drawing.Color.Transparent;
            this.browse_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browse_button.Image = global::NewAgeLauncher.Resources_ES.Browse;
            resources.ApplyResources(this.browse_button, "browse_button");
            this.browse_button.Name = "browse_button";
            this.browse_button.TabStop = false;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // wowLocationTextBox
            // 
            this.wowLocationTextBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.wowLocationTextBox, "wowLocationTextBox");
            this.wowLocationTextBox.Name = "wowLocationTextBox";
            this.wowLocationTextBox.ReadOnly = true;
            // 
            // wowLocationLabel
            // 
            resources.ApplyResources(this.wowLocationLabel, "wowLocationLabel");
            this.wowLocationLabel.BackColor = System.Drawing.Color.Transparent;
            this.wowLocationLabel.ForeColor = System.Drawing.Color.White;
            this.wowLocationLabel.Name = "wowLocationLabel";
            // 
            // menuBar1
            // 
            this.menuBar1.BackColor = System.Drawing.Color.Transparent;
            this.menuBar1.ButtonColor = System.Drawing.Color.White;
            this.menuBar1.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            resources.ApplyResources(this.menuBar1, "menuBar1");
            this.menuBar1.MenuBarText = "Settings";
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuBar1_MouseDown);
            // 
            // exitPictureBox
            // 
            this.exitPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitPictureBox.Image = global::NewAgeLauncher.Properties.Resources.ExitButtonNoHover;
            resources.ApplyResources(this.exitPictureBox, "exitPictureBox");
            this.exitPictureBox.Name = "exitPictureBox";
            this.exitPictureBox.TabStop = false;
            this.exitPictureBox.Click += new System.EventHandler(this.exitPictureBox_Click);
            this.exitPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitPictureBox_MouseDown);
            this.exitPictureBox.MouseEnter += new System.EventHandler(this.exitPictureBox_MouseEnter);
            this.exitPictureBox.MouseLeave += new System.EventHandler(this.exitPictureBox_MouseLeave);
            this.exitPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.exitPictureBox_MouseUp);
            // 
            // MinimizePictureBox
            // 
            this.MinimizePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizePictureBox.Image = global::NewAgeLauncher.Properties.Resources.MinimizeButtonNoHover;
            resources.ApplyResources(this.MinimizePictureBox, "MinimizePictureBox");
            this.MinimizePictureBox.Name = "MinimizePictureBox";
            this.MinimizePictureBox.TabStop = false;
            this.MinimizePictureBox.Click += new System.EventHandler(this.MinimizePictureBox_Click);
            this.MinimizePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizePictureBox_MouseDown);
            this.MinimizePictureBox.MouseEnter += new System.EventHandler(this.MinimizePictureBox_MouseEnter);
            this.MinimizePictureBox.MouseLeave += new System.EventHandler(this.MinimizePictureBox_MouseLeave);
            this.MinimizePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MinimizePictureBox_MouseUp);
            // 
            // Language_Checkbox
            // 
            resources.ApplyResources(this.Language_Checkbox, "Language_Checkbox");
            this.Language_Checkbox.BackColor = System.Drawing.Color.Transparent;
            this.Language_Checkbox.ForeColor = System.Drawing.Color.White;
            this.Language_Checkbox.Name = "Language_Checkbox";
            this.Language_Checkbox.UseVisualStyleBackColor = false;
            // 
            // Font_Checkbox
            // 
            resources.ApplyResources(this.Font_Checkbox, "Font_Checkbox");
            this.Font_Checkbox.BackColor = System.Drawing.Color.Transparent;
            this.Font_Checkbox.ForeColor = System.Drawing.Color.White;
            this.Font_Checkbox.Name = "Font_Checkbox";
            this.Font_Checkbox.UseVisualStyleBackColor = false;
            // 
            // Buglbl
            // 
            resources.ApplyResources(this.Buglbl, "Buglbl");
            this.Buglbl.BackColor = System.Drawing.Color.Transparent;
            this.Buglbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Buglbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Buglbl.Name = "Buglbl";
            // 
            // RequestaFeaturelbl
            // 
            resources.ApplyResources(this.RequestaFeaturelbl, "RequestaFeaturelbl");
            this.RequestaFeaturelbl.BackColor = System.Drawing.Color.Transparent;
            this.RequestaFeaturelbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RequestaFeaturelbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.RequestaFeaturelbl.Name = "RequestaFeaturelbl";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::NewAgeLauncher.Properties.Resources.BG;
            this.Controls.Add(this.Buglbl);
            this.Controls.Add(this.RequestaFeaturelbl);
            this.Controls.Add(this.Font_Checkbox);
            this.Controls.Add(this.Language_Checkbox);
            this.Controls.Add(this.exitPictureBox);
            this.Controls.Add(this.MinimizePictureBox);
            this.Controls.Add(this.canc_button);
            this.Controls.Add(this.WoWCache_CheckBox);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.Transparent_Checkbox);
            this.Controls.Add(this.menuBar1);
            this.Controls.Add(this.wowLocationLabel);
            this.Controls.Add(this.wowLocationTextBox);
            this.Controls.Add(this.browse_button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canc_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuBar menuBar1;
        private System.Windows.Forms.Label wowLocationLabel;
        private System.Windows.Forms.TextBox wowLocationTextBox;
        private System.Windows.Forms.PictureBox browse_button;
        private System.Windows.Forms.PictureBox save_button;
        private System.Windows.Forms.PictureBox canc_button;
        private System.Windows.Forms.CheckBox Transparent_Checkbox;
        private System.Windows.Forms.CheckBox WoWCache_CheckBox;
        private System.Windows.Forms.PictureBox exitPictureBox;
        private System.Windows.Forms.PictureBox MinimizePictureBox;
        private System.Windows.Forms.CheckBox Language_Checkbox;
        private System.Windows.Forms.CheckBox Font_Checkbox;
        private System.Windows.Forms.Label Buglbl;
        private System.Windows.Forms.Label RequestaFeaturelbl;
    }
}