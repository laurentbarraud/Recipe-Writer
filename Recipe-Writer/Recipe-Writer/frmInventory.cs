/// <file>frmInventory.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 20th 2025</date>
/// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        delegate void FillInListBoxesDelegate(int idTypeOfIngredient);

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInventory_Load(object sender, EventArgs e)
        {
            lblNbOfIngredientsStored.Text += _frmMain.dbConn.CountAllIngredientsStored().ToString();

            int totalNbOfTypes = _frmMain.dbConn.CountAllTypesOfIngredients();

            // Instantiates the delegate
            FillInListBoxesDelegate fillInListBoxesDelegate = new FillInListBoxesDelegate(FillInListBoxesWithIngredientsNamesAndQuantities);

            for (int idTypeToHandle = 1; idTypeToHandle <= totalNbOfTypes; idTypeToHandle++)
            {
                fillInListBoxesDelegate(idTypeToHandle);
            }
        }

        private void FillInListBoxesWithIngredientsNamesAndQuantities (int idTypeOfIngredient)
        {
            int currentIngredient = 0;

            string nameOfListBoxToHandle = "lstIngredientsType" + idTypeOfIngredient + "Available";
            ListBox listBoxToFill = (ListBox)this.Controls.Find(nameOfListBoxToHandle, true).First();

            // Clears the ingredients list before adding new ones
            listBoxToFill.Items.Clear();


            // Adds each ingredient name in the listbox control
            foreach (string ingredientName in _frmMain.dbConn.ReadAllIngredientsStoredForAType(idTypeOfIngredient))
            {
                listBoxToFill.Items.Add(ingredientName);
            }

            // Layout parameters =================================================================================
            int lineHeight = 5;
            int iconHeight = 12;
            int numericUpDownHeight = 10;
            int iconWidth = 25;
            int spacingWidth = 15;

            string nameOfPanelToHandle = "pnlIngredientsType" + idTypeOfIngredient + "Status";
            Panel panelToFill = (Panel)this.Controls.Find(nameOfPanelToHandle, true).First();

            // Clears the layout by removing all the labels, before adding new ones
            panelToFill.Controls.Clear();

            foreach (string ingredientItem in listBoxToFill.Items)
            {
                int ingredientId = _frmMain.dbConn.ReadIngredientId(ingredientItem);

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

                // Edit quantity numeric up-down control ===========================================================

                NumericUpDown nudQtyIngredient = new NumericUpDown();
                nudQtyIngredient.ValueChanged += (object sender_here, EventArgs e_here) =>
                {
                    _frmMain.dbConn.UpdateQtyIngredientAvailable(ingredientId, Convert.ToDouble(nudQtyIngredient.Value));
                };

                nudQtyIngredient.Value = 0;
                nudQtyIngredient.Maximum = 10000;
                nudQtyIngredient.Font = new Font(nudQtyIngredient.Font.FontFamily, 9);
                nudQtyIngredient.Width = 2 * (iconWidth);
                nudQtyIngredient.Height = numericUpDownHeight;
                nudQtyIngredient.Location = new Point(spacingWidth, currentIngredient * (iconHeight + lineHeight));
                nudQtyIngredient.BorderStyle = BorderStyle.FixedSingle;

                // Adds the ingredient quantity in the appropriate numeric up-down control
                nudQtyIngredient.Value = decimal.Parse(_frmMain.dbConn.ReadQtyAvailableForAnIngredient(ingredientId).ToString());

                // Label with the scale (unit of measure) used ===========================================================

                Label lblScaleIngredient = new Label();
                lblScaleIngredient.Text = _frmMain.dbConn.ReadIngredientScale(ingredientId);
                lblScaleIngredient.Font = new Font(lblScaleIngredient.Font.FontFamily, 9);
                lblScaleIngredient.AutoSize = true;
                lblScaleIngredient.Location = new Point(nudQtyIngredient.Width + spacingWidth, currentIngredient * (iconHeight + lineHeight));

                // Delete ingredient button code ===================================================================

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

                cmdDeleteIngredient.Text = "";
                cmdDeleteIngredient.Width = iconWidth;
                cmdDeleteIngredient.Height = iconHeight;
                cmdDeleteIngredient.Location = new Point(lblScaleIngredient.Width + spacingWidth, currentIngredient * (iconHeight + lineHeight));
                cmdDeleteIngredient.BackColor = Color.Transparent;
                cmdDeleteIngredient.FlatAppearance.BorderSize = 0;
                cmdDeleteIngredient.FlatStyle = FlatStyle.Flat;
                cmdDeleteIngredient.BackgroundImage = Recipe_Writer.Properties.Resources.delete;
                cmdDeleteIngredient.BackgroundImageLayout = ImageLayout.Zoom;

                // Adds the controls to the layout ================================================================
                panelToFill.Controls.Add(nudQtyIngredient);
                panelToFill.Controls.Add(lblScaleIngredient);
                panelToFill.Controls.Add(cmdDeleteIngredient);

                currentIngredient += 1;
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmMain.InventoryShown = false;
        }
    }
}
