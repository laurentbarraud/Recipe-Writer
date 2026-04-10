/// <file>frmNewRecipeInfosInput.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 6th 2025</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            int parsedNewRecipeCompletionTime = 0;
            int statusChkLowBudget = 0;

            if (txtNewRecipeTitle.Text != "")
            {
                // If the user has entered only numbers in the textbox
                if (txtNewRecipeCompletionTime.Text != "" && int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
                {
                    if (chkLowBudget.Checked)
                    {
                        statusChkLowBudget = 1;
                    }

                    // If the user hasn't checked the low budget checkbox
                    else
                    {
                        statusChkLowBudget = 0;
                    }
                    
                    // Adds the new recipe into the database
                    _frmMain.dbConn.AddNewRecipe(@txtNewRecipeTitle.Text, parsedNewRecipeCompletionTime.ToString(), statusChkLowBudget);

                    // Displayed the new recipe title into the search texbox
                    _frmMain.txtTitleSearch.Text = txtNewRecipeTitle.Text;

                    // Performs a search with the new recipe title
                    _frmMain.SearchRecipesByTitle(_frmMain.txtTitleSearch.Text);

                    this.Close();
                }
                // If the user hasn't input a number in the textbox
                else if (!int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
                {
                    MessageBox.Show(strings.ErrorMustEnterValidNumberForTimeCompletion, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If the user hasn't input a completion time for the new recipe
                else if (txtNewRecipeCompletionTime.Text == "")
                {
                    MessageBox.Show(strings.ErrorMustEnterACompletionTime, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // If the user hasn't input a title for the new recipe
            else if (txtNewRecipeTitle.Text == "")
            {
                MessageBox.Show(strings.ErrorMustEnterATitle, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
