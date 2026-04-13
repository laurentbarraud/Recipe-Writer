/// <file>frmAddNewIngredientToTheDB.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 13th 2026</date>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmAddNewIngredientToTheDB : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmAddNewIngredientToTheDB(frmMain parentForm)
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
            string windowTitle = strings.AddNewIngredientToBase;

            if (!string.IsNullOrEmpty(windowTitle))
            {
                this.Text = windowTitle;
            }

            // Labels
            lblNewIngredientNameFr.Text = strings.NewIngredientNameFr;
            lblNewIngredientNameEn.Text = strings.NewIngredientNameEn;
            lblNewIngredientNameEs.Text = strings.NewIngredientNameEs;
            lblTypeIngredient.Text = strings.TypeIngredient;
        }

        private void frmAddNewIngredientToTheDB_Load(object sender, EventArgs e)
        {
            List<string> listAllTypesOfIngredientsStored = new List<string>();
            listAllTypesOfIngredientsStored = _frmMain.dbConn.ReadAllTypesOfIngredientsStored();

            foreach (string typeName in listAllTypesOfIngredientsStored)
            {
                // Adding each ingredient's name to the combobox items
                cmbTypesIngredientsListedInDB.Items.Add(typeName);
            }

            List<string> listAllScalesStored = new List<string>();
            listAllScalesStored = _frmMain.dbConn.ReadAllScalesStored();

            foreach (string scaleName in listAllScalesStored)
            {
                // Adding each ingredient's name to the combobox items
                cmbScaleNewIngredient.Items.Add(scaleName);
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string ingredientFr = txtNewIngredientNameFr.Text.Trim();
            string ingredientEn = txtNewIngredientNameEn.Text.Trim();
            string ingredientEs = txtNewIngredientNameEs.Text.Trim();

            // Escape apostrophes
            ingredientFr = ingredientFr.Replace("'", "''");
            ingredientEn = ingredientEn.Replace("'", "''");
            ingredientEs = ingredientEs.Replace("'", "''");

            // Rejects if all three text fields are empty
            if (string.IsNullOrWhiteSpace(ingredientFr) &&
                string.IsNullOrWhiteSpace(ingredientEn) &&
                string.IsNullOrWhiteSpace(ingredientEs))
            {
                MessageBox.Show(strings.ErrorEmptyFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Auto-fill missing fields based on any available value
            if (string.IsNullOrWhiteSpace(ingredientFr))
            {
                ingredientFr = !string.IsNullOrWhiteSpace(ingredientEn) ? ingredientEn : ingredientEs;
            }

            if (string.IsNullOrWhiteSpace(ingredientEn))
            {
                ingredientEn = !string.IsNullOrWhiteSpace(ingredientFr) ? ingredientFr : ingredientEs;
            }

            if (string.IsNullOrWhiteSpace(ingredientEs))
            {
                ingredientEs = !string.IsNullOrWhiteSpace(ingredientFr) ? ingredientFr : ingredientEn;
            }

            // Validates dropdowns
            if (cmbTypesIngredientsListedInDB.SelectedIndex == -1 || cmbScaleNewIngredient.SelectedIndex == -1)
            {
                MessageBox.Show(strings.ErrorEmptyFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _frmMain.dbConn.AddNewIngredientToDB(ingredientFr, ingredientEn, ingredientEs, cmbScaleNewIngredient.SelectedIndex + 1,
                cmbTypesIngredientsListedInDB.SelectedIndex + 1);

                MessageBox.Show(strings.NewIngredientInsertedIntoBase, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(strings.ErrorIngredientInsert, ex.Message), strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
