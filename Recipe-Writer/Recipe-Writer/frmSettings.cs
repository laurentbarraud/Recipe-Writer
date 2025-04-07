/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 7th 2025</date>


using System;
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

        private void ApplyLanguage(string selectedLanguage)
        {
            var cultureInfo = new System.Globalization.CultureInfo(selectedLanguage);
            
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

                Application.Restart();
            }
        }
    }
}
