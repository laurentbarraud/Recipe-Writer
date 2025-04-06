/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 6th 2025</date>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Set the selected value according to the setting
            string currentLanguage = Properties.Settings.Default.LanguageSetting;
            
            if (currentLanguage == "fr")
            {
                cmbAppLanguage.SelectedItem = "français";
            }

            else
            {
                cmbAppLanguage.SelectedItem = "English";
            }

            lblInfosLicence.Text = strings.LicenceInfo1 +
                "\r\n\r\n" + strings.LicenceInfo2 +
                "\r\n" + strings.LicenceInfo3 +
                "\r\n\r\n" + strings.LicenceInfo4 + "\n" +
                "\r\n\r\n\r\n" + strings.LicenceVersion + "\n" + strings.LicenceAuthor;
        }
        private void cmbAppLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedLanguage;
            
            if (cmbAppLanguage.SelectedItem.ToString() == "français" || cmbAppLanguage.SelectedItem.ToString() == "French")
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

                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(selectedLanguage);

                Application.Restart();
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
