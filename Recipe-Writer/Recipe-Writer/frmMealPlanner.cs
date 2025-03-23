/// <file>frmMealPlanner.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 23th 2025</date>

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

            if (lblMondayRecipe.Text != "")
            {
                picMondayCancelled.Visible = true;
            }

            if (lblTuesdayRecipe.Text != "")
            {
                picTuesdayCancelled.Visible = true;
            }

            if (lblWednesdayRecipe.Text != "")
            {
                picWednesdayCancelled.Visible = true;
            }

            if (lblThursdayRecipe.Text != "")
            {
                picThursdayCancelled.Visible = true;
            }

            if (lblFridayRecipe.Text != "")
            {
                picFridayCancelled.Visible = true;
            }

            if (lblSaturdayRecipe.Text != "")
            {
                picSaturdayCancelled.Visible = true;
            }

            if (lblSundayRecipe.Text != "")
            {
                picSundayCancelled.Visible = true;
            }
        }


        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMealPlanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmMain.MealPlannerShown = false;
        }


        private void lblMondayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblMondayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picMondayCancelled.Visible = true;
        }

        private void lblTuesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblTuesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picTuesdayCancelled.Visible = true;
        }

        private void lblWednesdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblWednesdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picWednesdayCancelled.Visible = true;
        }

        private void lblThursdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblThursdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picThursdayCancelled.Visible = true;
        }

        private void lblFridayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblFridayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picFridayCancelled.Visible = true;
        }

        private void lblSaturdayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSaturdayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picSaturdayCancelled.Visible = true;
        }

        private void lblSundayRecipe_DragDrop(object sender, DragEventArgs e)
        {
            lblSundayRecipe.Text = e.Data.GetData(DataFormats.Text).ToString();
            picSundayCancelled.Visible = true;
        }

        private void lblMondayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lblTuesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblWednesdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblThursdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblFridayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            } 
        }

        private void lblSaturdayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblSundayRecipe_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void lblMondayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(1, lblMondayRecipe.Text);
        }

        private void lblTuesdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(2, lblTuesdayRecipe.Text);
        }

        private void lblWednesdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(3, lblWednesdayRecipe.Text);
        }

        private void lblThursdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(4, lblThursdayRecipe.Text);
        }

        private void lblFridayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(5, lblFridayRecipe.Text);
        }

        private void lblSaturdayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(6, lblSaturdayRecipe.Text);
        }

        private void lblSundayRecipe_TextChanged(object sender, EventArgs e)
        {
            _frmMain.dbConn.UpdatePlannedRecipeForADay(7, lblSundayRecipe.Text);
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


        private void picMondayCancelled_Click(object sender, EventArgs e)
        {
            lblMondayRecipe.Text = "";
            picMondayCancelled.Visible = false;
        }

        private void picTuesdayCancelled_Click(object sender, EventArgs e)
        {
            lblTuesdayRecipe.Text = "";
            picTuesdayCancelled.Visible = false;
        }

        private void picWednesdayCancelled_Click(object sender, EventArgs e)
        {
            lblWednesdayRecipe.Text = "";
            picWednesdayCancelled.Visible = false;
        }

        private void picThursdayCancelled_Click(object sender, EventArgs e)
        {
            lblThursdayRecipe.Text = "";
            picThursdayCancelled.Visible = false;
        }

        private void picFridayCancelled_Click(object sender, EventArgs e)
        {
            lblFridayRecipe.Text = "";
            picFridayCancelled.Visible = false;
        }

        private void picSaturdayCancelled_Click(object sender, EventArgs e)
        {
            lblSaturdayRecipe.Text = "";
            picSaturdayCancelled.Visible = false;
        }

        private void picSundayCancelled_Click(object sender, EventArgs e)
        {
            lblSundayRecipe.Text = "";
            picSundayCancelled.Visible = false;
        }
    }
}
