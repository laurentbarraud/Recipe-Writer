/// <file>frmNewInstruction.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 7th 2025</date>

using System;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmNewInstruction : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;
        private int idRecipeToEdit;
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


        private void frmNewInstruction_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
