/// <file>Ingredients.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.1</version>
/// <date>December 7th 2025</date>

using System;

namespace Recipe_Writer
{
	public class Ingredients
	{
		private int id;
		private string name;
		private double qtyRequested;
		private double qtyAvailable;
		private int scale_id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public double QtyRequested
		{
			get { return qtyRequested; }
			set { qtyRequested = value; }
		}

		public int Scale_id
		{
			get { return scale_id; }
			set { scale_id = value; }
		}

		public double QtyAvailable
		{
			get { return qtyAvailable; }
			set { qtyAvailable = value; }
		}

		/// <summary>
		/// Constructor of the Ingredients class
		/// </summary>
		/// <param name="nameProvided">the name of the ingredient</param>
		/// <param name="qtyRequested">the quantity of the ingredient requested</param>
		/// <param name="scaleProvided">the scale used to calculate with this ingredient</param>
		/// <param name="qtyAvailableProvided">the quantity of ingredient available in the inventory</param>

		public Ingredients(string nameProvided, double qtyRequestedProvided, int scale_idProvided, double qtyAvailableProvided = 0.0)
		{
			this.Name = nameProvided;
			this.QtyRequested = qtyRequestedProvided;
			this.scale_id = scale_idProvided;
			this.QtyAvailable = qtyAvailableProvided;
		}
	}
}
