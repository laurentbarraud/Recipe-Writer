using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Recipe_Writer
{
    public class DBConnection
    {
        // Declaration of a private attribute of type SQLiteConnection
        SQLiteConnection sqliteConn;

        // Constructor
        public DBConnection()
        {
            // Creates a new database connection :
            sqliteConn = new SQLiteConnection("Data Source=" + @Environment.CurrentDirectory + "\\" + "recipe-album" + ".db; Version=3; Compress=True;");
        }

        /// <summary>
        /// Opens the connection to the database
        /// </summary>
        public void Open()
        {
            sqliteConn.Open();
        }
        public bool CheckDBIntegrity()
        {
            // Checks the database integrity
            try
            {
                // Tries to do a transaction and at once rolls it back
                using (var transaction = sqliteConn.BeginTransaction())
                {
                    transaction.Rollback();
                }
            }

            // If the database is corrupted and an error is generated
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates the database file in the app's installation folder
        /// </summary>
        public void CreateFile()
        {
            SQLiteConnection.CreateFile(@Environment.CurrentDirectory + "\\" + "recipe-album" + ".db");
        }

        /// <summary>
        /// Create the tables, in case the database file is not found in the application directory
        /// </summary>
        public void CreateTables()
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = System.IO.File.ReadAllText(@Environment.CurrentDirectory + "\\scripts\\" + "Recipe-writer-create-tables" + ".sql");
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Inserts the data into the DB
        /// </summary>
        public void InsertInitialData()
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = System.IO.File.ReadAllText(@Environment.CurrentDirectory + "\\scripts\\" + "Recipe-writer-insert-initial-data" + ".sql");
            cmd.ExecuteNonQuery();
        }    


        /// <summary>
        /// Deletes a recipe from the database
        /// </summary>
        /// <param name="idRecipe">the id of the recipe to delete</param>
        /// <returns>Bool if the operation succeeded</returns>
        public bool DeleteRecipe(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "DELETE FROM 'Recipes' WHERE id=" + idRecipe + ";";
            SQLiteDataReader dataReader = cmd.ExecuteReader();

            return true;
        }

        /// <summary>
        /// Reads the id of a recipe, with its title given in argument
        /// </summary>
        /// <param name="titleRecipe"></param>the title of the selected recipe
        /// <returns>the id of the selected recipe</returns>
        public int ReadRecipeId(int titleRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT id AS idRecipeRequested FROM 'Recipes' WHERE title =" + titleRecipe + ";";

            int idRecipeFound = 0;
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataReader["idRecipeRequested"].ToString();
            }
            return idRecipeFound;
        }

        /// <summary>
        /// Reads a recipe title from the database
        /// </summary>
        /// <param name="idRecipe"></param>the id of the recipe
        /// <returns>the title of the recipe</returns>
        public string ReadRecipeTitle(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT title AS titleRecipe FROM 'Recipes' WHERE id =" + idRecipe + ";";

            string titleFound = "";
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataReader["titleRecipe"].ToString();
            }
            return titleFound;
        }

        /// <summary>
        /// Reads a recipe completion time (preparing and baking time cumulated).
        /// </summary>
        /// <param name="idRecipe"></param>the id of the recipe
        /// <returns>the preparing time of the recipe</returns>
        public int ReadRecipeCompletionTime(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT completionTime AS completionTimeRecipe FROM 'Recipes' WHERE id =" + idRecipe + ";";

            int completionTimeValueFound = 0;
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                int.TryParse(dataReader["completionTimeRecipe"].ToString(), out completionTimeValueFound);
            }
            return completionTimeValueFound;
        }

        /// <summary>
        /// Reads a recipe low budget status
        /// </summary>
        /// <param name="idRecipe"></param>the id of the recipe to display
        /// <returns>int value acting as a bool if the recipe is low budget or not</returns>
        public int ReadRecipeLowBudgetStatus(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT lowBudget AS recipeLowBudgetStatus FROM 'Recipes' WHERE id =" + idRecipe + ";";

            int lowBudgetValueFound = 0;
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                int.TryParse(dataReader["recipeLowBudgetStatus"].ToString(), out lowBudgetValueFound);
            }
            return lowBudgetValueFound;
        }

        /// <summary>
        /// Reads a recipe score
        /// </summary>
        /// <param name="idRecipe"></param>the id of the recipe to display
        /// <returns>the score currently affected to the the recipe</returns>
        public int ReadRecipeScore(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT score AS scoreRecipe FROM 'Recipes' WHERE id =" + idRecipe + ";";

            int scoreFound = 0;
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                int.TryParse(dataReader["scoreRecipe"].ToString(), out scoreFound);
            }
            return scoreFound;
        }

        /// <summary>
        /// Reads a recipe low budget status
        /// </summary>
        /// <param name="idRecipe"></param>the id of the recipe to display
        /// <returns>an int value acting as a bool if the recipe is low budget or not</returns>
        public string ReadRecipeImagePath(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT imagePath AS recipeImagePath FROM 'Recipes' WHERE id =" + idRecipe + ";";

            string imagePathFound = "";
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataReader["recipeLowBudgetStatus"].ToString();
            }
            return imagePathFound;
        }

        /// <summary>
        /// Reads the list of the recipes found with up to 8 keywords found in their title
        /// </summary>
        /// <param name="keywordInput1">first keyword to search with</param>
        /// <param name="keywordInput2">second keyword to search with</param>
        /// <param name="keywordInput3">third keyword to search with</param>
        /// <param name="keywordInput4">fourth keyword to search with</param>
        /// <param name="keywordInput5">fifth keyword to search with</param>
        /// <param name="keywordInput6">sixth keyword to search with</param>
        /// <param name="keywordInput7">seventh keyword to search with</param>
        /// <param name="keywordInput8">eight keyword to search with</param>
        /// <returns>List of the titles of the recipes found in the database</returns>
        public List<string> SearchRecipes(string keywordInput1 = "", string keywordInput2 = "", string keywordInput3 = "", string keywordInput4 = "", string keywordInput5 = "", string keywordInput6 = "", string keywordInput7 = "", string keywordInput8 = "")
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "SELECT title FROM 'Recipes'";

            // Counting the number of words given in arguments
            int nbKeywordsTyped = 0;

            if (keywordInput1 != "")
                nbKeywordsTyped++;
            if (keywordInput2 != "")
                nbKeywordsTyped++;
            if (keywordInput3 != "")
                nbKeywordsTyped++;
            if (keywordInput4 != "")
                nbKeywordsTyped++;
            if (keywordInput5 != "")
                nbKeywordsTyped++;
            if (keywordInput6 != "")
                nbKeywordsTyped++;
            if (keywordInput7 != "")
                nbKeywordsTyped++;
            if (keywordInput8 != "")
                nbKeywordsTyped++;

            if (nbKeywordsTyped > 0)
            {
                cmd.CommandText += "WHERE title LIKE '%"+ keywordInput1 +"%'";

                if (nbKeywordsTyped > 1)
                {
                    cmd.CommandText += " AND title LIKE '%" + keywordInput2 + "%'";

                    if (nbKeywordsTyped > 2)
                    {
                        cmd.CommandText += " AND title LIKE '%" + keywordInput3 + "%'";
                        
                        if (nbKeywordsTyped > 3)
                        {
                            cmd.CommandText += " AND title LIKE '%" + keywordInput4 + "%'";

                            if (nbKeywordsTyped > 4)
                            {
                                cmd.CommandText += " AND title LIKE '%" + keywordInput5 + "%'";

                                if (nbKeywordsTyped > 5)
                                {
                                    cmd.CommandText += " AND title LIKE '%" + keywordInput6 + "%'";
                                    
                                    if (nbKeywordsTyped > 6)
                                    {
                                        cmd.CommandText += " AND title LIKE '%" + keywordInput7 + "%'";
                                    
                                        if (nbKeywordsTyped > 7)
                                        {
                                            cmd.CommandText += " AND title LIKE '%" + keywordInput8 + "%'";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Completes the sql request
            cmd.CommandText += ";";

            // Declares a list of string to contain the results found in the database
            List<string> titlesFound = new List<string>();

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                titlesFound.Add(dataReader["title"].ToString());
            }

            return titlesFound;
        }


        /// <summary>
        /// Updates the title, the completionTime and the lowBudget status of a recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <param name="newTitleRecipe">the new title of the recipe, if the user has edited it</param>
        /// <param name="newCompletionTime">the new completion time of the recipe, if the user has edited it</param>
        /// <param name="newLowBudgetStatus">the low budget value of the recipe, if the user has edited it</param>
        public void UpdateRecipeBasicInfo(int idRecipe, string newTitleRecipe = "", string newCompletionTime = "", string newLowBudgetStatus = "")
        {
            if (newTitleRecipe != "")
            {
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = "UPDATE 'Recipes' SET title =" + newTitleRecipe + "WHERE id =" + idRecipe + ";";
                cmd.ExecuteReader();
            }

            if (newCompletionTime != "")
            {
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = "UPDATE 'Recipes' SET completionTime =" + newCompletionTime + "WHERE id =" + idRecipe + ";";
                cmd.ExecuteReader();
            }

            if (newLowBudgetStatus != "")
            {
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = "UPDATE 'Recipes' SET lowBudget =" + newLowBudgetStatus + "WHERE id =" + idRecipe + ";";
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Inserts a new recipe in the database, with its basic data
        /// </summary>
        /// <param name="newRecipeTitle">the new title of the recipe, if the user has edited it</param>
        /// <param name="newRecipeCompletionTime">the new completion time of the recipe, if the user has edited it</param>
        /// <param name="newRecipeLowBudgetStatus">the low budget value of the recipe, if the user has edited it</param>
        public void MakeNewRecipe(string newRecipeTitle, string newRecipeCompletionTime = "", string newRecipeLowBudgetStatus = "")
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "INSERT INTO 'Recipes' (title) VALUES (" + newRecipeTitle + ");";

            if (newRecipeCompletionTime != "")
            {
                cmd.CommandText += "INSERT INTO 'Recipes' (completionTime) VALUES (" + newRecipeCompletionTime + ");";
                
            }

            if (newRecipeLowBudgetStatus != "")
            {
                cmd.CommandText += "INSERT INTO 'Recipes' (lowBudget) VALUES (" + newRecipeLowBudgetStatus + ");";
            }                            
        }

        /// <summary>
        /// Closes the connection to the database
        /// </summary>
        public void Close()
        {
            sqliteConn.Close();
        }
    }
}
