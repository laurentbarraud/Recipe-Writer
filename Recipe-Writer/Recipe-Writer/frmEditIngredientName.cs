/// <file>frmEditIngredientName.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.3</version>
/// <date>February 26th 2026</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmEditIngredientName : Form
    {
        // Maps each button to its original image file path
        private readonly Dictionary<Button, string> _buttonOriginalImagePaths = new Dictionary<Button, string>();

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
        }

        private void frmEditIngredientName_Load(object sender, EventArgs e)
        {
            txtNewNameOfIngredient.Text = NameOfIngredientToEdit;

            // Sets the directory path for the resources folder, where all the button images are stored
            string resourcesDir = Path.Combine(Application.StartupPath, "Resources");

            // Sets the path for each button image by combining the resources directory path with the specific image filename
            string cmdCancelPath = Path.Combine(resourcesDir, "delete.png");
            string cmdValidatePath = Path.Combine(resourcesDir, "validate.png");

            // Assigns the background images to the buttons using the loaded paths
            cmdCancel.BackgroundImage = Image.FromFile(cmdCancelPath);
            cmdValidate.BackgroundImage = Image.FromFile(cmdValidatePath);

            // Fills the truth table that links each button to its original image path, 
            // for later restoration on mouse leave
            _buttonOriginalImagePaths[cmdCancel] = cmdCancelPath;
            _buttonOriginalImagePaths[cmdValidate] = cmdValidatePath;

            // Buttons hover event
            cmdCancel.MouseEnter += _frmMain.Button_MouseEnter;
            cmdCancel.MouseLeave += _frmMain.Button_MouseLeave;
            cmdValidate.MouseEnter += _frmMain.Button_MouseEnter;
            cmdValidate.MouseLeave += _frmMain.Button_MouseLeave;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
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
