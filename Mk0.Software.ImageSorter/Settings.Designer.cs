namespace Mk0.Software.ImageSorter
{
    partial class Settings
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
            this.checkBoxSingleInstance = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTargetPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // checkBoxSingleInstance
            // 
            this.checkBoxSingleInstance.AutoSize = true;
            this.checkBoxSingleInstance.Checked = true;
            this.checkBoxSingleInstance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSingleInstance.Location = new System.Drawing.Point(12, 12);
            this.checkBoxSingleInstance.Name = "checkBoxSingleInstance";
            this.checkBoxSingleInstance.Size = new System.Drawing.Size(366, 17);
            this.checkBoxSingleInstance.TabIndex = 0;
            this.checkBoxSingleInstance.Text = "SingleInstance - ImageSorter kann nur ein Mal gleichzeitig geöffnet sein.";
            this.checkBoxSingleInstance.UseVisualStyleBackColor = true;
            this.checkBoxSingleInstance.CheckedChanged += new System.EventHandler(this.CheckBoxSingleInstance_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ziel-Pfad:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ändern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // labelTargetPath
            // 
            this.labelTargetPath.AutoSize = true;
            this.labelTargetPath.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelTargetPath.Location = new System.Drawing.Point(67, 40);
            this.labelTargetPath.Name = "labelTargetPath";
            this.labelTargetPath.Size = new System.Drawing.Size(120, 13);
            this.labelTargetPath.TabIndex = 3;
            this.labelTargetPath.Text = "<kein Zielpfad gewählt>";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 96);
            this.Controls.Add(this.labelTargetPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxSingleInstance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageSorter | Einstellungen";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSingleInstance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTargetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}