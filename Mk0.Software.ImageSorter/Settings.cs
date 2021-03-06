﻿using System;
using System.Windows.Forms;

namespace Mk0.Software.ImageSorter
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.targetPath))
            {
                labelTargetPath.Text = Properties.Settings.Default.targetPath;
            }
            else
            {
                labelTargetPath.Text = Application.StartupPath;
                Properties.Settings.Default.targetPath = Application.StartupPath;
                Properties.Settings.Default.Save();
            }
            checkBoxSingleInstance.Checked = Properties.Settings.Default.singleInstance;
            checkBoxFileAssociation.Checked = Properties.Settings.Default.fileAssociation;
            checkBoxFading.Checked = Properties.Settings.Default.fading;
            trackBarFadingSpeed.Value = Properties.Settings.Default.fadingSpeed;
        }

        private void ButtonChangeTargetPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Properties.Settings.Default.targetPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
            labelTargetPath.Text = Properties.Settings.Default.targetPath;
        }

        private void CheckBoxSingleInstance_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.singleInstance = checkBoxSingleInstance.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBoxFileAssociation_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.fileAssociation = checkBoxFileAssociation.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBoxFading_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.fading = checkBoxFading.Checked;
            trackBarFadingSpeed.Enabled = checkBoxFading.Checked;
            label6.Enabled = checkBoxFading.Checked;
            label7.Enabled = checkBoxFading.Checked;
            label8.Enabled = checkBoxFading.Checked;
            Properties.Settings.Default.Save();
        }

        private void TrackBarFadingSpeed_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.fadingSpeed = trackBarFadingSpeed.Value;
        }
    }
}
