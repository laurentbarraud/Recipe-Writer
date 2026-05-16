/// <file>frmMain.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2</version>
/// <date>May 17th 2026</date>

using Recipe_Writer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Recipe_Writer
{
    /// <summary>
    /// Main application form for managing recipes, ingredients and instructions.
    /// </summary>
    public partial class frmMain : Form
    {
        // Private member variables

        /// <summary>
        /// Current recipe instruction rank, used for the instruction layout and
        /// for adding new instructions at the end of the list.
        /// </summary>
        private int currentInstruction = 0;

        /// <summary>
        /// Inventory form instance, ensures only one inventory window is opened at a time.
        /// </summary>
        private static frmInventory _frmInventory;

        /// <summary>
        /// Meal planner form instance, ensures only one planner window is opened at a time.
        /// </summary>
        private static frmMealPlanner _frmMealPlanner;

        /// <summary>
        /// List that tracks the mapping between instruction ranks and their labels in the UI.
        /// </summary>
        private List<InstructionSelections> instructionSelection = new List<InstructionSelections>();

        /// <summary>
        /// Rank of the currently selected instruction, or -1 if none is selected.
        /// </summary>
        private int _selectedInstructionRank = -1;

        /// <summary>
        /// Hides the default focus cues on buttons when they are clicked.
        /// </summary>
        protected override bool ShowFocusCues => false;

        // Public properties

        /// <summary>
        /// Currently displayed recipe, initialized with default values and accessible globally.
        /// </summary>
        public Recipes _currentDisplayedRecipe = null;

        /// <summary>
        /// Database connection used by the main form.
        /// </summary>
        public DBConnection dbConn = new DBConnection();

        /// <summary>
        /// Default list of ingredients used to initialize recipe objects.
        /// </summary>
        public static List<Ingredients> _defaultListIngredients = new List<Ingredients>();

        public int InstructionsFontSize
        {
            get
            {
                // Defaults to 12 if not set or invalid
                int value = Properties.Settings.Default.InstructionsFontSize;
                
                if (value < 10 || value > 24 || value % 2 != 0)
                {
                    value = 12;
                }
                
                return value;
            }
            
            set
            {
                // Clamps and normalizes to even steps between 10 and 24
                int clampedValue = Math.Max(10, Math.Min(24, value));
                
                if (clampedValue % 2 != 0)
                
                {
                    clampedValue--;
                }

                Properties.Settings.Default.InstructionsFontSize = clampedValue;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Initializes a new instance of the main form, optionally with a fade-in animation,
        /// registers hover effects, and localizes contextual menu items.
        /// </summary>
        /// <param name="enableFadeIn">If true, applies a fade-in effect when the form is shown.</param>
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
            UIHoverHelper.ButtonBaseResourceNames[cmdSearchByIngredient] = "search_by_ingredient";
            UIHoverHelper.ButtonBaseResourceNames[cmdInventory] = "inventory";
            UIHoverHelper.ButtonBaseResourceNames[cmdMealPlanner] = "planner";
            UIHoverHelper.ButtonBaseResourceNames[cmdSettings] = "settings";
            UIHoverHelper.ButtonBaseResourceNames[cmdingredientSearch] = "ingredientSearch";

            // Buttons hover events
            cmdNewRecipe.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdNewRecipe.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdTitleSearch.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdTitleSearch.MouseLeave += UIHoverHelper.Button_MouseLeave;
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

            // Contextual menu items
            newRecipe.Text = strings.ToolStripMenuItemNewRecipe;
            editThisRecipesInfos.Text = strings.ToolStripMenuItemEditBasicInfos;
            deleteThisRecipe.Text = strings.ToolStripMenuItemDeleteThisRecipe;
            exportThisRecipeToAWebPage.Text = strings.ToolStripMenuItemExportThisRecipeToAWebPage;
            planRecipeOn.Text = strings.ToolStripMenuItemPlanThisRecipeFor;

            mondayToolStripMenuItem.Text = strings.ToolStripMenuItemMonday;
            tuesdayToolStripMenuItem.Text = strings.ToolStripMenuItemTuesday;
            wednesdayToolStripMenuItem.Text = strings.ToolStripMenuItemWednesday;
            thursdayToolStripMenuItem.Text = strings.ToolStripMenuItemThursday;
            fridayToolStripMenuItem.Text = strings.ToolStripMenuItemFriday;
            saturdayToolStripMenuItem.Text = strings.ToolStripMenuItemSaturday;
            sundayToolStripMenuItem.Text = strings.ToolStripMenuItemSunday;

            addIngredientToThisRecipe.Text = strings.ToolStripMenuItemAddIngredientToThisRecipe;
            deleteSelectedIngredientFromThisRecipe.Text = strings.ToolStripMenuItemDeleteSelectedIngredientFromThisRecipe;
            
            addInstructionToThisRecipe.Text = strings.ToolStripMenuItemAddInstructionToThisRecipe;
            editSelectedInstruction.Text = strings.ToolStripMenuItemEditSelectedInstruction;
            deleteSelectedInstruction.Text = strings.ToolStripMenuItemDeleteSelectedInstruction;
        }

        /// <summary>
        /// Initializes the main form on startup by restoring user settings,
        /// setting initial UI focus, and ensuring the application database exists
        /// and is valid. If the database is missing or corrupted, it is rebuilt
        /// with the required tables and initial data.
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

        private void addInstructionToThisRecipe_Click(object sender, EventArgs e)
        {
            frmNewInstruction _frmNewInstruction = new frmNewInstruction(this);
            _frmNewInstruction.IdRecipeToEdit = _currentDisplayedRecipe.Id;
            _frmNewInstruction.NbInstructionsInCurrentRecipe = currentInstruction;
            _frmNewInstruction.ShowDialog();
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
                if (deleteSelectedIngredientFromThisRecipe.Visible == false)
                {
                    deleteSelectedIngredientFromThisRecipe.Visible = true;
                }
            }

            // No ingredient has been selected
            else
            {
                if (deleteSelectedIngredientFromThisRecipe.Visible == true)
                {
                    deleteSelectedIngredientFromThisRecipe.Visible = false;
                }
            }
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
            newRecipe.PerformClick();
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
                pnlSlideMenu.Width = 360;
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
        /// User can edit an instruction by double-clicking the label.
        /// </summary>
        public void CreateInstructionsLayout()
        {
            currentInstruction = 0;

            // Layout parameters
            int spacingWidth = 15;
            int spacingHeight = 5;

            // Clears the layout by removing all the labels, before adding new ones
            pnlInstructions.Controls.Clear();

            // Clears the instruction selection list to avoid keeping references to old labels
            // that would cause bugs with the selection and editing of instructions after refreshing the layout
            instructionSelection.Clear();

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
                lblInstruction.Click += (s, e) =>
                {
                    _selectedInstructionRank = instructionItem.Rank;
                    RefreshSelectedInstruction();
                };

                // Binds the label to its related instruction 
                InstructionSelections instructionSelected = new InstructionSelections();
                instructionSelected.InstructionRank = instructionItem.Rank;
                instructionSelected.InstructionLabel = lblInstruction;
                instructionSelection.Add(instructionSelected);

                // Handles the event to make an instruction label editable
                lblInstruction.DoubleClick += (s, e) =>
                {
                    _selectedInstructionRank = instructionItem.Rank;

                    TextBox txtEditInstruction = new TextBox
                    {
                        Parent = pnlInstructions,
                        Text = lblInstruction.Text,
                        Font = lblInstruction.Font,
                        Multiline = true,
                        WordWrap = true,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = lblInstruction.Location,
                        Width = lblInstruction.Width,
                        Height = lblInstruction.Height,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                        Padding = new Padding(3),
                    };

                    // Local handler to commit the edit when the user clicks outside the TextBox,
                    // then removes itself
                    MouseEventHandler panelClickHandler = null;

                    panelClickHandler = (sPanel, ePanel) =>
                    {
                        // Si on clique dans le TextBox, on ne fait rien
                        if (txtEditInstruction.Bounds.Contains(ePanel.Location))
                            return;

                        // Commit simple quand on clique ailleurs
                        string newText = txtEditInstruction.Text.Replace("'", "''");
                        dbConn.UpdateInstruction(instructionItem.Id, newText);

                        txtEditInstruction.Dispose();
                        pnlInstructions.MouseDown -= panelClickHandler; // on se désabonne
                        CreateInstructionsLayout();
                    };

                    pnlInstructions.MouseDown += panelClickHandler;

                    lblInstruction.Visible = false;

                    txtEditInstruction.TextChanged += (s2, e2) =>
                    {
                        Size proposedSize = new Size(txtEditInstruction.Width, int.MaxValue);

                        // Adds an extra space to ensure the last line is measured correctly
                        // when the user types and the text ends with a line break.
                        Size measuredSize = TextRenderer.MeasureText(txtEditInstruction.Text + " ",
                            txtEditInstruction.Font, proposedSize,
                            TextFormatFlags.WordBreak);

                        // Adds padding of 3px top and 3px bottom for better readability and sets a minimum height equal to the label height
                        txtEditInstruction.Height = Math.Max(measuredSize.Height + 6, lblInstruction.Height);
                    };

                    txtEditInstruction.KeyDown += (s2, e2) =>
                    {
                        if (e2.KeyCode == Keys.Enter && !e2.Shift)
                        {
                            // Prevents the "ding" sound on Enter key press and allows multiline input with Shift+Enter
                            e2.SuppressKeyPress = true;

                            string newText = txtEditInstruction.Text.Replace("'", "''");

                            // Saves the updated instruction text to the database
                            dbConn.UpdateInstruction(instructionItem.Id, newText);

                            // Unsubscribes the outside-click handler to avoid ghost commits
                            pnlInstructions.MouseDown -= panelClickHandler;

                            txtEditInstruction.Dispose();
                            CreateInstructionsLayout();
                        }
                        else if (e2.KeyCode == Keys.Escape)
                        {
                            // Unsubscribes the outside-click handler to avoid ghost commits
                            pnlInstructions.MouseDown -= panelClickHandler;

                            txtEditInstruction.Dispose();
                            CreateInstructionsLayout();
                        }
                    };

                    txtEditInstruction.Focus();
                    txtEditInstruction.SelectAll();
                };

                // Handles the event to show the instruction-related actions when the user right-clicks on an instruction label
                lblInstruction.MouseDown += (s, e2) =>
                {
                    if (e2.Button == MouseButtons.Right)
                    {
                        _selectedInstructionRank = instructionItem.Rank;

                        addInstructionToThisRecipe.Visible = true;
                        editSelectedInstruction.Visible = true;
                        deleteSelectedInstruction.Visible = true;

                        toolStripSeparator1.Visible = true;
                        toolStripSeparator2.Visible = true;
                    }

                    // Recalculates separators
                    toolStripSeparator2.Visible = addInstructionToThisRecipe.Visible ||
                        editSelectedInstruction.Visible || deleteSelectedInstruction.Visible;

                    toolStripSeparator1.Visible = editSelectedInstruction.Visible ||
                        deleteSelectedInstruction.Visible;
                };

                // Instruction label visual layout

                lblInstruction.Text = instructionItem.Text;

                // Applies the dynamic font size
                lblInstruction.Font = new Font(lblInstruction.Font.FontFamily, InstructionsFontSize, 
                    lblInstruction.Font.Style);

                // Adds light internal padding for better readability
                // Left = 5, Top = 2, Right = 5, Bottom = 2
                lblInstruction.Padding = new Padding(5, 2, 5, 2);

                // Enables automatic vertical resizing and line wrapping
                lblInstruction.AutoSize = true;

                // Maximum width = panel width minus margins (keeps text inside the visible area)
                lblInstruction.MaximumSize = new Size(pnlInstructions.Width - 20, 0);

                // Aligns text at the top-left corner
                lblInstruction.TextAlign = ContentAlignment.TopLeft;

                // Sets the label position (10px left margin, dynamic vertical stacking)
                lblInstruction.Location = new Point(10, spacingHeight + currentInstruction);

                lblInstruction.ForeColor = Color.Black;

                pnlInstructions.Controls.Add(lblInstruction);

                // Updates vertical offset for the next instruction
                currentInstruction += lblInstruction.Height + spacingWidth;
            }
        }

        /// <summary>
        /// Deletes the selected instruction from the database and refreshes the instruction layout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedInstruction_Click(object sender, EventArgs e)
        {
            // If no instruction was selected
            if (_selectedInstructionRank < 0)
            {
                return;
            }

            // Retrieves the instruction object using the selected rank
            var instructionItem = _currentDisplayedRecipe
                .InstructionsList
                .FirstOrDefault(instruction => instruction.Rank == _selectedInstructionRank);

            if (instructionItem == null)
            {
                return;
            }

            // Asks the user for confirmation
            var confirmResult = MessageBox.Show(strings.ConfirmDeleteInstruction,
                strings.ConfirmDeletion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Deletes the instruction from the DB using its rank and the current recipe ID
                dbConn.DeleteInstruction(_currentDisplayedRecipe.Id, instructionItem.Rank);

                CreateInstructionsLayout();

                // Resets selection
                _selectedInstructionRank = -1;
            }
        }

        private void deleteSelectedIngredientFromThisRecipe_Click(object sender, EventArgs e)
        {
            if (cmbRecipeIngredients.Items.Count >= 2 && cmbRecipeIngredients.SelectedIndex >= 1)
            {
                // If the ingredient has been correctly deleted, the function returns true
                if (dbConn.DeleteIngredientFromARecipe(_currentDisplayedRecipe.Id, cmbRecipeIngredients.SelectedIndex) == true) 
                {
                    // Shifts the ingredient list to the left to avoid empty rows
                    dbConn.OffsetRowValuesToLeft(_currentDisplayedRecipe.Id);

                    // Refreshes the displayed recipe info
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
            var confirmResult = MessageBox.Show(strings.ConfirmDeleteDisplayedRecipeFromDB,
                strings.ConfirmDeletion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                dbConn.DeleteRecipe(_currentDisplayedRecipe.Id);
                HidesRecipeInfosAndControls();
            }
        }

        /// <summary>
        /// Event when the user selects a recipe in the search result list control
        /// </summary>
        public void DisplayRecipeControls()
        {
            // Shows recipe-level actions
            editThisRecipesInfos.Visible = true;
            deleteThisRecipe.Visible = true;
            exportThisRecipeToAWebPage.Visible = true;
            planRecipeOn.Visible = true;

            // Shows ingredient actions
            addIngredientToThisRecipe.Visible = true;

            // Shows instruction actions
            addInstructionToThisRecipe.Visible = true;
            editSelectedInstruction.Visible = true;
            deleteSelectedInstruction.Visible = true;

            // Shows separators
            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = true;

            nudPersons.Visible = true;
            lblPortions.Visible = true;
            lblCompletionTime.Visible = true;
            cmbRecipeIngredients.Visible = true;
            picRecipeReadyToCookStatus.Visible = true;

            pnlInstructions.Visible = true;

            picRecipe.Visible = true;
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
            picCompletionTime.Visible = true;
            lblCompletionTime.Text = "";
            lblCompletionTime.Text = _currentDisplayedRecipe.CompletionTime + " min.";

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

            // Language of the recipe (read from DB)
            _currentDisplayedRecipe.Language = dbConn.ReadRecipeLanguage(idRecipe);

            // Instructions
            _currentDisplayedRecipe.InstructionsList = 
                dbConn.ReadInstructionsForARecipe(_currentDisplayedRecipe.Id, _currentDisplayedRecipe.Language);

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

        /// <summary>
        /// Allows the user to edit an instruction by double-clicking its label.
        /// Displays a temporary TextBox that auto-wraps and auto-resizes vertically.
        /// </summary>
        private void editSelectedInstruction_Click(object sender, EventArgs e)
        {
            if (_selectedInstructionRank < 0)
            {
                return;
            }

            var selectedInstructionLabelBinding = instructionSelection
                .FirstOrDefault(instruction => instruction.InstructionRank == _selectedInstructionRank);

            if (selectedInstructionLabelBinding == null)
            {
                return;
            }

            // Assumes the label exists since it is created in CreateInstructionsLayout and bound to the rank
            Label lblInstruction = selectedInstructionLabelBinding.InstructionLabel;

            var instructionItem = 
                _currentDisplayedRecipe.InstructionsList.First(instruction => instruction.Rank == _selectedInstructionRank);

            // Creates editable TextBox
            TextBox txtInputUser = new TextBox
            {
                Parent = pnlInstructions,
                Text = lblInstruction.Text,
                Font = lblInstruction.Font,
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true,
                WordWrap = true,
                ScrollBars = ScrollBars.None
            };

            txtInputUser.Location = lblInstruction.Location;
            txtInputUser.Width = lblInstruction.Width;

            // Initial height: label height
            txtInputUser.Height = lblInstruction.Height;

            lblInstruction.Visible = false;

            // Auto-resizes dynamically based on content
            txtInputUser.TextChanged += (s2, e2) =>
            {
                // Measures required height
                Size proposedSize = new Size(txtInputUser.Width, int.MaxValue);

                // Uses TextRenderer to measure the size of the text with the current font and
                // wrapping settings and adds an extra space to ensure the last line is measured
                // correctly when the user types and the text ends with a line break.
                Size measuredSize = TextRenderer.MeasureText(txtInputUser.Text + " ",
                    txtInputUser.Font, proposedSize, TextFormatFlags.WordBreak
                );

                int newHeight = measuredSize.Height + 6; // padding of 3px top and 3px bottom for better readability

                // Minimum is set to label height
                if (newHeight < lblInstruction.Height)
                {
                    newHeight = lblInstruction.Height;
                }

                txtInputUser.Height = newHeight;
            };

            // Handles Enter (save) and Escape (cancel)
            txtInputUser.KeyDown += (s2, e2) =>
            {
                // If the user presses Enter without Shift (to allow multiline input with Shift+Enter)
                if (e2.KeyCode == Keys.Enter && !e2.Shift)
                {
                    e2.SuppressKeyPress = true;

                    string formattedInputUserText = txtInputUser.Text;

                    if (!string.IsNullOrEmpty(formattedInputUserText) && formattedInputUserText.Contains("'"))
                    {
                        formattedInputUserText = formattedInputUserText.Replace("'", "''");
                    }
                    
                    // Saves the updated instruction text to the database
                    dbConn.UpdateInstruction(instructionItem.Id, formattedInputUserText);

                    txtInputUser.Dispose();
                    CreateInstructionsLayout();
                }
                else if (e2.KeyCode == Keys.Escape)
                {
                    txtInputUser.Dispose();
                    CreateInstructionsLayout();
                }
            };

            txtInputUser.Show();
            txtInputUser.Focus();
            txtInputUser.SelectAll();
        }

        private void editThisRecipesInfosToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// Hides the ingredients, image and instructions and the controls 
        /// for the current displayed recipe
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

            lstSearchResults.Items.Clear();
            lstSearchResults.Visible = false;
            cmbRecipeIngredients.Items.Clear();
            cmbRecipeIngredients.Visible = false;
            picCompletionTime.Visible = false;
            lblCompletionTime.Text = "";
            lblPortions.Visible = false;
            lblCompletionTime.Visible = false;

            nudPersons.Visible = false;

            picRecipe.Visible = false;
            pnlScore.Visible = false;
            picScore1.Visible = false;
            picScore2.Visible = false;
            picScore3.Visible = false;
            picLowBudget.Visible = false;
            picRecipe.BackgroundImage = null;
            picRecipe.BorderStyle = BorderStyle.FixedSingle;
            picRecipeReadyToCookStatus.Visible = false;

            // Hides recipe-level actions
            editThisRecipesInfos.Visible = false;
            deleteThisRecipe.Visible = false;
            exportThisRecipeToAWebPage.Visible = false;
            planRecipeOn.Visible = false;

            // Hides ingredient actions
            addIngredientToThisRecipe.Visible = false;

            // Hides instruction actions
            addInstructionToThisRecipe.Visible = false;
            editSelectedInstruction.Visible = false;
            deleteSelectedInstruction.Visible = false;

            // Hides separators
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;

            pnlInstructions.Controls.Clear();
            pnlInstructions.Visible = false;

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

            editThisRecipesInfos.PerformClick();
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
                return; // Exits early if no selection
            }

            // Creates a new recipe object for the newly selected recipe
            _currentDisplayedRecipe = new Recipes();

            // Retrieves the recipe ID from the database using the selected item
            _currentDisplayedRecipe.Id = dbConn.ReadRecipeId(lstSearchResults.SelectedItem.ToString());

            // Displays recipe information in the UI
            DisplayRecipeInfos(_currentDisplayedRecipe.Id);

            // Shows recipe controls if they are not already visible
            if (!nudPersons.Visible)
            {
                DisplayRecipeControls();
            }
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
            // Prevents crash at startup when no recipe is selected yet
            if (_currentDisplayedRecipe == null || _currentDisplayedRecipe.Id == 0)
            {
                return;
            }

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
                // Forces dialog culture to match the app language
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    new System.Globalization.CultureInfo(Properties.Settings.Default.AppLanguageCode);

                // Creates a fresh dialog so it uses the correct culture
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = strings.SelectRecipeImage;
                    ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        picRecipe.Load(ofd.FileName);
                        picRecipe.BorderStyle = BorderStyle.None;

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

        private void pnlInstructions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Shows the 3 instruction options
                addInstructionToThisRecipe.Visible = true;
                editSelectedInstruction.Visible = true;
                deleteSelectedInstruction.Visible = true;

                // Shows both separators
                toolStripSeparator1.Visible = true;
                toolStripSeparator2.Visible = true;
            }

            else
            {
                // Hides instruction options if the user clicks elsewhere on the panel
                addInstructionToThisRecipe.Visible = false;
                editSelectedInstruction.Visible = false;
                deleteSelectedInstruction.Visible = false;

                // Hides separators too
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
            }

            // Bottom separator visible only if at least one instruction option is visible
            toolStripSeparator2.Visible =
                addInstructionToThisRecipe.Visible ||
                editSelectedInstruction.Visible ||
                deleteSelectedInstruction.Visible;

            // Top separator visible only if edit or delete are visible
            toolStripSeparator1.Visible =
                editSelectedInstruction.Visible ||
                deleteSelectedInstruction.Visible;
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
        /// Changes the background color of the selected instruction and changes 
        /// the background to transparent for the unselected instructions
        /// </summary>
        public void RefreshSelectedInstruction()
        {
            foreach (var binding in instructionSelection)
            {
                // The label whose rank = _selectedInstructionRank is blue
                if (binding.InstructionRank == _selectedInstructionRank) 
                { 
                    binding.InstructionLabel.BackColor = Color.FromArgb(168, 208, 230);
                }

                // All the other labels are transparent
                else
                {
                    binding.InstructionLabel.BackColor = Color.Transparent;
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

            if (lstSearchResults.Enabled == false)
            {
                lstSearchResults.Enabled = true;
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

        /// <summary>
        /// Triggers a title search when pressing Enter inside the search textbox,
        /// while suppressing the default system "ding" sound.
        /// </summary>
        private void txtTitleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevents the default beep sound
                e.SuppressKeyPress = true;

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
