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
    public partial class frmInventory : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmInventory(frmMain parentForm)
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
        private void frmInventory_Load(object sender, EventArgs e)
        {
            int currentIngredient = 0;

            // Clears the ingredients list before adding new ones
            lstIngredientsAvailable.Items.Clear();

            foreach (string ingredientName in _frmMain.dbConn.ReadAllIngredientsStored())
            {
                lstIngredientsAvailable.Items.Add(ingredientName);
            }

            // Layout parameters =================================================================================
            int lineHeight = 5;
            int iconHeight = 12;
            int numericUpDownHeight = 10;
            int iconWidth = 25;
            int spacingWidth = 15;

            // Clears the layout by removing all the labels, before adding new ones
            pnlIngredientsStatus.Controls.Clear();

            foreach (string ingredientItem in lstIngredientsAvailable.Items)
            {
                // Picturebox that displays the status of the ingredient
                PictureBox picStatusIngredient = new PictureBox();

                // Shows a border around a picture box when the mouse hovers it
                picStatusIngredient.MouseHover += (object sender_here, EventArgs e_here) =>
                {
                    picStatusIngredient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                };

                // Hides the border around a picture box when the mouse leaves it
                picStatusIngredient.MouseLeave += (object sender_here, EventArgs e_here) =>
                {
                    picStatusIngredient.BorderStyle = System.Windows.Forms.BorderStyle.None;
                };

                // Edit quantity numeric up-down control ==============================================================================================

                NumericUpDown nudQtyIngredient = new NumericUpDown();
                nudQtyIngredient.ValueChanged += (object sender_here, EventArgs e_here) =>
                {
                        // To-Do : writes the function that change the ingredient quantity available according to the
                        // numeric up-down control value                  
                    };

                // Delete ingredient button code ================================================================================================

                Button cmdDeleteIngredient = new Button();
                cmdDeleteIngredient.Click += (object sender_here, EventArgs e_here) =>
                {
                    var confirmResult = MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer l'ingrédient de la base ?",
                    "Confirmer la suppression.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                            // To-Do : call the function that will delete the ingredient from the database

                            this.Refresh();
                    }
                };

                // Detailed layout =========================================================================================
                // Edit button for an instruction ==========================================================================
                nudQtyIngredient.Value = 0;
                nudQtyIngredient.Font = new Font(nudQtyIngredient.Font.FontFamily, 8);
                nudQtyIngredient.Width = 2 * (iconWidth);
                nudQtyIngredient.Height = numericUpDownHeight;
                nudQtyIngredient.Location = new Point(spacingWidth, currentIngredient*(iconHeight + lineHeight));
                nudQtyIngredient.BorderStyle = BorderStyle.FixedSingle;

                // Delete button for an instruction, detailed layout ========================================================
                cmdDeleteIngredient.Text = "";
                cmdDeleteIngredient.Width = iconWidth;
                cmdDeleteIngredient.Height = iconHeight;
                cmdDeleteIngredient.Location = new Point(nudQtyIngredient.Width + spacingWidth, currentIngredient*(iconHeight + lineHeight));
                cmdDeleteIngredient.BackColor = Color.Transparent;
                cmdDeleteIngredient.FlatAppearance.BorderSize = 0;
                cmdDeleteIngredient.FlatStyle = FlatStyle.Flat;
                cmdDeleteIngredient.BackgroundImage = Recipe_Writer.Properties.Resources.delete;
                cmdDeleteIngredient.BackgroundImageLayout = ImageLayout.Zoom;

                // Adds the controls to the layout ============================================================================================
                pnlIngredientsStatus.Controls.Add(nudQtyIngredient);
                pnlIngredientsStatus.Controls.Add(cmdDeleteIngredient);

                currentIngredient += 1;
            }
        }
    

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmInventory_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
