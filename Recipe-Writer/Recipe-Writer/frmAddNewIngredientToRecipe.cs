/// <file>frmNewIngredient.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 28th 2025</date>

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
    public partial class frmAddNewIngredientToRecipe : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmAddNewIngredientToRecipe(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void frmNewIngredient_Load(object sender, EventArgs e)
        {
            List<string> listAllIngredientsStored = new List<string>();
            listAllIngredientsStored = _frmMain.dbConn.ReadAllIngredientsStoredForAType();

            foreach (string ingredientName in listAllIngredientsStored)
            {
                // Adding each ingredient's name to the combobox items
                cmbIngredientsListedInDB.Items.Add(ingredientName);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _frmMain.cmbRecipeIngredients.SelectedIndex = 0;
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            double parsedQtyIngredient = 0.0;
            int nbIngredientsForARecipe = 0;

            string formattedIngredientName = cmbIngredientsListedInDB.Text;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (cmbIngredientsListedInDB.Text.Contains("'"))
            {
                formattedIngredientName = cmbIngredientsListedInDB.Text.Replace("'", "''");
            }

            
            // If the user has typed numbers in the quantity of ingredient textbox
            if (txtQtyIngredientNeeded.Text != "" && double.TryParse(txtQtyIngredientNeeded.Text, out parsedQtyIngredient))
            {
                // Calls the method to count the total number of ingredients affected to the currently selected recipe
                nbIngredientsForARecipe = _frmMain.dbConn.CountAllIngredientsForARecipe(_frmMain._currentDisplayedRecipe.Id);

                // Calls the method to add the new ingredient by reference to its id
                _frmMain.dbConn.AddNewIngredientToRecipe(_frmMain._currentDisplayedRecipe.Id, nbIngredientsForARecipe, cmbIngredientsListedInDB.SelectedIndex+1);

                this.Close();

                _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);
            }

            // If the user has left the quantity of ingredient textbox empty or has typed a not-valid number
            else if (txtQtyIngredientNeeded.Text == "" && double.TryParse(txtQtyIngredientNeeded.Text, out parsedQtyIngredient))
            {
                MessageBox.Show("Veuillez entrer un nombre réel valide pour la quantité de l'ingrédient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void cmbIngredientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIngredientsListedInDB.SelectedIndex != -1)
            {
                cmdValidate.Enabled = true;

                int idIngredientSelected = _frmMain.dbConn.ReadIdForAnIngredientName(cmbIngredientsListedInDB.Text);
                List<string> listStoredScalesInDB = new List<string>();
                listStoredScalesInDB = _frmMain.dbConn.ReadAllScalesStored();
                lblScaleAssociatedWithIngredientSelected.Text = listStoredScalesInDB[_frmMain.dbConn.ReadScaleIdForAnIngredient(idIngredientSelected) - 1];
            }

            else
            {
                cmdValidate.Enabled = false;

                lblScaleAssociatedWithIngredientSelected.Text = "";
            }
        }
    }
}
