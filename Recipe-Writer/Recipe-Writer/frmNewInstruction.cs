/// <file>frmNewInstruction.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 9th 2026</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmNewInstruction : Form
    {
        // Maps each button to its original image file path
        private readonly Dictionary<Button, string> _buttonOriginalImagePaths = new Dictionary<Button, string>();

        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Stores the recipe ID being edited
        private int idRecipeToEdit;

        // Stores the number of instructions currently in the recipe
        private int nbInstructionsInCurrentRecipe;

        public int IdRecipeToEdit
        {
            get { return idRecipeToEdit; }
            set { idRecipeToEdit = value; }
        }

        public int NbInstructionsInCurrentRecipe
        {
            get { return nbInstructionsInCurrentRecipe; }
            set { nbInstructionsInCurrentRecipe = value; }
        }

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewInstruction(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void frmNewInstruction_Load(object sender, EventArgs e)
        {
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

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the instruction is not empty
                if (string.IsNullOrWhiteSpace(txtNewInstruction.Text))
                {
                    ShowError(strings.ErrorEmptyFields);
                    return;
                }

                // Escape apostrophes before saving
                string formattedText = txtNewInstruction.Text.Trim().Replace("'", "''");

                // Add the instruction securely
                AddInstructionToRecipe(formattedText);

                // Refresh recipe information
                _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);
            }
            catch (Exception ex)
            {
                ShowError(string.Format(strings.ErrorIngredientInsert, ex.Message));
            }
            finally
            {
                // Close the form whether an error occurred or not
                this.Close();
            }
        }

        /// <summary>
        /// Displays an error message using MessageBox.
        /// </summary>
        private void ShowError(string message)
        {
            MessageBox.Show(message, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // Separate method to make the addition clearer and more secure
        private void AddInstructionToRecipe(string instruction)
        {
            _frmMain.dbConn.AddNewInstructionToRecipe(this.IdRecipeToEdit, this.NbInstructionsInCurrentRecipe, instruction);
        }
    }
}
