/// <file>Program.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>December 7th 2025</date>

using System;
using System.Windows.Forms;

namespace Recipe_Writer
{
    static class Program
    {
        /// <summary>
        /// Main entry-point of the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmMain _frmMain = new frmMain();
            Application.Run(_frmMain);
        }
    }
}
