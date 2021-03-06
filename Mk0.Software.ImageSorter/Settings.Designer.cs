﻿namespace Mk0.Software.ImageSorter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.checkBoxSingleInstance = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChangeTargetPath = new System.Windows.Forms.Button();
            this.labelTargetPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBoxFileAssociation = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarFadingSpeed = new System.Windows.Forms.TrackBar();
            this.checkBoxFading = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFadingSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxSingleInstance
            // 
            this.checkBoxSingleInstance.AutoSize = true;
            this.checkBoxSingleInstance.Checked = true;
            this.checkBoxSingleInstance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSingleInstance.Location = new System.Drawing.Point(9, 54);
            this.checkBoxSingleInstance.Name = "checkBoxSingleInstance";
            this.checkBoxSingleInstance.Size = new System.Drawing.Size(136, 17);
            this.checkBoxSingleInstance.TabIndex = 0;
            this.checkBoxSingleInstance.Text = "Einzelinstanz aktivieren";
            this.checkBoxSingleInstance.UseVisualStyleBackColor = true;
            this.checkBoxSingleInstance.CheckedChanged += new System.EventHandler(this.CheckBoxSingleInstance_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zielpfad:";
            // 
            // buttonChangeTargetPath
            // 
            this.buttonChangeTargetPath.Location = new System.Drawing.Point(9, 71);
            this.buttonChangeTargetPath.Name = "buttonChangeTargetPath";
            this.buttonChangeTargetPath.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeTargetPath.TabIndex = 2;
            this.buttonChangeTargetPath.Text = "Ändern";
            this.buttonChangeTargetPath.UseVisualStyleBackColor = true;
            this.buttonChangeTargetPath.Click += new System.EventHandler(this.ButtonChangeTargetPath_Click);
            // 
            // labelTargetPath
            // 
            this.labelTargetPath.AutoSize = true;
            this.labelTargetPath.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelTargetPath.Location = new System.Drawing.Point(64, 49);
            this.labelTargetPath.Name = "labelTargetPath";
            this.labelTargetPath.Size = new System.Drawing.Size(120, 13);
            this.labelTargetPath.TabIndex = 3;
            this.labelTargetPath.Text = "<kein Zielpfad gewählt>";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 133);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.checkBoxSingleInstance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 107);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Einzelinstanz";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.labelTargetPath);
            this.tabPage2.Controls.Add(this.buttonChangeTargetPath);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 107);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zielpfad";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(489, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBoxFileAssociation);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(498, 107);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dateizuordnung";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileAssociation
            // 
            this.checkBoxFileAssociation.AutoSize = true;
            this.checkBoxFileAssociation.Location = new System.Drawing.Point(8, 56);
            this.checkBoxFileAssociation.Name = "checkBoxFileAssociation";
            this.checkBoxFileAssociation.Size = new System.Drawing.Size(150, 17);
            this.checkBoxFileAssociation.TabIndex = 1;
            this.checkBoxFileAssociation.Text = "Dateizuordnung aktivieren";
            this.checkBoxFileAssociation.UseVisualStyleBackColor = true;
            this.checkBoxFileAssociation.CheckedChanged += new System.EventHandler(this.CheckBoxFileAssociation_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(490, 39);
            this.label4.TabIndex = 0;
            this.label4.Text = "Wenn sie die Dateizuordnung aktivieren, werden Bildtypen mit ImageSorter verbunde" +
    "n. Sie können dann Bilder mittels Doppelklick bzw. rechter Maustaste \"Öffnen mit" +
    "...\" mit dem ImageSorter direkt öffnen.";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.trackBarFadingSpeed);
            this.tabPage4.Controls.Add(this.checkBoxFading);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(498, 107);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Fading";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(114, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Langsam";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(450, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Schnell";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(249, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fading-Geschwindigkeit";
            // 
            // trackBarFadingSpeed
            // 
            this.trackBarFadingSpeed.Enabled = false;
            this.trackBarFadingSpeed.LargeChange = 3;
            this.trackBarFadingSpeed.Location = new System.Drawing.Point(170, 56);
            this.trackBarFadingSpeed.Minimum = 1;
            this.trackBarFadingSpeed.Name = "trackBarFadingSpeed";
            this.trackBarFadingSpeed.Size = new System.Drawing.Size(274, 45);
            this.trackBarFadingSpeed.TabIndex = 2;
            this.trackBarFadingSpeed.Value = 1;
            this.trackBarFadingSpeed.Scroll += new System.EventHandler(this.TrackBarFadingSpeed_Scroll);
            // 
            // checkBoxFading
            // 
            this.checkBoxFading.AutoSize = true;
            this.checkBoxFading.Location = new System.Drawing.Point(9, 40);
            this.checkBoxFading.Name = "checkBoxFading";
            this.checkBoxFading.Size = new System.Drawing.Size(107, 17);
            this.checkBoxFading.TabIndex = 1;
            this.checkBoxFading.Text = "Fading aktivieren";
            this.checkBoxFading.UseVisualStyleBackColor = true;
            this.checkBoxFading.CheckedChanged += new System.EventHandler(this.CheckBoxFading_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(486, 34);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mit Fading wird eine farbliche markierung von zuletzt gedrückten Ziel-Buttons akt" +
    "iviert. Die Geschwindigkeit regelt, wie schnell diese Markierung wieder verblass" +
    "t.";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 157);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageSorter | Einstellungen";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFadingSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSingleInstance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChangeTargetPath;
        private System.Windows.Forms.Label labelTargetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxFileAssociation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TrackBar trackBarFadingSpeed;
        private System.Windows.Forms.CheckBox checkBoxFading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}