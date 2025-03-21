﻿/// <file>Program.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 20th 2025</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
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
