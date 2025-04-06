/// <file>frmNewInstruction.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 6th 2025</date>

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
                // Vérification que l'instruction n'est pas vide
                if (string.IsNullOrWhiteSpace(txtNewInstruction.Text))
                {
                    MessageBox.Show(strings.ErrorEmptyFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Adding the instruction with secure parameters
                AddInstructionToRecipe(txtNewInstruction.Text.Trim());

                // Recipe info refresh
                _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(strings.ErrorIngredientInsert, ex.Message), strings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
