/// <file>Recipes.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2</version>
/// <date>May 21th 2026</date>

using System;
using System.Collections.Generic;

namespace Recipe_Writer
{
	public class Recipes
	{
		private int id;
		private string title;
		private int completionTime;
        private string language;
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

        public string Language 
		{
			get { return language; } 
			set { language = value; }
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
        /// Default constructor used to create an empty recipe instance.
        /// Properties are initialized step by step when a recipe is selected.
        /// </summary>
        public Recipes()
        {
            // Initializes lists to avoid null reference issues
            this.IngredientsList = new List<Ingredients>();
            this.InstructionsList = new List<Instructions>();
        }
	}
}
