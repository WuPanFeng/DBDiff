using System;
using System.Windows.Forms;
using DBDiff.Front;

namespace DBDiff
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //new Sunisoft.IrisSkin.SkinEngine().SkinFile = "skins/Calmness.ssk";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PrincipalForm());
        }
    }
}
