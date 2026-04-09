/// <file>frmNewRecipeInfosInput.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 6th 2025</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmNewRecipeInfosInput : Form
    {
        // Maps each button to its original image file path
        private readonly Dictionary<Button, string> _buttonOriginalImagePaths = new Dictionary<Button, string>();

        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewRecipeInfosInput(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void frmNewRecipeInfosInput_Load(object sender, EventArgs e)
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
            int parsedNewRecipeCompletionTime = 0;
            int statusChkLowBudget = 0;

            if (txtNewRecipeTitle.Text != "")
            {
                // If the user has entered only numbers in the textbox
                if (txtNewRecipeCompletionTime.Text != "" && int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
                {
                    if (chkLowBudget.Checked)
                    {
                        statusChkLowBudget = 1;
                    }

                    // If the user hasn't checked the low budget checkbox
                    else
                    {
                        statusChkLowBudget = 0;
                    }
                    
                    // Adds the new recipe into the database
                    _frmMain.dbConn.AddNewRecipe(@txtNewRecipeTitle.Text, parsedNewRecipeCompletionTime.ToString(), statusChkLowBudget);

                    // Displayed the new recipe title into the search texbox
                    _frmMain.txtTitleSearch.Text = txtNewRecipeTitle.Text;

                    // Performs a search with the new recipe title
                    _frmMain.cmdTitleSearch.PerformClick();

                    this.Close();
                }
                // If the user hasn't input a number in the textbox
                else if (!int.TryParse(txtNewRecipeCompletionTime.Text, out parsedNewRecipeCompletionTime))
                {
                    MessageBox.Show(strings.ErrorMustEnterValidNumberForTimeCompletion, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If the user hasn't input a completion time for the new recipe
                else if (txtNewRecipeCompletionTime.Text == "")
                {
                    MessageBox.Show(strings.ErrorMustEnterACompletionTime, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // If the user hasn't input a title for the new recipe
            else if (txtNewRecipeTitle.Text == "")
            {
                MessageBox.Show(strings.ErrorMustEnterATitle, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
