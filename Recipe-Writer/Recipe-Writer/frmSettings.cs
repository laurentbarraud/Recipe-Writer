/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 12th 2026</date>


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmSettings : Form
    { 
        // Reference to the main form
        private readonly frmMain _frmMain;

        /// <summary>
        /// Constructor with optional fade-in animation that accepts the parent form.
        /// </summary>
        public frmSettings(frmMain mainForm, bool enableFadeIn = false)
        {
            InitializeComponent();
            _frmMain = mainForm;

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";

            // Buttons hover event
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Language ComboBox initialization
            string currentLanguageCode = Properties.Settings.Default.AppLanguageCode;

            var languages = new List<LanguageItem>
            {
                new LanguageItem(strings.French,  "fr"),
                new LanguageItem(strings.English, "en")
            };

            cmbAppLanguage.DisplayMember = "DisplayName";
            cmbAppLanguage.ValueMember = "LanguageCode";
            cmbAppLanguage.DataSource = languages;
            cmbAppLanguage.SelectedValue = currentLanguageCode;

            // License info
            lblInfosLicence.Text = strings.LicenceInfo + "\n\n" +
                                   strings.LicenceVersion + "\n\n" +
                                   strings.LicenceAuthor;

            // Optional fade-in animation
            if (enableFadeIn)
            {
                this.Opacity = 0;

                System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
                fadeTimer.Interval = 25;

                fadeTimer.Tick += (s, e) =>
                {
                    if (this.Opacity < 1.0)
                    {
                        this.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                        fadeTimer.Dispose();
                    }
                };

                fadeTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Load event of the Settings form.
        /// Initializes the language selection ComboBox with localized display text bound to stable codes,
        /// selects the current application language based on saved settings,
        /// and updates the license information label.
        /// </summary>
        private void frmSettings_Load(object sender, EventArgs e)
        {
            string currentLanguageCode = Properties.Settings.Default.AppLanguageCode;

            var languages = new List<LanguageItem>
            {
                new LanguageItem(strings.French,  "fr"),
                new LanguageItem(strings.English, "en")
            };

            cmbAppLanguage.DisplayMember = "DisplayName";           // what the user sees
            cmbAppLanguage.ValueMember = "LanguageCode";            // stable internal value
            cmbAppLanguage.DataSource = languages;                  // binds the list
            cmbAppLanguage.SelectedValue = currentLanguageCode;     // selects current language

            lblInfosLicence.Text = strings.LicenceInfo + "\n\n" +
                                   strings.LicenceVersion + "\n\n" +
                                   strings.LicenceAuthor;
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
        /// Saves the new language setting, applies the culture immediately,
        /// recreates the main form, and reopens the Settings form with fade-in.
        /// </summary>
        private void cmbAppLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Ignore invalid selections
            if (cmbAppLanguage.SelectedValue == null)
            {
                return;
            }

            // Gets the selected language code from the ComboBox
            string selectedLanguageCode = cmbAppLanguage.SelectedValue.ToString();

            // Only proceeds if the language actually changed
            if (selectedLanguageCode != Properties.Settings.Default.AppLanguageCode)
            {
                Properties.Settings.Default.AppLanguageCode = selectedLanguageCode;
                Properties.Settings.Default.Save();

                // Applies culture
                CultureInfo culture = new CultureInfo(selectedLanguageCode);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                // Switches the main form
                frmMain newMain = new frmMain(enableFadeIn: true);
                Program.SwitchMainForm(newMain);

                // Reopens the Settings form on top with fade-in
                frmSettings settingsForm = new frmSettings(newMain, enableFadeIn: true);
                settingsForm.Show(newMain);
            }
        }
    }
}