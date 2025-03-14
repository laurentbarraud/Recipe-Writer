/// <file>frmNewInstruction.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 14th 2025</date>

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
    public partial class frmNewInstruction : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;
        private int idRecipeToEdit;
        private string instructionToAdd;
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
            _frmMain.dbConn.AddNewInstructionToRecipe(this.IdRecipeToEdit, this.NbInstructionsInCurrentRecipe, txtNewInstruction.Text);
            _frmMain.DisplayRecipeInfos();
            this.Close();
        }

        private void frmNewInstruction_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
