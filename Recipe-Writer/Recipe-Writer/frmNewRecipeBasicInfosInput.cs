/// <file>frmNewRecipeBasicInfosInput.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 20th 2025</date>

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
    public partial class frmNewRecipeBasicInfosInput : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewRecipeBasicInfosInput(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
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
                    _frmMain.cmdTitleSearch.PerformClick();

                    this.Close();
                }
                // If the user hasn't input a number in the textbox
                else if (!int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
                {
                    MessageBox.Show("Vous devez saisir un nombre valide pour le temps de réalisation de la nouvelle recette", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If the user hasn't input a completion time for the new recipe
                else if (txtNewRecipeCompletionTime.Text == "")
                {
                    MessageBox.Show("Vous devez saisir un temps de réalisation pour la nouvelle recette", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // If the user hasn't input a title for the new recipe
            else if (txtNewRecipeTitle.Text == "")
            {
                MessageBox.Show("Vous devez saisir un titre pour la nouvelle recette", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNewRecipeBasicInfosInput_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
