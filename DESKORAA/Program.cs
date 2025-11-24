using System;
using System.Windows.Forms;

namespace DESKORAA
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmlogin());
            Application.Run(new frmUserView());
        }
    }
}
