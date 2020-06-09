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
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _frmMain.cmbRecipeIngredients.SelectedIndex = 0;
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            // If the user has selected an ingredient from the list
            if (cmbIngredientsList.Text == cmbIngredientsList.SelectedItem.ToString())
            {
                // Stores the id of the current selected recipe
                int idSelectedRecipe = _frmMain._currentDisplayedRecipe.Id;

                // Calls the method to count the total number of ingredients affected to the currently selected recipe
                int nbIngredientsForARecipe = _frmMain.dbConn.CountAllIngredientsForARecipe(idSelectedRecipe);

                // Calls the method to get the ingredient scale in use in the database
                string scaleUsedForIngredient = _frmMain.dbConn.ReadIngredientScale(_frmMain._currentDisplayedRecipe.Id, cmbIngredientsList.SelectedIndex - 1, _frmMain._currentDisplayedRecipe.IngredientsList.Count + 1);

                // Calls the method to add the new ingredient by reference to its id to the currently selected recipe ingredients list
                _frmMain.dbConn.AddNewIngredientToRecipe(_frmMain._currentDisplayedRecipe.Id, nbIngredientsForARecipe, cmbIngredientsList.SelectedIndex - 1, scaleUsedForIngredient);   
            }

            // If the user has entered a new ingredient not in the list
            else
            {
                // To-Do : 
                // adds a new ingredient id in the database (dbConn.CountAllIngredients + 1)


                // then store the id returned in newIngredientId
            }
        }

        private void frmNewIngredient_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
