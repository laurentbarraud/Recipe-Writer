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
        /// Deletes an instruction from a recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <param name="rankInstruction">the rank of the instruction</param>
        /// <returns>Bool if the operation succeeded</returns>
        public bool DeleteInstruction(int idRecipe, int rankInstruction)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "DELETE FROM 'Instructions_has_Recipes' WHERE id=" + idRecipe + " AND InstructionNb=" + rankInstruction + ";";
            SQLiteDataReader dataReader = cmd.ExecuteReader();

            return true;
        }

        /// <summary>
        /// Reads the id of a recipe, with its title given in argument
        /// </summary>
        /// <param name="titleRecipe"></param>the title of the selected recipe
        /// <returns>the id of the selected recipe</returns>
        public int ReadRecipeId(string titleRecipe)
        {
            string formattedTitle = titleRecipe;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (titleRecipe.Contains("'"))
            {
                formattedTitle = titleRecipe.Replace("'", "''");
            }

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT id AS idRecipeRequested FROM 'Recipes' WHERE title ='"+ formattedTitle + "';";

            int idRecipeFound = 0;
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                int.TryParse(dataReader["idRecipeRequested"].ToString(), out idRecipeFound);
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
        /// <returns>the image path for the currently selected recipe</returns>
        public string ReadRecipeImagePath(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT imagePath AS recipeImagePath FROM 'Recipes' WHERE id =" + idRecipe + ";";

            string imagePathFound = "";
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                imagePathFound = dataReader["recipeImagePath"].ToString();
            }
            return imagePathFound;
        }

        /// <summary>
        /// Reads the quantity of ingredients needed to make the current selected recipe, with their scales
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <returns>List of quantities and names of the ingredients needed to make the recipe, concatenated with their scales</returns>
        public List<string> ReadIngredientsQtyForARecipe(int idRecipe)
        {
            // Declares a list of string to contain the quantity of ingredients needed to make the recipe, concatenated with their scale
            List<string> listQtyIngredientPlusScale = new List<string>();

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Retrieves all the data about ingredients needed for the currently selected recipe
            cmd.CommandText = "SELECT qtyIngredient1, scale1.scaleName AS 'scaleIngredient1', ingredient1.ingredientName AS 'ingredient1Name', " +
                                "qtyIngredient2, scale2.scaleName AS 'scaleIngredient2', ingredient2.ingredientName AS 'ingredient2Name', " +
                                "qtyIngredient3, scale3.scaleName AS 'scaleIngredient3', ingredient3.ingredientName AS 'ingredient3Name', " +
                                "qtyIngredient4, scale4.scaleName AS 'scaleIngredient4', ingredient4.ingredientName AS 'ingredient4Name', " +
                                "qtyIngredient5, scale5.scaleName AS 'scaleIngredient5', ingredient5.ingredientName AS 'ingredient5Name', " +
                                "qtyIngredient6, scale6.scaleName AS 'scaleIngredient6', ingredient6.ingredientName AS 'ingredient6Name', " +
                                "qtyIngredient7, scale7.scaleName AS 'scaleIngredient7', ingredient7.ingredientName AS 'ingredient7Name', " +
                                "qtyIngredient8, scale8.scaleName AS 'scaleIngredient8', ingredient8.ingredientName AS 'ingredient8Name', " +
                                "qtyIngredient9, scale9.scaleName AS 'scaleIngredient9', ingredient9.ingredientName AS 'ingredient9Name', " +
                                "qtyIngredient10, scale10.scaleName AS 'scaleIngredient10', ingredient10.ingredientName AS 'ingredient10Name', " +
                                "qtyIngredient11, scale11.scaleName AS 'scaleIngredient11', ingredient11.ingredientName AS 'ingredient11Name', " +
                                "qtyIngredient12, scale12.scaleName AS 'scaleIngredient12', ingredient12.ingredientName AS 'ingredient12Name', " +
                                "qtyIngredient13, scale13.scaleName AS 'scaleIngredient13', ingredient13.ingredientName AS 'ingredient13Name', " +
                                "qtyIngredient14, scale14.scaleName AS 'scaleIngredient14', ingredient14.ingredientName AS 'ingredient14Name', " +
                                "qtyIngredient15, scale15.scaleName AS 'scaleIngredient15', ingredient15.ingredientName AS 'ingredient15Name', " +
                                "qtyIngredient16, scale16.scaleName AS 'scaleIngredient16', ingredient16.ingredientName AS 'ingredient16Name', " +
                                "qtyIngredient17, scale17.scaleName AS 'scaleIngredient17', ingredient17.ingredientName AS 'ingredient17Name', " +
                                "qtyIngredient18, scale18.scaleName AS 'scaleIngredient18', ingredient18.ingredientName AS 'ingredient18Name', " +
                                "qtyIngredient19, scale19.scaleName AS 'scaleIngredient19', ingredient19.ingredientName AS 'ingredient19Name', " +
                                "qtyIngredient20, scale20.scaleName AS 'scaleIngredient20', ingredient20.ingredientName AS 'ingredient20Name' " +
                                "FROM Recipes_has_Ingredients " +
                                "LEFT JOIN Scales AS scale1 ON Recipes_has_Ingredients.scales1_id = scale1.id " +
                                "LEFT JOIN Scales AS scale2 ON Recipes_has_Ingredients.scales2_id = scale2.id " +
                                "LEFT JOIN Scales AS scale3 ON Recipes_has_Ingredients.scales3_id = scale3.id " +
                                "LEFT JOIN Scales AS scale4 ON Recipes_has_Ingredients.scales4_id = scale4.id " +
                                "LEFT JOIN Scales AS scale5 ON Recipes_has_Ingredients.scales5_id = scale5.id " +
                                "LEFT JOIN Scales AS scale6 ON Recipes_has_Ingredients.scales6_id = scale6.id " +
                                "LEFT JOIN Scales AS scale7 ON Recipes_has_Ingredients.scales7_id = scale7.id " +
                                "LEFT JOIN Scales AS scale8 ON Recipes_has_Ingredients.scales8_id = scale8.id " +
                                "LEFT JOIN Scales AS scale9 ON Recipes_has_Ingredients.scales9_id = scale9.id " +
                                "LEFT JOIN Scales AS scale10 ON Recipes_has_Ingredients.scales10_id = scale10.id " +
                                "LEFT JOIN Scales AS scale11 ON Recipes_has_Ingredients.scales11_id = scale11.id " +
                                "LEFT JOIN Scales AS scale12 ON Recipes_has_Ingredients.scales12_id = scale12.id " +
                                "LEFT JOIN Scales AS scale13 ON Recipes_has_Ingredients.scales13_id = scale13.id " +
                                "LEFT JOIN Scales AS scale14 ON Recipes_has_Ingredients.scales14_id = scale14.id " +
                                "LEFT JOIN Scales AS scale15 ON Recipes_has_Ingredients.scales15_id = scale15.id " +
                                "LEFT JOIN Scales AS scale16 ON Recipes_has_Ingredients.scales16_id = scale16.id " +
                                "LEFT JOIN Scales AS scale17 ON Recipes_has_Ingredients.scales17_id = scale17.id " +
                                "LEFT JOIN Scales AS scale18 ON Recipes_has_Ingredients.scales18_id = scale18.id " +
                                "LEFT JOIN Scales AS scale19 ON Recipes_has_Ingredients.scales19_id = scale19.id " +
                                "LEFT JOIN Scales AS scale20 ON Recipes_has_Ingredients.scales20_id = scale20.id " +
                                "LEFT JOIN Ingredients AS ingredient1 ON Recipes_has_Ingredients.ingredient1_id = ingredient1.id " +
                                "LEFT JOIN Ingredients AS ingredient2 ON Recipes_has_Ingredients.ingredient2_id = ingredient2.id " +
                                "LEFT JOIN Ingredients AS ingredient3 ON Recipes_has_Ingredients.ingredient3_id = ingredient3.id " +
                                "LEFT JOIN Ingredients AS ingredient4 ON Recipes_has_Ingredients.ingredient4_id = ingredient4.id " +
                                "LEFT JOIN Ingredients AS ingredient5 ON Recipes_has_Ingredients.ingredient5_id = ingredient5.id " +
                                "LEFT JOIN Ingredients AS ingredient6 ON Recipes_has_Ingredients.ingredient6_id = ingredient6.id " +
                                "LEFT JOIN Ingredients AS ingredient7 ON Recipes_has_Ingredients.ingredient7_id = ingredient7.id " +
                                "LEFT JOIN Ingredients AS ingredient8 ON Recipes_has_Ingredients.ingredient8_id = ingredient8.id " +
                                "LEFT JOIN Ingredients AS ingredient9 ON Recipes_has_Ingredients.ingredient9_id = ingredient9.id " +
                                "LEFT JOIN Ingredients AS ingredient10 ON Recipes_has_Ingredients.ingredient10_id = ingredient10.id " +
                                "LEFT JOIN Ingredients AS ingredient11 ON Recipes_has_Ingredients.ingredient11_id = ingredient11.id " +
                                "LEFT JOIN Ingredients AS ingredient12 ON Recipes_has_Ingredients.ingredient12_id = ingredient12.id " +
                                "LEFT JOIN Ingredients AS ingredient13 ON Recipes_has_Ingredients.ingredient13_id = ingredient13.id " +
                                "LEFT JOIN Ingredients AS ingredient14 ON Recipes_has_Ingredients.ingredient14_id = ingredient14.id " +
                                "LEFT JOIN Ingredients AS ingredient15 ON Recipes_has_Ingredients.ingredient15_id = ingredient15.id " +
                                "LEFT JOIN Ingredients AS ingredient16 ON Recipes_has_Ingredients.ingredient16_id = ingredient16.id " +
                                "LEFT JOIN Ingredients AS ingredient17 ON Recipes_has_Ingredients.ingredient17_id = ingredient17.id " +
                                "LEFT JOIN Ingredients AS ingredient18 ON Recipes_has_Ingredients.ingredient18_id = ingredient18.id " +
                                "LEFT JOIN Ingredients AS ingredient19 ON Recipes_has_Ingredients.ingredient19_id = ingredient19.id " +
                                "LEFT JOIN Ingredients AS ingredient20 ON Recipes_has_Ingredients.ingredient20_id = ingredient20.id " +
                                "WHERE Recipes_id ="+idRecipe+";";

                SQLiteDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        if (dataReader["qtyIngredient" + i].ToString() != "")
                        {
                            // Adds the data into the list of string in a proper formatted way
                            listQtyIngredientPlusScale.Add(dataReader["qtyIngredient" + i].ToString() + " " + dataReader["scaleIngredient" + i].ToString() + " de " + dataReader["ingredient" +i+ "Name"].ToString());       
                        }
                    }
                }

            return listQtyIngredientPlusScale;
        }

        /// <summary>
        /// Reads the name of an ingredient for a given id
        /// </summary>
        /// <param name="idIngredient">the id of the ingredient</param>
        /// <returns>Name of the ingredient</returns>
        public string ReadIngredientName(int idIngredient)
        {
            // Declares a string to contain the ingredient name
            string ingredientNameFound = "";

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "SELECT ingredientName FROM 'Ingredients' WHERE id=" + idIngredient + ";";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ingredientNameFound = dataReader["ingredientName"].ToString();
            }

            return ingredientNameFound;
        }

        /// <summary>
        /// Reads the instructions needed to make the currently selected recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <returns>List of the instructions to follow to make the recipe</returns>
        public List<Instructions> ReadInstructionsForARecipe(int idRecipe)
        {
            int instructionId = 0;
            string textInstruction = "";
            int recipeId = 0;
            int rankInstruction = 0;

            // Declares a list of string to contain the instructions to follow to make the currently selected recipe
            List<Instructions> listInstructionsRequested = new List<Instructions>();

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Retrieves all the data about ingredients needed for the currently selected recipe
            cmd.CommandText = "SELECT Instructions_id, instruction, Recipes_id, InstructionNb " +
                                "FROM Instructions_has_Recipes " +
                                "INNER JOIN Instructions ON Instructions_has_Recipes.Instructions_id = Instructions.id " +
                                "WHERE Recipes_id ='" + idRecipe + "';";

            SQLiteDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int.TryParse(dataReader["Instructions_id"].ToString(), out instructionId);
                textInstruction = dataReader["instruction"].ToString();
                int.TryParse(dataReader["Recipes_id"].ToString(), out recipeId);
                int.TryParse(dataReader["InstructionNb"].ToString(), out rankInstruction);

                Instructions instructionToAdd = new Instructions(instructionId, textInstruction, recipeId, rankInstruction);
                listInstructionsRequested.Add(instructionToAdd);
            }

            return listInstructionsRequested;
        }

        /// <summary>
        /// Reads the list of the ingredients found with up to 3 ingredients found in the recipes
        /// </summary>
        /// <param name="ingredientInput1">first ingredient to search with</param>
        /// <param name="ingredientInput2">second ingredient to search with</param>
        /// <param name="ingredientInput3">third ingredient to search with</param>
        /// <returns>Integer list of the id of the recipes found in the database</returns>
        public List<string> SearchRecipesByIngredients(string ingredientInput1 = "", string ingredientInput2 = "", string ingredientInput3 = "")
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "SELECT Recipes.title AS RecipesTitlesRequested, ingredient1.ingredientName AS 'ingredient1Name'," +
                                "ingredient2.ingredientName AS 'ingredient2Name', ingredient3.ingredientName AS 'ingredient3Name', ingredient4.ingredientName AS 'ingredient4Name', " +
                                "ingredient5.ingredientName AS 'ingredient5Name', ingredient6.ingredientName AS 'ingredient6Name', ingredient7.ingredientName AS 'ingredient7Name',  " +
                                "ingredient8.ingredientName AS 'ingredient8Name', ingredient9.ingredientName AS 'ingredient9Name', ingredient10.ingredientName AS 'ingredient10Name', " +
                                "ingredient11.ingredientName AS 'ingredient11Name', ingredient12.ingredientName AS 'ingredient12Name', ingredient13.ingredientName AS 'ingredient13Name', " +
                                "ingredient14.ingredientName AS 'ingredient14Name', ingredient15.ingredientName AS 'ingredient15Name', ingredient16.ingredientName AS 'ingredient16Name', " +
                                "ingredient17.ingredientName AS 'ingredient17Name', ingredient18.ingredientName AS 'ingredient18Name', ingredient19.ingredientName AS 'ingredient19Name', ingredient20.ingredientName AS 'ingredient20Name' " +
                                "FROM Recipes_has_Ingredients " +
                                "LEFT JOIN Ingredients AS ingredient1 ON Recipes_has_Ingredients.ingredient1_id = ingredient1.id " +
                                "LEFT JOIN Ingredients AS ingredient2 ON Recipes_has_Ingredients.ingredient2_id = ingredient2.id " +
                                "LEFT JOIN Ingredients AS ingredient3 ON Recipes_has_Ingredients.ingredient3_id = ingredient3.id " +
                                "LEFT JOIN Ingredients AS ingredient4 ON Recipes_has_Ingredients.ingredient4_id = ingredient4.id " +
                                "LEFT JOIN Ingredients AS ingredient5 ON Recipes_has_Ingredients.ingredient5_id = ingredient5.id " +
                                "LEFT JOIN Ingredients AS ingredient6 ON Recipes_has_Ingredients.ingredient6_id = ingredient6.id " +
                                "LEFT JOIN Ingredients AS ingredient7 ON Recipes_has_Ingredients.ingredient7_id = ingredient7.id " +
                                "LEFT JOIN Ingredients AS ingredient8 ON Recipes_has_Ingredients.ingredient8_id = ingredient8.id " +
                                "LEFT JOIN Ingredients AS ingredient9 ON Recipes_has_Ingredients.ingredient9_id = ingredient9.id " +
                                "LEFT JOIN Ingredients AS ingredient10 ON Recipes_has_Ingredients.ingredient10_id = ingredient10.id " +
                                "LEFT JOIN Ingredients AS ingredient11 ON Recipes_has_Ingredients.ingredient11_id = ingredient11.id " +
                                "LEFT JOIN Ingredients AS ingredient12 ON Recipes_has_Ingredients.ingredient12_id = ingredient12.id " +
                                "LEFT JOIN Ingredients AS ingredient13 ON Recipes_has_Ingredients.ingredient13_id = ingredient13.id " +
                                "LEFT JOIN Ingredients AS ingredient14 ON Recipes_has_Ingredients.ingredient14_id = ingredient14.id " +
                                "LEFT JOIN Ingredients AS ingredient15 ON Recipes_has_Ingredients.ingredient15_id = ingredient15.id " +
                                "LEFT JOIN Ingredients AS ingredient16 ON Recipes_has_Ingredients.ingredient16_id = ingredient16.id " +
                                "LEFT JOIN Ingredients AS ingredient17 ON Recipes_has_Ingredients.ingredient17_id = ingredient17.id " +
                                "LEFT JOIN Ingredients AS ingredient18 ON Recipes_has_Ingredients.ingredient18_id = ingredient18.id " +
                                "LEFT JOIN Ingredients AS ingredient19 ON Recipes_has_Ingredients.ingredient19_id = ingredient19.id " +
                                "LEFT JOIN Ingredients AS ingredient20 ON Recipes_has_Ingredients.ingredient20_id = ingredient20.id " +
                                "LEFT JOIN Recipes ON Recipes_id = Recipes_id";

            // Counting the number of words given in arguments
            int nbIngredientsTyped = 0;

            if (ingredientInput1 != "")
                nbIngredientsTyped++;
            if (ingredientInput2 != "")
                nbIngredientsTyped++;
            if (ingredientInput3 != "")
                nbIngredientsTyped++;
           
            // Adding each ingredients to the search with AND operator
            if (nbIngredientsTyped > 0)
            {
                cmd.CommandText += " WHERE (ingredient1Name LIKE '%" + ingredientInput1 + "%' OR ingredient2Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient3Name LIKE '%" + ingredientInput1 + "%'  OR  ingredient4Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient5Name LIKE '%" + ingredientInput1 + "%' OR ingredient6Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient7Name LIKE '%" + ingredientInput1 + "%' OR ingredient8Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient9Name LIKE '%" + ingredientInput1 + "%' OR ingredient10Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient11Name LIKE '%" + ingredientInput1 + "%'  OR  ingredient12Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient13Name LIKE '%" + ingredientInput1 + "%' OR ingredient14Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient15Name LIKE '%" + ingredientInput1 + "%'  OR  ingredient16Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient17Name LIKE '%" + ingredientInput1 + "%' OR ingredient18Name LIKE '%" + ingredientInput1 + "%'" +
                                    " OR ingredient19Name LIKE '%" + ingredientInput1 + "%' OR ingredient20Name LIKE '%" + ingredientInput1 + "%'";

                if (nbIngredientsTyped > 1)
                {
                    cmd.CommandText += ") AND (ingredient1Name LIKE '%" + ingredientInput2 + "%' OR ingredient2Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient3Name LIKE '%" + ingredientInput2 + "%' OR  ingredient4Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient5Name LIKE '%" + ingredientInput2 + "%' OR ingredient6Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient7Name LIKE '%" + ingredientInput2 + "%' OR ingredient8Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient9Name LIKE '%" + ingredientInput2 + "%' OR ingredient10Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient11Name LIKE '%" + ingredientInput2 + "%' OR ingredient12Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient13Name LIKE '%" + ingredientInput2 + "%' OR ingredient14Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient15Name LIKE '%" + ingredientInput2 + "%' OR ingredient16Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient17Name LIKE '%" + ingredientInput2 + "%' OR ingredient18Name LIKE '%" + ingredientInput2 + "%'" +
                                    " OR ingredient19Name LIKE '%" + ingredientInput2 + "%' OR ingredient20Name LIKE '%" + ingredientInput2 + "%'";

                    if (nbIngredientsTyped > 2)
                    {
                        cmd.CommandText += ") AND (ingredient1Name LIKE '%" + ingredientInput3 + "%' OR ingredient2Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient3Name LIKE '%" + ingredientInput3 + "%' OR ingredient4Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient5Name LIKE '%" + ingredientInput3 + "%' OR ingredient6Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient7Name LIKE '%" + ingredientInput3 + "%' OR ingredient8Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient9Name LIKE '%" + ingredientInput3 + "%' OR ingredient10Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient11Name LIKE '%" + ingredientInput3 + "%' OR ingredient12Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient13Name LIKE '%" + ingredientInput3 + "%' OR ingredient14Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient15Name LIKE '%" + ingredientInput3 + "%' OR ingredient16Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient17Name LIKE '%" + ingredientInput3 + "%' OR ingredient18Name LIKE '%" + ingredientInput3 + "%'" +
                                    " OR ingredient19Name LIKE '%" + ingredientInput3 + "%' OR ingredient20Name LIKE '%" + ingredientInput3 + "%'";
                    }
                }
            }

            // Completes the sql request
            cmd.CommandText += ");";

            // Declares a list of string to contain the titles of the recipes found in the database
            List<string> recipesTitlesFound = new List<string>();
            string titleFound = "";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                titleFound = dataReader["RecipesTitlesRequested"].ToString();
                recipesTitlesFound.Add(titleFound);
            }

            return recipesTitlesFound;
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
        public List<string> SearchRecipesByTitle(string keywordInput1 = "", string keywordInput2 = "", string keywordInput3 = "", string keywordInput4 = "", string keywordInput5 = "", string keywordInput6 = "", string keywordInput7 = "", string keywordInput8 = "")
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

            // Adding each keywords to the search with AND operator
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
        /// Updates an instruction text for the selected recipe
        /// </summary>
        /// <param name="idInstruction">the id of the instruction</param>
        /// <param name="newInstructionText">the new text of the instruction</param>
        public void UpdateInstruction(int idInstruction, string newInstructionText)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'Instructions' SET instruction ='" + newInstructionText + "' WHERE id =" + idInstruction + ";";
            cmd.ExecuteReader();
        }

        /// <summary>
        /// Updates the image path for the selected recipe
        /// </summary>
        /// <param name="idRecipe">the id of the currently selected recipe</param>
        /// <param name="newImagePath">the new image path to update</param>
        public void UpdateImagePath(int idRecipe, string newImagePath)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'Recipes' SET imagePath ='" + newImagePath + "' WHERE id =" + idRecipe + ";";
            cmd.ExecuteReader();
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
