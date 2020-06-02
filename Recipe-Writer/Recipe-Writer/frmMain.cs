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
        // Declares and instanciates the current displayed recipe object, constructed with default values, and accessible globally
        Recipes _currentDisplayedRecipe = new Recipes(0, "", 0, 0, 0, "default", null, null);

        public frmMain()
        {
            InitializeComponent();
        }

        // Declares and instancies a connection to the database
        private DBConnection dbConn = new DBConnection();

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
            // Empties the listbox control
            lstSearchResults.Items.Clear();            

                // If the user has typed something in the textbox
                if (txtTitleSearch.Text != "")
                {
                    // Declares an array and stores the keywordsSeparates the text typed by the user in the search text box into keywords and stores them in an array
                    string[] arrayKeywordsInput = txtTitleSearch.Text.Split(' ');

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
                // If the search textbox is empty
                else
                {
                    MessageBox.Show("Veuillez taper un ou plusieurs terme(s) de recherche.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
        }

        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // To-Do : implement a function that affects to the _currentDisplayedRecipe object the values returned by each of the 5 functions,
            // each being called one after.
        }
    }
}
