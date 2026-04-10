/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 10th 2026</date>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmSettings : Form
    { 
        // Reference to the main form
        private readonly frmMain _frmMain;

        // Constructor that accepts the parent form
        public frmSettings(frmMain mainForm)
        {
            InitializeComponent();
            _frmMain = mainForm;

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";

            // Buttons hover event
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;
        }

        /// <summary>
        /// Handles the Load event of the Settings form.
        /// Initializes the language selection ComboBox with localized display text bound to stable codes,
        /// selects the current application language based on saved settings,
        /// and updates the license information label.
        /// </summary>
        private void frmSettings_Load(object sender, EventArgs e)
        {
            string currentLanguageCode = Properties.Settings.Default.AppLanguage;

            var languages = new[]
            {
                new { Text = strings.French,  Code = "fr" },
                new { Text = strings.English, Code = "en" }
            };

            cmbAppLanguage.DisplayMember = "Text";   // what the user sees
            cmbAppLanguage.ValueMember = "Code";     // stable internal value
            cmbAppLanguage.DataSource = languages;   // binds the list

            cmbAppLanguage.SelectedValue = currentLanguageCode; // selects current language

            lblInfosLicence.Text = strings.LicenceInfo + "\n\n" +
                                   strings.LicenceVersion + "\n\n" +
                                   strings.LicenceAuthor;

            // Button hover event
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdValidate_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cmdValidate_MouseLeave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the language selection change committed by the user.
        /// Saves the new language setting and restarts the application
        /// so that all forms reload with the updated culture.
        /// </summary>
        private void cmbAppLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbAppLanguage.SelectedValue == null)
            {
                return;
            }

            string selectedLanguageCode = cmbAppLanguage.SelectedValue.ToString();

            if (selectedLanguageCode != Properties.Settings.Default.AppLanguage)
            {
                Properties.Settings.Default.AppLanguage = selectedLanguageCode;
                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }
    }
}