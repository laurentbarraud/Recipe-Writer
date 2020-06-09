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
            // To-Do : If the user has entered a new ingredient not in the list
            // add a new ingredient id in the database (dbConn.CountAllIngredients + 1) 
            // then store the id returned in newIngredientId

            // if the user has selected an ingredient from the list, 
            // store the id selected in newIngredientId
            // add the id reference to this ingredient (newIngredientId) in the database, to the current selected recipe ingredient(dbConn.nbIngredientsForARecipe)+1
        }

        private void frmNewIngredient_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
