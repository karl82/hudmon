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
            if (args.Length == 0)
            {
                MessageBox.Show("Missing URL of Hudson server\nUsage: HudMon.exe <URL>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args[0]));
        }
    }
}
