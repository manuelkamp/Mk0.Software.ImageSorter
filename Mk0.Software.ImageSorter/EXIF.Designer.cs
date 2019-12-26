namespace Mk0.Software.ImageSorter
{
    partial class EXIF
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
            this.treeViewExif = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewExif
            // 
            this.treeViewExif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewExif.Location = new System.Drawing.Point(12, 12);
            this.treeViewExif.Name = "treeViewExif";
            this.treeViewExif.Size = new System.Drawing.Size(343, 367);
            this.treeViewExif.TabIndex = 1;
            // 
            // EXIF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 391);
            this.Controls.Add(this.treeViewExif);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EXIF";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "EXIF";
            this.Shown += new System.EventHandler(this.EXIF_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewExif;
    }
}