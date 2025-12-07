/// <file>Recipes.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>December 7th 2025</date>

using System;
using System.Collections.Generic;

namespace Recipe_Writer
{
	public class Recipes
	{
		private int id;
		private string title;
		private int completionTime;
		private int lowBudget;
		private int score;
		private string imagePath;
		private List<Ingredients> ingredientsList;
		private List<Instructions> instructionsList;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public int CompletionTime
		{
			get { return completionTime; }
			set { completionTime = value; }
		}

		public int LowBudget
		{
			get { return lowBudget; }
			set { lowBudget = value; }
		}

		public int Score
		{
			get { return score; }
			set { score = value; }
		}

		public string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; }
		}

		public List<Ingredients> IngredientsList
		{
			get { return ingredientsList; }
			set { ingredientsList = value; }
		}

		public List<Instructions> InstructionsList
		{
			get { return instructionsList; }
			set { instructionsList = value; }
		}

		/// <summary>
		/// Constructor of the Recipes class
		/// </summary>
		/// <param name="idRecipeProvided">the id of the recipe</param>
		/// <param name="titleProvided">the title of the recipe</param>
		/// <param name="completionTimeProvided">the completion time (preparing and baking) of the recipe</param>
		/// <param name="lowBudgetProvided">the status if this recipe is made for low budget</param>
		/// <param name="scoreProvided">the score affected to the recipe</param>
		/// <param name="imagePathProvided">the image path affected to the recipe</param>
		/// <param name="ingredientsListProvided">the list of ingredients needed to make the recipe</param>
		/// <param name="instructionsListProvided">the list of instructions to follow to make the recipe</param>
		public Recipes(int idRecipeProvided, string titleProvided, int completionTimeProvided, int lowBudgetProvided, int scoreProvided, string imagePathProvided, List<Ingredients> ingredientsListProvided, List<Instructions> instructionsListProvided, bool isReadyToCookProvided = false)
		{
			this.Id = idRecipeProvided;
			this.Title = titleProvided;
			this.CompletionTime = completionTimeProvided;
			this.LowBudget = lowBudgetProvided;
			this.Score = scoreProvided;
			this.ImagePath = imagePathProvided;
			this.IngredientsList = ingredientsListProvided;
			this.InstructionsList = instructionsListProvided;
		}
	}
}
