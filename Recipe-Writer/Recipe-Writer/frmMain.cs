/// <file>frmMain.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 12th 2026</date>

using Recipe_Writer.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmMain : Form
    {
        // Private member variables

        // Current recipe instruction rank, used for the instruction layout and
        // for adding new instructions at the end of the list
        private int currentInstruction = 0;

        // Declares and instanciates the forms that will be opened from the main form,
        // to ensure that only one instance of each can be opened at a time
        private static frmInventory _frmInventory;
        private static frmMealPlanner _frmMealPlanner;
        
        // Declares and instanciates the list that will handle the selected instruction
        private List<InstructionSelections> instructionSelection = new List<InstructionSelections>();

        private int selectedInstruction = -1;

        // Public properties

        // Declares and instancies a connection to the database
        public DBConnection dbConn = new DBConnection();
        
        // Declares and instanciates a default instruction
        public static Instructions _defaultInstruction = new Instructions(0, "", 0, 0);

        // Declares and instanciates a default list of instructions
        public static List<Instructions> _defaultListInstructions = new List<Instructions>();

        // Declares and instanciates a default list of ingredients
        public static List<Ingredients> _defaultListIngredients = new List<Ingredients>();

        // Declares and instanciates the current displayed recipe object, constructed with default values, and accessible globally
        public Recipes _currentDisplayedRecipe = new Recipes(0, "", 0, 0, 0, null, _defaultListIngredients, _defaultListInstructions);

        public frmMain(bool enableFadeIn = false)
        {
            InitializeComponent();

            // Optional fade-in animation
            if (enableFadeIn)
            {
                this.Opacity = 0;

                System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
                fadeTimer.Interval = 15;

                fadeTimer.Tick += (s, e) =>
                {
                    if (this.Opacity < 1.0)
                    {
                        this.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                        fadeTimer.Dispose();
                    }
                };

                fadeTimer.Start();
            }

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdNewRecipe] = "new_recipe";
            UIHoverHelper.ButtonBaseResourceNames[cmdTitleSearch] = "search";
            UIHoverHelper.ButtonBaseResourceNames[cmdEditRecipeInfos] = "edit_recipe_info";
            UIHoverHelper.ButtonBaseResourceNames[cmdDeleteRecipe] = "delete_recipe";
            UIHoverHelper.ButtonBaseResourceNames[cmdSearchByIngredient] = "search_by_ingredient";
            UIHoverHelper.ButtonBaseResourceNames[cmdInventory] = "inventory";
            UIHoverHelper.ButtonBaseResourceNames[cmdMealPlanner] = "planner";
            UIHoverHelper.ButtonBaseResourceNames[cmdSettings] = "settings";
            UIHoverHelper.ButtonBaseResourceNames[cmdingredientSearch] = "ingredientSearch";
            UIHoverHelper.ButtonBaseResourceNames[cmdAddInstruction] = "new_instruction";

            // Buttons hover events
            cmdNewRecipe.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdNewRecipe.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdTitleSearch.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdTitleSearch.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdEditRecipeInfos.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdEditRecipeInfos.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdDeleteRecipe.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdDeleteRecipe.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdSearchByIngredient.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdSearchByIngredient.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdInventory.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdInventory.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdMealPlanner.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdMealPlanner.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdSettings.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdSettings.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdingredientSearch.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdingredientSearch.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdAddInstruction.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdAddInstruction.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Labels
            lblSearchResults.Text = strings.SearchResults;

            // Contextual menu items
            newRecipeToolStripMenuItem.Text = strings.ToolStripMenuItemNewRecipe;
            editThisRecipesInfosToolStripMenuItem.Text = strings.ToolStripMenuItemEditBasicInfos;
            deleteThisRecipeToolStripMenuItem.Text = strings.ToolStripMenuItemDeleteThisRecipe;
            exportThisRecipeToAWebPageToolStripMenuItem.Text = strings.ToolStripMenuItemExportThisRecipeToAWebPage;
            planRecipeOn.Text = strings.ToolStripMenuItemPlanThisRecipeFor;
            addIngredientToThisRecipe.Text = strings.ToolStripMenuItemAddIngredientToThisRecipe;

            mondayToolStripMenuItem.Text = strings.ToolStripMenuItemMonday;
            tuesdayToolStripMenuItem.Text = strings.ToolStripMenuItemTuesday;
            wednesdayToolStripMenuItem.Text = strings.ToolStripMenuItemWednesday;
            thursdayToolStripMenuItem.Text = strings.ToolStripMenuItemThursday;
            fridayToolStripMenuItem.Text = strings.ToolStripMenuItemFriday;
            saturdayToolStripMenuItem.Text = strings.ToolStripMenuItemSaturday;
            sundayToolStripMenuItem.Text = strings.ToolStripMenuItemSunday;
        }

        /// <summary>
        /// Form load
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            int nbPersonsSet = Properties.Settings.Default.NbPersonsSet;
            nudPersons.Value = nbPersonsSet;

            txtTitleSearch.Focus();

            // Checks if the database file exists or not
            if (File.Exists(@Environment.CurrentDirectory + "\\" + "recipe-album" + ".db"))
            {
                // Opens the connexion
                dbConn.Open();

                // Checks if the database integrity is valid
                bool DBvalid = dbConn.CheckDBIntegrity();

                // If the database is corrupted
                if (!DBvalid)
                {
                    MessageBox.Show(strings.ErrorDatabaseCorrupted + "\n" + strings.BaseWillBeRebuilt, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Creates the database file recipe-album.db and its tables then fill-in the data
                    dbConn.CreateTables();
                    dbConn.InsertInitialData();
                }
            }

            // If the database file cannot be found in the application directory
            else
            {
                MessageBox.Show(strings.DBfileNotFound + "\n" + strings.DBWillBeBuiltWithInitialData, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Creates the database file in the app's installation folder
                dbConn.CreateFile();

                // Opens the connexion
                dbConn.Open();

                // Creates the database file recipe-album.db and its tables then fill-in the data
                dbConn.CreateTables();
                dbConn.InsertInitialData();
            }
        }

        private void addIngredientToThisRecipe_Click(object sender, EventArgs e)
        {
            frmAddNewIngredientToRecipe _frmAddNewNewIngredientToRecipe = new frmAddNewIngredientToRecipe(this);
            _frmAddNewNewIngredientToRecipe.Show();
        }

        /// <summary>
        /// Calculates if all ingredients needed for a recipe are in enough quantity in the inventory
        /// </summary>
        /// <param name="listOfIngredientsNeeded"</param>
        /// <returns>the status of a recipe : ready for cooking or not</returns>
        public bool CalculateRecipeReadyToCookStatus(List<Ingredients> listOfIngredientsNeeded)
        {
            bool RecipeIsReadyToCook = true;

            foreach (Ingredients ingredientNeeded in listOfIngredientsNeeded)
            {
                // If the ingredient is missing
                if (ingredientNeeded.QtyRequested > ingredientNeeded.QtyAvailable)
                {
                    RecipeIsReadyToCook = false;
                }
            }

            return RecipeIsReadyToCook;
        }

        /// <summary>
        /// Function that animates the close of the panel content
        /// </summary>
        private void ClosePanel()
        {
            if (pnlSlideMenu.Visible)
            {
                // Closing slide menu animation
                Animations.Animate(pnlSlideMenu, Animations.Effect.Slide, 150, 360);
                this.Refresh();
            }
        }
        private void cmbRecipeIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            // An ingredient of the combobox has been selected and there's at least one.
            if (cmbRecipeIngredients.SelectedIndex >= 1 && cmbRecipeIngredients.Items.Count >= 2)
            { 
                if (cmsRecipeResult.Items[7].Enabled == false)
                {
                    cmsRecipeResult.Items[7].Enabled = true;
                }
            }

            // No ingredient has been selected
            else
            {
                if (cmsRecipeResult.Items[7].Enabled == true)
                {
                    cmsRecipeResult.Items[7].Enabled = false;
                }
            }
        }


        /// <summary>
        /// Function to add an instruction to the currently selected recipe
        /// </summary>
        private void cmdAddInstruction_Click(object sender, EventArgs e)
        {
            frmNewInstruction _frmNewInstruction = new frmNewInstruction(this);
            _frmNewInstruction.IdRecipeToEdit = _currentDisplayedRecipe.Id;
            _frmNewInstruction.NbInstructionsInCurrentRecipe = currentInstruction;
            _frmNewInstruction.ShowDialog();
        }

        private void cmdAddInstruction_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cmdAddInstruction_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmdDeleteRecipe_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(strings.ConfirmDeleteDisplayedRecipeFromDB,
                strings.ConfirmDeletion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                dbConn.DeleteRecipe(_currentDisplayedRecipe.Id);
                HidesRecipeInfosAndControls();
            }
        }

        private void cmdEditRecipeInfos_Click(object sender, EventArgs e)
        {
            string formattedTitle = lstSearchResults.SelectedItem.ToString();

            // Checks if the keywords contain an apostroph, to avoid making the sql request crash
            if (lstSearchResults.SelectedItem.ToString().Contains("'"))
            {
                formattedTitle = txtTitleSearch.Text.Replace("'", "''");
            }


            frmEditRecipeInfos _frmEditRecipeTitle = new frmEditRecipeInfos(this);
            _frmEditRecipeTitle.IdRecipeToEdit = _currentDisplayedRecipe.Id;
            _frmEditRecipeTitle.RecipeTitleToEdit = _currentDisplayedRecipe.Title;
            _frmEditRecipeTitle.RecipeCompletionTime = _currentDisplayedRecipe.CompletionTime;
            _frmEditRecipeTitle.LowBudgetStatus = _currentDisplayedRecipe.LowBudget;
            _frmEditRecipeTitle.ShowDialog();
        }

        private void cmdingredientSearch_Click(object sender, EventArgs e)
        {
            // If the user has typed something in one of the textboxes
            if (txtSearchIngredient1.Text != "" || txtSearchIngredient2.Text != "" || txtSearchIngredient3.Text != "")
            {
                ClosePanel();

                //--- Normal ingredient search -------------
                if (!chkFilterRecipesForSmallBudget.Checked && !chkFilterRecipesForThreeStars.Checked)
                {
                    SearchRecipesByIngredients(txtSearchIngredient1.Text, txtSearchIngredient2.Text, txtSearchIngredient3.Text);
                }

                //--- Low budget recipes search ------------
                else if (chkFilterRecipesForSmallBudget.Checked && !chkFilterRecipesForThreeStars.Checked)
                {
                    SearchRecipesByIngredients(txtSearchIngredient1.Text, txtSearchIngredient2.Text, txtSearchIngredient3.Text, true);
                }

                //--- Three stars recipes search -------------
                else if (!chkFilterRecipesForSmallBudget.Checked && chkFilterRecipesForThreeStars.Checked)
                {
                    SearchRecipesByIngredients(txtSearchIngredient1.Text, txtSearchIngredient2.Text, txtSearchIngredient3.Text, false, true);
                }

                //--- Low budget and three stars recipes search ------------
                else if (chkFilterRecipesForSmallBudget.Checked && chkFilterRecipesForThreeStars.Checked)
                {
                    SearchRecipesByIngredients(txtSearchIngredient1.Text, txtSearchIngredient2.Text, txtSearchIngredient3.Text, true, true);
                }
            }
            // If all the textboxes are empty
            else
            {
                MessageBox.Show(strings.ErrorMustEnterAtLeastOneIngredient, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdInventory_Click(object sender, EventArgs e)
        {
            if (_frmInventory != null && !_frmInventory.IsDisposed)
            {
                _frmInventory.Close();
                _frmInventory = null;
            }
            else
            {
                ShowInventory();
            }
        }

        private void cmdInventory_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cmdInventory_MouseLeave(object sender, EventArgs e)
        {

        }
        private void cmdMealPlanner_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cmdMealPlanner_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmdMealPlanner_Click(object sender, EventArgs e)
        {
            if (_frmMealPlanner != null && !_frmMealPlanner.IsDisposed)
            {
                _frmMealPlanner.Close();
                _frmMealPlanner = null;
            }
            else
            {
                _frmMealPlanner = new frmMealPlanner(this);
                _frmMealPlanner.Show();
            }
        }

        private void cmdNewRecipe_Click(object sender, EventArgs e)
        {
            cmsRecipeResult.Items[0].PerformClick();
        }

        /// <summary>
        /// Toggles the slide menu to search for recipes by ingredients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearchByIngredient_Click(object sender, EventArgs e)
        {
            if (!pnlSlideMenu.Visible)
            {
                // Opening slide menu animation
                pnlSlideMenu.Width = 450;
                Animations.Animate(pnlSlideMenu, Animations.Effect.Slide, 250, 0);
                this.Refresh();
            }

            else
            {
                ClosePanel();
            }
        }

        private void cmdSearchByIngredient_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cmdSearchByIngredient_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            frmSettings _frmSettings = new frmSettings(this);
            _frmSettings.ShowDialog();
        }


        private void cmdSettings_MouseEnter(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Visible)
            {
                ClosePanel();
            }
        }

        private void cmdSettings_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmdTitleSearch_Click(object sender, EventArgs e)
        {
            // If the user has typed something in the textbox
            if (txtTitleSearch.Text != "")
            {
                SearchRecipesByTitle(txtTitleSearch.Text);
            }
            // If the search textbox is empty
            else
            {
                SearchRecipesByTitle("*");
            }
        }

        /// <summary>
        /// Creates the instruction layout to display them to the user.
        /// User can edit an instruction by clicking the edit button or double-clicking the label.
        /// </summary>
        public void CreateInstructionsLayout()
        {
            currentInstruction = 0;

            // Layout parameters =================================================================================
            int lineHeight = 20;
            int iconHeight = 25;
            int iconWidth = 25;
            int spacingWidth = 15;
            int spacingHeight = 5;

            // Clears the layout by removing all the labels, before adding new ones
            this.pnlInstructions.Controls.Clear();

            foreach (Instructions instructionItem in _currentDisplayedRecipe.InstructionsList)
            {
                // Label that displays the title of the current instruction
                Label lblInstruction = new Label();

                // Shows a border around a label when the mouse hovers it
                lblInstruction.MouseHover += (object sender_here, EventArgs e_here) =>
                {
                    lblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                };

                // Hides the border around a label when the mouse leaves it
                lblInstruction.MouseLeave += (object sender_here, EventArgs e_here) =>
                {
                    lblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
                };

                // Handles the event to make an instruction label appear selected when the user clicks on it
                lblInstruction.Click += (object sender_here, EventArgs e_here) =>
                {
                    int selectedInstruction = instructionItem.Rank;
                    RefreshSelectedInstruction();
                };

                // Binds the label to its related instruction =================================================================================
                InstructionSelections instructionSelected = new InstructionSelections();
                instructionSelected.InstructionRank = instructionItem.Rank;
                instructionSelected.InstructionLabel = lblInstruction;
                instructionSelection.Add(instructionSelected);

                // Edit instruction button code ==============================================================================================

                Button cmdEditInstruction = new Button();
                cmdEditInstruction.Click += (object sender_here, EventArgs e_here) =>
                {
                    // Check if a TextBox already exists
                    TextBox txtInputUser = lblInstruction.Controls.OfType<TextBox>().FirstOrDefault();

                    if (txtInputUser != null)
                    {
                        // Update text and remove TextBox
                        lblInstruction.Text = txtInputUser.Text;
                        dbConn.UpdateInstruction(instructionItem.Id, txtInputUser.Text);
                        txtInputUser.Dispose();

                        // Restore edit button icon
                        cmdEditInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.edit;
                    }
                    else
                    {
                        // Create TextBox
                        txtInputUser = new TextBox
                        {
                            Parent = lblInstruction,
                            Size = lblInstruction.Size,
                            Text = lblInstruction.Text
                        };

                        // Apply changes when focus is lost
                        txtInputUser.Leave += (s, e) =>
                        {
                            lblInstruction.Text = txtInputUser.Text;
                            dbConn.UpdateInstruction(instructionItem.Id, txtInputUser.Text);
                            txtInputUser.Dispose();
                            cmdEditInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.edit;
                        };

                        // Show the TextBox for editing
                        txtInputUser.Show();
                        cmdEditInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.validate;
                    }
                };

                // Handles the event to make an instruction label editable
                lblInstruction.DoubleClick += (object sender_here, EventArgs e_here) => { cmdEditInstruction.PerformClick(); };

                // Delete instruction code ================================================================================================

                Button cmdDeleteInstruction = new Button();
                cmdDeleteInstruction.Click += (object sender_here, EventArgs e_here) =>
                {
                    var confirmResult = MessageBox.Show(strings.ConfirmDeleteInstruction,
                    strings.ConfirmDeletion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        dbConn.DeleteInstruction(_currentDisplayedRecipe.Id, instructionItem.Rank);

                        // Loads all the instructions for the currently selected recipe
                        CreateInstructionsLayout();
                    }
                };

                // Instruction label, detailed layout =========================================================================================
                lblInstruction.Text = instructionItem.Text;
                lblInstruction.Width = 550;
                lblInstruction.Height = lineHeight;
                lblInstruction.Location = new Point(20, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);
                lblInstruction.TextAlign = ContentAlignment.MiddleLeft;
                lblInstruction.ForeColor = Color.Black;

                // Edit button for an instruction ==============================================================================================
                cmdEditInstruction.Text = "";
                cmdEditInstruction.Width = iconWidth;
                cmdEditInstruction.Height = iconHeight;
                cmdEditInstruction.Location = new Point(lblInstruction.Width, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);
                cmdEditInstruction.BackColor = Color.Transparent;
                cmdEditInstruction.FlatAppearance.BorderSize = 0;
                cmdEditInstruction.FlatStyle = FlatStyle.Flat;
                cmdEditInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.edit;
                cmdEditInstruction.BackgroundImageLayout = ImageLayout.Zoom;

                // Delete button for an instruction, detailed layout =========================================================================
                cmdDeleteInstruction.Text = "";
                cmdDeleteInstruction.Width = iconWidth;
                cmdDeleteInstruction.Height = iconHeight;
                cmdDeleteInstruction.Location = new Point(lblInstruction.Width + spacingWidth + cmdEditInstruction.Width, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);
                cmdDeleteInstruction.BackColor = Color.Transparent;
                cmdDeleteInstruction.FlatAppearance.BorderSize = 0;
                cmdDeleteInstruction.FlatStyle = FlatStyle.Flat;
                cmdDeleteInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.delete;
                cmdDeleteInstruction.BackgroundImageLayout = ImageLayout.Zoom;

                // Corrects the layout for the panel ============================================================================================
                cmdEditInstruction.Location = new Point(20 + lblInstruction.Width  + spacingWidth, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);
                cmdDeleteInstruction.Location = new Point(20 + lblInstruction.Width + spacingWidth + cmdEditInstruction.Width + spacingWidth, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);

                // Adds the controls to the layout ============================================================================================
                pnlInstructions.Controls.Add(lblInstruction);
                pnlInstructions.Controls.Add(cmdEditInstruction);
                pnlInstructions.Controls.Add(cmdDeleteInstruction);

                currentInstruction += 1;
            }
        }

        private void deleteSelectedIngredientFromThisRecipe_Click(object sender, EventArgs e)
        {
            if (cmbRecipeIngredients.Items.Count >= 2 && cmbRecipeIngredients.SelectedIndex >= 1)
            {
                // If the ingredient has been correctly deleted, the function returns true
                if (dbConn.DeleteIngredientFromARecipe(_currentDisplayedRecipe.Id, cmbRecipeIngredients.SelectedIndex) == true) 
                {
                    dbConn.OffsetRowValuesToLeft(_currentDisplayedRecipe.Id);
                    DisplayRecipeInfos(_currentDisplayedRecipe.Id);
                }

            }

            else
            {
                MessageBox.Show(strings.ErrorNoIngredientSelected, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteThisRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdDeleteRecipe.PerformClick();
        }

        /// <summary>
        /// Event when the user selects a recipe in the search result list control
        /// </summary>
        public void DisplayRecipeControls()
        {
            cmsRecipeResult.Items[1].Enabled = true;
            cmsRecipeResult.Items[2].Enabled = true;
            cmsRecipeResult.Items[3].Enabled = true;
            cmsRecipeResult.Items[4].Enabled = true;
            cmsRecipeResult.Items[6].Enabled = true;

            nudPersons.Visible = true;
            lblPortions.Visible = true;
            lblCompletionTime.Visible = true;
            cmbRecipeIngredients.Visible = true;
            picRecipeReadyToCookStatus.Visible = true;
            cmdAddInstruction.Visible = true;
            pnlScore.Visible = true;
            picScore1.Visible = true;
            picScore2.Visible = true;
            picScore3.Visible = true;
        }

        /// <summary>
        /// Displays the ingredients, image and instructions for the selected recipe
        /// </summary>
        public void DisplayRecipeInfos(int idRecipe)
        {
            // Ensures something is selected in the listbox
            if (lstSearchResults.SelectedItem == null)
            {
                return;
            }

            // Ensure _currentDisplayedRecipe is not null
            if (_currentDisplayedRecipe == null)
            {
                return;
            }

            // Title
            string selectedTitle = lstSearchResults.SelectedItem.ToString();
            if (!string.IsNullOrWhiteSpace(selectedTitle))
            {
                _currentDisplayedRecipe.Title = selectedTitle;
            }

            // DB reads with safety guards
            _currentDisplayedRecipe.CompletionTime = dbConn.ReadRecipeCompletionTime(idRecipe);
            _currentDisplayedRecipe.LowBudget = dbConn.ReadRecipeLowBudgetStatus(idRecipe);
            _currentDisplayedRecipe.Score = dbConn.ReadRecipeScore(idRecipe);

            string imagePath = dbConn.ReadRecipeImagePath(idRecipe);
            _currentDisplayedRecipe.ImagePath = imagePath ?? "";

            // Completion time
            lblCompletionTime.Text = "";
            lblCompletionTime.Text += strings.Preparation + _currentDisplayedRecipe.CompletionTime + " min.";

            // Low budget icon
            picLowBudget.Visible = (_currentDisplayedRecipe.LowBudget == 1);

            // Ingredients list
            _currentDisplayedRecipe.IngredientsList = dbConn.ReadIngredientsQtyForARecipe(_currentDisplayedRecipe.Id);

            cmbRecipeIngredients.Items.Clear();
            cmbRecipeIngredients.Items.Add(strings.NecessaryIngredients);

            if (_currentDisplayedRecipe.IngredientsList != null)
            {
                foreach (Ingredients ingredientToAdd in _currentDisplayedRecipe.IngredientsList)
                {
                    if (ingredientToAdd == null)
                    {
                        continue;
                    }

                    string scaleIngredientToAdd = dbConn.ReadScaleNameForAnID(ingredientToAdd.Scale_id);
                    string connector = strings.IngredientConnector;

                    cmbRecipeIngredients.Items.Add(ingredientToAdd.QtyRequested + " " +
                        scaleIngredientToAdd + " " +  connector + " " + ingredientToAdd.Name);
                }
            }

            // Ensures index exists
            if (cmbRecipeIngredients.Items.Count > 0)
            {
                cmbRecipeIngredients.SelectedIndex = 0;
            }

            // Ready to cook status
            if (_currentDisplayedRecipe.IngredientsList != null &&
                CalculateRecipeReadyToCookStatus(_currentDisplayedRecipe.IngredientsList))
            {
                picRecipeReadyToCookStatus.BackgroundImage = Resources.recipe_status_green;
            }
            
            else
            {
                picRecipeReadyToCookStatus.BackgroundImage = Resources.recipe_status_red;
            }

            // Score
            picScore1.BackgroundImage = Resources._1_star_disabled;
            picScore2.BackgroundImage = Resources._1_star_disabled;
            picScore3.BackgroundImage = Resources._1_star_disabled;

            if (_currentDisplayedRecipe.Score >= 1)
            {
                picScore1.BackgroundImage = Resources._1_star;
            }
            if (_currentDisplayedRecipe.Score >= 2)
            {
                picScore2.BackgroundImage = Resources._1_star;
            }
            if (_currentDisplayedRecipe.Score >= 3)
            {
                picScore3.BackgroundImage = Resources._1_star;
            }

            // Instructions
            _currentDisplayedRecipe.InstructionsList = dbConn.ReadInstructionsForARecipe(_currentDisplayedRecipe.Id);
            CreateInstructionsLayout();

            // Illustration
            string fullImagePath = Environment.CurrentDirectory + "\\illustrations\\" + _currentDisplayedRecipe.ImagePath + ".jpg";

            if (!string.IsNullOrWhiteSpace(_currentDisplayedRecipe.ImagePath) &&
                File.Exists(fullImagePath))
            {
                try
                {
                    picRecipe.BackgroundImage = Image.FromFile(fullImagePath);
                    picRecipe.BorderStyle = BorderStyle.None;
                }
                catch
                {
                    picRecipe.BackgroundImage = null;
                    picRecipe.BorderStyle = BorderStyle.None;
                }
            }
            else
            {
                picRecipe.BackgroundImage = null;
                picRecipe.BorderStyle = BorderStyle.None;
            }
        }

        private void editThisRecipesInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdEditRecipeInfos.PerformClick();
        }

        /// <summary>
        /// Ensures that the recipe controls on the main form are visible.
        /// If they are currently hidden (e.g., after switching language or refreshing the UI),
        public void EnsureRecipeControlsVisible()
        {
            if (!nudPersons.Visible)
            {
                DisplayRecipeControls();
            }
        }


        /// <summary>
        /// Exports the currently displayed recipe to a styled HTML web page.
        /// Opens a SaveFileDialog to let the user choose the file name and location,
        /// then generates the HTML content (including title, image, ingredients, and instructions),
        /// writes it to disk, and notifies the user of success or failure.
        /// </summary>
        private void exportThisRecipeToAWebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Detects current UI culture
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            // Uses localized strings from Resources
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = strings.ExportToHTMLDialogFilter,
                Title = strings.ExportToHTMLDialogTitle,
                FileName = _currentDisplayedRecipe.Title + ".html"
            };

            var dialogResult = saveFileDialog1.ShowDialog();

            // Proceeds only if a valid filename was provided and the user did not cancel
            if (!string.IsNullOrEmpty(saveFileDialog1.FileName) && dialogResult != DialogResult.Cancel)
            {
                try
                {
                    // Uses StringBuilder for efficient string concatenation
                    var stringBuilder = new StringBuilder();

                    // Starts HTML document with embedded CSS styles
                    stringBuilder.Append(@"
                                        <html>
                                        <head>
                                            <style>
                                                body {
                                                    font-family: Arial, sans-serif;
                                                    line-height: 1.6;
                                                    margin: 20px;
                                                    padding: 20px;
                                                    background-color: #f8f8f8;
                                                }
                                                h1 { color: #333; }
                                                .ingredients, .instructions { margin-bottom: 20px; }
                                                .ingredients ul { list-style-type: square; }
                                                .recipe-image {
                                                    max-width: 30%;
                                                    height: auto;
                                                    margin-bottom: 20px;
                                                }
                                            </style>
                                        </head>
                                        <body>
                                            <h1>" + _currentDisplayedRecipe.Title + @"</h1>");

                    // Adds recipe image if the file exists
                    if (File.Exists(Environment.CurrentDirectory + "\\illustrations\\" + _currentDisplayedRecipe.ImagePath + ".jpg"))
                    {
                        stringBuilder.Append("<img src='./illustrations/" + _currentDisplayedRecipe.ImagePath + ".jpg' " +
                            "alt='recipe-image' class='recipe-image' />");
                    }

                    // Adds preparation time
                    stringBuilder.Append("<p>Preparation time: " + _currentDisplayedRecipe.CompletionTime + " minutes.</p>");

                    // Adds ingredients list
                    stringBuilder.Append(@"
                                        <div class='ingredients'>
                                        <h2>Ingredients</h2>
                                        <ul>");

                    foreach (var ingredient in _currentDisplayedRecipe.IngredientsList)
                    {
                        stringBuilder.Append("<li>" + ingredient.QtyRequested + " " +
                            dbConn.ReadScaleNameForAnID(ingredient.Scale_id) + " " +
                            ingredient.Name + "</li>");
                    }

                    stringBuilder.Append(@"
                                        </ul>
                                        </div>
                                        <div class='instructions'>
                                        <h2>Instructions</h2>
                                        <ul>");

                    // Adds instructions list
                    foreach (var instruction in _currentDisplayedRecipe.InstructionsList)
                    {
                        stringBuilder.Append("<li>" + instruction.Text + "</li>");
                    }

                    stringBuilder.Append(@"
                                        </ul>
                                        </div>
                                        </body>
                                        </html>");

                    // Writes the generated HTML to the chosen file
                    File.WriteAllText(saveFileDialog1.FileName, stringBuilder.ToString());

                    // Notifies the user of success
                    MessageBox.Show(strings.InfoRecipeExported, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Notifies the user of any error during export
                    MessageBox.Show(string.Format(strings.ErrorExport, ex.Message), strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Visible)
            {
                ClosePanel();
            }
        }

        /// <summary>
        /// Hides the ingredients, image and instructions and the controls for the current displayed recipe
        /// </summary>
        public void HidesRecipeInfosAndControls()
        {
            _currentDisplayedRecipe.Title = "";
            _currentDisplayedRecipe.CompletionTime = 0;
            _currentDisplayedRecipe.LowBudget = 0;
            _currentDisplayedRecipe.Score = 0;
            _currentDisplayedRecipe.ImagePath = "";
            _currentDisplayedRecipe.IngredientsList.Clear();
            _currentDisplayedRecipe.InstructionsList.Clear();

            pnlScore.Visible = false;
            picScore1.Visible = false;
            picScore2.Visible = false;
            picScore3.Visible = false;
            picLowBudget.Visible = false;
            picRecipe.BackgroundImage = null;
            picRecipe.BorderStyle = BorderStyle.FixedSingle;
            picRecipeReadyToCookStatus.Visible = false;

            cmdAddInstruction.Visible = false;
            cmbRecipeIngredients.Items.Clear();
            cmbRecipeIngredients.Visible = false;
            lblCompletionTime.Text = "";
            lblPortions.Visible = false;
            lblCompletionTime.Visible = false;
            lstSearchResults.Items.Clear();
            nudPersons.Visible = false;
            

            cmsRecipeResult.Items[1].Enabled = false;
            cmsRecipeResult.Items[2].Enabled = false;
            cmsRecipeResult.Items[3].Enabled = false;
            cmsRecipeResult.Items[4].Enabled = false;
            cmsRecipeResult.Items[6].Enabled = false;
            cmsRecipeResult.Items[7].Enabled = false;

            
            pnlInstructions.Controls.Clear();

            this.Refresh();
        }

        private void lblSearchIngredient1_Click(object sender, EventArgs e)
        {
            txtSearchIngredient1.Focus();
        }

        private void lblSearchIngredient2_Click(object sender, EventArgs e)
        {
            txtSearchIngredient2.Focus();
        }

        private void lblSearchIngredient3_Click(object sender, EventArgs e)
        {
            txtSearchIngredient3.Focus();
        }

        /// <summary>
        /// Event when the user double-clicks on a recipe in the search result list
        /// </summary>
        private void lstSearchResults_DoubleClick(object sender, EventArgs e)
        {
            // Ensures that a valid item is selected before triggering edit
            if (lstSearchResults.Items.Count < 1 ||
                string.IsNullOrWhiteSpace(lstSearchResults.SelectedItem?.ToString()))
            {
                return; // Exits early if no valid selection
            }

            cmdEditRecipeInfos.PerformClick();
        }

        /// <summary>
        /// Allows the user to drag and drop the selected recipe title
        /// Adapted from this reference : https://docs.microsoft.com/en-us/dotnet/framework/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSearchResults_MouseMove(object sender, MouseEventArgs e)
        {
            if (lstSearchResults.SelectedIndex != -1 && e.Button == MouseButtons.Left)
            {
                lstSearchResults.DoDragDrop(lstSearchResults.SelectedItem.ToString(), DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Event when the user selects a recipe in the search result list control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensures that a valid item is selected before executing SQL
            if (lstSearchResults.Items.Count < 1 ||
                string.IsNullOrWhiteSpace(lstSearchResults.SelectedItem?.ToString()))
            {
                // Disables edit/delete buttons when no valid recipe is selected
                cmdEditRecipeInfos.Enabled = false;
                cmdDeleteRecipe.Enabled = false;
                return; // Exits early if no selection
            }

            // Retrieves the recipe ID from the database using the selected item
            _currentDisplayedRecipe.Id = dbConn.ReadRecipeId(lstSearchResults.SelectedItem.ToString());

            // Displays recipe information in the UI
            DisplayRecipeInfos(_currentDisplayedRecipe.Id);

            // Shows recipe controls if they are not already visible
            if (!nudPersons.Visible)
            {
                DisplayRecipeControls();
            }

            // Enables edit/delete buttons when a valid recipe is selected
            cmdEditRecipeInfos.Enabled = true;
            cmdDeleteRecipe.Enabled = true;
        }

        private void mondayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(1, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
            else
            {
                _frmMealPlanner.BringToFront();
            }
        }

        private void tuesdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(2, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
        }

        private void wednesdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(3, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
        }

        private void thursdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(4, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
        }

        private void fridayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(5, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
        }

        private void saturdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(6, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
        }

        private void sundayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConn.UpdatePlannedRecipeForADay(7, _currentDisplayedRecipe.Title);

            if (_frmMealPlanner == null || _frmMealPlanner.IsDisposed)
            {
                ShowMealPlanner();
            }
        }

        private void newRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewRecipeInfosInput _frmNewRecipeInfosInput = new frmNewRecipeInfosInput(this);
            _frmNewRecipeInfosInput.ShowDialog();
        }


        /// <summary>
        /// Handles the re-calculation of the quantity of each ingredient for the currently displayed recipe
        /// </summary>
        private void nudPersons_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NbPersonsSet = Convert.ToInt32(nudPersons.Value);

            // Save value for next sessions
            Properties.Settings.Default.Save();

            // Calls the function that will read the ingredients needed to make the recipe
            DisplayRecipeInfos(_currentDisplayedRecipe.Id);
        }
     

        /// <summary>
        /// Opens OpenFileDialog instance and affects the selected file to the picture box
        /// </summary>
        private void picRecipe_Click(object sender, EventArgs e)
        {
            if (nudPersons.Visible) 
            {
                // Wraps the creation of the OpenFileDialog instance in a using statement,
                // rather than manually calling the Dispose method to ensure proper disposal
                using (ofdAssociatedImage)
                {
                    if (ofdAssociatedImage.ShowDialog() == DialogResult.OK)
                    {
                        // Displays the image in the picturebox on the form       
                        picRecipe.Load(ofdAssociatedImage.FileName);
                        picRecipe.BorderStyle = BorderStyle.None;

                        // Shows a dialog form which asks the user to provide a file name for the new image
                        frmNewImagePath _frmNewImagePath = new frmNewImagePath(this);
                        _frmNewImagePath.Show();
                    }
                }
            }
        }

        private void picRecipeReadyToCookStatus_MouseHover(object sender, EventArgs e)
        {
            ttpRecipeReadyToCookStatus.Show(strings.ToolTipRecipeReadyToCookStatusText, picRecipeReadyToCookStatus);
        }

        private void picScore1_Click(object sender, EventArgs e)
        {
            UpdateScoreForCurrentRecipe(1);
        }

        private void picScore2_Click(object sender, EventArgs e)
        {
            UpdateScoreForCurrentRecipe(2);
        }

        private void picScore3_Click(object sender, EventArgs e)
        {
            UpdateScoreForCurrentRecipe(3);
        }

        private void pnlScore_MouseHover(object sender, EventArgs e)
        {
            picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
            picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
            picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
        }

        private void picScore1_MouseHover(object sender, EventArgs e)
        {
            picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
            picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
            picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
        }

        private void picScore2_MouseHover(object sender, EventArgs e)
        {
            picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
            picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
            picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
        }

        private void picScore3_MouseHover(object sender, EventArgs e)
        {
            picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
            picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
            picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
        }

        private void pnlScore_MouseLeave(object sender, EventArgs e)
        {
            if (_currentDisplayedRecipe.Score == 0)
            {
                picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
                picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
                picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;

            }
            else if (_currentDisplayedRecipe.Score == 1)
            {
                picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
                picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;
                picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;

            }
            else if (_currentDisplayedRecipe.Score == 2)
            {
                picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
                picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
                picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star_disabled;

            }
            else if (_currentDisplayedRecipe.Score == 3)
            {
                picScore1.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
                picScore2.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
                picScore3.BackgroundImage = Recipe_Writer.Properties.Resources._1_star;
            }
        }

        /// <summary>
        /// Changes the background color of the selected instruction and changes the background to transparent for the unselected instructions
        /// </summary>
        public void RefreshSelectedInstruction()
        {
            for (int i = 0; i < instructionSelection.Count; ++i)
            {
                if (instructionSelection[i].InstructionRank == selectedInstruction)
                {
                    if (instructionSelection[i].InstructionLabel.BackColor == Color.Transparent)
                    {
                        instructionSelection[i].InstructionLabel.BackColor = Color.FromArgb(168, 208, 230);
                    }
                    else
                    {
                        instructionSelection[i].InstructionLabel.BackColor = Color.Transparent;
                    }
                }
                else
                {
                    instructionSelection[i].InstructionLabel.BackColor = Color.Transparent;
                }
            }
        }


        /// <summary>
        /// Searches for recipes based on ingredients input and optional filters.
        /// </summary>
        private void SearchRecipesByIngredients(string ingredient1ToSearchFor, string ingredient2ToSearchFor, string ingredient3ToSearchFor, bool filterForSmallBudget = false, bool filterForThreeStars = false)
        {
            
            lstSearchResults.Items.Clear();
            txtTitleSearch.Text = "";

            List<string> searchIngredientsInputList = new List<string>();

            if (!string.IsNullOrWhiteSpace(ingredient1ToSearchFor))
            {
                searchIngredientsInputList.Add(ingredient1ToSearchFor.Replace("'", "''"));
            }

            if (!string.IsNullOrWhiteSpace(ingredient2ToSearchFor))
            {
                searchIngredientsInputList.Add(ingredient2ToSearchFor.Replace("'", "''"));
            }
            
            if (!string.IsNullOrWhiteSpace(ingredient3ToSearchFor))
            {
                searchIngredientsInputList.Add(ingredient3ToSearchFor.Replace("'", "''"));
            }

            // Appelle la base de données avec les filtres sélectionnés
            List<string> listTitlesRequested = dbConn.SearchRecipesByIngredients(searchIngredientsInputList, Properties.Settings.Default.AppLanguageCode, filterForSmallBudget, filterForThreeStars);

            // Ajoute les résultats à la liste
            foreach (string titleItem in listTitlesRequested)
            {
                if (!string.IsNullOrWhiteSpace(titleItem))
                {
                    lstSearchResults.Items.Add(titleItem);
                }
            }
        }

        /// <summary>
        /// Searches for recipes containing the input keywords in their title.
        /// </summary>
        internal void SearchRecipesByTitle(string titleToSearchFor)
        {
            // Empties the listbox control before displaying new results
            lstSearchResults.Items.Clear();

            // Replaces apostrophes to prevent SQL errors
            string formattedKeywords = titleToSearchFor.Replace("'", "''");

            // If the user entered "*", retrieve all recipes without filtering
            if (formattedKeywords.Trim() == "*")
            {
                foreach (string title in dbConn.ReadAllRecipesTitlesStored())
                {
                    lstSearchResults.Items.Add(title);
                }
                return;
            }

            // Splits the user input into individual keywords
            List<string> keywords = formattedKeywords.Split(' ').ToList();

            // Calls the database function with all the keywords
            foreach (string title in dbConn.SearchRecipesByTitle(keywords))
            {
                // Adds each found recipe title to the listbox
                lstSearchResults.Items.Add(title);
            }
        }

        private void ShowInventory()
        {
            if (_frmInventory == null || _frmInventory.IsDisposed)
            {
                _frmInventory = new frmInventory(this);
                _frmInventory.Show();
            }
            else
            {
                _frmInventory.BringToFront();
            }
        }

        private void ShowMealPlanner()
        {
            _frmMealPlanner = new frmMealPlanner(this);
            _frmMealPlanner.Show();
        }

        private void txtSearchIngredient1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevents the default "ding" sound when pressing Enter
                e.IsInputKey = true;

                cmdingredientSearch .PerformClick();
            }
        }

        private void txtSearchIngredient2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;

                cmdingredientSearch.PerformClick();
            }
        }

        private void txtSearchIngredient3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;

                cmdingredientSearch.PerformClick();
            }
        }

        private void txtTitleSearch_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = cmdTitleSearch;
        }

        private void txtTitleSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevents the default "ding" sound when pressing Enter
                e.IsInputKey = true;

                cmdTitleSearch.PerformClick();
            }
        }

        /// <summary>
        /// Updates the score for the current selected recipe
        /// </summary>
        private void UpdateScoreForCurrentRecipe(int scoreToInput)
        {
            dbConn.UpdateScoreForRecipe(_currentDisplayedRecipe.Id, scoreToInput);
            DisplayRecipeInfos(_currentDisplayedRecipe.Id);
        }
    }
}
