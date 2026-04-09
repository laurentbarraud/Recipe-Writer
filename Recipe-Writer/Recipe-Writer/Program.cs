/// <file>Program.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 9th 2026</date>

using Recipe_Writer.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Recipe_Writer
{
    static class Program
    {
        public static ApplicationContext appContext;
        public static DBConnection DbConn;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplyLocalization();

            // Global DB connection
            DbConn = new DBConnection();

            // Ensures DB exists and is valid before any UI
            InitializeDatabase();

            // Launches the main form through an ApplicationContext
            appContext = new ApplicationContext(new frmMain());
            Application.Run(appContext);
        }

        private static void ApplyLocalization()
        {
            string lang = Settings.Default.AppLanguage;

            if (string.IsNullOrEmpty(lang))
            {
                string systemLang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                lang = (systemLang == "fr") ? "fr" : "en";
                Settings.Default.AppLanguage = lang;
                Settings.Default.Save();
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
        }

        private static void InitializeDatabase()
        {
            string dbPath = Path.Combine(Application.StartupPath, "recipe-album.db");

            if (!File.Exists(dbPath))
            {
                MessageBox.Show(strings.DBfileNotFound + "\n" + strings.DBWillBeBuiltWithInitialData,
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DbConn.CreateFile();
                DbConn.Open();
                DbConn.CreateTables();
                DbConn.InsertInitialData();
                return;
            }

            DbConn.Open();

            bool isDBValid = DbConn.CheckDBIntegrity();
            if (!isDBValid)
            {
                MessageBox.Show(strings.ErrorDatabaseCorrupted + "\n" + strings.DBWillBeBuiltWithInitialData,
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DbConn.CreateTables();
                DbConn.InsertInitialData();
            }
        }

        public static void SwitchMainForm(Form newForm)
        {
            Form oldForm = appContext.MainForm;
            appContext.MainForm = newForm;

            newForm.Show();
            oldForm.Close();
        }
    }
}
