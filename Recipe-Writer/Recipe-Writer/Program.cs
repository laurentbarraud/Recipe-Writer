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
            // If the application is launched for the first time
            if (string.IsNullOrEmpty(Properties.Settings.Default.AppLanguage))
            {
                // Detects system language and apply default setting
                string systemLanguage = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                Properties.Settings.Default.AppLanguage = (systemLanguage == "fr") ? "fr" : "en";

                // Saves the setting for persistence
                Properties.Settings.Default.Save();
            }

            // Applies the detected or saved language globally
            var cultureInfoToApply = new System.Globalization.CultureInfo(Properties.Settings.Default.AppLanguage);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfoToApply;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfoToApply;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
