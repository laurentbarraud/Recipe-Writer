using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Writer
{
    public class Instructions
    {
		private int recipeId;
		private string text;
		private int nb;

		public int RecipeId
		{
			get { return recipeId; }
			set { recipeId = value; }
		}

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

		public int Nb
		{
			get { return nb; }
			set { nb = value; }
		}
	}
}
