namespace Recipe_Writer
{
    partial class frmAddNewIngredientToRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewIngredientToRecipe));
            this.lblNewIngredientName = new System.Windows.Forms.Label();
            this.lblQtyIngredient = new System.Windows.Forms.Label();
            this.txtQtyIngredientNeeded = new System.Windows.Forms.TextBox();
            this.cmbIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.lblScaleAssociatedWithIngredientSelected = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewIngredientName
            // 
            resources.ApplyResources(this.lblNewIngredientName, "lblNewIngredientName");
            this.lblNewIngredientName.Name = "lblNewIngredientName";
            // 
            // lblQtyIngredient
            // 
            resources.ApplyResources(this.lblQtyIngredient, "lblQtyIngredient");
            this.lblQtyIngredient.Name = "lblQtyIngredient";
            // 
            // txtQtyIngredientNeeded
            // 
            resources.ApplyResources(this.txtQtyIngredientNeeded, "txtQtyIngredientNeeded");
            this.txtQtyIngredientNeeded.Name = "txtQtyIngredientNeeded";
            // 
            // cmbIngredientsListedInDB
            // 
            this.cmbIngredientsListedInDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngredientsListedInDB.FormattingEnabled = true;
            resources.ApplyResources(this.cmbIngredientsListedInDB, "cmbIngredientsListedInDB");
            this.cmbIngredientsListedInDB.Name = "cmbIngredientsListedInDB";
            this.cmbIngredientsListedInDB.SelectedIndexChanged += new System.EventHandler(this.cmbIngredientsList_SelectedIndexChanged);
            // 
            // lblScaleAssociatedWithIngredientSelected
            // 
            resources.ApplyResources(this.lblScaleAssociatedWithIngredientSelected, "lblScaleAssociatedWithIngredientSelected");
            this.lblScaleAssociatedWithIngredientSelected.Name = "lblScaleAssociatedWithIngredientSelected";
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmAddNewIngredientToRecipe
            // 
            this.AcceptButton = this.cmdValidate;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cmdCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblScaleAssociatedWithIngredientSelected);
            this.Controls.Add(this.cmbIngredientsListedInDB);
            this.Controls.Add(this.txtQtyIngredientNeeded);
            this.Controls.Add(this.lblQtyIngredient);
            this.Controls.Add(this.lblNewIngredientName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewIngredientToRecipe";
            this.Load += new System.EventHandler(this.frmNewIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewIngredientName;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblQtyIngredient;
        private System.Windows.Forms.TextBox txtQtyIngredientNeeded;
        private System.Windows.Forms.ComboBox cmbIngredientsListedInDB;
        private System.Windows.Forms.Label lblScaleAssociatedWithIngredientSelected;
    }
}