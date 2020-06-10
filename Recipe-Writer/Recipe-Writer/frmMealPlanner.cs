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
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdMondayCancelled_Click(object sender, EventArgs e)
        {
            lblMondayRecipe.Text = "";
            cmdMondayCancelled.Visible = false;
            cmdMondayDone.Visible = false;
        }

        private void cmdTuesdayCancelled_Click(object sender, EventArgs e)
        {
            lblTuesdayRecipe.Text = "";
            cmdTuesdayCancelled.Visible = false;
            cmdTuesdayDone.Visible = false;
        }

        private void lblWednesdayRecipe_Click(object sender, EventArgs e)
        {
            lblWednesdayRecipe.Text = "";
            cmdWednesdayCancelled.Visible = false;
            cmdWednesdayDone.Visible = false;
        }

        private void cmdThursdayCancelled_Click(object sender, EventArgs e)
        {
            lblThursdayRecipe.Text = "";
            cmdThursdayCancelled.Visible = false;
            cmdThursdayDone.Visible = false;
        }

        private void cmdFridayCancelled_Click(object sender, EventArgs e)
        {
            lblFridayRecipe.Text = "";
            cmdFridayCancelled.Visible = false;
            cmdFridayDone.Visible = false;
        }

        private void cmdSaturdayCancelled_Click(object sender, EventArgs e)
        {
            lblSaturdayRecipe.Text = "";
            cmdSaturdayCancelled.Visible = false;
            cmdSaturdayDone.Visible = false;
        }

        private void cmdSundayCancelled_Click(object sender, EventArgs e)
        {
            lblSundayRecipe.Text = "";
            cmdSundayCancelled.Visible = false;
            cmdSundayDone.Visible = false;
        }

        private void lblMondayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lblTuesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblTuesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void lblWednesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblWednesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void lblThursdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblThursdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void lblFridayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblFridayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void lblSaturdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblSaturdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void lblSundayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            lblSundayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void lblMondayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblMondayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdMondayCancelled.Visible = true;
            cmdMondayDone.Visible = true;
        }

        private void lblTuesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblTuesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdTuesdayCancelled.Visible = true;
            cmdTuesdayDone.Visible = true;
        }

        private void lblWednesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblWednesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdWednesdayCancelled.Visible = true;
            cmdWednesdayDone.Visible = true;
        }

        private void lblThursdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblThursdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdThursdayCancelled.Visible = true;
            cmdThursdayDone.Visible = true;
        }

        private void lblFridayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblFridayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdFridayCancelled.Visible = true;
            cmdFridayDone.Visible = true;
        }

        private void lblSaturdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSaturdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSaturdayCancelled.Visible = true;
            cmdSaturdayDone.Visible = true;
        }

        private void lblSundayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSundayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            cmdSundayCancelled.Visible = true;
            cmdSundayDone.Visible = true;
        }

        private void frmMealPlanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmMain.MealPlannerShown = false;
        }
    }
}
