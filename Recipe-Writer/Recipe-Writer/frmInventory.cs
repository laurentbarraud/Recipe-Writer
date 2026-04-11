/// <file>frmInventory.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 12th 2026</date>
/// 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmInventory : Form
    {
        // Declares the parent form to be able to access its controls
        public frmMain _frmMain;

        // Dynamic delegate to update ingredient lists with localization support
        private Action<int> fillInListBoxesDelegate;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmInventory(frmMain parentMain)
        {
            // Affects the parent form to an alias
            InitializeComponent();
            _frmMain = parentMain;

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdAddNewIngredientIntoDB] = "add_new_ingredient_into_db";
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";

            // Buttons hover event
            cmdAddNewIngredientIntoDB.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdAddNewIngredientIntoDB.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Title
            string windowTitle = strings.Inventory;

            if (!string.IsNullOrEmpty(windowTitle))
            {
                this.Text = windowTitle;
            }

            // Labels
            lblTypeIngredient1.Text = strings.lblTypeIngredient1;
            lblTypeIngredient2.Text = strings.lblTypeIngredient2;
            lblTypeIngredient3.Text = strings.lblTypeIngredient3;
            lblTypeIngredient4.Text = strings.lblTypeIngredient4;
            lblTypeIngredient11.Text = strings.lblTypeIngredient11;
            lblTypeIngredient12.Text = strings.lblTypeIngredient12;
            lblNbOfIngredientsStored.Text = strings.NbOfIngredientsStored;
        }

        /// <summary>
        /// Handles the load event of the form.
        /// Localizes the window title and the tab headers using resource keys TabInventory_0..8
        /// from strings.resx, then refreshes the inventory quantities.
        /// </summary>
        private void frmInventory_Load(object sender, EventArgs e)
        {
            var cultureInfoCode = new System.Globalization.CultureInfo(Properties.Settings.Default.AppLanguageCode);

            // Tabs
            foreach (TabControl tabControl in this.Controls.OfType<TabControl>())
            {
                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    var tabPageSelected = tabControl.TabPages[i];
                    string resourceKeyComposed = $"TabInventory_{i}";

                    
                    string localized = strings.ResourceManager.GetString(resourceKeyComposed, cultureInfoCode);

                    if (!string.IsNullOrEmpty(localized)) 
                    { 
                        tabPageSelected.Text = localized;
                    }

                    foreach (Control child in tabPageSelected.Controls)
                    {
                        ApplyResourcesRecursively(child, new ComponentResourceManager(typeof(frmInventory)), cultureInfoCode);
                    }
                }
            }

            RefreshInventory();
        }

        /// <summary>
        /// Recursively applies localized resources to a control and its children.
        /// Handles common containers (Panel, GroupBox, TableLayoutPanel, etc.),
        /// as well as MenuStrip, ToolStrip, and StatusStrip items.
        /// </summary>
        private void ApplyResourcesRecursively(Control control, ComponentResourceManager resources, System.Globalization.CultureInfo cultureInfo)
        {
            if (control == null) return;

            // Applies resources to the control itself
            resources.ApplyResources(control, control.Name, cultureInfo);

            // Handles MenuStrip: applies resources to menu items recursively
            if (control is MenuStrip menuStrip)
            {
                foreach (ToolStripMenuItem item in menuStrip.Items.OfType<ToolStripMenuItem>())
                {
                    ApplyToolStripItemResources(item, resources, cultureInfo);
                }
            }

            // Handles ToolStrip : applies resources to each item
            else if (control is ToolStrip toolStrip)
            {
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    resources.ApplyResources(item, item.Name, cultureInfo);

                    // If the item is a drop-down, applies resources to its children as well
                    if (item is ToolStripDropDownItem dropDown)
                    {
                        foreach (ToolStripItem subItem in dropDown.DropDownItems)
                        {
                            resources.ApplyResources(subItem, subItem.Name, cultureInfo);
                        }
                    }
                }
            }
            // Handles StatusStrip: apploes resources to each status label/panel
            else if (control is StatusStrip statusStrip)
            {
                foreach (ToolStripItem item in statusStrip.Items)
                {
                    resources.ApplyResources(item, item.Name, cultureInfo);
                }
            }

            // Applies resources to child controls 
            foreach (Control child in control.Controls)
            {
                ApplyResourcesRecursively(child, resources, cultureInfo);
            }
        }

        /// <summary>
        /// Applies resources to a ToolStripMenuItem and its child menu items recursively.
        /// </summary>
        private void ApplyToolStripItemResources(ToolStripMenuItem item, ComponentResourceManager resources, System.Globalization.CultureInfo cultureInfo)
        {
            if (item == null) return;

            // Applies resources to this menu item
            resources.ApplyResources(item, item.Name, cultureInfo);

            // Recursively applies to nested menu items
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                resources.ApplyResources(subItem, subItem.Name, cultureInfo);

                // If nested item is also a drop-down menu, goes deeper
                if (subItem is ToolStripMenuItem subMenu)
                {
                    ApplyToolStripItemResources(subMenu, resources, cultureInfo);
                }
            }
        }

        private void cmdAddNewIngredientIntoDB_Click(object sender, EventArgs e)
        {
            frmAddNewIngredientToTheDB _frmAddNewIngredientToTheDB = new frmAddNewIngredientToTheDB(_frmMain);
            _frmAddNewIngredientToTheDB.Show();
        }

        private void FillInListBoxesWithIngredientsNamesAndQuantities(int idTypeOfIngredient)
        {
            int currentIngredient = 0;

            // Tries to find the ListBox
            ListBox listBoxToFill = null;

            try
            {
                string listBoxName = "lstIngredientsType" + idTypeOfIngredient;
                listBoxToFill = (ListBox)this.Controls.Find(listBoxName, true).First();
            }
            catch
            {
                // If the ListBox does not exist, does nothing
                return;
            }

            listBoxToFill.Items.Clear();

            // Adds ingredient names to the ListBox
            foreach (string ingredientName in _frmMain.dbConn.ReadAllIngredientsStoredForAType(idTypeOfIngredient))
            {
                listBoxToFill.Items.Add(ingredientName);
            }

            // Tries to find the Panel
            Panel panelToFill = null;

            try
            {
                string panelName = "pnlIngredientsType" + idTypeOfIngredient;
                panelToFill = (Panel)this.Controls.Find(panelName, true).First();
            }
            catch
            {
                // If the Panel does not exist, do nothing
                return;
            }

            // Clears the panel before adding new controls
            panelToFill.Controls.Clear();

            // Layout parameters
            int lineHeight = 5;
            int iconHeight = 14;
            int numericUpDownHeight = 10;
            int iconWidth = 25;
            int spacingWidth = 8;

            // Generates dynamic controls
            foreach (string ingredientName in listBoxToFill.Items)
            {
                int ingredientId = _frmMain.dbConn.ReadIdForAnIngredientName(ingredientName);

                // Quantity numeric up-down
                NumericUpDown nudQtyIngredient = new NumericUpDown();
                nudQtyIngredient.ValueChanged += (object sender_here, EventArgs e_here) =>
                {
                    _frmMain.dbConn.UpdateQtyIngredientAvailable(ingredientId, Convert.ToDouble(nudQtyIngredient.Value));
                };

                nudQtyIngredient.Value = 0;
                nudQtyIngredient.Maximum = 10000;
                nudQtyIngredient.Font = new Font(nudQtyIngredient.Font.FontFamily, 9);
                nudQtyIngredient.Width = 2 * iconWidth;
                nudQtyIngredient.Height = numericUpDownHeight;
                nudQtyIngredient.Location = new Point(0, currentIngredient * (iconHeight + lineHeight));
                nudQtyIngredient.BorderStyle = BorderStyle.FixedSingle;

                nudQtyIngredient.Value = decimal.Parse(_frmMain.dbConn.ReadQtyAvailableForAnIngredient(ingredientId).ToString());

                // Scale label
                Label lblScaleIngredient = new Label();
                int scaleId = _frmMain.dbConn.ReadScaleIdForAnIngredient(ingredientId);
                lblScaleIngredient.Text = _frmMain.dbConn.ReadScaleNameForAnID(scaleId);
                lblScaleIngredient.Font = new Font(lblScaleIngredient.Font.FontFamily, 9);
                lblScaleIngredient.AutoSize = true;
                lblScaleIngredient.Location = new Point(nudQtyIngredient.Width + spacingWidth, currentIngredient * (iconHeight + lineHeight));

                // Edit ingredient name button
                Button editIngredientName = new Button();
                editIngredientName.Click += (object sender_here, EventArgs e_here) =>
                {
                    frmEditIngredientName editForm = new frmEditIngredientName(this);
                    editForm.IdIngredientToEdit = ingredientId;
                    editForm.NameOfIngredientToEdit = ingredientName;
                    editForm.Show(this);
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

                // Delete ingredient button
                Button cmdDeleteIngredient = new Button();
                cmdDeleteIngredient.Click += (object sender_here, EventArgs e_here) =>
                {
                    var confirm = MessageBox.Show(strings.ConfirmDeleteIngredientFromDB,
                                                  strings.ConfirmDeletion,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
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
                cmdDeleteIngredient.Cursor = Cursors.Hand;

                // Adds controls to the panel
                panelToFill.Controls.Add(nudQtyIngredient);
                panelToFill.Controls.Add(lblScaleIngredient);
                panelToFill.Controls.Add(editIngredientName);
                panelToFill.Controls.Add(cmdDeleteIngredient);

                currentIngredient += 1;
            }
        }

        public void RefreshInventory()
        {
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
