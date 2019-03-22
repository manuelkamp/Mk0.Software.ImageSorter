using Mk0.Tools.Calculation;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mk0.Software.ImageSorter
{
    public partial class Vergleicher : Form
    {
        public Vergleicher(string text, string img1, string img2)
        {
            InitializeComponent();
            label1.Text = text;
            pictureBox1.ImageLocation = img1;
            pictureBox2.ImageLocation = img2;
            double quellsize = new FileInfo(img1).Length;
            double zielsize = new FileInfo(img2).Length;
            labelquellinfo.Text = FileSize.GetFileSize(quellsize) + "; " + new FileInfo(img1).LastWriteTime;
            labelzielinfo.Text = FileSize.GetFileSize(zielsize) + "; " + new FileInfo(img2).LastWriteTime;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
