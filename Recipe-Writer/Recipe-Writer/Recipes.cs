using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Writer
{
    public class Recipes
    {
		private string title;
		private int completionTime;
		private int lowBudget;
		private int score;
		private string imagePath;

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

	}
}
