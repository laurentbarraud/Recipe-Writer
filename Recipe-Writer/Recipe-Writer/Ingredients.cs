﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Writer
{
	public class Ingredients
	{
		private string name;
		private double qtyRequested;
		private double qtyAvailable;
		private string scale;

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

		public string Scale
		{
			get { return scale; }
			set { scale = value; }
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
		/// <param name="scaleProvidedProvided">the scale used to calculate with this ingredient</param>
		/// <param name="qtyAvailableProvided">the quantity of ingredient available in the inventory</param>

		public Ingredients(string nameProvided, double qtyRequestedProvided, string scaleProvided, double qtyAvailableProvided = 0.0)
		{
			this.Name = nameProvided;
			this.QtyRequested = qtyRequestedProvided;
			this.Scale = scaleProvided;
			this.QtyAvailable = qtyAvailableProvided;
		}
	}
}
