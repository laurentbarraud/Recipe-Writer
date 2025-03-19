/// <file>frmMain.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 19th 2025</date>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Recipe_Writer
{
    public partial class frmMain : Form
    {
        // Declares and instancies a connection to the database
        public DBConnection dbConn = new DBConnection();

        // Declares and instanciates a default instruction, accessible globally
        public static Instructions _defaultInstruction = new Instructions(0, "", 0, 0);

        // Declares and instanciates a default list of instructions, accessible globally
        public static List<Instructions> _defaultListInstructions = new List<Instructions>();

        // Declares and instanciates a default list of ingredients, accessible globally
        public static List<Ingredients> _defaultListIngredients = new List<Ingredients>();

        // Declares and instanciates the list that will handle the selected instruction
        private List<InstructionSelections> instructionSelection = new List<InstructionSelections>();

        // Declares and instanciates the current displayed recipe object, constructed with default values, and accessible globally
        public Recipes _currentDisplayedRecipe = new Recipes(0, "", 0, 0, 0, "default", _defaultListIngredients, _defaultListInstructions);

        private int currentInstruction = 0;
        private int selectedInstruction = -1;
        
        // These variables store if the inventory and meal planner forms are shown on screen
        private bool inventoryShown = false;
        private bool mealPlannerShown = false;

        // This variable store the previous title search value
        private string previousTitleSearch = "";

        public string PreviousTitleSearch
        {
            get { return previousTitleSearch; }
            set { previousTitleSearch = value; }
        }

        public bool InventoryShown
        {
            get { return inventoryShown; }
            set { inventoryShown = value; }
        }

        public bool MealPlannerShown
        {
            get { return mealPlannerShown; }
            set { mealPlannerShown = value; }
        }


        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Stores the value of the numeric updown control
            DBConnection.NbPersonsPreviouslySet = Convert.ToInt32(nudPersons.Value);
            DBConnection.NbPersonsSet = Convert.ToInt32(nudPersons.Value);

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
                    MessageBox.Show("La base de donnée est corrompue.\nLa base va être reconstruite.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Creates the database file recipe-album.db and its tables then fill-in the data
                    dbConn.CreateTables();
                    dbConn.InsertInitialData();
                }
            }
            // If the database file cannot be found in the application directory
            else
            {
                MessageBox.Show("Le fichier de la base de donnée n'a pas été trouvé.\nLa base va être construite avec les données initiales.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Creates the database file in the app's installation folder
                dbConn.CreateFile();

                // Opens the connexion
                dbConn.Open();

                // Creates the database file recipe-album.db and its tables then fill-in the data
                dbConn.CreateTables();
                dbConn.InsertInitialData();
            }
        }

        /// <summary>
        /// Creates the instructions layout to display them to the user
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
                    // Source-code : https://stackoverflow.com/questions/40416262/change-label-text-on-its-own-click-event-during-runtime

                    TextBox txtInputUser;

                    // Is the textbox already created ?
                    if (lblInstruction.Controls.Count > 0)
                    {
                        // Sets reference.
                        txtInputUser = ((TextBox)lblInstruction.Controls[0]);

                        lblInstruction.Text = txtInputUser.Text;
                        txtInputUser.Hide();

                        cmdEditInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.edit;
                    }

                    // We need to create the textbox
                    else
                    {
                        txtInputUser = new TextBox();

                        // Adds it to the label's controls collection
                        txtInputUser.Parent = lblInstruction;

                        // Sizes it
                        txtInputUser.Size = lblInstruction.Size;

                        // Sets the event that ends editing when focus goes elsewhere
                        txtInputUser.LostFocus += (ss, ee) => { lblInstruction.Text = txtInputUser.Text; txtInputUser.Hide(); };

                        // Gets current text
                        txtInputUser.Text = lblInstruction.Text;

                        // Displays the textbox in place
                        txtInputUser.Show();

                        // Displays the validate icon
                        cmdEditInstruction.BackgroundImage = Recipe_Writer.Properties.Resources.validate;
                    }
                };

                // Handles the event to make an instruction label editable
                lblInstruction.DoubleClick += (object sender_here, EventArgs e_here) => { cmdEditInstruction.PerformClick(); };

                // Delete instruction code ================================================================================================

                Button cmdDeleteInstruction = new Button();
                cmdDeleteInstruction.Click += (object sender_here, EventArgs e_here) =>
                {
                    var confirmResult = MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer l'instruction ?",
                    "Confirmer la suppression.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        dbConn.DeleteInstruction(_currentDisplayedRecipe.Id, instructionItem.Rank);

                        // Loads all the instructions for the currently selected recipe
                        CreateInstructionsLayout();
                    }
                };

                // Instruction label, detailed layout =========================================================================================
                lblInstruction.Text = instructionItem.Text;
                lblInstruction.Width = 615;
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
                cmdEditInstruction.Location = new Point(20 + spacingWidth + lblInstruction.Width + spacingWidth + spacingWidth + spacingWidth, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);
                cmdDeleteInstruction.Location = new Point(20 + spacingWidth + lblInstruction.Width + spacingWidth + spacingWidth + spacingWidth + cmdEditInstruction.Width + spacingWidth, spacingHeight + currentInstruction * (lblInstruction.Height + spacingWidth) + lblInstruction.Height);

                // Adds the controls to the layout ============================================================================================
                pnlInstructions.Controls.Add(lblInstruction);
                pnlInstructions.Controls.Add(cmdEditInstruction);
                pnlInstructions.Controls.Add(cmdDeleteInstruction);

                currentInstruction += 1;
            }
        }

        private void cmdNewRecipe_Click(object sender, EventArgs e)
        {
            cmsRecipeResult.Items[0].PerformClick();
        }

        private void nouvelleRecetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewRecipeBasicInfosInput _frmNewRecipeBasicInfosInput = new frmNewRecipeBasicInfosInput(this);
            _frmNewRecipeBasicInfosInput.ShowDialog();
        }

        private void cmdTitleSearch_Click(object sender, EventArgs e)
        {
            this.PreviousTitleSearch = txtTitleSearch.Text;

            // If the user has typed something in the textbox
            if (txtTitleSearch.Text != "")
            {
                SearchRecipesByTitle(txtTitleSearch.Text);
            }
            // If the search textbox is empty
            else
            {
                MessageBox.Show("Veuillez taper un ou plusieurs terme(s) de recherche.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }


        /// <summary>
        /// Search recipes containing the input keywords in their title
        /// </summary>
        private void SearchRecipesByTitle(string titleToSearchFor)
        {
            // Empties the listbox control
            lstSearchResults.Items.Clear();

            string formattedKeywords = titleToSearchFor;

            // Checks if the keywords contain an apostroph, to avoid making the sql request crash
            if (titleToSearchFor.Contains("'"))
            {
                formattedKeywords = titleToSearchFor.Replace("'", "''");
            }

            // Declares an array and stores the keywordsSeparates the text typed by the user in the search text box into keywords and stores them in an array
            string[] arrayKeywordsInput = formattedKeywords.Split(' ');

            // If the user has typed 8 words or less in the textbox
            if (arrayKeywordsInput.Length <= 8)
            {
                switch (arrayKeywordsInput.Length)
                {
                    // If the user has typed only one word in the search textbox
                    case 1:

                        // Calls the dbConn.SearchRecipesByTitle function with only one keyword in argument and adds the returned title in the list of string
                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0]))
                        {
                            // Adds each title found as a new item in the listbox control
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    // If the user has typed two words in the search textbox
                    case 2:

                        // Calls the dbConn.SearchRecipesByTitle function with two keywords in argument and adds the returned titles in the list of string
                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1]))
                        {
                            // Adds each title found as a new item in the listbox control
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 3:

                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 4:

                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 5:

                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 6:

                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 7:

                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5], arrayKeywordsInput[6]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 8:

                        // Calls the dbConn.SearchRecipesByTitle function with eight keywords in argument and adds the returned title in the list of string
                        foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5], arrayKeywordsInput[6], arrayKeywordsInput[7]))
                        {
                            // Adds each title found as a new item in the listbox control
                            lstSearchResults.Items.Add(title);
                        }
                        break;
                }
            }
            // If the user has typed more than 8 words in the search textbox
            else
            {
                // Calls the dbConn.SearchRecipesByTitle function with eight keywords in argument and adds the returned title in the list of string
                foreach (string title in dbConn.SearchRecipesByTitle(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5], arrayKeywordsInput[6], arrayKeywordsInput[7]))
                {
                    // Adds each title found as a new item in the listbox control
                    lstSearchResults.Items.Add(title);
                }
            }
        }

        private void cmdIngredientsSearch_Click(object sender, EventArgs e)
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
                MessageBox.Show("Veuillez entrer au moins un ingrédient", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search recipes which contain all the input ingredients
        /// <param name="filterForSmallBudget"></param>
        /// <param name="ingredient1ToSearchFor"</param>
        /// <param name="ingredient2ToSearchFor"</param>
        /// <param name="ingredient3ToSearchFor"</param>
        /// </summary>
        private void SearchRecipesByIngredients(string ingredient1ToSearchFor, string ingredient2ToSearchFor, string ingredient3ToSearchFor, bool filterForSmallBudget = false, bool filterForThreeStars = false)
        {
            // Empties the listbox control and the title search textbox
            lstSearchResults.Items.Clear();
            txtTitleSearch.Text = "";

            string formattedInputIngredient1 = ingredient1ToSearchFor;
            string formattedInputIngredient2 = ingredient2ToSearchFor;
            string formattedInputIngredient3 = ingredient3ToSearchFor;

            // Checks if the search ingredients input by the user contains an apostroph, to avoid making the SQL request crash
            formattedInputIngredient1 = ingredient1ToSearchFor.Replace("'", "''");
            formattedInputIngredient2 = ingredient2ToSearchFor.Replace("'", "''");
            formattedInputIngredient3 = ingredient3ToSearchFor.Replace("'", "''");

            // Declares a list of string and stores each ingredient the user wants to use for the search
            List<string> searchIngredientsInputList = new List<string>();

            if (formattedInputIngredient1 != "")
            {
                searchIngredientsInputList.Add(formattedInputIngredient1);
            }

            if (formattedInputIngredient2 != "")
            {
                searchIngredientsInputList.Add(formattedInputIngredient2);
            }

            if (formattedInputIngredient3 != "")
            {
                searchIngredientsInputList.Add(formattedInputIngredient3);
            }

            // Declares an array to stock the input ingredient list
            string[] arraySearchIngredientsInput = searchIngredientsInputList.ToArray();
            List<string> listTitlesRequested = new List<string>();

            // Normal mode search
            if (!filterForSmallBudget && !filterForThreeStars)
            {
                switch (searchIngredientsInputList.Count)
                {
                    // If the user has typed only one ingredient to search recipes for
                    case 1:

                        // Calls the dbConn function with only one ingredient in argument and affects the returned list to the list control
                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0]);

                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }
                        }
                        break;

                    // If the user has typed two ingredients to search recipe for
                    case 2:

                        // Calls the dbConn.SearchRecipesByTitle function with two ingredients in argument and affects the returned list to the list control
                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1]);

                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }
                        }
                        break;

                    case 3:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], arraySearchIngredientsInput[2]);

                        // Calls the dbConn.SearchRecipesByTitle function with three ingredients in argument and affects the returned list to the list control
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }
                        }
                        break;
                }
            }
            
            // If the checkbox to filter recipes for small budget is checked
            else if (filterForSmallBudget && !filterForThreeStars)
            {
                switch (searchIngredientsInputList.Count)
                {
                    // If the user has typed only one ingredient
                    case 1:

                        // Calls the dbConn function with only one keyword in argument and adds each returned title from the list to the list control
                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], "", "", true);

                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }
                        }
                        break;

                    // If the user has typed two ingredients
                    case 2:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], "", true);

                        // Calls the dbConn.SearchRecipesByTitle function with two keywords in argument and adds the returned titles in the list of string
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }

                        }
                        break;

                    // If the user has typed three ingredients
                    case 3:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], arraySearchIngredientsInput[2], true);

                        // Calls the dbConn.SearchRecipesByTitle function with three keywords in argument and adds the returned titles in the list of string
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }

                        }
                        break;
                }
            }

            // If the checkbox to filter recipes for the ones ranked three stars is checked
            else if (!filterForSmallBudget && filterForThreeStars)
            {
                switch (searchIngredientsInputList.Count)
                {
                    // If the user has typed only one ingredient
                    case 1:

                        // Calls the dbConn function with only one keyword in argument and adds each returned title from the list to the list control
                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], "", "", false, true);

                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }
                        }
                        break;

                    // If the user has typed two ingredients
                    case 2:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], "", false, true);

                        // Calls the dbConn.SearchRecipesByTitle function with two keywords in argument and adds the returned titles in the list of string
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }

                        }
                        break;

                    // If the user has typed three ingredients
                    case 3:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], arraySearchIngredientsInput[2], false, true);

                        // Calls the dbConn.SearchRecipesByTitle function with three keywords in argument and adds the returned titles in the list of string
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }

                        }
                        break;
                }
            }

            // If the checkboxes to filter recipes for small budget and to filter for the ones ranked three stars are checked
            else if (filterForSmallBudget && filterForThreeStars)
            {
                switch (searchIngredientsInputList.Count)
                {
                    // If the user has typed only one ingredient
                    case 1:

                        // Calls the dbConn function with only one keyword in argument and adds each returned title from the list to the list control
                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], "", "", true, true);

                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }
                        }
                        break;

                    // If the user has typed two ingredients
                    case 2:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], "", true, true);

                        // Calls the dbConn.SearchRecipesByTitle function with two keywords in argument and adds the returned titles in the list of string
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }

                        }
                        break;

                    // If the user has typed three ingredients
                    case 3:

                        listTitlesRequested = dbConn.SearchRecipesByIngredients(arraySearchIngredientsInput[0], arraySearchIngredientsInput[1], arraySearchIngredientsInput[2], true, true);

                        // Calls the dbConn.SearchRecipesByTitle function with three keywords in argument and adds the returned titles in the list of string
                        foreach (string titleItem in listTitlesRequested)
                        {
                            if (titleItem != "")
                            {
                                lstSearchResults.Items.Add(titleItem);
                            }

                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Event when the user selects a recipe in the search result list control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRecipeInfos();

            if (!nudPersons.Visible)
            {
                DisplayRecipeControls();   
            }
        }

        /// <summary>
        /// Event when the user selects a recipe in the search result list control
        /// </summary>
        private void DisplayRecipeControls()
        {
            cmsRecipeResult.Items[1].Enabled = true;
            cmsRecipeResult.Items[2].Enabled = true;
            cmsRecipeResult.Items[3].Enabled = true;
            cmsRecipeResult.Items[4].Enabled = true;

            nudPersons.Visible = true;
            lblPortions.Visible = true;
            lblCompletionTime.Visible = true;
            cmbRecipeIngredients.Visible = true;
            cmdAddInstruction.Visible = true;
            pnlScore.Visible = true;
            picScore1.Visible = true;
            picScore2.Visible = true;
            picScore3.Visible = true;
        }

        /// <summary>
        /// Displays the ingredients, image and instructions for the selected recipe
        /// </summary>
        public void DisplayRecipeInfos()
        {
            // Affects to the title property of the _currentDisplayedRecipe object the selected recipe, in the search result listbox
            _currentDisplayedRecipe.Title = lstSearchResults.SelectedItem.ToString();

            // Calls the function that returns the id of a recipe, given its title in argument
            _currentDisplayedRecipe.Id = dbConn.ReadRecipeId(_currentDisplayedRecipe.Title);

            // Affects to the properties of the _currentDisplayedRecipe object the others values returned by the dbConn functions
            _currentDisplayedRecipe.CompletionTime = dbConn.ReadRecipeCompletionTime(_currentDisplayedRecipe.Id);
            _currentDisplayedRecipe.LowBudget = dbConn.ReadRecipeLowBudgetStatus(_currentDisplayedRecipe.Id);
            _currentDisplayedRecipe.Score = dbConn.ReadRecipeScore(_currentDisplayedRecipe.Id);
            _currentDisplayedRecipe.ImagePath = dbConn.ReadRecipeImagePath(_currentDisplayedRecipe.Id);

            // --- Affecting the _currentDisplayedRecipe properties to the controls properties ----------------------------------------------------

            // --- Completion time
            lblCompletionTime.Text = "";
            lblCompletionTime.Text += "Préparation : " + _currentDisplayedRecipe.CompletionTime+" min.";

            // --- Low budget status
            if (_currentDisplayedRecipe.LowBudget == 1)
            {
                picLowBudget.Visible = true;
            }

            else
            {
                picLowBudget.Visible = false;
            }

            // --- Ingredients list
            _currentDisplayedRecipe.IngredientsList = dbConn.ReadIngredientsQtyForARecipe(_currentDisplayedRecipe.Id);
 
            cmbRecipeIngredients.Items.Clear();
            cmbRecipeIngredients.Items.Add("Ingrédients nécessaires");

            // Adds each ingredients list item as a new item in the ingredients comboBo
            foreach (Ingredients ingredientToAdd in _currentDisplayedRecipe.IngredientsList)
            {
                cmbRecipeIngredients.Items.Add(ingredientToAdd.QtyRequested.ToString() + " " + ingredientToAdd.Scale + " de " + ingredientToAdd.Name);
            }

            if (_currentDisplayedRecipe.IngredientsList.Count() <= 19)
            {
                cmbRecipeIngredients.Items.Add("Ajouter un ingrédient...");
            }

            // Selects automatically the first item of the combobox
            cmbRecipeIngredients.SelectedIndex = 0;

            // --- Calculates if the recipe is ready to cook with what is stored in the inventory.
            if (CalculateRecipeReadyToCookStatus(_currentDisplayedRecipe.IngredientsList))
            {
                picRecipeReadyToCookStatus.BackgroundImage = Recipe_Writer.Properties.Resources.recipe_status_green;
            }

            // If there's one or more ingredient(s) missing
            else
            {
                picRecipeReadyToCookStatus.BackgroundImage = Recipe_Writer.Properties.Resources.recipe_status_red;
            }

            // --- Score
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

            // --- Instructions
            // Calls the function that will return the instructions list to follow to make the recipe,
            // then and affects them to the current displayed Recipe instruction list.
            _currentDisplayedRecipe.InstructionsList = dbConn.ReadInstructionsForARecipe(_currentDisplayedRecipe.Id);

            // Calls the function that creates the instruction labels dynamically
            CreateInstructionsLayout();


            // --- ImagePath
            // Calls the function that displays the illustration image for the currently selected recipe
            _currentDisplayedRecipe.ImagePath = dbConn.ReadRecipeImagePath(_currentDisplayedRecipe.Id);

            // If there's an image file stored in the illustrations folder for this recipe
            if (_currentDisplayedRecipe.ImagePath != "default")
            {
                // Affects to the pictureBox the current displayed recipe illustration image
                picRecipe.Load(@Environment.CurrentDirectory + "\\illustrations\\" + _currentDisplayedRecipe.ImagePath + ".jpg");
                picRecipe.BorderStyle = BorderStyle.None;
            }
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
        /// Handles the re-calculation of the quantity of each ingredient for the currently displayed recipe
        /// </summary>
        private void nudPersons_ValueChanged(object sender, EventArgs e)
        {
            // If the user has increased by one the numeric updown control
            if (DBConnection.NbPersonsPreviouslySet < Convert.ToInt32(nudPersons.Value))
            {
                // Stores the old value of the numeric updown control in the exposed property
                DBConnection.NbPersonsPreviouslySet = Convert.ToInt32(nudPersons.Value) - 1;
            }

            // If the user has decreased by one the numeric updown control
            else if (DBConnection.NbPersonsPreviouslySet > Convert.ToInt32(nudPersons.Value))
            {
                // Stores the old value of the numeric updown control in the exposed property
                DBConnection.NbPersonsPreviouslySet = Convert.ToInt32(nudPersons.Value) + 1;
            }

            // Stores the new value of the numeric updown control in the exposed property
            DBConnection.NbPersonsSet = Convert.ToInt32(nudPersons.Value);

            // Calls the function that will read the ingredients needed to make the recipe
            DisplayRecipeInfos();
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
        /// Function to add an instruction to the currently selected recipe
        /// </summary>
        private void cmdAddInstruction_Click(object sender, EventArgs e)
        {
            frmNewInstruction _frmNewInstruction = new frmNewInstruction(this);
            _frmNewInstruction.IdRecipeToEdit = _currentDisplayedRecipe.Id;
            _frmNewInstruction.NbInstructionsInCurrentRecipe = currentInstruction;
            _frmNewInstruction.ShowDialog();
        }

        /// <summary>
        /// Opens OpenFileDialog instance and affects the selected file to the picture box
        /// </summary>
        private void picRecipe_Click(object sender, EventArgs e)
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

        private void frmMain_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Visible)
            {
                ClosePanel();  
            }
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

        private void txtTitleSearch_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = cmdTitleSearch;
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

        /// <summary>
        /// Event when the user selects a recipe in the results list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRecipeIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRecipeIngredients.SelectedIndex == cmbRecipeIngredients.Items.Count - 1)
            {
                frmNewIngredient _frmNewIngredient = new frmNewIngredient(this);
                _frmNewIngredient.ShowDialog();
            }
        }
        private void cmdDeleteIngredient_Click(object sender, EventArgs e)
        {
            dbConn.DeleteIngredient(_currentDisplayedRecipe.Id, cmbRecipeIngredients.Items.Count, _currentDisplayedRecipe.IngredientsList[cmbRecipeIngredients.Items.Count].Scale);
            this.Refresh();
        }

        /// <summary>
        /// Function to edit the title of the currently selected recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierLeTitreDeCetteRecetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string formattedTitle = lstSearchResults.SelectedItem.ToString();

            // Checks if the keywords contain an apostroph, to avoid making the sql request crash
            if (lstSearchResults.SelectedItem.ToString().Contains("'"))
            {
                formattedTitle = txtTitleSearch.Text.Replace("'", "''");
            }


            frmEditRecipeTitle _frmEditRecipeTitle = new frmEditRecipeTitle(this);
            _frmEditRecipeTitle.IdRecipeToEdit = dbConn.ReadRecipeId(formattedTitle);
            _frmEditRecipeTitle.RecipeTitleToEdit = lstSearchResults.SelectedItem.ToString();
            _frmEditRecipeTitle.ShowDialog();
        }

        /// <summary>
        /// Allows the user to drag and drop the selected recipe title
        /// Source: https://docs.microsoft.com/en-us/dotnet/framework/winforms/advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms
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

        /// <summary>
        /// Updates the score for the current selected recipe
        /// </summary>
        private void UpdateScoreForCurrentRecipe(int scoreToInput)
        {
            dbConn.UpdateScoreForRecipe(_currentDisplayedRecipe.Id, scoreToInput);
            DisplayRecipeInfos();
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

        private void picSearchByIngredient_MouseHover(object sender, EventArgs e)
        {
            if (!pnlSlideMenu.Visible)
            {
                // Opening slide menu animation
                pnlSlideMenu.Width = 350;
                Animations.Animate(pnlSlideMenu, Animations.Effect.Slide, 250, 0);
                this.Refresh();
                this.AcceptButton = cmdIngredientsSearch;
            }
        }

        private void picInventory_MouseHover(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Visible)
            {
                ClosePanel();
            }
        }

        private void picMealPlanner_MouseHover(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Visible)
            {
                ClosePanel();
            }
        }

        private void picSettings_MouseHover(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Visible)
            {
                ClosePanel();
            }
        }

        private void picInventory_Click(object sender, EventArgs e)
        {
            if (!this.InventoryShown)
            {
                this.InventoryShown = true;
                frmInventory _frmInventory = new frmInventory(this);
                _frmInventory.ShowDialog();
            }
        }

        private void picMealPlanner_Click(object sender, EventArgs e)
        {
            if (!this.MealPlannerShown)
            {
                this.MealPlannerShown = true;
                frmMealPlanner _frmMealPlanner = new frmMealPlanner(this);
                _frmMealPlanner.Show();
            }
        }

        private void picRecipeReadyToCookStatus_MouseHover(object sender, EventArgs e)
        {
            ttpMissingIngredients.Show("Indique si vous avez assez d'ingrédients pour faire la recette.", picRecipeReadyToCookStatus);
        }
       
        private void picSettings_Click(object sender, EventArgs e)
        {
            frmAbout _frmAbout = new frmAbout();
            _frmAbout.ShowDialog();
        }
    }
}
