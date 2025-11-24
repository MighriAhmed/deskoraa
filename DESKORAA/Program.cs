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
            frmMain mainForm = new frmMain();
            frmUserView userView = new frmUserView();
            mainForm.AddControls(userView);
            Application.Run(mainForm);
        }
    }
}
