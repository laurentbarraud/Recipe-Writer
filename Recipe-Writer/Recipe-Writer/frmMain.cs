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
        public static List<Instructions> _defaultListInstruction = new List<Instructions>();

        // Declares and instanciates the list that will handle the selected instruction
        private List<InstructionSelections> instructionSelection = new List<InstructionSelections>();

        // Declares and instanciates the current displayed recipe object, constructed with default values, and accessible globally
        public Recipes _currentDisplayedRecipe = new Recipes(0, "", 0, 0, 0, "default", null, _defaultListInstruction);

        private int currentInstruction = 0;
        private int selectedInstruction = -1;


        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
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

        private void cmdTitleSearch_Click(object sender, EventArgs e)
        { 
            // If the user has typed something in the textbox
            if (txtTitleSearch.Text != "")
            {
                SearchRecipes();
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
        private void SearchRecipes()
        {
            // Empties the listbox control
            lstSearchResults.Items.Clear();

            string formattedKeywords = txtTitleSearch.Text;

            // Checks if the keywords contain an apostroph, to avoid making the sql request crash
            if (txtTitleSearch.Text.Contains("'"))
            {
                formattedKeywords = txtTitleSearch.Text.Replace("'", "''");
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

                        // Calls the dbConn.SearchRecipes function with only one keyword in argument and adds the returned title in the list of string
                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0]))
                        {
                            // Adds each title found as a new item in the listbox control
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    // If the user has typed two words in the search textbox
                    case 2:

                        // Calls the dbConn.SearchRecipes function with two keywords in argument and adds the returned titles in the list of string
                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1]))
                        {
                            // Adds each title found as a new item in the listbox control
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 3:

                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 4:

                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 5:

                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 6:

                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 7:

                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5], arrayKeywordsInput[6]))
                        {
                            lstSearchResults.Items.Add(title);
                        }
                        break;

                    case 8:

                        // Calls the dbConn.SearchRecipes function with eight keywords in argument and adds the returned title in the list of string
                        foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5], arrayKeywordsInput[6], arrayKeywordsInput[7]))
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
                // Calls the dbConn.SearchRecipes function with eight keywords in argument and adds the returned title in the list of string
                foreach (string title in dbConn.SearchRecipes(arrayKeywordsInput[0], arrayKeywordsInput[1], arrayKeywordsInput[2], arrayKeywordsInput[3], arrayKeywordsInput[4], arrayKeywordsInput[5], arrayKeywordsInput[6], arrayKeywordsInput[7]))
                {
                    // Adds each title found as a new item in the listbox control
                    lstSearchResults.Items.Add(title);
                }
            }
        }
                
        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRecipeInfos();
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

            // Calls the function that will read the ingredients needed to make the recipe
            _currentDisplayedRecipe.QtyIngredientsScaleList = dbConn.ReadIngredientsQtyForARecipe(_currentDisplayedRecipe.Id);

            // Clears the combobox of ingredients before adding the items found
            cmbRecipeIngredients.Items.Clear();

            // Adds each ingredients list item as a new item in the ingredients comboBox
            foreach (string ingredientItem in _currentDisplayedRecipe.QtyIngredientsScaleList)
            {
                cmbRecipeIngredients.Items.Add(ingredientItem);
            }

            // Calls the function that will return the instructions list to follow to make the recipe,
            // then and affects them to the current displayed Recipe instruction list.
            _currentDisplayedRecipe.InstructionsList = dbConn.ReadInstructionsForARecipe(_currentDisplayedRecipe.Id);

            // Calls the function that creates the instruction labels dynamically
            CreateInstructionsLayout();

            // Calls the function that display the illustration image for the currently selected recipe
            _currentDisplayedRecipe.ImagePath = dbConn.ReadRecipeImagePath(_currentDisplayedRecipe.Id);

            // Affects to the pictureBox the current displayed recipe illustration image
            picRecipe.Load(@Environment.CurrentDirectory + "\\illustrations\\" + _currentDisplayedRecipe.ImagePath + ".jpg");
            picRecipe.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Creates the instructions layout to display them to the user
        /// </summary>
        public void CreateInstructionsLayout()
        {
            currentInstruction = 0;

            // Layout parameters =================================================================================
            int lineHeight = 24;
            int iconHeight = 25;
            int iconWidth = 25;
            int spacingWidth = 15;
            int spacingHeight = 15;

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
    }
}
