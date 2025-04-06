/// <file>frmInventory.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>April 6th 2025</date>
/// 
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Recipe_Writer
{
    public partial class frmInventory : Form
    {
        // Declares the parent form to be able to access its controls
        public frmMain _frmMain;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmInventory(frmMain parentMain)
        {
            // Affects the parent form to an alias
            InitializeComponent();
            _frmMain = parentMain;
        }

        // Generic delegate
        private Action<int> fillInListBoxesDelegate;

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInventory_Load(object sender, EventArgs e)
        {
            RefreshInventory();
        }

        private void cmdAddNewIngredientIntoDB_Click(object sender, EventArgs e)
        {
            frmAddNewIngredientToTheDB _frmAddNewIngredientToTheDB = new frmAddNewIngredientToTheDB(_frmMain);
            _frmAddNewIngredientToTheDB.Show();
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
            int iconHeight = 14;
            int numericUpDownHeight = 10;
            int iconWidth = 25;
            int spacingWidth = 8;

            string nameOfPanelToHandle = "pnlIngredientsType" + idTypeOfIngredient + "Status";
            Panel panelToFill = (Panel)this.Controls.Find(nameOfPanelToHandle, true).First();

            // Clears the layout by removing all the labels, before adding new ones
            panelToFill.Controls.Clear();

            foreach (string ingredientName in listBoxToFill.Items)
            {
                int ingredientId = _frmMain.dbConn.ReadIdForAnIngredientName(ingredientName);

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
                int scaleIdForThisIngredient = _frmMain.dbConn.ReadScaleIdForAnIngredient(ingredientId);               
                lblScaleIngredient.Text = _frmMain.dbConn.ReadScaleNameForAnID(scaleIdForThisIngredient);
                lblScaleIngredient.Font = new Font(lblScaleIngredient.Font.FontFamily, 9);
                lblScaleIngredient.AutoSize = true;
                lblScaleIngredient.Location = new Point(nudQtyIngredient.Width + spacingWidth, currentIngredient * (iconHeight + lineHeight));

                // Edit ingredient name button ===================================================================
                Button editIngredientName = new Button();
                editIngredientName.Click += (object sender_here, EventArgs e_here) =>
                {
                    frmEditIngredientName _frmEditIngredientName = new frmEditIngredientName(this);
                    _frmEditIngredientName.IdIngredientToEdit = ingredientId;
                    _frmEditIngredientName.NameOfIngredientToEdit = ingredientName;
                    _frmEditIngredientName.Show(this); // Links to frmInventory form
                };

                editIngredientName.Text = "";
                editIngredientName.Width = iconWidth;
                editIngredientName.Height = iconHeight;
                editIngredientName.BackColor = Color.Transparent;
                editIngredientName.FlatAppearance.BorderSize = 0;
                editIngredientName.FlatStyle = FlatStyle.Flat;
                editIngredientName.BackgroundImage = Recipe_Writer.Properties.Resources.edit;
                editIngredientName.BackgroundImageLayout = ImageLayout.Zoom;
                editIngredientName.Location = new Point(lblScaleIngredient.Width + spacingWidth, currentIngredient * (iconHeight + lineHeight));
                
                // Delete ingredient button code ===================================================================
                Button cmdDeleteIngredient = new Button();
                cmdDeleteIngredient.Click += (object sender_here, EventArgs e_here) =>
                {
                    var confirmResult = MessageBox.Show(strings.ConfirmDeleteIngredientFromDB,
                    strings.ConfirmDeletion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        _frmMain.dbConn.DeleteIngredientFromAllRecipesAndFromDB(ingredientId);
                        RefreshInventory();
                    }
                };

                cmdDeleteIngredient.Text = "";
                cmdDeleteIngredient.Width = iconWidth;
                cmdDeleteIngredient.Height = iconHeight;
                cmdDeleteIngredient.BackColor = Color.Transparent;
                cmdDeleteIngredient.FlatAppearance.BorderSize = 0;
                cmdDeleteIngredient.FlatStyle = FlatStyle.Flat;
                cmdDeleteIngredient.BackgroundImage = Recipe_Writer.Properties.Resources.delete;
                cmdDeleteIngredient.BackgroundImageLayout = ImageLayout.Zoom;
                cmdDeleteIngredient.Location = new Point(editIngredientName.Left + 20, editIngredientName.Top);

                // Adds the controls to the layout ================================================================
                panelToFill.Controls.Add(nudQtyIngredient);
                panelToFill.Controls.Add(lblScaleIngredient);
                panelToFill.Controls.Add(editIngredientName);
                panelToFill.Controls.Add(cmdDeleteIngredient);

                currentIngredient += 1;
            }
        }

        public void RefreshInventory()
        {
            lblNbOfIngredientsStored.Text = strings.NbIngredientsStored;
            lblNbOfIngredientsStored.Text += _frmMain.dbConn.CountAllIngredientsStored().ToString();

            int totalNbOfTypes = _frmMain.dbConn.CountAllTypesOfIngredients();

            fillInListBoxesDelegate = FillInListBoxesWithIngredientsNamesAndQuantities;

            for (int idTypeToHandle = 1; idTypeToHandle <= totalNbOfTypes; idTypeToHandle++)
            {
                fillInListBoxesDelegate(idTypeToHandle);
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
