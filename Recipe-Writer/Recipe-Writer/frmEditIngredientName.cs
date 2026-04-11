/// <file>frmEditIngredientName.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 12th 2026</date>

using System;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmEditIngredientName : Form
    {
        // Declares the main form to be able to access its controls
        private frmMain _frmMain = null;

        // Declares the parent form to be able to access its controls
        private frmInventory _frmInventory = null;

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
            _frmMain = _frmInventory._frmMain;

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";
            UIHoverHelper.ButtonBaseResourceNames[cmdDelete] = "delete";

            // Buttons hover event
            cmdDelete.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdDelete.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Title
            string windowTitle = strings.EditIngredientName;

            if (!string.IsNullOrEmpty(windowTitle))
            {
                this.Text = windowTitle;
            }

            // Labels
            lblNewIngredientName.Text = strings.NewIngredientName;
        }

        private void frmEditIngredientName_Load(object sender, EventArgs e)
        {
            txtNewNameOfIngredient.Text = NameOfIngredientToEdit;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validates the new name of the ingredient and updates it in the database, 
        /// then refreshes the inventory form to reflect the changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string formattedTitle = txtNewNameOfIngredient.Text.Trim();

            // Escapes apostrophes to avoid SQL errors
            if (formattedTitle.Contains("'"))
            {
                formattedTitle = formattedTitle.Replace("'", "''");
            }

            // Checks if the title is not empty
            if (!string.IsNullOrWhiteSpace(formattedTitle))
            {
                try
                {   // Gets the app active language
                    string selectedLanguage = Properties.Settings.Default.AppLanguageCode;
                    
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
