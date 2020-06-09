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
    public partial class frmNewIngredient : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewIngredient(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void frmNewIngredient_Load(object sender, EventArgs e)
        {
            // Empties the combobox before adding new ingredients to it
            cmbIngredientsList.Items.Clear();

            List<string> allIngredientsStoredList = new List<string>();
            allIngredientsStoredList = _frmMain.dbConn.ReadAllIngredientsStored();

            foreach (string ingredientName in allIngredientsStoredList)
            {
                // Adding each ingredient's name to the combobox items
                cmbIngredientsList.Items.Add(ingredientName);
            }

            // Empties the combobox before adding new scales to it
            cmbScalesList.Items.Clear();

            List<string> allScalesStoredList = new List<string>();
            allScalesStoredList = _frmMain.dbConn.ReadAllScalesStored();

            foreach (string scaleName in allScalesStoredList)
            {
                // Adding each ingredient's name to the combobox items
                cmbScalesList.Items.Add(scaleName);
            }

            cmbScalesList.SelectedIndex = 0;
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
            int idSelectedRecipe = 0;
            string scaleUsedForIngredient = "";

            string formattedIngredientName = cmbIngredientsList.Text;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (cmbIngredientsList.Text.Contains("'"))
            {
                formattedIngredientName = cmbIngredientsList.Text.Replace("'", "''");
            }

            // If the user has selected an ingredient from the list
            if (cmbIngredientsList.Text == cmbIngredientsList.SelectedItem.ToString())
            {
                // If the user has typed numbers in the quantity of ingredient textbox
                if (txtQtyIngredient.Text != "" && double.TryParse(txtQtyIngredient.Text, out parsedQtyIngredient))
                {
                    // Stores the id of the current selected recipe
                    idSelectedRecipe = _frmMain._currentDisplayedRecipe.Id;

                    // Calls the method to count the total number of ingredients affected to the currently selected recipe
                    nbIngredientsForARecipe = _frmMain.dbConn.CountAllIngredientsForARecipe(idSelectedRecipe);

                    // Calls the method to get the ingredient scale in use in the database
                    scaleUsedForIngredient = _frmMain.dbConn.ReadIngredientScale(_frmMain._currentDisplayedRecipe.Id, cmbIngredientsList.SelectedIndex - 1, _frmMain._currentDisplayedRecipe.IngredientsList.Count + 1);

                    // Calls the method to add the new ingredient by reference to its id to the currently selected recipe ingredients list
                    _frmMain.dbConn.AddNewIngredientToRecipe(_frmMain._currentDisplayedRecipe.Id, nbIngredientsForARecipe, cmbIngredientsList.SelectedIndex - 1, scaleUsedForIngredient);
                }

                // If the user has left the quantity of ingredient textbox empty or has typed a not-valid number
                else
                {
                    MessageBox.Show("Veuillez entrer un nombre réel valide pour la quantité de l'ingrédient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (cmbIngredientsList.Text == "")
            {
                MessageBox.Show("Veuillez sélectionner un ingrédient ou en taper un nouveau", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // If the user has entered a new ingredient not in the list
            else
            {
                // If the user has typed numbers in the quantity of ingredient textbox
                if (txtQtyIngredient.Text != "" && double.TryParse(txtQtyIngredient.Text, out parsedQtyIngredient))
                {
                    // Stores the id of the current selected recipe
                    idSelectedRecipe = _frmMain._currentDisplayedRecipe.Id;

                    // Calls the method to count the total number of ingredients affected to the currently selected recipe
                    nbIngredientsForARecipe = _frmMain.dbConn.CountAllIngredientsForARecipe(idSelectedRecipe);

                    // Calls the method to get the ingredient scale in use in the database
                    scaleUsedForIngredient = _frmMain.dbConn.ReadIngredientScale(_frmMain._currentDisplayedRecipe.Id, cmbIngredientsList.SelectedIndex - 1, _frmMain._currentDisplayedRecipe.IngredientsList.Count + 1);

                    // Calls the method to add the new ingredient by reference to its id to the currently selected recipe ingredients list
                    _frmMain.dbConn.AddNewIngredient(_frmMain._currentDisplayedRecipe.Id, parsedQtyIngredient, formattedIngredientName, cmbScalesList.Text, nbIngredientsForARecipe);
                }

                // If the user has left the quantity of ingredient textbox empty or has typed a not-valid number
                else
                {
                    MessageBox.Show("Veuillez entrer un nombre réel valide pour la quantité de l'ingrédient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmNewIngredient_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
