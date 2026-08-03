/// <file>frmEditIngredientName.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.2.1</version>
/// <date>August, 4th 2026</date>

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmEditIngredientName : Form
    {
        // Private members

        // Declares the main form to be able to access its controls
        private frmMain _frmMain = null;

        // Declares the parent form to be able to access its controls
        private frmInventory _frmInventory = null;

        private int idIngredientToEdit;

        // Public properties

        public int IdIngredientToEdit
        {
            get { return idIngredientToEdit; }
            set { idIngredientToEdit = value; }
        }

        public frmEditIngredientName(frmInventory parentInventory, int ingredientId)
        {
            InitializeComponent();
            _frmInventory = parentInventory;
            _frmMain = _frmInventory._frmMain;

            IdIngredientToEdit = ingredientId;

            // Register buttons in the global dictionary for hover effect
            UIHoverHelper.ButtonBaseResourceNames[cmdValidate] = "validate";
            UIHoverHelper.ButtonBaseResourceNames[cmdDelete] = "delete";

            // Buttons hover event
            cmdDelete.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdDelete.MouseLeave += UIHoverHelper.Button_MouseLeave;
            cmdValidate.MouseEnter += UIHoverHelper.Button_MouseEnter;
            cmdValidate.MouseLeave += UIHoverHelper.Button_MouseLeave;

            // Window title
            string windowTitle = strings.EditIngredientName;

            if (!string.IsNullOrEmpty(windowTitle))
            {
                this.Text = windowTitle;
            }

            // Localized labels
            lblIngredientNameFr.Text = strings.NewIngredientNameFr;
            lblIngredientNameEn.Text = strings.NewIngredientNameEn;
            lblIngredientNameEs.Text = strings.NewIngredientNameEs;
            lblTypeIngredient.Text = strings.TypeIngredient;

            // Loads dropdowns (types + scales)
            LoadTypesAndScales();

            // Selects the current type and scale for this ingredient
            int readTypeId = _frmMain.dbConn.ReadTypeIdForIngredient(IdIngredientToEdit);
            int readScaleId = _frmMain.dbConn.ReadScaleIdForAnIngredient(IdIngredientToEdit);

            if (readTypeId > 0 && readTypeId <= cmbTypesIngredientsListedInDB.Items.Count)
            {
                cmbTypesIngredientsListedInDB.SelectedIndex = readTypeId - 1;
            }

            if (readTypeId > 0 && readTypeId <= cmbScaleIngredient.Items.Count)
            {
                cmbScaleIngredient.SelectedIndex = readScaleId - 1;
            }

            // Loads names (FR/EN/ES) and auto-fills missing ones
            string[] languageCodes = { "fr", "en", "es" };
            TextBox[] textBoxesIngredientNamesArray = { txtIngredientNameFr, txtIngredientNameEn, txtIngredientNameEs };

            // Reads names for each language
            for (int i = 0; i < languageCodes.Length; i++)
            {
                string languageCode = languageCodes[i];
                string nameFromDb = _frmMain.dbConn.ReadNameForAnIngredientId(IdIngredientToEdit, languageCode);

                textBoxesIngredientNamesArray[i].Text = nameFromDb;
            }

            // Auto-fills missing fields using available names
            for (int i = 0; i < textBoxesIngredientNamesArray.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(textBoxesIngredientNamesArray[i].Text))
                {
                    // Tries to copy from another language
                    for (int j = 0; j < textBoxesIngredientNamesArray.Length; j++)
                    {
                        if (i != j && !string.IsNullOrWhiteSpace(textBoxesIngredientNamesArray[j].Text))
                        {
                            textBoxesIngredientNamesArray[i].Text = textBoxesIngredientNamesArray[j].Text;
                            break;
                        }
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validates the edited ingredient fields (FR/EN/ES + type + scale),
        /// updates the ingredient in the database, and refreshes the inventory.
        /// </summary>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            // Reads user input
            string ingredientNameFr = txtIngredientNameFr.Text.Trim();
            string ingredientNameEn = txtIngredientNameEn.Text.Trim();
            string ingredientNameEs = txtIngredientNameEs.Text.Trim();

            // Escapes apostrophes
            ingredientNameFr = ingredientNameFr.Replace("'", "''");
            ingredientNameEn = ingredientNameEn.Replace("'", "''");
            ingredientNameEs = ingredientNameEs.Replace("'", "''");

            // Rejects if all fields are empty
            if (string.IsNullOrWhiteSpace(ingredientNameFr) &&
                string.IsNullOrWhiteSpace(ingredientNameEn) &&
                string.IsNullOrWhiteSpace(ingredientNameEs))
            {
                MessageBox.Show(strings.ErrorEmptyFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Auto-fills missing fields using available names, so that each ingredient
            // always has a valid name in all three languages.
            // This prevents the ingredient from appearing “empty” in lists or recipes
            // and ensures that it remains identifiable regardless of the active UI language.
            if (string.IsNullOrWhiteSpace(ingredientNameFr))
            {
                ingredientNameFr = !string.IsNullOrWhiteSpace(ingredientNameEn) ? ingredientNameEn : ingredientNameEs;
            }

            if (string.IsNullOrWhiteSpace(ingredientNameEn))
            {
                ingredientNameEn = !string.IsNullOrWhiteSpace(ingredientNameFr) ? ingredientNameFr : ingredientNameEs;
            }

            if (string.IsNullOrWhiteSpace(ingredientNameEs))
            {
                ingredientNameEs = !string.IsNullOrWhiteSpace(ingredientNameFr) ? ingredientNameFr : ingredientNameEn;
            }

            // Validates dropdowns
            if (cmbTypesIngredientsListedInDB.SelectedIndex == -1 ||
                cmbScaleIngredient.SelectedIndex == -1)
            {
                MessageBox.Show(strings.ErrorEmptyFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedTypeId = cmbTypesIngredientsListedInDB.SelectedIndex + 1;
            int selectedScaleId = cmbScaleIngredient.SelectedIndex + 1;

            try
            {
                // Updates the ingredient in the database
                _frmMain.dbConn.UpdateIngredientFull(IdIngredientToEdit, ingredientNameFr, ingredientNameEn,
                    ingredientNameEs, selectedTypeId, selectedScaleId);

                // Refreshes inventory and closes window
                _frmInventory.RefreshInventory();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(strings.ErrorIngredientInsert, ex.Message),
                    strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Loads ingredient types and scales into their ComboBoxes
        /// and selects the current values for the ingredient.
        /// </summary>
        private void LoadTypesAndScales()
        {
            // Determines active language with fallback to English
            string appLanguageCode = Properties.Settings.Default.AppLanguageCode.ToLower();
            if (appLanguageCode != "fr" && appLanguageCode != "en" && appLanguageCode != "es")
            {
                appLanguageCode = "en";
            }

            // Loads types
            List<string> allTypes = _frmMain.dbConn.ReadAllTypesOfIngredientsStored(appLanguageCode);
            cmbTypesIngredientsListedInDB.Items.Clear();
            cmbTypesIngredientsListedInDB.Items.AddRange(allTypes.ToArray());

            // Reads the current type id for this ingredient from the database
            int currentTypeId = _frmMain.dbConn.ReadTypeIdForIngredient(IdIngredientToEdit);

            if (currentTypeId > 0 && currentTypeId <= allTypes.Count)
            {
                cmbTypesIngredientsListedInDB.SelectedIndex = currentTypeId - 1;
            }

            // Loads scales
            List<string> listStoredScalesInDB = _frmMain.dbConn.ReadAllScalesStored(appLanguageCode);
            cmbScaleIngredient.Items.Clear();
            cmbScaleIngredient.Items.AddRange(listStoredScalesInDB.ToArray());

            // Reads the scale id for the ingredient being edited
            int currentScaleId = _frmMain.dbConn.ReadScaleIdForAnIngredient(IdIngredientToEdit);

            // Selects the correct scale in the ComboBox
            if (currentScaleId > 0 && currentScaleId <= listStoredScalesInDB.Count)
            {
                cmbScaleIngredient.SelectedIndex = currentScaleId - 1;
            }
        }
    }
}
