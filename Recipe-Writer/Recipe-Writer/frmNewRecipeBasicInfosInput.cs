/// <file>frmNewRecipeInfosInput.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2</version>
/// <date>April 6th 2025</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmNewRecipeInfosInput : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewRecipeInfosInput(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdDelete] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";

            // Buttons hover event
            cmdDelete.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdDelete.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Title
            string windowTitle = strings.EnterBasicInfoForNewRecipe;

            if (!string.IsNullOrEmpty(windowTitle))
            {
                this.Text = windowTitle;
            }

            // Labels
            lblRecipeTitle.Text = strings.Title;
            lblRecipeLanguage.Text = strings.RecipeLanguage;
            lblRecipeCompletionTime.Text = strings.CompletionTime;
            lblMinutes.Text = strings.Minutes;

            // Checkboxes
            chkLowBudget.Text = strings.LowBudget;

            // ComboBox for recipe language
            var supportedLanguages = new List<LanguageItem>
            {
                new LanguageItem(strings.English, "en"),
                new LanguageItem(strings.French,  "fr"),
                new LanguageItem(strings.Spanish, "es")
            };

            cmbRecipeLanguage.DisplayMember = "DisplayName";
            cmbRecipeLanguage.ValueMember = "LanguageCode";
            cmbRecipeLanguage.DataSource = supportedLanguages;

            // Default selected language in the combo box based on the app language
            string currentLanguageCode = Properties.Settings.Default.AppLanguageCode;
            
            if (!supportedLanguages.Any(language => language.LanguageCode == currentLanguageCode))
            {
                currentLanguageCode = "en";
            }

            cmbRecipeLanguage.SelectedValue = currentLanguageCode;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validates the user input for creating a new recipe and inserts it into the database.
        /// </summary>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            int parsedNewRecipeCompletionTime = 0;
            int statusChkLowBudget = 0;

            // Checks if a title has been input
            if (txtNewRecipeTitle.Text == "")
            {
                MessageBox.Show(strings.ErrorMustEnterATitle, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Checks if a completion time has been input and that it is numeric
            if (txtNewRecipeCompletionTime.Text == "" ||
                !int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
            {
                MessageBox.Show(strings.ErrorMustEnterValidNumberForTimeCompletion, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Checks if a language has been defined
            if (cmbRecipeLanguage.SelectedValue == null)
            {
                MessageBox.Show(strings.ErrorMustSelectLanguage, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedLanguage = cmbRecipeLanguage.SelectedValue.ToString();

            // Low budget flag
            statusChkLowBudget = chkLowBudget.Checked ? 1 : 0;

            // Inserts the data into DB
            _frmMain.dbConn.AddNewRecipe(txtNewRecipeTitle.Text, parsedNewRecipeCompletionTime.ToString(),
                statusChkLowBudget, selectedLanguage
            );

            // Displays the new recipe title in the search textbox
            _frmMain.txtTitleSearch.Text = txtNewRecipeTitle.Text;

            // Performs a search with the new recipe title
            _frmMain.SearchRecipesByTitle(_frmMain.txtTitleSearch.Text);

            this.Close();
        }

    }
}
