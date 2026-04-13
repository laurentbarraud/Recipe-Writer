/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 13th 2026</date>


using Recipe_Writer.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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

            // Form title
            this.Text = strings.Settings;

            // Label
            lblAppLanguage.Text = strings.AppLanguage;

            // Language ComboBox initialization
            string currentLanguageCode = Properties.Settings.Default.AppLanguageCode;

            var supportedLanguages = new List<LanguageItem>
            {
                new LanguageItem(strings.French,  "fr"),
                new LanguageItem(strings.English, "en"),
                new LanguageItem(strings.Spanish, "es")
            };

            cmbAppLanguage.DisplayMember = "DisplayName";
            cmbAppLanguage.ValueMember = "LanguageCode";
            cmbAppLanguage.DataSource = supportedLanguages;

            // Fallback used to avoid a crash if the language saved in settings
            // no longer exists in the list of languages displayed in the ComboBox.
            if (!supportedLanguages.Any(lang => lang.LanguageCode == currentLanguageCode))
            {
                currentLanguageCode = "en";
            }

            cmbAppLanguage.SelectedValue = currentLanguageCode;

            lblInfosLicence.Text = strings.LicenceInfo + "\n\n" +
                                   strings.LicenceVersion + "\n\n" +
                                   strings.LicenceAuthor;

            // Fade-in animation for the form
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