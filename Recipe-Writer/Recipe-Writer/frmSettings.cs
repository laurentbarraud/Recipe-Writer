/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>December 7th 2025</date>


using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            string currentLanguage = Properties.Settings.Default.LanguageSetting;

            if (Properties.Settings.Default.LanguageSetting == "fr")
            {
                cmbAppLanguage.Items.Clear();
                cmbAppLanguage.Items.Add("français");
                cmbAppLanguage.Items.Add("anglais");

                cmbAppLanguage.SelectedItem = "français";
            }

            else
            {
                cmbAppLanguage.Items.Clear();
                cmbAppLanguage.Items.Add("English");
                cmbAppLanguage.Items.Add("French");

                cmbAppLanguage.SelectedItem = "English";
            }

            lblInfosLicence.Text = strings.LicenceInfo1 +
                "\r\n\r\n" + strings.LicenceInfo2 +
                "\r\n" + strings.LicenceInfo3 +
                "\r\n\r\n" + strings.LicenceInfo4 + "\n" +
                "\r\n" + strings.LicenceVersion + "\n" + strings.LicenceAuthor;
        }
        /// <summary>
        /// Applies the specified language to the current application thread.
        /// This sets both the culture and the UI culture, ensuring that
        /// localized resources (such as strings, dates, and formatting)
        /// are displayed according to the selected language.
        /// It then refreshes all open forms (including frmMain) with the new culture,
        /// disabling AutoScale to avoid DPI issues.
        /// </summary>
        /// <param name="selectedLanguage">
        /// The language code to apply (e.g., "fr" for French, "en" for English).
        /// </param>
        private void ApplyLanguage(string selectedLanguage)
        {
            var cultureInfo = new System.Globalization.CultureInfo(selectedLanguage);

            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Refreshes all open forms with the new culture
            foreach (Form form in Application.OpenForms)
            {
                // Disables autoscaling to prevent DPI enlargement
                form.AutoScaleMode = AutoScaleMode.None;

                var resources = new ComponentResourceManager(form.GetType());

                // Relocalizes all direct controls
                foreach (Control ctrl in form.Controls)
                {
                    ApplyResourcesRecursively(ctrl, resources, cultureInfo);
                }

                lblInfosLicence.Text = strings.LicenceInfo1 +
                "\r\n\r\n" + strings.LicenceInfo2 +
                "\r\n" + strings.LicenceInfo3 +
                "\r\n\r\n" + strings.LicenceInfo4 + "\n" +
                "\r\n" + strings.LicenceVersion + "\n" + strings.LicenceAuthor;

                // Handles TabPages separately
                foreach (TabControl tabControl in form.Controls.OfType<TabControl>())
                {
                    foreach (TabPage tab in tabControl.TabPages)
                    {
                        resources.ApplyResources(tab, tab.Name, cultureInfo);
                        foreach (Control child in tab.Controls)
                        {
                            ApplyResourcesRecursively(child, resources, cultureInfo);
                        }
                    }
                }

                form.Invalidate(); // force redraw without scaling
            }
        }

        /// <summary>
        /// Recursively applies localized resources to a control and its children.
        /// </summary>
        /// <param name="control">The control to update.</param>
        /// <param name="resources">The resource manager for the control's type.</param>
        /// <param name="culture">The culture to apply.</param>
        private void ApplyResourcesRecursively(Control control, ComponentResourceManager resources, CultureInfo culture)
        {
            resources.ApplyResources(control, control.Name, culture);

            foreach (Control child in control.Controls)
            {
                ApplyResourcesRecursively(child, resources, culture);
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the language selection change in the ComboBox.
        /// If the selected language differs from the current setting,
        /// the new language is saved and applied immediately to all open forms,
        /// forcing them to refresh their localized resources.
        /// </summary>
        /// <param name="sender">The ComboBox control that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void cmbAppLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAppLanguage.SelectedItem == null) return;

            string selectedLanguageItem = cmbAppLanguage.SelectedItem.ToString();
            string selectedLanguage;

            if (selectedLanguageItem == "français" || selectedLanguageItem == "French")
            {
                selectedLanguage = "fr";
            }

            else
            {
                selectedLanguage = "en";
            }

            if (selectedLanguage != Properties.Settings.Default.LanguageSetting)
            {
                Properties.Settings.Default.LanguageSetting = selectedLanguage;
                Properties.Settings.Default.Save();

                ApplyLanguage(selectedLanguage);
            }
        }
    }
}
