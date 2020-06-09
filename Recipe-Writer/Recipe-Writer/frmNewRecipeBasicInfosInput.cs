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
            this.Hide();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            if (txtNewRecipeTitle.Text != "")
            {
                string formattedNewRecipeTitle = txtNewRecipeTitle.Text;

                // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
                if (txtNewRecipeTitle.Text.Contains("'"))
                {
                    formattedNewRecipeTitle = txtNewRecipeTitle.Text.Replace("'", "''");
                }

                _frmMain.txtTitleSearch.Text = txtNewRecipeTitle.Text;

                if (txtNewRecipeCompletionTime.Text != "")
                {
                    int parsedNewRecipeCompletionTime = 0;

                    if (int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
                    {
                        _frmMain.dbConn.WriteNewRecipe(formattedNewRecipeTitle, txtNewRecipeCompletionTime.Text, chkLowBudget.Checked);
                    }

                    // If the user hasn't input a number in the textbox
                    else
                    {
                        MessageBox.Show("Vous devez saisir un nombre valide pour le temps de réalisation de la nouvelle recette", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   
                }

                // If the user hasn't input a completion time for the new recipe
                else
                {
                    MessageBox.Show("Vous devez saisir un temps de réalisation pour la nouvelle recette", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If the user hasn't input a title for the new recipe
            else
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
