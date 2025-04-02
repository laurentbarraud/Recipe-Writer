/// <file>frmNewIngredient.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 28th 2025</date>

using System;
using System.Collections.Generic;
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
            if (!double.TryParse(txtQtyIngredientNeeded.Text, out double parsedQtyIngredient))
            {
                MessageBox.Show("Veuillez entrer un nombre réel valide pour la quantité de l'ingrédient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string formattedIngredientName = cmbIngredientsListedInDB.Text.Replace("'", "''");

            int idNewIngredient = _frmMain.dbConn.ReadIdForAnIngredientName(formattedIngredientName);

            _frmMain.dbConn.AddNewIngredientToRecipe(_frmMain._currentDisplayedRecipe.Id, idNewIngredient);

            _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);

            this.Close();
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
