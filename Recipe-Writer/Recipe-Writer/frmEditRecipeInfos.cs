/// <file>frmEditRecipeTitle.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2.1</version>
/// <date>August, 4th 2026</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmEditRecipeInfos : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        private int idRecipeToEdit = 0;
        private string recipeTitleToEdit = "";
        private int recipeCompletionTime = 0;
        private int lowBudgetStatus = 0;

        public int IdRecipeToEdit
        {
            get { return idRecipeToEdit; }
            set { idRecipeToEdit = value; }
        }
        public string RecipeTitleToEdit
        {
            get { return recipeTitleToEdit; }
            set { recipeTitleToEdit = value; }
        }

        public int RecipeCompletionTime
        {
            get { return recipeCompletionTime; }
            set { recipeCompletionTime = value; }
        }

        public int LowBudgetStatus
        {
            get { return lowBudgetStatus; }
            set { lowBudgetStatus = value; }
        }

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmEditRecipeInfos(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";
            UIHoverHelper.ButtonBaseResourceNames[cmdDelete] = "delete";

            // Buttons hover event
            cmdDelete.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdDelete.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Title
            string windowTitle = strings.EditRecipeBasicInfo;

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

            // The default selected language in the ComboBox is the language of the recipe currently displayed in the main form
            string currentLanguageCode = _frmMain._currentDisplayedRecipe.Language;

            // Fallback if recipe language is not supported
            if (!supportedLanguages.Any(language => language.LanguageCode == currentLanguageCode))
            {
                currentLanguageCode = "en";
            }

            cmbRecipeLanguage.SelectedValue = currentLanguageCode;
        }

        private void frmEditRecipeInfos_Load(object sender, EventArgs e)
        {
            txtRecipeTitleToEdit.Text = RecipeTitleToEdit;
            txtRecipeCompletionTime.Text = RecipeCompletionTime.ToString();
            if (LowBudgetStatus == 1)
            {
                chkLowBudget.Checked = true;
            }
            else
            {
                chkLowBudget.Checked = false;
            }
        }

        private void chkLowBudget_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLowBudget.Checked)
            {
                LowBudgetStatus = 1;
            }
            else
            {
                LowBudgetStatus = 0;
            }
        }


        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validates the edited recipe information, updates the database,
        /// and refreshes the recipe details in the parent form.
        /// </summary>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string formattedRecipeTitle = txtRecipeTitleToEdit.Text;
            int parsedRecipeCompletionTime = 0;

            // Escapes apostrophes to avoid SQL issues
            if (txtRecipeTitleToEdit.Text.Contains("'"))
            {
                formattedRecipeTitle = txtRecipeTitleToEdit.Text.Replace("'", "''");
            }

            // Checks title has been input
            if (txtRecipeTitleToEdit.Text == "")
            {
                MessageBox.Show(strings.ErrorMustEnterATitle, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Checks completion time has been input and that it is numeric
            if (txtRecipeCompletionTime.Text == "" ||
                !int.TryParse(txtRecipeCompletionTime.Text, out parsedRecipeCompletionTime))
            {
                MessageBox.Show(strings.ErrorMustEnterValidNumberForTimeCompletion, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Checks that language has been input
            if (cmbRecipeLanguage.SelectedValue == null)
            {
                MessageBox.Show(strings.ErrorMustSelectLanguage, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedLanguage = cmbRecipeLanguage.SelectedValue.ToString();

            // Updates DB 
            _frmMain.dbConn.UpdateRecipeInfos(idRecipeToEdit, formattedRecipeTitle,
                txtRecipeCompletionTime.Text, LowBudgetStatus.ToString(), selectedLanguage);

            // Refreshes UI
            _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);

            this.Close();
        }
    }
}
