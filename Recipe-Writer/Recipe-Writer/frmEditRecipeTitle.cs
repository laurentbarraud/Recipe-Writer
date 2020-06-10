﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmEditRecipeTitle : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;
        private string recipeTitleToEdit = "";

        public string RecipeTitleToEdit
        {
            get { return recipeTitleToEdit; }
            set { recipeTitleToEdit = value; }
        }


        // Constructor - Adds the parent form as parameter in the form constructor
        public frmEditRecipeTitle(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }


        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditRecipeTitle_Load(object sender, EventArgs e)
        {
            txtRecipeTitleToEdit.Text = this.RecipeTitleToEdit;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmEditRecipeTitle_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
