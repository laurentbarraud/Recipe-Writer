/// <file>Instructions.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2</version>
/// <date>May 19th 2026</date>

namespace Recipe_Writer
{
    public class Instructions
    {
		private int id;
		private string text;
		private int recipeId;
		private int rank;
        private string language;

        public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

		public int RecipeId
		{
			get { return recipeId; }
			set { recipeId = value; }
		}

		public int Rank
		{
			get { return rank; }
			set { rank = value; }
		}

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        /// <summary>
        /// Default constructor used to create an empty Instructions instance.
        /// Its properties are assigned later when loading a recipe.
        /// </summary>
        public Instructions() 
		{ 
		
		}
	}
}
