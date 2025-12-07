/// <file>frmEditRecipeTitle.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>April 6th 2025</date>

using System;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmEditRecipeBasicInfos : Form
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
        public frmEditRecipeBasicInfos(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }


        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditRecipeTitle_Load(object sender, EventArgs e)
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


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string formattedRecipeTitle = txtRecipeTitleToEdit.Text;
            int parsedRecipeCompletionTime = 0;


            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (txtRecipeTitleToEdit.Text.Contains("'"))
            {
                formattedRecipeTitle = txtRecipeTitleToEdit.Text.Replace("'", "''");
            }

            if (txtRecipeTitleToEdit.Text != "")
            {
                // If the user has entered only numbers in the textbox
                if (txtRecipeCompletionTime.Text != "" && int.TryParse(txtRecipeCompletionTime.Text, out parsedRecipeCompletionTime))
                {
                    _frmMain.dbConn.UpdateRecipeBasicInfos(idRecipeToEdit, formattedRecipeTitle, txtRecipeCompletionTime.Text, LowBudgetStatus.ToString());
                    _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);

                    this.Close();
                }
                // If the user hasn't input a number in the completion time textbox
                else if (!int.TryParse(txtRecipeCompletionTime.Text, out parsedRecipeCompletionTime))
                {
                    MessageBox.Show(strings.ErrorMustEnterValidNumberForTimeCompletion, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If the user hasn't input a completion time for the recipe
                else if (txtRecipeCompletionTime.Text == "")
                {
                    MessageBox.Show(strings.ErrorMustEnterACompletionTime, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // If the user hasn't input a title for the recipe
            else if (txtRecipeTitleToEdit.Text == "")
            {
                MessageBox.Show(strings.ErrorMustEnterATitle, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
            this.Close();
        }

        private void frmEditRecipeTitle_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
