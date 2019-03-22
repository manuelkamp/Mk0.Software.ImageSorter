using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Mk0.Software.ImageSorter
{
    public partial class Cropper : Form
    {
        private string imageLocation;
        internal string NewFileLocation;

        private Image img, cropped;

        public Cropper(string imageLocation)
        {
            InitializeComponent();
            this.imageLocation = imageLocation;
            img = Image.FromFile(imageLocation);
            rubberBand1.Image = img;
        }

        private void RubberBand1_ImageCropped(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(imageLocation);
            string file = Path.GetFileNameWithoutExtension(imageLocation) + "_crp";
            string ext = Path.GetExtension(imageLocation);
            NewFileLocation = Path.Combine(folder, file + ext);

            cropped = rubberBand1.SelectedImage;

            if (ext == ".png")
            {
                cropped.Save(NewFileLocation, ImageFormat.Png);
            }
            else if (ext == ".gif")
            {
                cropped.Save(NewFileLocation, ImageFormat.Gif);
            }
            else
            {
                cropped.Save(NewFileLocation, ImageFormat.Jpeg);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cropper_FormClosing(object sender, FormClosingEventArgs e)
        {
            img.Dispose();
        }
    }
}
