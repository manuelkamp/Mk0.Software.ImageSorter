using System;
using Microsoft.VisualBasic.ApplicationServices;

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
            App myApp = new App();
            myApp.Run(args);
        }

        class App : WindowsFormsApplicationBase
        {
            public App()
            {
                IsSingleInstance = Properties.Settings.Default.singleInstance;
                EnableVisualStyles = true;

                ShutdownStyle = ShutdownMode.AfterMainFormCloses;
                StartupNextInstance += new StartupNextInstanceEventHandler(SIApp_StartupNextInstance);
            }

            protected override void OnCreateMainForm()
            {
                MainForm = new Main();
                ((Main)MainForm).Args = new string[CommandLineArgs.Count];
                CommandLineArgs.CopyTo(((Main)MainForm).Args, 0);
            }

            protected void SIApp_StartupNextInstance(object sender, StartupNextInstanceEventArgs eventArgs)
            {
                string[] args = new string[eventArgs.CommandLine.Count];
                eventArgs.CommandLine.CopyTo(args, 0);

                object[] parameters = new object[2];
                parameters[0] = MainForm;
                parameters[1] = args;

                MainForm.Invoke(new Main.ProcessParametersDelegate(((Main)MainForm).ProcessParameters), parameters);
            }
        }
    }
}
