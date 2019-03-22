using System;
using System.Windows.Forms;
using Mk0.Tools.SingleInstance;

namespace Mk0.Software.ImageSorter
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleApplication.Run(args.Length == 0 ? new Main(string.Empty) : new Main(args[0]), Mk0.Software.ImageSorter.Properties.Settings.Default.singleInstance);
        }
    }
}
