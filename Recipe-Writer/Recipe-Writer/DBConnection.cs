/// <file>DBConnection.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 1st 2025</date>

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public class DBConnection
    {
        // Declaration of a private attribute of type SQLiteConnection
        SQLiteConnection sqliteConn;

        // These variables are used to recalculate the portions for a selected recipe
        private static int nbPersonsPreviouslySet = 2;
        private static int nbPersonsSet = 2;

        /// <summary>
        /// This exposed property is used to store the previous numeric updown value during execution
        /// </summary>
        public static int NbPersonsPreviouslySet
        {
            get { return nbPersonsPreviouslySet; }
            set { nbPersonsPreviouslySet = value; }
        }

        /// <summary>
        /// This exposed property is used to store the current numeric updown value during execution
        /// </summary>
        public static int NbPersonsSet
        {
            get { return nbPersonsSet; }
            set { nbPersonsSet = value; }
        }


        // Constructor - Adds the parent form as parameter
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
        /// Adds a new ingredient into the database to the recipe given in argument
        /// </summary>
        /// <param name="idRecipe">the id of the recipe whose is adding the new ingredient</param>
        /// <param name="qtyIngredient">the quantity of the new ingredient</param>
        /// <param name="newIngredientName">the name of the new ingredient/param>
        /// <param name="scaleIngredient">the scale used by the new ingredient</param>
        /// <param name="nbIngredientsForARecipe">the number of ingredients needed for the selected recipe</param>
        public void AddNewIngredient(int idRecipe, double qtyIngredient, string newIngredientName, string scaleIngredient, int nbIngredientsForARecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "INSERT INTO 'Ingredients' (ingredientName, qtyAvailable) VALUES ("+newIngredientName+", '0.0') " +
                              "INSERT INTO 'Recipes_has_Ingredients' (qtyIngredient"+nbIngredientsForARecipe+1+", ingredient"+nbIngredientsForARecipe+1+", scales"+nbIngredientsForARecipe+1+") VALUES ('"+qtyIngredient+"', '"+newIngredientName+"', '"+scaleIngredient+"') " +
                              "WHERE id = '"+idRecipe+"';";
        }


        /// <summary>
        /// Adds a new instruction into the database
        /// </summary>
        /// <param name="idRecipe">the text of the new instruction</param>
        /// <param name="txtNewInstruction">the text of the new instruction</param>
        public int AddNewInstruction(int idRecipe, string txtNewInstruction)
        {
            int lastInstructionId = 0;

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "INSERT INTO 'Instructions' (instruction) VALUES ('"+txtNewInstruction+"');";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "Select id FROM 'Instructions' ORDER BY id DESC LIMIT 1;";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                // Parses the id of the instruction which got affected by auto-increment
                int.TryParse(dataReader["id"].ToString(), out lastInstructionId);
            }
            
            return lastInstructionId;  
        }

        /// <summary>
        /// Adds a new instruction reference into the database for the recipe given in argument
        /// </summary>
        /// <param name="idRecipe">the id of the recipe whose for which we add the new instruction</param>
        /// <param name="nbInstructionsForRecipe">the number of instructions already store for the selected recipe</param>
        /// <param name="txtNewInstruction">the text of the new instruction</param>
        public void AddNewInstructionToRecipe(int idRecipeToInput, int nbInstructionsForRecipe, string txtNewInstruction)
        {
            int lastInstructionId = AddNewInstruction(idRecipeToInput, txtNewInstruction);

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "INSERT INTO 'Instructions_has_Recipes' (Recipes_id, Instructions_id, InstructionNb) " +
                              "VALUES ('" + idRecipeToInput + "','" + lastInstructionId + "','" + nbInstructionsForRecipe + 1 + "')";

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds a new recipe into the database, with its basic data
        /// </summary>
        /// <param name="newRecipeTitle">the title of the new recipe</param>
        /// <param name="newRecipeCompletionTime">the completion time of the new recipe</param>
        /// <param name="newRecipeLowBudgetStatus">the low budget value of the new recipe</param>
        public void AddNewRecipe(string newRecipeTitle, string newRecipeCompletionTime, int newRecipeLowBudgetStatus)
        {
            string formattedNewRecipeTitle = newRecipeTitle;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (newRecipeTitle.Contains("'"))
            {
                formattedNewRecipeTitle = newRecipeTitle.Replace("'", "''");
            }

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "INSERT INTO Recipes (title, completionTime, lowBudget, score, imagePath) VALUES (@title, @completionTime, @lowBudget, @score, @imagePath);";

            cmd.Parameters.AddWithValue("@title", formattedNewRecipeTitle);
            cmd.Parameters.AddWithValue("@completionTime", newRecipeCompletionTime);
            cmd.Parameters.AddWithValue("@lowBudget", newRecipeLowBudgetStatus);
            cmd.Parameters.AddWithValue("@score", 0);
            cmd.Parameters.AddWithValue("@imagePath", DBNull.Value); // We use DBNull.Value to indicate null value in SQLite

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds a new ingredient to the database
        /// <param name="idTypeOfIngredient"></param>
        /// </summary>
        public void AddNewIngredientToDB(string ingredientName, int scaleIdForThisIngredient, int idTypeOfIngredient)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Configure the command with parameters to avoid SQL injection
            cmd.CommandText = "INSERT INTO Ingredients (ingredientName, scale_id, typeOfIngredient_id) " +
                              "VALUES (@ingredientName, @scaleId, @idTypeOfIngredient);";
            cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
            cmd.Parameters.AddWithValue("@scaleId", scaleIdForThisIngredient);
            cmd.Parameters.AddWithValue("@idTypeOfIngredient", idTypeOfIngredient);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds a new ingredient to the selected recipe in argument
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <param name="newIngredientId">the id of the new ingredient</param>
        /// <param name="nbIngredientsForARecipe">the number of ingredients linked to the recipe</param>
        public void AddNewIngredientToRecipe(int idRecipe, int nbIngredientsForARecipe, int newIngredientId)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Configure the command with parameters to avoid SQL injection
            cmd.CommandText = "INSERT INTO Recipes_has_Ingredients (qtyIngredient, ingredient_id) " +
                              "VALUES (@qtyIngredient, @ingredientId) WHERE id = @idRecipe;";
            cmd.Parameters.AddWithValue("@qtyIngredient", 0.0);
            cmd.Parameters.AddWithValue("@ingredientId", newIngredientId);
            cmd.Parameters.AddWithValue("@idRecipe", idRecipe);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Counts the number of ingredients stored in the database
        /// </summary>
        /// <returns>the number of ingredients stored in the database</returns>
        public int CountAllIngredientsStored()
        {
            // Declares a list of ingredients to contain the ones needed to make the recipe
            int nbOfIngredientsStored = 0;

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) AS nbIngredientsStored FROM Ingredients;";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {     
                // Parses the quantity of the ingredient
                int.TryParse(dataReader["nbIngredientsStored"].ToString(), out nbOfIngredientsStored);
            }

            return nbOfIngredientsStored;
        }

        /// <summary>
        /// Counts the number of ingredients stored for a given recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <returns>the number of ingredients stored for the recipe</returns>
        public int CountAllIngredientsForARecipe(int idRecipe)
        {
            int nbOfIngredientsRequiredForThisRecipe = 0;

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = @"SELECT ingredient1_id, ingredient2_id, ingredient3_id, ingredient4_id, ingredient5_id, ingredient6_id," +
                                "ingredient7_id, ingredient8_id, ingredient9_id, ingredient10_id, ingredient11_id, ingredient12_id," +
                                "ingredient13_id, ingredient14_id, ingredient15_id, ingredient16_id, ingredient17_id, ingredient18_id," +
                                "ingredient19_id, ingredient20_id FROM Recipes_has_Ingredients WHERE id = '"+idRecipe+"';";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 1; i <= 20; i++)
                {
                    if (dataReader["ingredient"+i+"_id"].ToString() != "")
                    {
                        nbOfIngredientsRequiredForThisRecipe++;
                    }
                }
            }

            return nbOfIngredientsRequiredForThisRecipe;
        }


        /// <summary>
        /// Counts the total of types of ingredients stored
        /// </summary>
        /// <returns>the total of types stored</returns>
        public byte CountAllTypesOfIngredients()
        {
            Byte nbOfTypesOfIngredientsFound = 0;

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(type) FROM TypesOfIngredient;";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Byte.TryParse(dataReader["COUNT(type)"].ToString(), out nbOfTypesOfIngredientsFound);
            }

            return nbOfTypesOfIngredientsFound;
        }

        /// <summary>
        /// Deletes the selected ingredient in the combobox from the currently displayed recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <param name="rankIngredient">the rank of ingredient</param>
        public bool DeleteIngredientFromARecipe(int idRecipe, int rankIngredient)
        {
            try
            {
                // SQL Query using parameters to avoid errors and SQL injections
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = $@"UPDATE Recipes_has_Ingredients
                                     SET qtyIngredient{rankIngredient} = NULL,
                                      ingredient{rankIngredient}_id = NULL
                                     WHERE id = @IdRecipe;";

                // Added parameters for better security and readability
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                cmd.ExecuteNonQuery();

                return true;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur pendant la suppression de l'ingrédient de la recette : {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Deletes an ingredient from all recipes in Recipes_has_ingredients and from Ingredients,
        /// ensuring columns are shifted and IDs are reordered.
        /// </summary>
        /// <param name="idIngredient">The ID of the ingredient to delete></param>
        /// <returns></returns>
        public bool DeleteIngredientFromAllRecipesAndFromDB(int idIngredient)
        {
            try
            {
                // Ensures the database connection is open
                if (sqliteConn.State != System.Data.ConnectionState.Open)
                {
                    sqliteConn.Open();
                }

                // Step 1: Gets all recipe IDs in Recipes_has_Ingredients
                List<int> recipesIDs = new List<int>();
                string selectRecipeIdsQuery = "SELECT id FROM Recipes_has_Ingredients;";
                using (SQLiteCommand selectCommand = new SQLiteCommand(selectRecipeIdsQuery, sqliteConn))
                {
                    using (SQLiteDataReader dataReader = selectCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            recipesIDs.Add(dataReader.GetInt32(0)); // Collect recipe IDs
                        }
                    }
                }

                // Step 2: Processes each recipe to delete the ingredient and shift columns
                foreach (int idRecipe in recipesIDs)
                {
                    bool ingredientFound = false;

                    for (int i = 1; i <= 20; i++)
                    {
                        string selectIngredientQuery = $"SELECT ingredient{i}_id FROM Recipes_has_Ingredients WHERE id = @RecipeID;";
                        using (SQLiteCommand selectIngredientCommand = new SQLiteCommand(selectIngredientQuery, sqliteConn))
                        {
                            selectIngredientCommand.Parameters.AddWithValue("@RecipeID", idRecipe);

                            object ingredientId = selectIngredientCommand.ExecuteScalar(); // Gets a single value

                            if (ingredientId != null && ingredientId != DBNull.Value && Convert.ToInt32(ingredientId) == idIngredient)
                            {
                                ingredientFound = true;

                                // Deletes the ingredient and its associated qtyIngredient
                                string deleteQuery = $"UPDATE Recipes_has_Ingredients " +
                                                     $"SET ingredient{i}_id = NULL, qtyIngredient{i} = NULL " +
                                                     $"WHERE id = @RecipeID;";

                                using (SQLiteCommand deleteFromRecipesCommand = new SQLiteCommand(deleteQuery, sqliteConn))
                                {
                                    deleteFromRecipesCommand.Parameters.AddWithValue("@RecipeID", idRecipe);
                                    deleteFromRecipesCommand.ExecuteNonQuery();
                                }

                                // Shifts columns to fill the gap
                                OffsetRowValuesToLeft(idRecipe);

                                break; // Exits loop once the ingredient is deleted
                            }
                        }
                    }
                }

                // Step 3: Remove the ingredient from Ingredients table
                string deleteIngredientQuery = "DELETE FROM Ingredients WHERE id = @IngredientID;";
                using (SQLiteCommand deleteFromInventoryCommand = new SQLiteCommand(deleteIngredientQuery, sqliteConn))
                {
                    deleteFromInventoryCommand.Parameters.AddWithValue("@IngredientID", idIngredient);
                    deleteFromInventoryCommand.ExecuteNonQuery();
                }

                // Step 4: Reorders IDs in Ingredients, changes propagated via ON UPDATE CASCADE
                OffsetColumnsValuesToUp();

                return true; // Operation successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur pendant la suppression de l'ingrédient: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Deletes a recipe from the database
        /// </summary>
        /// <param name="idRecipe">the id of the recipe to delete</param>
        /// <returns>Bool if the operation succeeded</returns>
        public void DeleteRecipe(int idRecipe)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "DELETE FROM 'Recipes' WHERE id='"+idRecipe+"';";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes an instruction from a recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <param name="rankInstruction">the rank of the instruction</param>
        public void DeleteInstruction(int idRecipe, int rankInstruction)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "DELETE FROM 'Instructions_has_Recipes' WHERE id='"+idRecipe+"' AND InstructionNb='"+rankInstruction+"';";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Shifts non-null values of qtyIngredient and ingredient_id to the left in the column
        /// Handles gaps and aligns the columns appropriately
        /// </summary>
        /// <param name="idRecipe">the id of the recipe to adjust </param>
        public void OffsetRowValuesToLeft(int idRecipe)
        {
            try
            {
                // Step 1: Retrieves all columns related to qtyIngredient and ingredient_id for the recipe
                string selectQuery = "SELECT * FROM Recipes_has_Ingredients WHERE id = @RecipeID;";

                using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@RecipeID", idRecipe);

                    using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            // Step 2 : Create lists of non-null values for qtyIngredient and ingredient_id
                            List<object> nonNullQty = new List<object>();
                            List<object> nonNullIngredientsIds = new List<object>();

                            for (int i = 1; i <= 20; i++)
                            {
                                var qty = dataReader[$"qtyIngredient{i}"];
                                var ingredientId = dataReader[$"ingredient{i}_id"];

                                if (ingredientId != DBNull.Value)
                                {
                                    nonNullQty.Add(qty != DBNull.Value ? qty : DBNull.Value);
                                    nonNullIngredientsIds.Add(ingredientId);
                                }
                            }

                            // Step 3 : Build the update query dynamically
                            string updateQuery = "UPDATE Recipes_has_Ingredients SET ";

                            // For qtyIngredient columns
                            for (int i = 1; i <= 20; i++)
                            {
                                if (i <= nonNullQty.Count)
                                {
                                    updateQuery += $"qtyIngredient{i} = @Qty{i}, ";
                                }

                                else
                                {
                                    updateQuery += $"qtyIngredient{i} = NULL, ";
                                }
                            }

                            // For ingredient_id columns
                            for (int i = 1; i <= 20; i++)
                            {
                                if (i <= nonNullIngredientsIds.Count)
                                {
                                    updateQuery += $"ingredient{i}_id = @IngredientId{i}, ";
                                }

                                else
                                {
                                    updateQuery += $"ingredient{i}_id = NULL, ";
                                }
                            }

                            updateQuery = updateQuery.TrimEnd(',', ' ') + " WHERE id = @RecipeID;";

                            // Step 4: Execute the update query
                            using (var updateCommand = new SQLiteCommand(updateQuery, sqliteConn))
                            {

                                updateCommand.Parameters.AddWithValue("@RecipeID", idRecipe);

                                for (int i = 1; i <= nonNullQty.Count; i++)
                                {
                                    updateCommand.Parameters.AddWithValue($"@Qty{i}", nonNullQty[i - 1]);
                                    updateCommand.Parameters.AddWithValue($"@IngredientId{i}", nonNullIngredientsIds[i - 1]);
                                }
                                
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur pendant le décalage des valeurs de la ligne : {ex.Message}");
            }
        }


        /// <summary>
        /// Reorders IDs in the Ingredient table to ensure they are continuous.
        /// Removes any gaps in the sequence caused by deletions.
        /// </summary>
        public void OffsetColumnsValuesToUp()
        {
            try
            {
                // Retrives all current IDs in ascending order
                string selectQuery = "SELECT id FROM Ingredients ORDER BY id ASC;";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, sqliteConn);
                SQLiteDataReader dataReader = selectCommand.ExecuteReader();

                List<int> currentIds = new List<int>();
                while (dataReader.Read())
                {
                    // Stores the current IDs
                    currentIds.Add(dataReader.GetInt32(0));
                }
                dataReader.Close();

                // Loops through and assigns new consecutive IDs
                int newId = 1; 
                foreach (int currentId in currentIds)
                {
                    if (currentId != newId)
                    {
                        string updateQuery = "UPDATE Ingredients SET id = @NewID WHERE id = @CurrentID;";
                        using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, sqliteConn))
                        {
                            updateCommand.Parameters.AddWithValue("@NewID", newId);
                            updateCommand.Parameters.AddWithValue("@CurrentID", currentId);
                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    newId++;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la réorganisation des ID: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads all ingredients stored in the database for a type
        /// If the type in argument is 0, the function returns all ingredients found in the database.
        /// </summary>
        /// <returns>the list of ingredients names stored in the database</returns>
        public List<string> ReadAllIngredientsStoredForAType(int typeProvided = 0)
        {
            List<string> listAllIngredientsFoundInDB = new List<string>();

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            
            // Query all ingredients of a specified type
            if (typeProvided != 0)
            {
                cmd.CommandText = "SELECT id, ingredientName, qtyAvailable FROM Ingredients WHERE typeOfIngredient_id ='" + typeProvided + "' ORDER BY ingredientName;";
            }

            // Query for returning all ingredients names found in the DB
            else
            {
                cmd.CommandText = "SELECT id, ingredientName, qtyAvailable FROM Ingredients ORDER BY ingredientName;";
            }

            int nbIngredientsStored = CountAllIngredientsStored();

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader["ingredientName"].ToString() != "")
                {
                    // Adds the ingredient to the list
                    listAllIngredientsFoundInDB.Add(dataReader["ingredientName"].ToString());
                }
            }
            
            return listAllIngredientsFoundInDB;
        }


        /// <summary>
        /// Reads all ingredients stored in the database for a type
        /// If the type in argument is 0, the function returns all ingredients found in the database.
        /// </summary>
        /// <returns>the list of ingredients names stored in the database</returns>
        public List<string> ReadAllTypesOfIngredientsStored()
        {
            List<string> listAllTypesOfIngredientsFoundInDB = new List<string>();

            SQLiteCommand cmd = sqliteConn.CreateCommand();
                             
            cmd.CommandText = "SELECT type FROM TypesOfIngredient;";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader["type"].ToString() != "")
                {
                    // Adds the ingredient to the list
                    listAllTypesOfIngredientsFoundInDB.Add(dataReader["type"].ToString());
                }
            }

            return listAllTypesOfIngredientsFoundInDB;
        }

        /// <summary>
        /// Reads the quantity available for an ingredient
        /// </summary>
        /// <param name="ingredientIdProvided">the id of the ingredient</param>
        /// <returns>quantity available for the ingredient</returns>
        public double ReadQtyAvailableForAnIngredient(int ingredientId)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT id, ingredientName, qtyAvailable FROM Ingredients WHERE id='"+ingredientId+"';";

            double qtyIngredientStored = 0.0;

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                double.TryParse(dataReader["qtyAvailable"].ToString(), out qtyIngredientStored);
            }

            return qtyIngredientStored;
        }

        /// <summary>
        /// Reads the quantity of an ingredient available 
        /// </summary>
        /// <param name="ingredientName">the name of the ingredient</param>
        /// <returns>Quantity of the ingredient found in the inventory</returns>
        public double ReadQtyAvailableForAnIngredient(string nameIngredient)
        {
            double qtyIngredientFound = 0.0;
            string formattednameIngredient = nameIngredient;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (nameIngredient.Contains("'"))
            {
                formattednameIngredient = nameIngredient.Replace("'", "''");
            }

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "SELECT qtyAvailable FROM Ingredients WHERE ingredientName = '" + formattednameIngredient + "';";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                // Parses the quantity of the ingredient
                double.TryParse(dataReader["qtyAvailable"].ToString(), out qtyIngredientFound);
            }

            return qtyIngredientFound;
        }

        /// <summary>
        /// Reads all scales stored in the database
        /// </summary>
        /// <returns>the list of scales stored in the database</returns>
        public List<string> ReadAllScalesStored()
        {
            // Declares a list of ingredients to contain the ones needed to make the recipe
            List<string> allScalesNamesList = new List<string>();

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT id, scaleName FROM Scales;";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                // Adds the ingredient to the list
                allScalesNamesList.Add(dataReader["scaleName"].ToString());    
            }

            return allScalesNamesList;
        }

        /// <summary>
        /// Reads the quantity of ingredients needed to make the current selected recipe, with their scales
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <returns>List of the ingredients needed to make the recipe</returns>
        public List<Ingredients> ReadIngredientsQtyForARecipe(int idRecipe)
        {
            // Declares a list of string to contain the ones needed to make the recipe
            List<Ingredients> listIngredientsRequested = new List<Ingredients>();
            
            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "SELECT * FROM Recipes_has_Ingredients WHERE Recipes_has_Ingredients.id = '" + idRecipe + "';";

            int nbIngredientsForThisRecipe = CountAllIngredientsForARecipe(idRecipe);

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {

                for (int i = 1; i <= nbIngredientsForThisRecipe; i++)
                {
                    double qtyIngredientNeeded = 0.0;
                    double qtyIngredientAvailable = 0.0;
                    
                    Ingredients _ingredientToAdd = new Ingredients("defaultIngredient", 0.0, 1, 0.0);

                    if (dataReader["qtyIngredient"+i].ToString() != "")
                    {
                        // Parses the quantity of the ingredient
                        double.TryParse(dataReader["qtyIngredient"+i].ToString(), out qtyIngredientNeeded);

                        // If the number of persons == 1 or > 2
                        if (DBConnection.NbPersonsSet == 1 || DBConnection.NbPersonsSet > 2)
                        {
                            // Divides by 2 the quantity
                            qtyIngredientNeeded /= 2;
                        }

                        // If the number of persons > 2
                        if (DBConnection.NbPersonsSet > 2)
                        {
                            // Multiply by the new value set in the numeric updown control
                            qtyIngredientNeeded *= DBConnection.NbPersonsSet;
                        }

                    if (dataReader["qtyIngredient"+i].ToString() != "")
                    {
                       // Parses the quantity of the ingredient
                       double.TryParse(dataReader["qtyIngredient"+i].ToString(), out qtyIngredientAvailable);
                    }

                        // Affects the ingredient quantity, scale and name to the properties of the ingredient object
                        int ingredientIdFound;
                        int.TryParse(dataReader["ingredient" + i + "_id"].ToString(), out ingredientIdFound);
                       
                        _ingredientToAdd.Id = ingredientIdFound;
                        _ingredientToAdd.Name = ReadNameForAnIngredientId(_ingredientToAdd.Id);
                        _ingredientToAdd.Scale_id = ReadScaleIdForAnIngredient(_ingredientToAdd.Id);
                        _ingredientToAdd.QtyRequested = qtyIngredientNeeded;
                        _ingredientToAdd.QtyAvailable = qtyIngredientAvailable;

                        // Adds the ingredients to the list
                        listIngredientsRequested.Add(_ingredientToAdd);
                    }
                }
            }

            DBConnection.NbPersonsPreviouslySet = DBConnection.NbPersonsSet;
            return listIngredientsRequested;
        }

        /// <summary>
        /// Reads id of an ingredient for a given name
        /// </summary>
        /// <param name="nameIngredient">the name of the ingredient</param>
        /// <returns>Id of the ingredient</returns>
        public int ReadIdForAnIngredientName(string nameIngredient)
        {
            // Declares a string to contain the ingredient id
            int ingredientIdFound = 0;

            string formattednameIngredient = nameIngredient;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (nameIngredient.Contains("'"))
            {
                formattednameIngredient = nameIngredient.Replace("'", "''");
            }

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            cmd.CommandText = "SELECT id FROM 'Ingredients' WHERE ingredientName='"+formattednameIngredient+"';";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ingredientIdFound = int.Parse(dataReader["id"].ToString());
            }

            return ingredientIdFound;
        }

        /// <summary>
        /// Reads name of an ingredient for its id
        /// </summary>
        /// <param name="ingredientId">the id of the ingredient</param>
        /// <returns>name of an ingredient</returns>
        public string ReadNameForAnIngredientId(int ingredientId)
        {
            string nameOfIngredientFound = "";

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Ingredients WHERE id='" + ingredientId + "';";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                nameOfIngredientFound = dataReader["ingredientName"].ToString();
            }

            return nameOfIngredientFound;
        }

        /// <summary>
        /// Reads planned meal for a day of the week stored in the database
        /// </summary>
        /// <param>the id of the day of the week</param>
        /// <returns>title of the recipes planned for that day</returns>
        public string ReadPlannedMealsForADay(int idDayOfTheWeek)
        {
            string titleOfPlannedRecipeFound = ""; 

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT titleOfPlannedRecipe FROM PlannedMeals WHERE id='"+idDayOfTheWeek+"';";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                titleOfPlannedRecipeFound = dataReader["titleOfPlannedRecipe"].ToString();
            }

            return titleOfPlannedRecipeFound;
        }


        /// <summary>
        /// Reads the scale used by an ingredient
        /// </summary>
        /// <param name="idIngredient">the id of the ingredient</param>
        /// <returns>the scale id used by the ingredient</returns>
        public int ReadScaleIdForAnIngredient(int idIngredient)
        {
            // Stores the id of the scale used by that ingredient
            int scaleIdFound = 0;

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Retrieves all the data about ingredients needed for the currently selected recipe
            cmd.CommandText = "SELECT scale_id " +
                                "FROM Ingredients " +
                                "WHERE Ingredients.Id = " + idIngredient + ";";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader["scale_id"].ToString() != "")
                {
                    int.TryParse(dataReader["scale_id"].ToString(), out scaleIdFound);
                }
            }

            return scaleIdFound;
        }


        /// <summary>
        /// Reads the scale name corresponding to an id
        /// </summary>
        /// <param name="idIngredient">the id of the ingredient</param>
        /// <returns>the scale name used by the ingredient</returns>
        public string ReadScaleNameForAnID(int scaleId)
        {
            // Stores the id of the scale used by that ingredient
            string scaleNameFound = "";

            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Retrieves all the data about ingredients needed for the currently selected recipe
            cmd.CommandText = "SELECT scaleName " +
                                "FROM Scales " +
                                "WHERE id = " + scaleId + ";";

            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader["scaleName"].ToString() != "")
                {
                    scaleNameFound = dataReader["scaleName"].ToString();
                }
            }

            return scaleNameFound;
        }

        /// <summary>
        /// Reads the type of an ingredient for a given id
        /// </summary>
        /// <param name="nameIngredient">the name of the ingredient</param>
        /// <returns>Name of the type of ingredient</returns>
        public string ReadTypeName (int idTypeOfIngredient)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "SELECT type FROM 'TypesOfIngredient' WHERE id ='" + idTypeOfIngredient + "';";

            string typeFound = "";
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                dataReader["type"].ToString();
            }
            return typeFound;
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
                                "WHERE Recipes_id = '"+idRecipe+"';";

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
            cmd.CommandText = "SELECT id AS idRecipeRequested FROM 'Recipes' WHERE title ='"+formattedTitle+"';";

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
            cmd.CommandText = "SELECT title AS titleRecipe FROM 'Recipes' WHERE id ='"+idRecipe+"';";

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
            cmd.CommandText = "SELECT completionTime AS completionTimeRecipe FROM 'Recipes' WHERE id ='"+idRecipe+"';";

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
            cmd.CommandText = "SELECT lowBudget AS recipeLowBudgetStatus FROM 'Recipes' WHERE id='"+idRecipe+"';";

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
            cmd.CommandText = "SELECT score AS scoreRecipe FROM 'Recipes' WHERE id='"+idRecipe+"';";

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
            cmd.CommandText = "SELECT imagePath AS recipeImagePath FROM 'Recipes' WHERE id='"+idRecipe+"';";

            string imagePathFound = "";
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                imagePathFound = dataReader["recipeImagePath"].ToString();
            }
            return imagePathFound;
        }

        public List<string> SearchRecipesByIngredients(string ingredientInput1 = "", string ingredientInput2 = "", string ingredientInput3 = "", bool filterForLowBudget = false, bool filterForThreeStars = false)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();

            // Declares a list of string to contain the titles of the recipes found in the database
            List<string> recipesTitlesFound = new List<string>();

          
                cmd.CommandText = "SELECT Recipes.title, Recipes.lowBudget, ingredient1.ingredientName AS 'ingredient1Name'," +
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
                            "LEFT JOIN Recipes ON Recipes_has_Ingredients.id = Recipes.id";

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
                                    " OR ingredient19Name LIKE '%" + ingredientInput1 + "%' OR ingredient20Name LIKE '%" + ingredientInput1 + "%')";
            }
            
            if (nbIngredientsTyped > 1)
            {
                cmd.CommandText += " AND (ingredient1Name LIKE '%" + ingredientInput2 + "%' OR ingredient2Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient3Name LIKE '%" + ingredientInput2 + "%' OR  ingredient4Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient5Name LIKE '%" + ingredientInput2 + "%' OR ingredient6Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient7Name LIKE '%" + ingredientInput2 + "%' OR ingredient8Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient9Name LIKE '%" + ingredientInput2 + "%' OR ingredient10Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient11Name LIKE '%" + ingredientInput2 + "%' OR ingredient12Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient13Name LIKE '%" + ingredientInput2 + "%' OR ingredient14Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient15Name LIKE '%" + ingredientInput2 + "%' OR ingredient16Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient17Name LIKE '%" + ingredientInput2 + "%' OR ingredient18Name LIKE '%" + ingredientInput2 + "%'" +
                                   " OR ingredient19Name LIKE '%" + ingredientInput2 + "%' OR ingredient20Name LIKE '%" + ingredientInput2 + "%')";
            }
            
            if (nbIngredientsTyped > 2)
            {
                cmd.CommandText += " AND (ingredient1Name LIKE '%" + ingredientInput3 + "%' OR ingredient2Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient3Name LIKE '%" + ingredientInput3 + "%' OR ingredient4Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient5Name LIKE '%" + ingredientInput3 + "%' OR ingredient6Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient7Name LIKE '%" + ingredientInput3 + "%' OR ingredient8Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient9Name LIKE '%" + ingredientInput3 + "%' OR ingredient10Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient11Name LIKE '%" + ingredientInput3 + "%' OR ingredient12Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient13Name LIKE '%" + ingredientInput3 + "%' OR ingredient14Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient15Name LIKE '%" + ingredientInput3 + "%' OR ingredient16Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient17Name LIKE '%" + ingredientInput3 + "%' OR ingredient18Name LIKE '%" + ingredientInput3 + "%'" +
                                   " OR ingredient19Name LIKE '%" + ingredientInput3 + "%' OR ingredient20Name LIKE '%" + ingredientInput3 + "%')";
            }

            if (filterForLowBudget)
            {
               cmd.CommandText += " AND (lowBudget = '1')";
        
            }

            if (filterForThreeStars)
            {
                cmd.CommandText += " AND (score = '3')";
            }

            cmd.CommandText += ";";

               string titleFound = "";

               SQLiteDataReader dataReader = cmd.ExecuteReader();
               while (dataReader.Read())
               {
                   titleFound = dataReader["title"].ToString();
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
            if (nbKeywordsTyped > 0 && keywordInput1 != "*")
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
            cmd.CommandText = "UPDATE 'Instructions' SET instruction='"+newInstructionText+"' WHERE id='"+idInstruction+"';";
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
            cmd.CommandText = "UPDATE 'Recipes' SET imagePath='" + newImagePath + "' WHERE id='"+idRecipe+"';";
            cmd.ExecuteReader();
        }

        /// <summary>
        /// Updates the image path for the selected recipe
        /// </summary>
        /// <param name="idRecipe">the id of the currently selected recipe</param>
        /// <param name="newImagePath">the new image path to update</param>
        public void UpdateIngredientName(int idIngredientToEdit, string newNameOfIngredient)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'Ingredients' SET ingredientName ='" + newNameOfIngredient + "' WHERE id='" + idIngredientToEdit + "';";
            cmd.ExecuteReader();
        }


        /// <summary>
        /// Updates the image path for the selected recipe
        /// </summary>
        /// <param name="idRecipe">the id of the day of the week (from 1 to 7)</param>
        /// <param name="titleOfTheRecipe">the title of the recipe to plan</param>
        public void UpdatePlannedRecipeForADay(int idDayOfTheWeek, string titleOfTheRecipe)
        {
            string formattedTitle = titleOfTheRecipe;

            // Checks if the title of the recipe contains an apostroph, to avoid making the sql request crash
            if (titleOfTheRecipe.Contains("'"))
            {
                formattedTitle = titleOfTheRecipe.Replace("'", "''");
            }

            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'PlannedMeals' SET titleOfPlannedRecipe='" + formattedTitle + "' WHERE id='" + idDayOfTheWeek + "';";
            cmd.ExecuteReader();
        }

        /// <summary>
        /// Updates a recipe low budget status
        /// </summary>
        /// <param name="idRecipe"></param>the id of the recipe
        public void UpdateRecipeLowBudgetStatus(int idRecipe, int LowBudgetStatus)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'Recipes' SET lowBudget='" + LowBudgetStatus + "' WHERE id='" + idRecipe + "';";
            cmd.ExecuteReader();
        }

        /// <summary>
        /// Updates the score for the selected recipe
        /// </summary>
        /// <param name="idRecipe">the id of the currently selected recipe</param>
        /// <param name="newScore">the new score to input</param>
        public void UpdateScoreForRecipe(int idRecipe, int newScore)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'Recipes' SET score='"+newScore+"' WHERE id='"+idRecipe+"';";
            cmd.ExecuteReader();
        }

        /// <summary>
        /// Updates the quantity available for a given ingredient
        /// </summary>
        /// <param name="idIngredient">the id of the ingredient</param>
        /// <param name="newQtyIngredientAvailable">the new quantity of the ingredient available</param>
        public void UpdateQtyIngredientAvailable(int idIngredient, double newQtyIngredientAvailable)
        {
            SQLiteCommand cmd = sqliteConn.CreateCommand();
            cmd.CommandText = "UPDATE 'Ingredients' SET qtyAvailable='"+newQtyIngredientAvailable+"' WHERE id='"+idIngredient+"';";
            cmd.ExecuteReader();
        }

        /// <summary>
        /// Updates the title, the completionTime and the lowBudget status of a recipe
        /// </summary>
        /// <param name="idRecipe">the id of the recipe</param>
        /// <param name="newTitleRecipe">the new title of the recipe, if the user has edited it</param>
        /// <param name="newCompletionTime">the new completion time of the recipe, if the user has edited it</param>
        /// <param name="newLowBudgetStatus">the low budget value of the recipe, if the user has edited it</param>
        public void UpdateRecipeBasicInfos(int idRecipe, string newTitleRecipe = "", string newCompletionTime = "", string newLowBudgetStatus = "")
        {
            if (newTitleRecipe != "")
            {
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = "UPDATE 'Recipes' SET title ='"+newTitleRecipe+"' WHERE id='"+idRecipe+"';";
                cmd.ExecuteReader();
            }

            if (newCompletionTime != "")
            {
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = "UPDATE 'Recipes' SET completionTime ='"+newCompletionTime+"' WHERE id='"+ idRecipe+"';";
                cmd.ExecuteReader();
            }

            if (newLowBudgetStatus != "")
            {
                SQLiteCommand cmd = sqliteConn.CreateCommand();
                cmd.CommandText = "UPDATE 'Recipes' SET lowBudget ='"+newLowBudgetStatus+"' WHERE id='"+idRecipe+"';";
                cmd.ExecuteReader();
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
