namespace Mk0.Software.ImageSorter
{
    partial class Cropper
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
            this.rubberBand1 = new Mk0.Tools.ImageCropper.RubberBand();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rubberBand1
            // 
            this.rubberBand1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rubberBand1.Disabled = false;
            this.rubberBand1.Image = null;
            this.rubberBand1.Location = new System.Drawing.Point(12, 25);
            this.rubberBand1.Name = "rubberBand1";
            this.rubberBand1.Size = new System.Drawing.Size(776, 527);
            this.rubberBand1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rubberBand1.TabIndex = 0;
            this.rubberBand1.ImageCropped += new System.EventHandler(this.RubberBand1_ImageCropped);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mit der Maus einen Rahmen ziehen. Dieser ist veränderbar. Doppelklick im Rahmen s" +
    "peichert den Zuschnitt. Klick außerhalb bricht den Zuschneide-Vorgang ab.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Cropper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rubberBand1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 603);
            this.Name = "Cropper";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bild zuschneiden";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cropper_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Mk0.Tools.ImageCropper.RubberBand rubberBand1;
        private System.Windows.Forms.Label label1;
    }
}