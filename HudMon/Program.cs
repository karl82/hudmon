using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HudMon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Do default configuration log4net
            log4net.Config.BasicConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Application.Run(new MainWindow(args[0]));
            }
            else
            {
                Application.Run(new MainWindow());
            }
        }
    }
}
