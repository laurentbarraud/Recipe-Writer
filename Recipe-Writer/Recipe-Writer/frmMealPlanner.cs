/// <file>frmMealPlanner.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.3</version>
/// <date>April 6th 2025</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmMealPlanner : Form
    {
        // Maps each button to its original image file path
        private readonly Dictionary<Button, string> _buttonOriginalImagePaths = new Dictionary<Button, string>();

        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Generic delegate
        private Action<int> loadPlannedMeal;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmMealPlanner(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMealPlanner_Load(object sender, EventArgs e)
        {
            this.Location = new Point(_frmMain.Width - 150, _frmMain.Height / 2);

            loadPlannedMeal = LoadPlannedMealForADay;

            for (int idDayOfWeek = 1; idDayOfWeek < 6; idDayOfWeek++)
            {
                loadPlannedMeal(idDayOfWeek);
            }

            if (!string.IsNullOrEmpty(lblMondayRecipe.Text))
            {
                cmdMondayCancelled.Visible = true;
                cmdMondayCooked.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblTuesdayRecipe.Text))
            {
                cmdTuesdayCancelled.Visible = true;
                cmdTuesdayCooked.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblWednesdayRecipe.Text))
            {
                cmdWednesdayCancelled.Visible = true;
                cmdWednesdayCooked.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblThursdayRecipe.Text))
            {
                cmdThursdayCancelled.Visible = true;
                cmdThursdayCooked.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblFridayRecipe.Text))
            {
                cmdFridayCancelled.Visible = true;
                cmdFridayCooked.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblSaturdayRecipe.Text))
            {
                cmdSaturdayCancelled.Visible = true;
                cmdSaturdayCooked.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblSundayRecipe.Text))
            {
                cmdSundayCancelled.Visible = true;
                cmdSundayCooked.Visible = true;
            }

            // Sets the directory path for the resources folder, where all the button images are stored
            string resourcesDir = Path.Combine(Application.StartupPath, "Resources");

            // Sets the path for each button image by combining the resources directory path with the specific image filename
            string cmdMondayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdMondayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdTuesdayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdTuesdayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdWednesdayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdWednesdayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdThursdayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdThursdayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdFridayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdFridayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdSaturdayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdSaturdayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdSundayCancelledPath = Path.Combine(resourcesDir, "delete.png");
            string cmdSundayCookedPath = Path.Combine(resourcesDir, "recipeCooked.png");
            string cmdValidatePath = Path.Combine(resourcesDir, "validate.png");

            // Assigns the background images to the buttons using the loaded paths
            cmdMondayCancelled.BackgroundImage = Image.FromFile(cmdMondayCancelledPath);
            cmdMondayCooked.BackgroundImage = Image.FromFile(cmdMondayCookedPath);
            cmdTuesdayCancelled.BackgroundImage = Image.FromFile(cmdTuesdayCancelledPath);
            cmdTuesdayCooked.BackgroundImage = Image.FromFile(cmdTuesdayCookedPath);
            cmdWednesdayCancelled.BackgroundImage = Image.FromFile(cmdWednesdayCancelledPath);
            cmdWednesdayCooked.BackgroundImage = Image.FromFile(cmdWednesdayCookedPath);
            cmdThursdayCancelled.BackgroundImage = Image.FromFile(cmdThursdayCancelledPath);
            cmdThursdayCooked.BackgroundImage = Image.FromFile(cmdThursdayCookedPath);
            cmdFridayCancelled.BackgroundImage = Image.FromFile(cmdFridayCancelledPath);
            cmdFridayCooked.BackgroundImage = Image.FromFile(cmdFridayCookedPath);
            cmdSaturdayCancelled.BackgroundImage = Image.FromFile(cmdSaturdayCancelledPath);
            cmdSaturdayCooked.BackgroundImage = Image.FromFile(cmdSaturdayCookedPath);
            cmdSundayCancelled.BackgroundImage = Image.FromFile(cmdSundayCancelledPath);
            cmdSundayCooked.BackgroundImage = Image.FromFile(cmdSundayCookedPath);
            cmdValidate.BackgroundImage = Image.FromFile(cmdValidatePath);

            // Fills the truth table that links each button to its original image path, 
            // for later restoration on mouse leave
            _buttonOriginalImagePaths[cmdMondayCancelled] = cmdMondayCancelledPath;
            _buttonOriginalImagePaths[cmdMondayCooked] = cmdMondayCookedPath;
            _buttonOriginalImagePaths[cmdTuesdayCancelled] = cmdTuesdayCancelledPath;
            _buttonOriginalImagePaths[cmdTuesdayCooked] = cmdTuesdayCookedPath;
            _buttonOriginalImagePaths[cmdWednesdayCancelled] = cmdWednesdayCancelledPath;
            _buttonOriginalImagePaths[cmdWednesdayCooked] = cmdWednesdayCookedPath;
            _buttonOriginalImagePaths[cmdThursdayCancelled] = cmdThursdayCancelledPath;
            _buttonOriginalImagePaths[cmdThursdayCooked] = cmdThursdayCookedPath;
            _buttonOriginalImagePaths[cmdFridayCancelled] = cmdFridayCancelledPath;
            _buttonOriginalImagePaths[cmdFridayCooked] = cmdFridayCookedPath;
            _buttonOriginalImagePaths[cmdSaturdayCancelled] = cmdSaturdayCancelledPath;
            _buttonOriginalImagePaths[cmdSaturdayCooked] = cmdSaturdayCookedPath;
            _buttonOriginalImagePaths[cmdSundayCancelled] = cmdSundayCancelledPath;
            _buttonOriginalImagePaths[cmdSundayCooked] = cmdSundayCookedPath;
            _buttonOriginalImagePaths[cmdValidate] = cmdValidatePath;

            // Buttons hover event
            cmdMondayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdMondayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdMondayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdMondayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdTuesdayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdTuesdayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdTuesdayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdTuesdayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdWednesdayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdWednesdayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdWednesdayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdWednesdayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdThursdayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdThursdayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdThursdayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdThursdayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdFridayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdFridayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdFridayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdFridayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdSaturdayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdSaturdayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdSaturdayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdSaturdayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdSundayCancelled.MouseEnter += _frmMain.Button_MouseEnter;
            cmdSundayCancelled.MouseLeave += _frmMain.Button_MouseLeave;
            cmdSundayCooked.MouseEnter += _frmMain.Button_MouseEnter;
            cmdSundayCooked.MouseLeave += _frmMain.Button_MouseLeave;
            cmdValidate.MouseEnter += _frmMain.Button_MouseEnter;
            cmdValidate.MouseLeave += _frmMain.Button_MouseLeave;
        }

        private void cmdMondayCancelled_Click(object sender, EventArgs e)
        {
            lblMondayRecipe.Text = "";
            cmdMondayCancelled.Visible = false;
            cmdMondayCooked.Visible = false;
        }

        private void cmdTuesdayCancelled_Click(object sender, EventArgs e)
        {
            lblTuesdayRecipe.Text = "";
            cmdTuesdayCancelled.Visible = false;
            cmdTuesdayCooked.Visible = false;
        }

        private void cmdWednesdayCancelled_Click(object sender, EventArgs e)
        {
            lblWednesdayRecipe.Text = "";
            cmdWednesdayCancelled.Visible = false;
            cmdWednesdayCooked.Visible = false;
        }

        private void cmdThursdayCancelled_Click(object sender, EventArgs e)
        {
            lblThursdayRecipe.Text = "";
            cmdThursdayCancelled.Visible = false;
            cmdThursdayCooked.Visible = false;
        }

        private void cmdFridayCancelled_Click(object sender, EventArgs e)
        {
            lblFridayRecipe.Text = "";
            cmdFridayCancelled.Visible = false;
            cmdFridayCooked.Visible = false;
        }

        private void cmdSaturdayCancelled_Click(object sender, EventArgs e)
        {
            lblSaturdayRecipe.Text = "";
            cmdSaturdayCancelled.Visible = false;
            cmdSaturdayCooked.Visible = false;
        }

        private void cmdSundayCancelled_Click(object sender, EventArgs e)
        {
            lblSundayRecipe.Text = "";
            cmdSundayCancelled.Visible = false;
            cmdSundayCooked.Visible = false;
        }

        private void cmdMondayCooked_Click(object sender, EventArgs e)
        {
            if (lblMondayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblMondayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblMondayRecipe.Text = "";
                cmdMondayCancelled.Visible = false;
                cmdMondayCooked.Visible = false;
            }
        }

        private void cmdTuesdayCooked_Click(object sender, EventArgs e)
        {
            if (lblTuesdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblTuesdayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblTuesdayRecipe.Text = "";
                cmdTuesdayCancelled.Visible = false;
                cmdTuesdayCooked.Visible = false;
            }
        }

        private void cmdWednesdayCooked_Click(object sender, EventArgs e)
        {
            if (lblWednesdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblWednesdayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblWednesdayRecipe.Text = "";
                cmdWednesdayCancelled.Visible = false;
                cmdWednesdayCooked.Visible = false;
            } 
        }

        private void cmdThursdayCooked_Click(object sender, EventArgs e)
        {
            if (lblThursdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblThursdayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblThursdayRecipe.Text = "";
                cmdThursdayCancelled.Visible = false;
                cmdThursdayCooked.Visible = false;
            }
        }

        private void cmdFridayCooked_Click(object sender, EventArgs e)
        {
            if (lblFridayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblFridayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblFridayRecipe.Text = "";
                cmdFridayCancelled.Visible = false;
                cmdFridayCooked.Visible = false;
            }
        }

        private void cmdSaturdayCooked_Click(object sender, EventArgs e)
        {
            if (lblSaturdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblSaturdayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblSaturdayRecipe.Text = "";
                cmdSaturdayCancelled.Visible = false;
                cmdSaturdayCooked.Visible = false;
            }
        }

        private void cmdSundayCooked_Click(object sender, EventArgs e)
        {
            if (lblSundayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblSundayRecipe.Text);
                DeductEachIngredientUsedToCookARecipe(idRecipe);

                lblSundayRecipe.Text = "";
                cmdSundayCancelled.Visible = false;
                cmdSundayCooked.Visible = false;
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeductEachIngredientUsedToCookARecipe(int idRecipe)
        {
            List<Ingredients> listIngredientsToDeduct = _frmMain.dbConn.ReadIngredientsQtyForARecipe(idRecipe);

            foreach (Ingredients ingredientToDeduct in listIngredientsToDeduct)
            {
                // If we have more than requested of the ingredient
                if (ingredientToDeduct.QtyAvailable > ingredientToDeduct.QtyRequested) 
                {
                    ingredientToDeduct.QtyAvailable -= ingredientToDeduct.QtyRequested;
                }

                // If we have less than requested of the ingredient
                else 
                {
                    ingredientToDeduct.QtyAvailable = 0.0;
                }

                ingredientToDeduct.Id = _frmMain.dbConn.ReadIdForAnIngredientName(ingredientToDeduct.Name);
                _frmMain.dbConn.UpdateQtyIngredientAvailable(ingredientToDeduct.Id, ingredientToDeduct.QtyAvailable);
            }

            MessageBox.Show(strings.InfoAmountOfIngredientsNeededDeducted, strings.DeductionFromInventory, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblMondayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblMondayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblMondayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdMondayCancelled.Visible = true;
                cmdMondayCooked.Visible = true;
            }
        }

        private void lblTuesdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblTuesdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblTuesdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdTuesdayCancelled.Visible = true;
                cmdTuesdayCooked.Visible = true;
            }
        }

        private void lblWednesdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblWednesdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblWednesdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdWednesdayCancelled.Visible = true;
                cmdWednesdayCooked.Visible = true;
            }
        }

        private void lblThursdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblThursdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblThursdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdThursdayCancelled.Visible = true;
                cmdThursdayCooked.Visible = true;
            }
        }

        private void lblFridayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblFridayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblFridayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdFridayCancelled.Visible = true;
                cmdFridayCooked.Visible = true;
            }
        }

        private void lblSaturdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblSaturdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblSaturdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdSaturdayCancelled.Visible = true;
                cmdSaturdayCooked.Visible = true;
            }
        }

        private void lblSundayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblSundayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblSundayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdSundayCancelled.Visible = true;
                cmdSundayCooked.Visible = true;
            }
        }
        private void lblMondayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblMondayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdMondayCancelled.Visible = true;
            cmdMondayCooked.Visible = true;
        }

        private void lblTuesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblTuesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdTuesdayCancelled.Visible = true;
            cmdTuesdayCooked.Visible = true;
        }

        private void lblWednesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblWednesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdWednesdayCancelled.Visible = true;
            cmdWednesdayCooked.Visible = true;
        }

        private void lblThursdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblThursdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdThursdayCancelled.Visible = true;
            cmdThursdayCooked.Visible = true;
        }

        private void lblFridayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblFridayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdFridayCancelled.Visible = true;
            cmdFridayCooked.Visible = true;
        }

        private void lblSaturdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSaturdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSaturdayCancelled.Visible = true;
            cmdSaturdayCooked.Visible = true;
        }

        private void lblSundayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSundayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSundayCancelled.Visible = true;
            cmdSundayCooked.Visible = true;
        }

        private void lblMondayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lblTuesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblWednesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblThursdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblFridayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            } 
        }

        private void lblSaturdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblSundayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblMondayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(1, lblMondayRecipe.Text);
        }

        private void lblTuesdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(2, lblTuesdayRecipe.Text);
        }

        private void lblWednesdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(3, lblWednesdayRecipe.Text);
        }

        private void lblThursdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(4, lblThursdayRecipe.Text);
        }

        private void lblFridayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(5, lblFridayRecipe.Text);
        }

        private void lblSaturdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(6, lblSaturdayRecipe.Text);
        }

        private void lblSundayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(7, lblSundayRecipe.Text);
        }


        private void LoadPlannedMealForADay(int idDayOfTheWeek)
        {
            string titlePlannedMeal = _frmMain.dbConn.ReadPlannedMealsForADay(idDayOfTheWeek);

            switch (idDayOfTheWeek)
            {
                case 1:
                    lblMondayRecipe.Text = titlePlannedMeal;
                    break;

                case 2:
                    lblThursdayRecipe.Text = titlePlannedMeal;
                    break;

                case 3:
                    lblWednesdayRecipe.Text = titlePlannedMeal;
                    break;

                case 4:
                    lblThursdayRecipe.Text = titlePlannedMeal;
                    break;

                case 5:
                    lblFridayRecipe.Text = titlePlannedMeal;
                    break;

                case 6:
                    lblSaturdayRecipe.Text = titlePlannedMeal;
                    break;

                case 7:
                    lblSundayRecipe.Text = titlePlannedMeal;
                    break;
            }
        }
    }
}
