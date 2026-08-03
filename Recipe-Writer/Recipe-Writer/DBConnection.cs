
/// <file>DBConnection.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2.1</version>
/// <date>August, 4th 2026</date>

using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Recipe_Writer
{
    public class DBConnection
    {
        private SQLiteConnection sqliteConn;

        // Constructor - Initializes the database connection
        public DBConnection()
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "recipe-album.db");
            sqliteConn = new SQLiteConnection($"Data Source={dbPath}; Version=3; Compress=True;");
        }

        /// <summary>
        /// Opens the connection to the database securely
        /// </summary>
        public void Open()
        {
            if (sqliteConn.State != System.Data.ConnectionState.Open)
            {
                sqliteConn.Open();
            }
        }

        /// <summary>
        /// Checks the database integrity
        /// </summary>
        public bool CheckDBIntegrity()
        {
            try
            {
                using (var transaction = sqliteConn.BeginTransaction())
                {
                    transaction.Rollback();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database integrity check failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Creates the database file in the application's installation folder
        /// </summary>
        public void CreateFile()
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "recipe-album.db");
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
        }

        /// <summary>
        /// Create the tables if the database file is not found
        /// </summary>
        public void CreateTables()
        {
            string scriptPath = Path.Combine(Environment.CurrentDirectory, "scripts", "Recipe-writer-create-tables.sql");

            if (File.Exists(scriptPath))
            {
                using (SQLiteCommand cmd = sqliteConn.CreateCommand())
                {
                    cmd.CommandText = File.ReadAllText(scriptPath);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Table creation script not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Inserts initial data into the database
        /// </summary>
        public void InsertInitialData()
        {
            string scriptPath = Path.Combine(Environment.CurrentDirectory, "scripts", "Recipe-writer-insert-initial-data.sql");

            if (File.Exists(scriptPath))
            {
                using (SQLiteCommand cmd = sqliteConn.CreateCommand())
                {
                    cmd.CommandText = File.ReadAllText(scriptPath);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Data insertion script not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Adds a new ingredient to the database, ensuring French, English and Spanish names are stored.
        /// If only one name is provided, it is copied into the others.
        /// </summary>
        public void AddNewIngredientToDB(string ingredientNameFr, string ingredientNameEn, string ingredientNameEs,
                                         int scaleIdForThisIngredient, int idTypeOfIngredient)
        {
            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                // Ensures all names have a value
                if (string.IsNullOrWhiteSpace(ingredientNameFr))
                {
                    ingredientNameFr = !string.IsNullOrWhiteSpace(ingredientNameEn) ? ingredientNameEn : ingredientNameEs;
                }

                if (string.IsNullOrWhiteSpace(ingredientNameEn))
                {
                    ingredientNameEn = !string.IsNullOrWhiteSpace(ingredientNameFr) ? ingredientNameFr : ingredientNameEs;
                }

                if (string.IsNullOrWhiteSpace(ingredientNameEs))
                {
                    ingredientNameEs = !string.IsNullOrWhiteSpace(ingredientNameFr) ? ingredientNameFr : ingredientNameEn;
                }

                // Inserts the new ingredient into the Ingredients table
                cmd.CommandText =
                    "INSERT INTO Ingredients (ingredientName_fr, ingredientName_en, ingredientName_es, scale_id, typeOfIngredient_id) " +
                    "VALUES (@ingredientNameFr, @ingredientNameEn, @ingredientNameEs, @scaleId, @idTypeOfIngredient);";

                cmd.Parameters.AddWithValue("@ingredientNameFr", ingredientNameFr);
                cmd.Parameters.AddWithValue("@ingredientNameEn", ingredientNameEn);
                cmd.Parameters.AddWithValue("@ingredientNameEs", ingredientNameEs);
                cmd.Parameters.AddWithValue("@scaleId", scaleIdForThisIngredient);
                cmd.Parameters.AddWithValue("@idTypeOfIngredient", idTypeOfIngredient);

                cmd.ExecuteNonQuery();
            }
        }

        // <summary>
        /// Adds a new ingredient to the selected recipe.
        /// </summary>
        public void AddNewIngredientToRecipe(int idRecipe, int newIngredientId)
        {
            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Recipes_has_Ingredients (recipe_id, ingredient_id, qtyIngredient) VALUES (@RecipeId, @IngredientId, @QtyIngredient);";

                cmd.Parameters.AddWithValue("@RecipeId", idRecipe);
                cmd.Parameters.AddWithValue("@IngredientId", newIngredientId);
                cmd.Parameters.AddWithValue("@QtyIngredient", 0.0);

                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Adds a new instruction into the database and returns its generated ID.
        /// </summary>
        public int AddNewInstruction(string txtNewInstruction)
        {
            int lastInstructionId = 0;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                // Inserts the instruction into the Instructions table
                cmd.CommandText = "INSERT INTO Instructions (instruction) VALUES (@InstructionText)";
                cmd.Parameters.AddWithValue("@InstructionText", txtNewInstruction);
                cmd.ExecuteNonQuery();

                // Retrieves the last inserted instruction ID
                cmd.CommandText = "SELECT last_insert_rowid()";
                cmd.Parameters.Clear();

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lastInstructionId = reader.GetInt32(0);
                    }
                }
            }

            return lastInstructionId;
        }

        /// <summary>
        /// Links a newly added instruction to a recipe.
        /// </summary>
        public void AddNewInstructionToRecipe(int idRecipe, int nbInstructionsForRecipe, string txtNewInstruction)
        {
            int lastInstructionId = AddNewInstruction(txtNewInstruction); // Get new instruction ID

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                // Inserts reference in Instructions_has_Recipes
                cmd.CommandText = "INSERT INTO Instructions_has_Recipes (Recipes_id, Instructions_id, InstructionNb) VALUES (@RecipeId, @InstructionId, @InstructionNb)";
                cmd.Parameters.AddWithValue("@RecipeId", idRecipe);
                cmd.Parameters.AddWithValue("@InstructionId", lastInstructionId);
                cmd.Parameters.AddWithValue("@InstructionNb", nbInstructionsForRecipe + 1);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Adds a new recipe into the database with its basic information.
        /// </summary>
        /// <param name="title">The title of the new recipe.</param>
        /// <param name="completionTime">The total completion time of the recipe.</param>
        /// <param name="lowBudgetStatus">The low budget flag (1 = yes, 0 = no).</param>
        /// <param name="language">The language code of the recipe (en, fr, es).</param>
        public void AddNewRecipe(string title, string completionTime, int lowBudgetStatus, string language)
        {
            // Defensive copy of the title
            string formattedTitle = title;

            // Escapes single quotes in the title to prevent SQL errors
            if (!string.IsNullOrEmpty(title) && title.Contains("'"))
            {
                formattedTitle = title.Replace("'", "''");
            }

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText =
                    "INSERT INTO Recipes (title, completionTime, lowBudget, score, imagePath, language) " +
                    "VALUES (@title, @completionTime, @lowBudget, @score, @imagePath, @language);";

                cmd.Parameters.AddWithValue("@title", formattedTitle);
                cmd.Parameters.AddWithValue("@completionTime", completionTime);
                cmd.Parameters.AddWithValue("@lowBudget", lowBudgetStatus);
                cmd.Parameters.AddWithValue("@score", 0);
                cmd.Parameters.AddWithValue("@imagePath", DBNull.Value);
                cmd.Parameters.AddWithValue("@language", language);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Counts the number of ingredients stored in the database.
        /// </summary>
        /// <returns>The number of ingredients stored.</returns>
        public int CountAllIngredientsStored()
        {
            int nbOfIngredientsStored = 0;

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Ingredients;", sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Directly retrieve the count without unnecessary loops
                    {
                        nbOfIngredientsStored = reader.GetInt32(0); // Directly get the integer value
                    }
                }
            }

            return nbOfIngredientsStored;
        }

        /// <summary>
        /// Counts the number of ingredients stored for a given recipe.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <returns>The number of ingredients stored for the recipe.</returns>
        public int CountAllIngredientsForARecipe(int idRecipe)
        {
            int nbOfIngredientsRequiredForThisRecipe = 0;

            string query = @"SELECT ingredient1_id, ingredient2_id, ingredient3_id, ingredient4_id, ingredient5_id, ingredient6_id,
                     ingredient7_id, ingredient8_id, ingredient9_id, ingredient10_id, ingredient11_id, ingredient12_id,
                     ingredient13_id, ingredient14_id, ingredient15_id, ingredient16_id, ingredient17_id, ingredient18_id,
                     ingredient19_id, ingredient20_id FROM Recipes_has_Ingredients WHERE id = @IdRecipe;";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Vérifie s'il y a des résultats
                    {
                        for (int i = 1; i <= 20; i++)
                        {
                            string columnName = $"ingredient{i}_id";

                            if (!reader.IsDBNull(reader.GetOrdinal(columnName))) // Vérifie si la colonne contient une valeur
                            {
                                nbOfIngredientsRequiredForThisRecipe++;
                            }
                        }
                    }
                }
            }

            return nbOfIngredientsRequiredForThisRecipe;
        }


        /// <summary>
        /// Counts the total number of ingredient types stored in the database.
        /// </summary>
        /// <returns>The total number of ingredient types stored.</returns>
        public int CountAllTypesOfIngredients()
        {
            int nbOfTypesOfIngredientsFound = 0;

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM TypesOfIngredient;", sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Directly retrieve the count without unnecessary loops
                    {
                        nbOfTypesOfIngredientsFound = reader.GetInt32(0); // Retrieve the count in a safe way
                    }
                }
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
                // Gets all recipe IDs in Recipes_has_Ingredients
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

                // Processes each recipe to delete the ingredient and shift columns
                foreach (int idRecipe in recipesIDs)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        string selectIngredientQuery = $"SELECT ingredient{i}_id FROM Recipes_has_Ingredients WHERE id = @RecipeID;";
                        using (SQLiteCommand selectIngredientCommand = new SQLiteCommand(selectIngredientQuery, sqliteConn))
                        {
                            selectIngredientCommand.Parameters.AddWithValue("@RecipeID", idRecipe);

                            object ingredientId = selectIngredientCommand.ExecuteScalar(); // Gets a single value

                            if (ingredientId != null && ingredientId != DBNull.Value && Convert.ToInt32(ingredientId) == idIngredient)
                            {
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

                                MessageBox.Show(strings.InfoIngredientDeletedFromDB, "Information", MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);

                                break; // Exits loop once the ingredient is deleted
                            }
                        }
                    }
                }

                // Removes the ingredient from Ingredients table
                string deleteIngredientQuery = "DELETE FROM Ingredients WHERE id = @IngredientID;";
                using (SQLiteCommand deleteFromInventoryCommand = new SQLiteCommand(deleteIngredientQuery, sqliteConn))
                {
                    deleteFromInventoryCommand.Parameters.AddWithValue("@IngredientID", idIngredient);
                    deleteFromInventoryCommand.ExecuteNonQuery();
                }

                // Reorders IDs in Ingredients, changes propagated via ON UPDATE CASCADE
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
        /// Deletes a recipe and its associated ingredient relations from the database.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe to delete.</param>
        public void DeleteRecipe(int idRecipe)
        {
            using (SQLiteTransaction transaction = sqliteConn.BeginTransaction())
            {
                try
                {
                    // Deletes ingredient associations for the recipe
                    using (SQLiteCommand cmdDeleteIngredients = new SQLiteCommand("DELETE FROM Recipes_has_Ingredients WHERE recipe_id = @IdRecipe;", sqliteConn, transaction))
                    {
                        cmdDeleteIngredients.Parameters.AddWithValue("@IdRecipe", idRecipe);
                        cmdDeleteIngredients.ExecuteNonQuery();
                    }

                    // Deletes the recipe itself
                    using (SQLiteCommand cmdDeleteRecipe = new SQLiteCommand("DELETE FROM Recipes WHERE id = @IdRecipe;", sqliteConn, transaction))
                    {
                        cmdDeleteRecipe.Parameters.AddWithValue("@IdRecipe", idRecipe);
                        cmdDeleteRecipe.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Confirms the deletion process
                }
                catch (Exception)
                {
                    transaction.Rollback(); // Undoes changes if an error occurs
                }
            }
        }

        /// <summary>
        /// Deletes an instruction from a recipe.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <param name="rankInstruction">The rank of the instruction.</param>
        public void DeleteInstruction(int idRecipe, int rankInstruction)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Instructions_has_Recipes WHERE id = @IdRecipe AND InstructionNb = @RankInstruction;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                cmd.Parameters.AddWithValue("@RankInstruction", rankInstruction);
                cmd.ExecuteNonQuery();
            }
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
                // Retrieves all columns related to qtyIngredient and ingredient_id for the recipe
                string selectQuery = "SELECT * FROM Recipes_has_Ingredients WHERE id = @RecipeID;";

                using (var cmd = new SQLiteCommand(selectQuery, sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@RecipeID", idRecipe);

                    using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            // Creates lists of non-null values for qtyIngredient and ingredient_id
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

                            // Builds the update query dynamically
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

                            // Executes the update query
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
        /// Reads all ingredients stored in the database for a given type.
        /// The ingredient name is localized based on the active language setting.
        /// </summary>
        /// <param name="typeProvided">The type identifier of the ingredient, or 0 to retrieve all.</param>
        /// <returns>A list of localized ingredient names.</returns>
        public List<string> ReadAllIngredientsStoredForAType(int typeProvided = 0)
        {
            List<string> listAllIngredientsFoundInDB = new List<string>();

            // Normalizes language code
            string selectedLanguage = Properties.Settings.Default.AppLanguageCode.ToString().ToLower();

            // Fallback to English if unknown language
            if (selectedLanguage != "en" && selectedLanguage != "fr" && selectedLanguage != "es")
            {
                selectedLanguage = "en";
            }

            // Determines the correct column
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            string query = $"SELECT id, {ingredientColumn} AS ingredientName FROM Ingredients";

            if (typeProvided != 0)
            {
                // If a specific ingredient type was requested,
                // we add a WHERE clause to filter ingredients by that type.
                query += " WHERE typeOfIngredient_id = @TypeProvided";
            }

            // Always add an ORDER BY clause to sort the results
            // according to the localized ingredient column.
            query += $" ORDER BY {ingredientColumn};";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (typeProvided != 0)
                {
                    // If a type filter is used, we pass its value to the SQL query
                    // to safely replace the @TypeProvided parameter.
                    cmd.Parameters.AddWithValue("@TypeProvided", typeProvided);
                }

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    // Loops through each row returned by the SQL query
                    while (reader.Read())
                    {
                        // Checks if the ingredient name is not NULL in the database
                        if (!reader.IsDBNull(reader.GetOrdinal("ingredientName")))
                        {
                            // Adds the ingredient name (localized) to the final list
                            listAllIngredientsFoundInDB.Add(reader["ingredientName"].ToString());
                        }
                    }
                }
            }

            // Returns the full list of ingredient names found in the database
            return listAllIngredientsFoundInDB;

        }

        /// <summary>
        /// Retrieves all recipe titles from the database.
        /// </summary>
        /// <returns>List of all recipe titles.</returns>
        public List<string> ReadAllRecipesTitlesStored()
        {
            List<string> allRecipes = new List<string>();

            string query = "SELECT title FROM Recipes ORDER BY title;";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allRecipes.Add(reader["title"].ToString());
                    }
                }
            }

            return allRecipes;
        }

        /// <summary>
        /// Reads all scales stored in the database, adapted to the active language.
        /// </summary>
        /// <param name="selectedLanguage">The active language code ("fr", "en", "es").</param>
        /// <returns>List of scales stored in the database.</returns>
        public List<string> ReadAllScalesStored(string selectedLanguage = "en")
        {
            List<string> allScalesNamesList = new List<string>();

            // Normalizes language code
            selectedLanguage = selectedLanguage.ToLower();

            // Fallback to English if unknown language
            if (selectedLanguage != "en" && selectedLanguage != "fr" && selectedLanguage != "es")
            {
                selectedLanguage = "en";
            }

            // Determines the correct column based on the language
            string scaleColumn = "scaleName_" + selectedLanguage;

            string query = $"SELECT id, {scaleColumn} AS scaleName FROM Scales;";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        allScalesNamesList.Add(dataReader["scaleName"].ToString());
                    }
                }
            }

            return allScalesNamesList;
        }

        /// <summary>
        /// Retrieves all types of ingredients stored in the database,
        /// localized according to the active language setting.
        /// </summary>
        /// <param name="selectedLanguage">The active language code.</param>
        /// <returns>A list of localized ingredient types.</returns>
        public List<string> ReadAllTypesOfIngredientsStored(string selectedLanguage = "en")
        {
            List<string> listAllTypesOfIngredientsFoundInDB = new List<string>();

            // Normalizes language code
            selectedLanguage = selectedLanguage.ToLower();

            // Fallback to English if unknown
            if (selectedLanguage != "en" && selectedLanguage != "fr" && selectedLanguage != "es")
            {
                selectedLanguage = "en";
            }

            // Determines the correct column based on the language
            string typeColumn = "type_" + selectedLanguage;

            string query = $"SELECT {typeColumn} FROM TypesOfIngredient ORDER BY {typeColumn};";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listAllTypesOfIngredientsFoundInDB.Add(reader[typeColumn].ToString());
                    }
                }
            }

            return listAllTypesOfIngredientsFoundInDB;
        }

        /// <summary>
        /// Reads the ID of an ingredient for a given name, based on the selected language.
        /// Supported languages: "fr", "en", "es".
        /// </summary>
        /// <param name="nameIngredient">The name of the ingredient.</param>
        /// <param name="selectedLanguage">The language code ("fr", "en", "es") used for lookup.</param>
        /// <returns>ID of the ingredient, or 0 if not found.</returns>
        public int ReadIdForAnIngredientName(string nameIngredient, string selectedLanguage = "en")
        {
            int ingredientIdFound = 0;

            // Normalizes language code
            selectedLanguage = selectedLanguage.ToLower();

            // Fallback to English if unknown language
            if (selectedLanguage != "en" && selectedLanguage != "fr" && selectedLanguage != "es")
                selectedLanguage = "en";

            // Determines the correct column based on the language
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = $"SELECT id FROM Ingredients WHERE {ingredientColumn} = @IngredientName;";
                cmd.Parameters.AddWithValue("@IngredientName", nameIngredient.Trim());

                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        ingredientIdFound = dataReader.GetInt32(0);
                    }
                }
            }

            return ingredientIdFound;
        }

        /// <summary>
        /// Reads all ingredients for a given type using a single SQL query.
        /// </summary>
        /// <returns> A list of tuples: (Id, Name, Qty, Scale).
        /// </returns>
        public List<(int Id, string Name, double Qty, string Scale)> ReadIngredientsForType(int typeProvided)
        {
            var computedList = new List<(int, string, double, string)>();

            // Determines active language with fallback to English if unknown
            string lang = Properties.Settings.Default.AppLanguageCode.ToLower();

            if (lang != "en" && lang != "fr" && lang != "es")
            {
                lang = "en";
            }

            // Builds SQL query dynamically for the correct language column
            string query = $@"SELECT 
                                Ingredients.id,
                                Ingredients.qtyAvailable,
                                Ingredients.ingredientName_{lang} AS ingredientName,
                                Scales.scaleName_{lang} AS scaleName
                            FROM Ingredients
                            LEFT JOIN Scales ON Scales.id = Ingredients.scale_id
                            WHERE (@TypeProvided = 0 OR Ingredients.typeOfIngredient_id = @TypeProvided)
                            ORDER BY ingredientName;";

            using (var cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@TypeProvided", typeProvided);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int readId = reader.GetInt32(0);
                        double readQty = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                        string readName = reader["ingredientName"].ToString();
                        string readScale = reader["scaleName"].ToString();

                        computedList.Add((readId, readName, readQty, readScale));
                    }
                }
            }

            return computedList;
        }

        /// <summary>
        /// Reads the quantity of ingredients needed for a given recipe, including their scales.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <returns>List of the ingredients needed to make the recipe.</returns>
        public List<Ingredients> ReadIngredientsQtyForARecipe(int idRecipe)
        {
            List<Ingredients> listIngredientsRequested = new List<Ingredients>();

            string query = "SELECT * FROM Recipes_has_Ingredients WHERE id = @IdRecipe;";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int nbIngredientsForThisRecipe = CountAllIngredientsForARecipe(idRecipe);

                    // Reads only one row as expected
                    if (reader.Read())
                    {
                        for (int i = 1; i <= nbIngredientsForThisRecipe; i++)
                        {
                            double qtyIngredientNeeded = 0.0;
                            double qtyIngredientAvailable = 0.0;

                            Ingredients ingredientToAdd = new Ingredients("defaultIngredient", 0.0, 1, 0.0);

                            string qtyColumn = $"qtyIngredient{i}";
                            string ingredientColumn = $"ingredient{i}_id";

                            if (!reader.IsDBNull(reader.GetOrdinal(qtyColumn)))
                            {
                                qtyIngredientNeeded = reader.GetDouble(reader.GetOrdinal(qtyColumn));

                                // Adjust quantity based on number of persons
                                if (Properties.Settings.Default.NbPortionsSet == 1 || Properties.Settings.Default.NbPortionsSet > 2)
                                {
                                    qtyIngredientNeeded /= 2;
                                }
                                if (Properties.Settings.Default.NbPortionsSet > 2)
                                {
                                    qtyIngredientNeeded *= Properties.Settings.Default.NbPortionsSet;
                                }
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal(ingredientColumn)))
                            {
                                int ingredientIdFound = reader.GetInt32(reader.GetOrdinal(ingredientColumn));

                                // Assign ingredient properties
                                ingredientToAdd.Id = ingredientIdFound;
                                ingredientToAdd.Name = ReadNameForAnIngredientId(ingredientToAdd.Id);
                                ingredientToAdd.Scale_id = ReadScaleIdForAnIngredient(ingredientToAdd.Id);
                                ingredientToAdd.QtyRequested = qtyIngredientNeeded;
                                ingredientToAdd.QtyAvailable = qtyIngredientAvailable;

                                listIngredientsRequested.Add(ingredientToAdd);
                            }
                        }
                    }
                }
            }

            return listIngredientsRequested;
        }

        /// <summary>
        /// Reads the name of an ingredient for its ID based on the selected language.
        /// </summary>
        /// <param name="ingredientId">The ID of the ingredient.</param>
        /// <param name="selectedLanguage">The language code.</param>
        /// <returns>Name of the ingredient.</returns>
        public string ReadNameForAnIngredientId(int ingredientId, string selectedLanguage = "en")
        {
            string nameOfIngredientFound = "";

            // Normalizes language code
            selectedLanguage = selectedLanguage.ToLower();

            // Fallback to English if unknown language
            if (selectedLanguage != "en" && selectedLanguage != "fr" && selectedLanguage != "es")
            {
                selectedLanguage = "en";
            }

            // Selects the appropriate column based on the language
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = $"SELECT {ingredientColumn} FROM Ingredients WHERE id = @IngredientId;";
                cmd.Parameters.AddWithValue("@IngredientId", ingredientId);

                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    // Only one expected result
                    if (dataReader.Read())
                    {
                        nameOfIngredientFound = dataReader[ingredientColumn].ToString();
                    }
                }
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
        /// Reads the instructions needed to make the selected recipe.
        /// </summary>
        /// <param name="providedRecipeId">The provided ID of the recipe.</param>
        /// <param name="providedLanguage">The language code for the instructions to retrieve.</param>
        /// <returns>List of instructions for the recipe.</returns>
        public List<Instructions> ReadInstructionsForARecipe(int providedRecipeId, string providedLanguage)
        {
            List<Instructions> listInstructionsRequested = new List<Instructions>();

            string query = @"
                            SELECT id, instruction, recipe_id, language, rank
                            FROM Instructions
                            WHERE recipe_id = @IdRecipe AND language = @Language
                            ORDER BY rank;";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", providedRecipeId);
                cmd.Parameters.AddWithValue("@Language", providedLanguage);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Instructions instruction = new Instructions();

                        instruction.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        instruction.Text = reader["instruction"].ToString();
                        instruction.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                        instruction.Rank = reader.GetInt32(reader.GetOrdinal("rank"));
                        instruction.Language = reader["language"].ToString();

                        listInstructionsRequested.Add(instruction);
                    }
                }
            }

            return listInstructionsRequested;
        }
        
        /// <summary>
        /// Reads the planned portion count for a specific day.
        /// Returns 0 if the database entry is null or missing.
        /// </summary>
        /// <param name="idDayOfTheWeek">Numeric identifier of the day (1 = Monday).</param>
        /// <returns>The number of planned portions.</returns>
        public int ReadNbPortionsForADay(int idDayOfTheWeek)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(
                "SELECT nbPortionsPlanned FROM PlannedMeals WHERE id = @IdDay;",
                sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdDay", idDayOfTheWeek);

                object DBresult = cmd.ExecuteScalar();

                if (DBresult == null || DBresult == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(DBresult);
            }
        }

        /// <summary>
        /// Reads the ID of a recipe given its title.
        /// </summary>
        /// <param name="titleRecipe">The title of the selected recipe.</param>
        /// <returns>The ID of the selected recipe.</returns>
        public int ReadRecipeId(string titleRecipe)
        {
            int idRecipeFound = 0;

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT id FROM Recipes WHERE title = @TitleRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@TitleRecipe", titleRecipe.Replace("'", "''")); // Prevent SQL errors with apostrophes

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    idRecipeFound = Convert.ToInt32(result);
                }
            }

            return idRecipeFound;
        }

        /// <summary>
        /// Reads a recipe title from the database given its ID.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <returns>The title of the recipe.</returns>
        public string ReadRecipeTitle(int idRecipe)
        {
            string titleFound = "";

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT title FROM Recipes WHERE id = @IdRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        titleFound = reader["title"].ToString();
                    }
                }
            }

            return titleFound;
        }

        /// <summary>
        /// Reads the completion time of a recipe (preparing and baking time combined).
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <returns>The completion time of the recipe.</returns>
        public int ReadRecipeCompletionTime(int idRecipe)
        {
            int completionTimeValueFound = 0;

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT completionTime FROM Recipes WHERE id = @IdRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    completionTimeValueFound = Convert.ToInt32(result);
                }
            }

            return completionTimeValueFound;
        }

        /// <summary>
        /// Reads a recipe image path.
        /// </summary>
        /// <param name="idRecipe">The id of the recipe to display.</param>
        /// <returns>The image path for the currently selected recipe.</returns>
        public string ReadRecipeImagePath(int idRecipe)
        {
            string imagePathFound = string.Empty;

            using (var cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = "SELECT imagePath AS recipeImagePath FROM Recipes WHERE id = @idRecipe;";
                cmd.Parameters.AddWithValue("@idRecipe", idRecipe);

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["recipeImagePath"] != DBNull.Value)
                        {
                            imagePathFound = dataReader["recipeImagePath"].ToString();
                        }
                    }
                }
            }

            return imagePathFound;
        }

        /// <summary>
        /// Reads the language code of a recipe from the database.
        /// This value determines which set of instructions should 
        /// be loaded for the selected recipe.
        /// </summary>
        /// <returns>The language code of the recipe, or 'en' as a fallback.</returns>
        public string ReadRecipeLanguage(int idRecipe)
        {
            string query = "SELECT language FROM Recipes WHERE id = @IdRecipe";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["language"].ToString();
                    }
                }
            }

            // Fallback if nothing found
            return "en";
        }

        /// <summary>
        /// Reads a recipe's low budget status.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <returns>1 if the recipe is low budget, 0 otherwise.</returns>
        public int ReadRecipeLowBudgetStatus(int idRecipe)
        {
            int lowBudgetValueFound = 0;

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT lowBudget FROM Recipes WHERE id = @IdRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    lowBudgetValueFound = Convert.ToInt32(result);
                }
            }

            return lowBudgetValueFound;
        }

        /// <summary>
        /// Reads a recipe score.
        /// </summary>
        /// <param name="idRecipe">The id of the recipe to display.</param>
        /// <returns>The score currently assigned to the recipe.</returns>
        public int ReadRecipeScore(int idRecipe)
        {
            int scoreFound = 0;

            using (var cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = "SELECT score AS scoreRecipe FROM Recipes WHERE id = @idRecipe;";
                cmd.Parameters.AddWithValue("@idRecipe", idRecipe);

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["scoreRecipe"] != DBNull.Value)
                        {
                            int.TryParse(dataReader["scoreRecipe"].ToString(), out scoreFound);
                        }
                    }
                }
            }

            return scoreFound;
        }

        /// <summary>
        /// Reads the scale used by an ingredient.
        /// </summary>
        /// <param name="idIngredient">The id of the ingredient.</param>
        /// <returns>The scale id used by the ingredient.</returns>
        public int ReadScaleIdForAnIngredient(int idIngredient)
        {
            int scaleIdFound = 0;

            using (var cmd = sqliteConn.CreateCommand())
            {
                // Use parameterized query to prevent SQL injection
                cmd.CommandText = "SELECT scale_id FROM Ingredients WHERE Id = @idIngredient;";
                cmd.Parameters.AddWithValue("@idIngredient", idIngredient);

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["scale_id"] != DBNull.Value)
                        {
                            int.TryParse(dataReader["scale_id"].ToString(), out scaleIdFound);
                        }
                    }
                }
            }

            return scaleIdFound;
        }

        /// <summary>
        /// Reads the scale name corresponding to an ID, adapted to the active language.
        /// </summary>
        /// <param name="scaleId">The ID of the scale.</param>
        /// <returns>The scale name used by the ingredient.</returns>
        public string ReadScaleNameForAnID(int scaleId)
        {
            string scaleNameFound = "";
            string selectedLanguage = Properties.Settings.Default.AppLanguageCode.ToString();

            // Determining the correct column by language
            string scaleColumn = "scaleName_" + selectedLanguage;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = $"SELECT {scaleColumn} AS scaleName FROM Scales WHERE id = @ScaleId;";
                cmd.Parameters.AddWithValue("@ScaleId", scaleId);

                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        scaleNameFound = dataReader["scaleName"].ToString();
                    }
                }
            }

            return scaleNameFound;
        }

        /// <summary>
        /// Reads the type id assigned to an ingredient.
        /// </summary>
        /// <param name="ingredientId">The id of the ingredient to read.</param>
        /// <returns>The type id currently assigned to the ingredient.</returns>
        public int ReadTypeIdForIngredient(int ingredientId)
        {
            int typeIdFound = 0;

            using (var cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = "SELECT typeOfIngredient_id AS ingredientType FROM Ingredients WHERE id = @idIngredient;";
                cmd.Parameters.AddWithValue("@idIngredient", ingredientId);

                object resultValue = cmd.ExecuteScalar();

                if (resultValue != null && resultValue != DBNull.Value)
                {
                    int.TryParse(resultValue.ToString(), out typeIdFound);
                }
            }

            return typeIdFound;
        }


        /// <summary>
        /// Reads the type name of an ingredient for a given ID, adapted to the active language.
        /// </summary>
        /// <param name="idTypeOfIngredient">The ID of the ingredient type.</param>
        /// <param name="selectedLanguage">The active language ('fr' or 'en').</param>
        /// <returns>Name of the ingredient type.</returns>
        public string ReadTypeName(int idTypeOfIngredient, string selectedLanguage = "en")
        {
            string typeFound = "";

            // Determine the correct column based on the language
            string typeColumn = "type_" + selectedLanguage;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = $"SELECT {typeColumn} AS type FROM TypesOfIngredient WHERE id = @IdTypeOfIngredient;";
                cmd.Parameters.AddWithValue("@IdTypeOfIngredient", idTypeOfIngredient);

                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read()) // Optimisation : un seul résultat attendu
                    {
                        typeFound = dataReader["type"].ToString();
                    }
                }
            }

            return typeFound;
        }


        /// <summary>
        /// Searches for recipes based on multiple ingredient names and optional filters.
        /// Adapts ingredient name search based on the selected language.
        /// </summary>
        /// <param name="ingredientInputs">List of ingredient names to search for.</param>
        /// <param name="selectedLanguage">The language code for ingredient names.</param>
        /// <param name="filterForLowBudget">Filter for low-budget recipes.</param>
        /// <param name="filterForThreeStars">Filter for recipes with three stars.</param>
        /// <returns>List of matching recipe titles.</returns>
        public List<string> SearchRecipesByIngredients(List<string> ingredientInputs, string selectedLanguage = "en",
                                                       bool filterForLowBudget = false, bool filterForThreeStars = false)
        {
            List<string> recipesTitlesFound = new List<string>();

            // Normalizes language code
            selectedLanguage = selectedLanguage.ToLower();

            // Fallback to English if unknown language
            if (selectedLanguage != "en" && selectedLanguage != "fr" && selectedLanguage != "es")
            {
                selectedLanguage = "en";
            }

            // Determines the correct ingredient column name dynamically
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            string query = $@"
            SELECT DISTINCT Recipes.title FROM Recipes
            LEFT JOIN Recipes_has_Ingredients RHI ON Recipes.id = RHI.id
            LEFT JOIN Ingredients I ON 
                   I.id = RHI.ingredient1_id OR
                   I.id = RHI.ingredient2_id OR
                   I.id = RHI.ingredient3_id OR
                   I.id = RHI.ingredient4_id OR
                   I.id = RHI.ingredient5_id OR
                   I.id = RHI.ingredient6_id OR
                   I.id = RHI.ingredient7_id OR
                   I.id = RHI.ingredient8_id OR
                   I.id = RHI.ingredient9_id OR
                   I.id = RHI.ingredient10_id OR
                   I.id = RHI.ingredient11_id OR
                   I.id = RHI.ingredient12_id OR
                   I.id = RHI.ingredient13_id OR
                   I.id = RHI.ingredient14_id OR
                   I.id = RHI.ingredient15_id OR
                   I.id = RHI.ingredient16_id OR
                   I.id = RHI.ingredient17_id OR
                   I.id = RHI.ingredient18_id OR
                   I.id = RHI.ingredient19_id OR
                   I.id = RHI.ingredient20_id
            WHERE 1=1"; 

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                // Ingredient search conditions
                if (ingredientInputs != null && ingredientInputs.Count > 0)
                {
                    List<string> ingredientConditions = new List<string>();

                    for (int i = 0; i < ingredientInputs.Count; i++)
                    {
                        ingredientConditions.Add($"I.{ingredientColumn} LIKE @Ingredient{i}");
                        cmd.Parameters.AddWithValue($"@Ingredient{i}", $"%{ingredientInputs[i]}%");
                    }

                    query += " AND (" + string.Join(" OR ", ingredientConditions) + ")";
                }

                // Optional filters
                if (filterForLowBudget)
                {
                    query += " AND Recipes.lowBudget = 1";
                }

                if (filterForThreeStars)
                {
                    query += " AND Recipes.score = 3";
                }

                cmd.CommandText = query;

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        recipesTitlesFound.Add(reader["title"].ToString());
                    }
                }
            }

            return recipesTitlesFound;
        }

        /// <summary>
        /// Reads the list of recipes that contain at least one of the specified keywords in their title.
        /// </summary>
        /// <param name="keywords">List of keywords to search for in recipe titles</param>
        /// <returns>List of recipe titles found in the database</returns>
        public List<string> SearchRecipesByTitle(List<string> keywords)
        {
            List<string> titlesFound = new List<string>();

            // Base query
            string query = "SELECT title FROM Recipes";

            // Adds dynamic conditions if keywords are provided
            if (keywords != null && keywords.Count > 0)
            {
                // Dynamically builds the WHERE clause for the SQL query
                // It loops through the keywords list
                query += " WHERE " + string.Join(" OR ", keywords.Select((keyword, index) => $"title LIKE @keyword{index}"));
            }

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                // Adds each keyword as a parameter (ensuring security)
                if (keywords != null && keywords.Count > 0)
                {
                    for (int i = 0; i < keywords.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@keyword{i}", $"%{keywords[i]}%");
                    }
                }

                // Executes the query
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        titlesFound.Add(reader["title"].ToString());
                    }
                }
            }

            return titlesFound;
        }

        /// <summary>
        /// Updates the text of an instruction safely in the database.
        /// Escapes apostrophes to prevent SQL issues.
        /// </summary>
        public void UpdateInstruction(int idInstruction, string newInstructionText)
        {
            // Defensive copy
            string formattedText = newInstructionText;

            // Escapes apostrophes
            if (!string.IsNullOrEmpty(newInstructionText) && newInstructionText.Contains("'"))
            {
                formattedText = newInstructionText.Replace("'", "''");
            }

            using (SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Instructions SET instruction = @NewInstructionText WHERE id = @IdInstruction;",
                sqliteConn))
            {
                cmd.Parameters.AddWithValue("@NewInstructionText", formattedText);
                cmd.Parameters.AddWithValue("@IdInstruction", idInstruction);
                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Updates the image path for the selected recipe.
        /// </summary>
        public void UpdateImagePath(int idRecipe, string newImagePath)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Recipes SET imagePath = @NewImagePath WHERE id = @IdRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@NewImagePath", newImagePath);
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates all ingredient fields (FR/EN/ES names, type and scale)
        /// for the specified ingredient.
        /// </summary>
        /// <param name="ingredientId">The id of the ingredient to update.</param>
        /// <param name="nameFr">The French name of the ingredient.</param>
        /// <param name="nameEn">The English name of the ingredient.</param>
        /// <param name="nameEs">The Spanish name of the ingredient.</param>
        /// <param name="typeId">The type id assigned to the ingredient.</param>
        /// <param name="scaleId">The scale id assigned to the ingredient.</param>
        public void UpdateIngredientFull(int ingredientId, string nameFr, string nameEn, string nameEs, int typeId, int scaleId)
        {
            using (var cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText =
                    "UPDATE Ingredients SET " +
                    "ingredientName_fr = @nameFr, " +
                    "ingredientName_en = @nameEn, " +
                    "ingredientName_es = @nameEs, " +
                    "typeOfIngredient_id = @typeId, " +
                    "scale_id = @scaleId " +
                    "WHERE id = @ingredientId;";

                cmd.Parameters.AddWithValue("@nameFr", nameFr);
                cmd.Parameters.AddWithValue("@nameEn", nameEn);
                cmd.Parameters.AddWithValue("@nameEs", nameEs);
                cmd.Parameters.AddWithValue("@typeId", typeId);
                cmd.Parameters.AddWithValue("@scaleId", scaleId);
                cmd.Parameters.AddWithValue("@ingredientId", ingredientId);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the planned recipe entry for a given day of the week.
        /// If a recipe title is provided, it is stored in the database; 
        /// if the title is null or empty, the column is set to NULL to indicate no recipe planned.
        /// </summary>
        /// <param name="idDayOfTheWeek">The unique identifier of the day of the week (e.g., 1 = Monday).</param>
        /// <param name="titleOfTheRecipe">The title of the recipe to assign, or null/empty to clear the entry.</param>
        /// <param name="nbPortionsPlanned">The number of portions that has effectively been cooked.</param>
        public void UpdatePlannedRecipeForADay(int idDayOfTheWeek, string titleOfTheRecipe, int nbPortionsPlanned)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE PlannedMeals " +
                "SET titleOfPlannedRecipe = @TitleOfPlannedRecipe, " +
                "    nbPortionsPlanned   = @NbPortionsPlanned " +
                "WHERE id = @IdDayOfTheWeek;",
                sqliteConn))
            {
                if (string.IsNullOrWhiteSpace(titleOfTheRecipe))
                {
                    // Stores null in the database if no recipe is planned
                    cmd.Parameters.AddWithValue("@TitleOfPlannedRecipe", DBNull.Value);
                    cmd.Parameters.AddWithValue("@NbPortionsPlanned", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TitleOfPlannedRecipe", titleOfTheRecipe);
                    cmd.Parameters.AddWithValue("@NbPortionsPlanned", nbPortionsPlanned);
                }

                cmd.Parameters.AddWithValue("@IdDayOfTheWeek", idDayOfTheWeek);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates a recipe's low budget status.
        /// </summary>
        public void UpdateRecipeLowBudgetStatus(int idRecipe, int lowBudgetStatus)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Recipes SET lowBudget = @LowBudgetStatus WHERE id = @IdRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@LowBudgetStatus", lowBudgetStatus);
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the score for the selected recipe.
        /// </summary>
        public void UpdateScoreForRecipe(int idRecipe, int newScore)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Recipes SET score = @NewScore WHERE id = @IdRecipe;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@NewScore", newScore);
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the quantity available for a given ingredient.
        /// </summary>
        public void UpdateQtyIngredientAvailable(int idIngredient, double newQtyIngredientAvailable)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Ingredients SET qtyAvailable = @NewQtyIngredientAvailable WHERE id = @IdIngredient;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@NewQtyIngredientAvailable", newQtyIngredientAvailable);
                cmd.Parameters.AddWithValue("@IdIngredient", idIngredient);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the title, completion time, low budget status and language of a recipe.
        /// Only the non-empty parameters are applied.
        /// </summary>
        public void UpdateRecipeInfos(int idRecipe, string newTitle, string newCompletionTime, string newLowBudgetStatus, string newLanguage)
        {
            // Updates title
            if (!string.IsNullOrEmpty(newTitle))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(
                    "UPDATE Recipes SET title = @NewTitle WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewTitle", newTitle);
                    cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                    cmd.ExecuteNonQuery();
                }
            }

            // Updates completion time
            if (!string.IsNullOrEmpty(newCompletionTime))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(
                    "UPDATE Recipes SET completionTime = @NewCompletionTime WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewCompletionTime", newCompletionTime);
                    cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                    cmd.ExecuteNonQuery();
                }
            }

            // Updates low budget status
            if (!string.IsNullOrEmpty(newLowBudgetStatus))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(
                    "UPDATE Recipes SET lowBudget = @NewLowBudgetStatus WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewLowBudgetStatus", newLowBudgetStatus);
                    cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                    cmd.ExecuteNonQuery();
                }
            }

            // Updates language
            if (!string.IsNullOrEmpty(newLanguage))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(
                    "UPDATE Recipes SET language = @NewLanguage WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewLanguage", newLanguage);
                    cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                    cmd.ExecuteNonQuery();
                }
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
