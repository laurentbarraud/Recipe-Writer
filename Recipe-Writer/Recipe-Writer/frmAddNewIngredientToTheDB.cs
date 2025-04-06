/// <file>frmAddNewIngredientToTheDB.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 6th 2025</date>

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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string formattedNewIngredientName = txtNameNewIngredient.Text;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (txtNameNewIngredient.Text.Contains("'"))
            {
                formattedNewIngredientName = txtNameNewIngredient.Text.Replace("'", "''");
            }
          
            if (cmbTypesIngredientsListedInDB.SelectedIndex != -1 && cmbScaleNewIngredient.SelectedIndex != -1 && txtNameNewIngredient.Text != "")
            {
                try
                {
                    _frmMain.dbConn.AddNewIngredientToDB(formattedNewIngredientName, cmbScaleNewIngredient.SelectedIndex + 1, cmbTypesIngredientsListedInDB.SelectedIndex + 1 );
                    MessageBox.Show(strings.NewIngredientInsertedIntoBase, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(strings.ErrorIngredientInsert, ex.Message), strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            else
            {
               MessageBox.Show(strings.ErrorEmptyFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
