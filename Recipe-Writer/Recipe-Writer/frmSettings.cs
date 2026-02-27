/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.3</version>
/// <date>February 26th 2026</date>


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
        // Maps each button to its original image file path
        private readonly Dictionary<Button, string> _buttonOriginalImagePaths = new Dictionary<Button, string>();

        // Reference to the main form
        private readonly frmMain _frmMain;

        // Constructor that accepts the parent form
        public frmSettings(frmMain mainForm)
        {
            InitializeComponent();
            _frmMain = mainForm;
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



            // Sets the directory path for the resources folder, where all the button images are stored
            string resourcesDir = Path.Combine(Application.StartupPath, "Resources");

            // Sets the path for each button image by combining the resources directory path with the specific image filename
            string cmdCancelPath = Path.Combine(resourcesDir, "delete.png");
            string cmdValidatePath = Path.Combine(resourcesDir, "validate.png");

            // Assigns the background image to the button using the loaded paths
            cmdValidate.BackgroundImage = Image.FromFile(cmdValidatePath);

            // Fills the truth table that links the button to its original image path, 
            // for later restoration on mouse leave
            _buttonOriginalImagePaths[cmdValidate] = cmdValidatePath;

            // Button hover event
            cmdValidate.MouseEnter += _frmMain.Button_MouseEnter;
            cmdValidate.MouseLeave += _frmMain.Button_MouseLeave;
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