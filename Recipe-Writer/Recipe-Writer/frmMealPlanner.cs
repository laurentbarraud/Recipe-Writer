/// <file>frmMealPlanner.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 21th 2025</date>

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
    public partial class frmMealPlanner : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Generic delegate
        private Action<int> loadPlannedMeal;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmMealPlanner(frmMain parentForm)
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
        private void frmMealPlanner_Load(object sender, EventArgs e)
        {
            this.Location = new Point(_frmMain.Width - 150, _frmMain.Height / 2);

            loadPlannedMeal = LoadPlannedMealForADay;

            for (int idDayOfWeek = 1; idDayOfWeek < 6; idDayOfWeek++)
            {
                loadPlannedMeal(idDayOfWeek);
            }

            if (lblMondayRecipe.)
        }


        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdMondayCancelled_Click(object sender, EventArgs e)
        {
            lblMondayRecipe.Text = "";
            cmdMondayCancelled.Enabled = false;
        }

        private void cmdTuesdayCancelled_Click(object sender, EventArgs e)
        {
            lblTuesdayRecipe.Text = "";
            cmdTuesdayCancelled.Enabled = false;

        }

        private void lblWednesdayRecipe_Click(object sender, EventArgs e)
        {
            lblWednesdayRecipe.Text = "";
            cmdWednesdayCancelled.Enabled = false;

        }

        private void cmdThursdayCancelled_Click(object sender, EventArgs e)
        {
            lblThursdayRecipe.Text = "";
            cmdThursdayCancelled.Enabled = false;

        }

        private void cmdFridayCancelled_Click(object sender, EventArgs e)
        {
            lblFridayRecipe.Text = "";
            cmdFridayCancelled.Enabled = false;

        }

        private void cmdSaturdayCancelled_Click(object sender, EventArgs e)
        {
            lblSaturdayRecipe.Text = "";
            cmdSaturdayCancelled.Enabled = false;

        }

        private void cmdSundayCancelled_Click(object sender, EventArgs e)
        {
            lblSundayRecipe.Text = "";
            cmdSundayCancelled.Enabled = false;
            
        }


        private void frmMealPlanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmMain.MealPlannerShown = false;
        }

        private void lblMondayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblMondayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdMondayCancelled.Enabled = true;
        }

        private void lblTuesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblTuesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdTuesdayCancelled.Enabled = true;
        }

        private void lblWednesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblWednesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdWednesdayCancelled.Enabled = true;
        }

        private void lblThursdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblThursdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdThursdayCancelled.Enabled = true;
        }

        private void lblFridayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblFridayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdFridayCancelled.Enabled = true;
        }

        private void lblSaturdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblSaturdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSaturdayCancelled.Enabled = true;
        }

        private void lblSundayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblSundayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSundayCancelled.Enabled = true;

        }

        private void LoadPlannedMealForADay(int idDayOfTheWeek)
        {
            string titlePlannedMeal = _frmMain.dbConn.ReadPlannedMealsForADay(idDayOfTheWeek);
        
            switch (idDayOfTheWeek)
            {
                case 1:
                    lblMondayRecipe.Text = titlePlannedMeal; 
                    break;

                case 2:
                    lblThursdayRecipe.Text = titlePlannedMeal;
                    break;

                case 3:
                    lblWednesdayRecipe.Text = titlePlannedMeal;
                    break;

                case 4:
                    lblThursdayRecipe.Text = titlePlannedMeal;
                    break;

                case 5:
                    lblFridayRecipe.Text = titlePlannedMeal;
                    break;

                case 6:
                    lblSaturdayRecipe.Text = titlePlannedMeal;
                    break;

                case 7:
                    lblSundayRecipe.Text = titlePlannedMeal;
                    break;
            }
        }

        private void lblMondayRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTuesdayRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblWednesdayRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblThursdayRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFridayRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSaturdayRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSundayRecipe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
