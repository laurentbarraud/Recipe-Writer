/// <file>frmEditIngredientName.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 1st 2025</date>

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
    public partial class frmEditIngredientName : Form
    {
        // Declares the parents forms to be able to access their controls
        private frmInventory _frmInventory; // Direct parent
        private frmMain _frmMain; // Indirect parent


        private int idIngredientToEdit;
        private string nameOfIngredientToEdit;

        public int IdIngredientToEdit
        {
            get { return idIngredientToEdit; }
            set { idIngredientToEdit = value; }
        }

        public string NameOfIngredientToEdit
        {
            get { return nameOfIngredientToEdit; }
            set { nameOfIngredientToEdit = value; }
        }


        public frmEditIngredientName(frmInventory parentInventory)
        {
            InitializeComponent();
            _frmInventory = parentInventory;
            _frmMain = _frmInventory._frmMain; // Gets frmMain from frmInventory
        }

        private void frmEditIngredientName_Load(object sender, EventArgs e)
        {
            txtNewNameOfIngredient.Text = NameOfIngredientToEdit;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string formattedTitle = txtNewNameOfIngredient.Text;

            // Checks if the keywords contain an apostroph, to avoid making the sql request crash
            if (txtNewNameOfIngredient.Text.Contains("'"))
            {
                formattedTitle = txtNewNameOfIngredient.Text.Replace("'", "''");
            }

            if (txtNewNameOfIngredient.Text != "")
            {
                _frmMain.dbConn.UpdateIngredientName(IdIngredientToEdit, formattedTitle);
                _frmInventory.RefreshInventory();
                this.Close();
            }
        }
    }
}
