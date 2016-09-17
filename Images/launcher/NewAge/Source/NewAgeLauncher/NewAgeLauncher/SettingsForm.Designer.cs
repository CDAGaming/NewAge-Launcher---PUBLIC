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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.wowLocationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 106);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 27);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(534, 106);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(103, 27);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click_1);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(446, 42);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(85, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click_1);
            // 
            // wowLocationTextBox
            // 
            this.wowLocationTextBox.Location = new System.Drawing.Point(148, 42);
            this.wowLocationTextBox.Name = "wowLocationTextBox";
            this.wowLocationTextBox.ReadOnly = true;
            this.wowLocationTextBox.Size = new System.Drawing.Size(292, 20);
            this.wowLocationTextBox.TabIndex = 24;
            this.wowLocationTextBox.TextChanged += new System.EventHandler(this.wowLocationTextBox_TextChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 145);
            this.Controls.Add(this.wowLocationTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox wowLocationTextBox;
        private System.Windows.Forms.Label wowLocationLabel;
    }
}