
/// <file>DBConnection.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>December 7th 2025</date>

using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Globalization;

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
        /// Adds a new ingredient into the database for a given recipe.
        /// Ensures both French and English names are stored.
        /// </summary>
        public void AddNewIngredient(int idRecipe, double qtyIngredient, string newIngredientNameFr, string newIngredientNameEn, string scaleIngredient)
        {
            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                // Ensures both names have a value
                if (string.IsNullOrWhiteSpace(newIngredientNameFr)) newIngredientNameFr = newIngredientNameEn;
                if (string.IsNullOrWhiteSpace(newIngredientNameEn)) newIngredientNameEn = newIngredientNameFr;

                // Inserts the new ingredient into the Ingredients table
                cmd.CommandText = "INSERT INTO Ingredients (ingredientName_fr, ingredientName_en, qtyAvailable) VALUES (@IngredientNameFr, @IngredientNameEn, 0.0)";
                cmd.Parameters.AddWithValue("@IngredientNameFr", newIngredientNameFr);
                cmd.Parameters.AddWithValue("@IngredientNameEn", newIngredientNameEn);
                cmd.ExecuteNonQuery();

                // Gets the last inserted ingredient ID
                cmd.CommandText = "SELECT last_insert_rowid()";
                int newIngredientId = Convert.ToInt32(cmd.ExecuteScalar());

                // Inserts the ingredient reference into the Recipes_has_Ingredients table
                cmd.CommandText = "INSERT INTO Recipes_has_Ingredients (qtyIngredient, ingredientId, scales, recipeId) VALUES (@QtyIngredient, @IngredientId, @ScaleIngredient, @RecipeId)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QtyIngredient", qtyIngredient);
                cmd.Parameters.AddWithValue("@IngredientId", newIngredientId);
                cmd.Parameters.AddWithValue("@ScaleIngredient", scaleIngredient);
                cmd.Parameters.AddWithValue("@RecipeId", idRecipe);

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
        /// Adds a new ingredient to the database, ensuring French and English names are stored.
        /// If only one name is provided, it is copied into the other.
        /// </summary>
        public void AddNewIngredientToDB(string ingredientNameFr, string ingredientNameEn, int scaleIdForThisIngredient, int idTypeOfIngredient)
        {
            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                // Ensures both names have a value
                if (string.IsNullOrWhiteSpace(ingredientNameFr)) ingredientNameFr = ingredientNameEn;
                if (string.IsNullOrWhiteSpace(ingredientNameEn)) ingredientNameEn = ingredientNameFr;

                // Inserts the new ingredient into the Ingredients table
                cmd.CommandText = "INSERT INTO Ingredients (ingredientName_fr, ingredientName_en, scale_id, typeOfIngredient_id) " +
                                  "VALUES (@ingredientNameFr, @ingredientNameEn, @scaleId, @idTypeOfIngredient);";

                cmd.Parameters.AddWithValue("@ingredientNameFr", ingredientNameFr);
                cmd.Parameters.AddWithValue("@ingredientNameEn", ingredientNameEn);
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
        /// If <paramref name="typeProvided"/> is 0, the function returns all ingredients.
        /// The ingredient name is localized based on the active language setting.
        /// </summary>
        /// <param name="typeProvided">The type identifier of the ingredient, or 0 to retrieve all.</param>
        /// <returns>A list of localized ingredient names.</returns>
        public List<string> ReadAllIngredientsStoredForAType(int typeProvided = 0)
        {
            List<string> listAllIngredientsFoundInDB = new List<string>();
            string selectedLanguage = Properties.Settings.Default.LanguageSetting.ToString();
            
            // Determines the correct column based on the language
            string ingredientColumn = "ingredientName_" + selectedLanguage;
            string query = $"SELECT id, {ingredientColumn} AS ingredientName FROM Ingredients";

            if (typeProvided != 0)
            {
                query += " WHERE typeOfIngredient_id = @TypeProvided";
            }

            query += $" ORDER BY {ingredientColumn};";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (typeProvided != 0)
                {
                    cmd.Parameters.AddWithValue("@TypeProvided", typeProvided);
                }

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("ingredientName")))
                        {
                            listAllIngredientsFoundInDB.Add(reader["ingredientName"].ToString());
                        }
                    }
                }
            }

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
        /// Retrieves all types of ingredients stored in the database,
        /// localized according to the active language setting.
        /// </summary>
        /// <param name="selectedLanguage">The active language code ('fr' or 'en').</param>
        /// <returns>A list of localized ingredient types.</returns>
        public List<string> ReadAllTypesOfIngredientsStored(string selectedLanguage = "en")
        {
            List<string> listAllTypesOfIngredientsFoundInDB = new List<string>();

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
        /// Reads the quantity available for a given ingredient.
        /// </summary>
        /// <param name="ingredientId">The ID of the ingredient.</param>
        /// <returns>Quantity available for the ingredient.</returns>
        public double ReadQtyAvailableForAnIngredient(int ingredientId)
        {
            double qtyIngredientStored = 0.0;

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT qtyAvailable FROM Ingredients WHERE id = @IngredientId;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IngredientId", ingredientId);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && !reader.IsDBNull(0))
                    {
                        qtyIngredientStored = reader.GetDouble(0);
                    }
                }
            }

            return qtyIngredientStored;
        }


        /// <summary>
        /// Reads the quantity of an ingredient available, based on the selected language.
        /// </summary>
        /// <param name="ingredientName">The name of the ingredient.</param>
        /// <param name="selectedLanguage">The language ('fr' or 'en') for ingredient lookup.</param>
        /// <returns>Quantity of the ingredient found in the inventory.</returns>
        public double ReadQtyAvailableForAnIngredient(string ingredientName, string selectedLanguage = "fr")
        {
            double qtyIngredientFound = 0.0;

            // Ensure apostrophes are escaped to avoid SQL errors
            string formattedNameIngredient = ingredientName.Replace("'", "''");

            // Select the appropriate column based on the language
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = $"SELECT qtyAvailable FROM Ingredients WHERE {ingredientColumn} = @IngredientName;";
                cmd.Parameters.AddWithValue("@IngredientName", formattedNameIngredient);

                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        // Parses the quantity of the ingredient
                        double.TryParse(dataReader["qtyAvailable"].ToString(), out qtyIngredientFound);
                    }
                }
            }

            return qtyIngredientFound;
        }


        /// <summary>
        /// Reads all scales stored in the database, adapted to the active language.
        /// </summary>
        /// <param name="selectedLanguage">The active language ('fr' or 'en').</param>
        /// <returns>List of scales stored in the database.</returns>
        public List<string> ReadAllScalesStored(string selectedLanguage = "fr")
        {
            List<string> allScalesNamesList = new List<string>();

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
                                if (Properties.Settings.Default.NbPersonsSet == 1 || Properties.Settings.Default.NbPersonsSet > 2)
                                {
                                    qtyIngredientNeeded /= 2;
                                }
                                if (Properties.Settings.Default.NbPersonsSet > 2)
                                {
                                    qtyIngredientNeeded *= Properties.Settings.Default.NbPersonsSet;
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
        /// Reads the ID of an ingredient for a given name, based on the selected language. 
        /// </summary> 
        /// <param name="nameIngredient">The name of the ingredient.</param> 
        /// <param name="selectedLanguage">The language ('fr' or 'en') for ingredient lookup.</param> 
        /// <returns>ID of the ingredient.</returns>
        public int ReadIdForAnIngredientName(string nameIngredient, string selectedLanguage = "en")
        {
            int ingredientIdFound = 0;

            // Determines the correct column based on the language
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                cmd.CommandText = $"SELECT id FROM Ingredients WHERE {ingredientColumn} = @IngredientName;";
                cmd.Parameters.AddWithValue("@IngredientName", nameIngredient.Trim()); // Deletes invisible spaces

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
        /// Reads the name of an ingredient for its ID based on the selected language.
        /// </summary>
        /// <param name="ingredientId">The ID of the ingredient.</param>
        /// <param name="selectedLanguage">The language ('fr' or 'en') for ingredient name lookup.</param>
        /// <returns>Name of the ingredient.</returns>
        public string ReadNameForAnIngredientId(int ingredientId, string selectedLanguage = "en")
        {
            string nameOfIngredientFound = "";

            // Select the appropriate column based on the language
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
            string selectedLanguage = Properties.Settings.Default.LanguageSetting.ToString();

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
        /// Reads the type name of an ingredient for a given ID, adapted to the active language.
        /// </summary>
        /// <param name="idTypeOfIngredient">The ID of the ingredient type.</param>
        /// <param name="selectedLanguage">The active language ('fr' or 'en').</param>
        /// <returns>Name of the ingredient type.</returns>
        public string ReadTypeName(int idTypeOfIngredient, string selectedLanguage = "fr")
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
        /// Reads the instructions needed to make the selected recipe.
        /// </summary>
        /// <param name="idRecipe">The ID of the recipe.</param>
        /// <returns>List of instructions for the recipe.</returns>
        public List<Instructions> ReadInstructionsForARecipe(int idRecipe)
        {
            List<Instructions> listInstructionsRequested = new List<Instructions>();

            string query = @"SELECT Instructions.id AS Instructions_id, instruction, Recipes_id, InstructionNb
                     FROM Instructions_has_Recipes
                     INNER JOIN Instructions ON Instructions_has_Recipes.Instructions_id = Instructions.id
                     WHERE Recipes_id = @IdRecipe;";

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int instructionId = reader.GetInt32(reader.GetOrdinal("Instructions_id"));
                        string textInstruction = reader["instruction"].ToString();
                        int recipeId = reader.GetInt32(reader.GetOrdinal("Recipes_id"));
                        int rankInstruction = reader.GetInt32(reader.GetOrdinal("InstructionNb"));

                        listInstructionsRequested.Add(new Instructions(instructionId, textInstruction, recipeId, rankInstruction));
                    }
                }
            }

            return listInstructionsRequested;
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
        /// Searches for recipes based on multiple ingredient names and optional filters.
        /// Adapts ingredient name search based on the selected language.
        /// </summary>
        /// <param name="ingredientInputs">List of ingredient names to search for.</param>
        /// <param name="selectedLanguage">The language ('fr' or 'en') for ingredient names.</param>
        /// <param name="filterForLowBudget">Filter for low-budget recipes.</param>
        /// <param name="filterForThreeStars">Filter for recipes with three stars.</param>
        /// <returns>List of matching recipe titles.</returns>
        public List<string> SearchRecipesByIngredients(List<string> ingredientInputs, string selectedLanguage = "en", bool filterForLowBudget = false, bool filterForThreeStars = false)
        {
            List<string> recipesTitlesFound = new List<string>();

            // Determine the correct ingredient column name dynamically
            string ingredientColumn = "ingredientName_" + selectedLanguage;

            string query = $@"SELECT DISTINCT Recipes.title FROM Recipes
                     LEFT JOIN Recipes_has_Ingredients ON Recipes.id = Recipes_has_Ingredients.recipeId
                     LEFT JOIN Ingredients ON Ingredients.id = Recipes_has_Ingredients.ingredientId
                     WHERE 1=1"; // Ensures proper query structure for dynamic conditions

            using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConn))
            {
                if (ingredientInputs != null && ingredientInputs.Count > 0)
                {
                    List<string> ingredientConditions = new List<string>();
                    for (int i = 0; i < ingredientInputs.Count; i++)
                    {
                        ingredientConditions.Add($"Ingredients.{ingredientColumn} LIKE @Ingredient{i}");
                        cmd.Parameters.AddWithValue($"@Ingredient{i}", $"%{ingredientInputs[i]}%");
                    }
                    query += " AND (" + string.Join(" OR ", ingredientConditions) + ")";
                }

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
                // Add each keyword as a parameter (ensuring security)
                if (keywords != null && keywords.Count > 0)
                {
                    for (int i = 0; i < keywords.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@keyword{i}", $"%{keywords[i]}%");
                    }
                }

                // Execute the query
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
        /// Updates an instruction text for the selected recipe.
        /// </summary>
        public void UpdateInstruction(int idInstruction, string newInstructionText)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Instructions SET instruction = @NewInstructionText WHERE id = @IdInstruction;", sqliteConn))
            {
                cmd.Parameters.AddWithValue("@NewInstructionText", newInstructionText);
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
        /// Updates the name of an ingredient only in the active language.
        /// </summary>
        /// <param name="idIngredientToEdit">The ID of the ingredient.</param>
        /// <param name="newNameOfIngredient">The new name of the ingredient.</param>
        /// <param name="selectedLanguage">The active language ('fr' or 'en').</param>
        public void UpdateIngredientName(int idIngredientToEdit, string newNameOfIngredient, string selectedLanguage)
        {
            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                // Determine the correct column based on the language
                string ingredientColumn = "ingredientName_" + selectedLanguage;

                // Prepare SQL query
                cmd.CommandText = $"UPDATE Ingredients SET {ingredientColumn} = @NewNameOfIngredient WHERE id = @IdIngredient;";
                cmd.Parameters.AddWithValue("@NewNameOfIngredient", newNameOfIngredient);
                cmd.Parameters.AddWithValue("@IdIngredient", idIngredientToEdit);

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

        public void UpdatePlannedRecipeForADay(int idDayOfTheWeek, string titleOfTheRecipe)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE PlannedMeals SET titleOfPlannedRecipe = @TitleOfPlannedRecipe WHERE id = @IdDayOfTheWeek;",
                sqliteConn))
            {
                if (string.IsNullOrWhiteSpace(titleOfTheRecipe))
                {
                    // Stores NULL in the database if no recipe is planned
                    cmd.Parameters.AddWithValue("@TitleOfPlannedRecipe", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TitleOfPlannedRecipe", titleOfTheRecipe);
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
        /// Updates the title, completion time, and low budget status of a recipe.
        /// </summary>
        public void UpdateRecipeBasicInfos(int idRecipe, string newTitleRecipe = "", string newCompletionTime = "", string newLowBudgetStatus = "")
        {
            if (!string.IsNullOrEmpty(newTitleRecipe))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Recipes SET title = @NewTitleRecipe WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewTitleRecipe", newTitleRecipe);
                    cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                    cmd.ExecuteNonQuery();
                }
            }

            if (!string.IsNullOrEmpty(newCompletionTime))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Recipes SET completionTime = @NewCompletionTime WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewCompletionTime", newCompletionTime);
                    cmd.Parameters.AddWithValue("@IdRecipe", idRecipe);
                    cmd.ExecuteNonQuery();
                }
            }

            if (!string.IsNullOrEmpty(newLowBudgetStatus))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Recipes SET lowBudget = @NewLowBudgetStatus WHERE id = @IdRecipe;", sqliteConn))
                {
                    cmd.Parameters.AddWithValue("@NewLowBudgetStatus", newLowBudgetStatus);
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
