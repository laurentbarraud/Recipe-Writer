/// <file>frmInventory.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2</version>
/// <date>May 21th 2026</date>
/// 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

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

        /// <summary>
        /// Fills a target panel with ingredient rows (name + qty + scale + edit/delete buttons).
        /// Each row is a horizontal panel aligned manually.
        /// </summary>
        public void FillPanelWithIngredients(Panel targetPanel, int typeId)
        {
            // Clears previous controls
            targetPanel.Controls.Clear();

            // Read all ingredients for this type
            var ingredientsListForTypeId = _frmMain.dbConn.ReadIngredientsForType(typeId);

            int posY = 0;
            int rowHeight = 32;

            foreach (var ingredient in ingredientsListForTypeId)
            {
                // Creates row panel
                Panel pnlRow = new Panel();
                pnlRow.Left = 0;
                pnlRow.Top = posY;
                pnlRow.Width = targetPanel.Width - 20;
                pnlRow.Height = rowHeight;

                // Ingredient name label
                Label lblIngredientName = new Label();
                lblIngredientName.Text = ingredient.Name;
                lblIngredientName.Left = 0;
                lblIngredientName.Top = 6;
                lblIngredientName.Width = 170;

                // Quantity numeric up-down
                NumericUpDown nudIngredientQty = new NumericUpDown();
                nudIngredientQty.Left = 180;
                nudIngredientQty.Top = 4;
                nudIngredientQty.Width = 50;
                nudIngredientQty.Maximum = 10000;
                nudIngredientQty.Value = (decimal)ingredient.Qty;
                nudIngredientQty.ValueChanged += (s, e) =>
                {
                    _frmMain.dbConn.UpdateQtyIngredientAvailable(ingredient.Id, (double)nudIngredientQty.Value);
                };

                // Scale label
                Label lblScale = new Label();
                lblScale.Text = ingredient.Scale;
                lblScale.TextAlign = ContentAlignment.MiddleLeft;
                lblScale.Left = 234;
                lblScale.Top = 6;
                lblScale.Width = 35;

                // Edit button
                Button btnEdit = new Button();
                btnEdit.Left = 270;
                btnEdit.Top = 4;
                btnEdit.Width = 22;
                btnEdit.Height = 22;
                btnEdit.Cursor = Cursors.Hand;
                btnEdit.FlatStyle = FlatStyle.Flat;
                btnEdit.FlatAppearance.BorderSize = 0;
                btnEdit.BackgroundImage = Recipe_Writer.Properties.Resources.edit;
                btnEdit.BackgroundImageLayout = ImageLayout.Zoom;

                // Delete button
                Button btnDelete = new Button();
                btnDelete.Left = 295;
                btnDelete.Top = 4;
                btnDelete.Width = 22;
                btnDelete.Height = 22;
                btnDelete.Cursor = Cursors.Hand;
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.BackgroundImage = Recipe_Writer.Properties.Resources.delete;
                btnDelete.BackgroundImageLayout = ImageLayout.Zoom;

                btnEdit.Click += (s, e) =>
                {
                    var formEditIngredientName = new frmEditIngredientName(this, ingredient.Id);
                    formEditIngredientName.Show();
                };

                btnDelete.Click += (s, e) =>
                {
                    if (MessageBox.Show(strings.ConfirmDeleteIngredientFromDB, strings.ConfirmDeletion, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _frmMain.dbConn.DeleteIngredientFromAllRecipesAndFromDB(ingredient.Id);
                        RefreshInventory();
                    }
                };

                // Adds controls to row
                pnlRow.Controls.Add(lblIngredientName);
                pnlRow.Controls.Add(nudIngredientQty);
                pnlRow.Controls.Add(lblScale);
                pnlRow.Controls.Add(btnEdit);
                pnlRow.Controls.Add(btnDelete);

                // Adds row to panel
                targetPanel.Controls.Add(pnlRow);

                posY += rowHeight + 4;
            }
        }

        /// <summary>
        /// Refreshes the inventory by loading all ingredient types and filling their panels.
        /// </summary>
        public void RefreshInventory()
        {
            lblNbOfIngredientsStored.Text += " " + _frmMain.dbConn.CountAllIngredientsStored().ToString();

            int totalTypes = _frmMain.dbConn.CountAllTypesOfIngredients();

            for (int typeId = 1; typeId <= totalTypes; typeId++)
            {
                // Finds the panel for this type
                string panelName = "pnlIngredientsType" + typeId;
                Panel pnlControl = this.Controls.Find(panelName, true).FirstOrDefault() as Panel;

                if (pnlControl != null)
                {
                    FillPanelWithIngredients(pnlControl, typeId);
                }
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
