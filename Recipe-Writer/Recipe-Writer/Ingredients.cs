using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Writer
{
    public class Ingredients
    {
		private string name;
		private int qtyAvailable;
		private string scale;
		private int score;
		private string imagePath;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int QtyAvailable
		{
			get { return qtyAvailable; }
			set { qtyAvailable = value; }
		}

		public string Scale
		{
			get { return scale; }
			set { scale = value; }
		}
	}
}
