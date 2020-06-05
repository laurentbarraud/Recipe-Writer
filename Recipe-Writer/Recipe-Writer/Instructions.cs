namespace Recipe_Writer
{
    public class Instructions
    {
		private int id;
		private string text;
		private int recipeId;
		private int rank;

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

		/// <summary>
		/// Constructor of the Instructions class
		/// </summary>
		public Instructions(int idInstructionProvided, string textInstructionProvided, int recipeIdProvided, int rankInstructionProvided)
		{
			this.Id = idInstructionProvided;
			this.Text = textInstructionProvided;
			this.RecipeId = recipeIdProvided;
			this.Rank = rankInstructionProvided;
		}
	}
}
