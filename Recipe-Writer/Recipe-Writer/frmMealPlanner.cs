/// <file>frmMealPlanner.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2.1</version>
/// <date>August, 4th 2026</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmMealPlanner : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Generic delegate used to load the planned meal for a
        // given day of the week in the corresponding label
        private Action<int> loadPlannedMeal;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmMealPlanner(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();

            // Register buttons in the global dictionary
            UIHoverHelper.ButtonBaseResourceNames[cmdMondayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdMondayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdTuesdayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdTuesdayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdWednesdayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdWednesdayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdThursdayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdThursdayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdFridayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdFridayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdSaturdayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdSaturdayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdSundayCancelled] = "delete";
            UIHoverHelper.ButtonBaseResourceNames[cmdSundayCooked] = "recipeCooked";
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";

            // Buttons hover event
            cmdMondayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdMondayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdMondayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdMondayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdTuesdayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdTuesdayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdTuesdayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdTuesdayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdWednesdayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdWednesdayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdWednesdayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdWednesdayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdThursdayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdThursdayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdThursdayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdThursdayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdFridayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdFridayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdFridayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdFridayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdSaturdayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdSaturdayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdSaturdayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdSaturdayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdSundayCancelled.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdSundayCancelled.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdSundayCooked.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdSundayCooked.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Title
            string windowTitle = strings.MealPlanner;

            if (!string.IsNullOrEmpty(windowTitle))
            {
                this.Text = windowTitle;
            }

            // Labels
            lblMonday.Text = strings.Monday;
            lblTuesday.Text = strings.Tuesday;
            lblWednesday.Text = strings.Wednesday;
            lblThursday.Text = strings.Thursday;
            lblFriday.Text = strings.Friday;
            lblSaturday.Text = strings.Saturday;
            lblSunday.Text = strings.Sunday;
            lblHowToUse.Text = strings.HowToUsePlannerText;
        }
        
        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMealPlanner_Load(object sender, EventArgs e)
        {
            // Reads stored window coordinates
            string storedMealPlannerWindowLastPosition = Properties.Settings.Default.MealPlannerLastPosition;

            bool positionRestored = false;

            // Tries to parse saved coordinates
            if (!string.IsNullOrWhiteSpace(storedMealPlannerWindowLastPosition))
            {
                string[] posCoordinates = storedMealPlannerWindowLastPosition.Split(';');

                if (posCoordinates.Length == 2 &&
                    int.TryParse(posCoordinates[0], out int posX) &&
                    int.TryParse(posCoordinates[1], out int posY))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(posX, posY);
                    positionRestored = true;
                }
            }

            // Default placement: bottom-right corner
            if (!positionRestored)
            {
                Rectangle screenRect = Screen.PrimaryScreen.WorkingArea;

                this.Location = new Point(screenRect.Right - this.Width,
                    screenRect.Bottom - this.Height
                );
            }

            // Loads planned meals for all days (Monday = 1, Sunday = 7)
            for (int idDayOfWeek = 1; idDayOfWeek <= 7; idDayOfWeek++)
            {
                LoadPlannedMealForADay(idDayOfWeek);
            }

            // Loads portion values for each day
            var daysOfWeek = new[]
            {
                new { Id = 1, Nud = nudMondayPortions, Label = lblMondayRecipe },
                new { Id = 2, Nud = nudTuesdayPortions, Label = lblTuesdayRecipe },
                new { Id = 3, Nud = nudWednesdayPortions, Label = lblWednesdayRecipe },
                new { Id = 4, Nud = nudThursdayPortions, Label = lblThursdayRecipe },
                new { Id = 5, Nud = nudFridayPortions, Label = lblFridayRecipe },
                new { Id = 6, Nud = nudSaturdayPortions, Label = lblSaturdayRecipe },
                new { Id = 7, Nud = nudSundayPortions, Label = lblSundayRecipe }
            };

            foreach (var day in daysOfWeek)
            {
                // If a recipe is planned, load its portion count
                if (!string.IsNullOrWhiteSpace(day.Label.Text))
                {
                    int readPortionsForThisDay = _frmMain.dbConn.ReadNbPortionsForADay(day.Id);
                    day.Nud.Value = readPortionsForThisDay;
                    day.Nud.Visible = true;
                }
                
                else
                {
                    day.Nud.Visible = false;
                }
            }

            // Shows buttons for each day where a recipe is planned
            if (!string.IsNullOrEmpty(lblMondayRecipe.Text))
            {
                cmdMondayCancelled.Visible = true;
                cmdMondayCooked.Visible = true;
                nudMondayPortions.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblTuesdayRecipe.Text))
            {
                cmdTuesdayCancelled.Visible = true;
                cmdTuesdayCooked.Visible = true;
                nudTuesdayPortions.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblWednesdayRecipe.Text))
            {
                cmdWednesdayCancelled.Visible = true;
                cmdWednesdayCooked.Visible = true;
                nudWednesdayPortions.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblThursdayRecipe.Text))
            {
                cmdThursdayCancelled.Visible = true;
                cmdThursdayCooked.Visible = true;
                nudThursdayPortions.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblFridayRecipe.Text))
            {
                cmdFridayCancelled.Visible = true;
                cmdFridayCooked.Visible = true;
                nudFridayPortions.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblSaturdayRecipe.Text))
            {
                cmdSaturdayCancelled.Visible = true;
                cmdSaturdayCooked.Visible = true;
                nudSaturdayPortions.Visible = true;
            }

            if (!string.IsNullOrEmpty(lblSundayRecipe.Text))
            {
                cmdSundayCancelled.Visible = true;
                cmdSundayCooked.Visible = true;
                nudSundayPortions.Visible = true;
            }
        }

        private void cmdMondayCancelled_Click(object sender, EventArgs e)
        {
            lblMondayRecipe.Text = "";
            cmdMondayCancelled.Visible = false;
            cmdMondayCooked.Visible = false;
            nudMondayPortions.Visible = false;
        }

        private void cmdTuesdayCancelled_Click(object sender, EventArgs e)
        {
            lblTuesdayRecipe.Text = "";
            cmdTuesdayCancelled.Visible = false;
            cmdTuesdayCooked.Visible = false;
            nudTuesdayPortions.Visible = false;
        }

        private void cmdWednesdayCancelled_Click(object sender, EventArgs e)
        {
            lblWednesdayRecipe.Text = "";
            cmdWednesdayCancelled.Visible = false;
            cmdWednesdayCooked.Visible = false;
            nudWednesdayPortions.Visible = false;
        }

        private void cmdThursdayCancelled_Click(object sender, EventArgs e)
        {
            lblThursdayRecipe.Text = "";
            cmdThursdayCancelled.Visible = false;
            cmdThursdayCooked.Visible = false;
            nudThursdayPortions.Visible = false;
        }

        private void cmdFridayCancelled_Click(object sender, EventArgs e)
        {
            lblFridayRecipe.Text = "";
            cmdFridayCancelled.Visible = false;
            cmdFridayCooked.Visible = false;
            nudFridayPortions.Visible = false;
        }

        private void cmdSaturdayCancelled_Click(object sender, EventArgs e)
        {
            lblSaturdayRecipe.Text = "";
            cmdSaturdayCancelled.Visible = false;
            cmdSaturdayCooked.Visible = false;
            nudSaturdayPortions.Visible = false;
        }

        private void cmdSundayCancelled_Click(object sender, EventArgs e)
        {
            lblSundayRecipe.Text = "";
            cmdSundayCancelled.Visible = false;
            cmdSundayCooked.Visible = false;
            nudSundayPortions.Visible = false;
        }

        private void cmdMondayCooked_Click(object sender, EventArgs e)
        {
            if (lblMondayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblMondayRecipe.Text);
               
                DeductEachIngredientUsedToCookARecipe(idRecipe, 1);
            
                lblMondayRecipe.Text = "";
                cmdMondayCancelled.Visible = false;
                cmdMondayCooked.Visible = false;
                nudMondayPortions.Visible = false;
            }
        }

        private void cmdTuesdayCooked_Click(object sender, EventArgs e)
        {
            if (lblTuesdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblTuesdayRecipe.Text);
                
                DeductEachIngredientUsedToCookARecipe(idRecipe, 2);

                lblTuesdayRecipe.Text = "";
                cmdTuesdayCancelled.Visible = false;
                cmdTuesdayCooked.Visible = false;
                nudTuesdayPortions.Visible = false;
            }
        }

        private void cmdWednesdayCooked_Click(object sender, EventArgs e)
        {
            if (lblWednesdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblWednesdayRecipe.Text);
                
                DeductEachIngredientUsedToCookARecipe(idRecipe, 3);

                lblWednesdayRecipe.Text = "";
                cmdWednesdayCancelled.Visible = false;
                cmdWednesdayCooked.Visible = false;
                nudWednesdayPortions.Visible = false;
            } 
        }

        private void cmdThursdayCooked_Click(object sender, EventArgs e)
        {
            if (lblThursdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblThursdayRecipe.Text);
                
                DeductEachIngredientUsedToCookARecipe(idRecipe, 4);

                lblThursdayRecipe.Text = "";
                cmdThursdayCancelled.Visible = false;
                cmdThursdayCooked.Visible = false;
                nudThursdayPortions.Visible = false;
            }
        }

        private void cmdFridayCooked_Click(object sender, EventArgs e)
        {
            if (lblFridayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblFridayRecipe.Text);
                
                DeductEachIngredientUsedToCookARecipe(idRecipe, 5);

                lblFridayRecipe.Text = "";
                cmdFridayCancelled.Visible = false;
                cmdFridayCooked.Visible = false;
                nudFridayPortions.Visible = false;
            }
        }

        private void cmdSaturdayCooked_Click(object sender, EventArgs e)
        {
            if (lblSaturdayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblSaturdayRecipe.Text);
                
                DeductEachIngredientUsedToCookARecipe(idRecipe, 6);

                lblSaturdayRecipe.Text = "";
                cmdSaturdayCancelled.Visible = false;
                cmdSaturdayCooked.Visible = false;
                nudSaturdayPortions.Visible = false;
            }
        }

        private void cmdSundayCooked_Click(object sender, EventArgs e)
        {
            if (lblSundayRecipe.Text != "")
            {
                int idRecipe = _frmMain.dbConn.ReadRecipeId(lblSundayRecipe.Text);
                
                DeductEachIngredientUsedToCookARecipe(idRecipe, 7);

                lblSundayRecipe.Text = "";
                cmdSundayCancelled.Visible = false;
                cmdSundayCooked.Visible = false;
                nudSundayPortions.Visible = false;
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Deducts ingredient quantities from inventory based on the recipe and
        /// the planned portion count for the specified day.
        /// </summary>
        /// <param name="idRecipe">The recipe identifier.</param>
        /// <param name="idDayOfWeek">Numeric identifier of the day (1 = Monday).</param>
        private void DeductEachIngredientUsedToCookARecipe(int idRecipe, int idDayOfWeek)
        {
            List<Ingredients> listIngredientsToDeduct = _frmMain.dbConn.ReadIngredientsQtyForARecipe(idRecipe);

            int nbPortionsPlannedForThatDay = _frmMain.dbConn.ReadNbPortionsForADay(idDayOfWeek);

            // Computes scaling factor: all recipes are stored in the database for 2 portions.
            double scalingFactor = nbPortionsPlannedForThatDay / 2.0;

            foreach (Ingredients ingredientToDeduct in listIngredientsToDeduct)
            {
                // Computes real quantity to deduct
                double qtyToDeduct = ingredientToDeduct.QtyRequested * scalingFactor;

                // If we have more than requested of the ingredient
                if (ingredientToDeduct.QtyAvailable > qtyToDeduct)
                {
                    ingredientToDeduct.QtyAvailable -= qtyToDeduct;
                }
                
                else
                {
                    ingredientToDeduct.QtyAvailable = 0.0;
                }

                ingredientToDeduct.Id = _frmMain.dbConn.ReadIdForAnIngredientName(ingredientToDeduct.Name);
                _frmMain.dbConn.UpdateQtyIngredientAvailable(ingredientToDeduct.Id, ingredientToDeduct.QtyAvailable);
            }

            MessageBox.Show(strings.InfoAmountOfIngredientsNeededDeducted, strings.DeductionFromInventory,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblMondayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblMondayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblMondayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdMondayCancelled.Visible = true;
                cmdMondayCooked.Visible = true;
                nudMondayPortions.Visible = true;
            }
        }

        private void lblTuesdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblTuesdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblTuesdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdTuesdayCancelled.Visible = true;
                cmdTuesdayCooked.Visible = true;
                nudTuesdayPortions.Visible = true;
            }
        }

        private void lblWednesdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblWednesdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblWednesdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdWednesdayCancelled.Visible = true;
                cmdWednesdayCooked.Visible = true;
                nudWednesdayPortions.Visible = true;
            }
        }

        private void lblThursdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblThursdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblThursdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdThursdayCancelled.Visible = true;
                cmdThursdayCooked.Visible = true;
                nudThursdayPortions.Visible = true;
            }
        }

        private void lblFridayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblFridayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblFridayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdFridayCancelled.Visible = true;
                cmdFridayCooked.Visible = true;
                nudFridayPortions.Visible = true;
            }
        }

        private void lblSaturdayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblSaturdayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblSaturdayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdSaturdayCancelled.Visible = true;
                cmdSaturdayCooked.Visible = true;
                nudSaturdayPortions.Visible = true;
            }
        }

        private void lblSundayRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lblSundayRecipe.Text == "" && _frmMain.lstSearchResults.Text != "")
            {
                lblSundayRecipe.Text = _frmMain.lstSearchResults.Text;
                cmdSundayCancelled.Visible = true;
                cmdSundayCooked.Visible = true;
                nudSundayPortions.Visible = true;
            }
        }
        private void lblMondayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblMondayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdMondayCancelled.Visible = true;
            cmdMondayCooked.Visible = true;
            nudMondayPortions.Visible = true;
        }

        private void lblTuesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblTuesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdTuesdayCancelled.Visible = true;
            cmdTuesdayCooked.Visible = true;
            nudTuesdayPortions.Visible = true;
        }

        private void lblWednesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblWednesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdWednesdayCancelled.Visible = true;
            cmdWednesdayCooked.Visible = true;
            nudWednesdayPortions.Visible = true;
        }

        private void lblThursdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblThursdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdThursdayCancelled.Visible = true;
            cmdThursdayCooked.Visible = true;
            nudThursdayPortions.Visible = true;
        }

        private void lblFridayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblFridayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdFridayCancelled.Visible = true;
            cmdFridayCooked.Visible = true;
            nudFridayPortions.Visible = true;
        }

        private void lblSaturdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSaturdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSaturdayCancelled.Visible = true;
            cmdSaturdayCooked.Visible = true;
            nudSaturdayPortions.Visible = true;
        }

        private void lblSundayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSundayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSundayCancelled.Visible = true;
            cmdSundayCooked.Visible = true;
            nudSundayPortions.Visible = true;
        }


        /// <summary>
        /// Essential DragEnter handler. 
        /// WinForms will not fire DragDrop unless DragEnter explicitly sets 
        /// a valid drop effect. 
        /// This method checks that the incoming payload is text, and if so 
        /// does a Copy operation. 
        /// Without this handshake, the control is never considered a legal drop target.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Updates the planned recipe and its portion count for a specific day.
        /// If the recipe title is null or empty, both the recipe entry and the
        /// portion count are cleared in the database.
        /// </summary>
        /// <param name="idDayOfTheWeek">
        /// Numeric identifier of the day (1 = Monday, 2 = Tuesday, etc.).
        /// </param>
        /// <param name="titleOfTheRecipe">
        /// The recipe title to assign, or null/empty to clear the planned meal.
        /// </param>
        /// <param name="nbPortionsPlanned">
        /// The number of portions planned for that day. When a recipe is newly
        /// assigned, this value is initialized using _frmMain.nudPortions.Value.
        /// </param>
        private void lblMondayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(1, lblMondayRecipe.Text, (int)nudMondayPortions.Value);
        }

        private void lblTuesdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(2, lblTuesdayRecipe.Text, (int)nudTuesdayPortions.Value);
        }

        private void lblWednesdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(3, lblWednesdayRecipe.Text, (int)nudWednesdayPortions.Value);
        }

        private void lblThursdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(4, lblThursdayRecipe.Text, (int)nudThursdayPortions.Value);
        }

        private void lblFridayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(5, lblFridayRecipe.Text, (int)nudFridayPortions.Value);
        }

        private void lblSaturdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(6, lblSaturdayRecipe.Text, (int)nudSaturdayPortions.Value);
        }

        private void lblSundayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(7, lblSundayRecipe.Text, (int)nudSundayPortions.Value);
        }

        /// <summary>
        /// Loads the planned meal for a given day of the week 
        /// and displays it in the corresponding label
        /// </summary>
        /// <param name="idDayOfTheWeek"></param>
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

        /// <summary>
        /// Saves the updated portion count for Monday into the database.
        /// </summary>
        private void nudMondayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblMondayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(1,
                    lblMondayRecipe.Text, (int)nudMondayPortions.Value);
            }
        }

        private void nudTuesdayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblTuesdayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(2,
                    lblTuesdayRecipe.Text, (int)nudTuesdayPortions.Value);
            }
        }

        private void nudWednesdayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblWednesdayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(3,
                    lblWednesdayRecipe.Text, (int)nudWednesdayPortions.Value);
            }
        }

        private void nudThursdayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblThursdayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(4,
                    lblThursdayRecipe.Text, (int)nudThursdayPortions.Value);
            }
        }

        private void nudFridayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblFridayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(5,
                    lblFridayRecipe.Text, (int)nudFridayPortions.Value);
            }
        }

        private void nudSaturdayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblSaturdayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(6,
                    lblSaturdayRecipe.Text, (int)nudSaturdayPortions.Value);
            }
        }

        private void nudSundayPortions_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblSundayRecipe.Text))
            {
                _frmMain.dbConn.UpdatePlannedRecipeForADay(7,
                    lblSundayRecipe.Text, (int)nudSundayPortions.Value);
            }
        }

        /// <summary>
        /// Saves the current window position whenever the form is moved.
        /// </summary>
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);

            // Only saves valid coordinates
            if (this.WindowState == FormWindowState.Normal)
            {
                string newPosition = $"{this.Location.X};{this.Location.Y}";
                Properties.Settings.Default.MealPlannerLastPosition = newPosition;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Provides simple keyboard handling for this form. Pressing ENTER triggers
        /// the validation button (cmdValidate), while pressing ESC closes the window.
        /// This improves basic UX by allowing quick confirmation or cancellation
        /// without using the mouse.
        /// </summary>
        /// <param name="msg">The Windows message associated with the key event.</param>
        /// <param name="keyData">The key combination pressed by the user.</param>
        /// <returns>
        /// true if the key was handled by the form; otherwise false to allow
        /// default processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (cmdValidate != null && cmdValidate.Enabled)
                {
                    cmdValidate.PerformClick();
                }

                return true; 
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true; 
            }

            // Lets the base class handle all other keys
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
