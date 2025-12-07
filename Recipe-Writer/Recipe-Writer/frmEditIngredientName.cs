/// <file>frmEditIngredientName.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>December 7th 2025</date>

using System;
using System.Collections.Generic;
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
            string formattedTitle = txtNewNameOfIngredient.Text.Trim();

            // Échapper les apostrophes pour éviter les erreurs SQL
            if (formattedTitle.Contains("'"))
            {
                formattedTitle = formattedTitle.Replace("'", "''");
            }

            // Vérifier que le champ n'est pas vide
            if (!string.IsNullOrWhiteSpace(formattedTitle))
            {
                try
                {   // Gets the app active language
                    string selectedLanguage = Properties.Settings.Default.AppLanguage;
                    _frmMain.dbConn.UpdateIngredientName(IdIngredientToEdit, formattedTitle, selectedLanguage);
                    _frmInventory.RefreshInventory();
                    this.Close();
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
