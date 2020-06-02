using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdTitleSearch_Click(object sender, EventArgs e)
        {
            // To-Do : implement a function that takes every keyword in the textfield and send them to the SearchRecipes function as arguments
        }

        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // To-Do : implement a function that affects to the currentDisplayedRecipe object the values returned by each of the 5 functions,
            // each being called after.
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // To-Do : instanciates a new Recipes objet, with default values for its properties
        }
    }
}
