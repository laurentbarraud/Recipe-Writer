namespace Recipe_Writer
{
    partial class frmAddNewIngredientToTheDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewIngredientToTheDB));
            this.txtNameNewIngredient = new System.Windows.Forms.TextBox();
            this.lblNewIngredientName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbTypesIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.cmbScaleNewIngredient = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNameNewIngredient
            // 
            resources.ApplyResources(this.txtNameNewIngredient, "txtNameNewIngredient");
            this.txtNameNewIngredient.Name = "txtNameNewIngredient";
            // 
            // lblNewIngredientName
            // 
            resources.ApplyResources(this.lblNewIngredientName, "lblNewIngredientName");
            this.lblNewIngredientName.Name = "lblNewIngredientName";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // cmbTypesIngredientsListedInDB
            // 
            resources.ApplyResources(this.cmbTypesIngredientsListedInDB, "cmbTypesIngredientsListedInDB");
            this.cmbTypesIngredientsListedInDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypesIngredientsListedInDB.FormattingEnabled = true;
            this.cmbTypesIngredientsListedInDB.Name = "cmbTypesIngredientsListedInDB";
            // 
            // cmbScaleNewIngredient
            // 
            resources.ApplyResources(this.cmbScaleNewIngredient, "cmbScaleNewIngredient");
            this.cmbScaleNewIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScaleNewIngredient.FormattingEnabled = true;
            this.cmbScaleNewIngredient.Name = "cmbScaleNewIngredient";
            // 
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdValidate
            // 
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // frmAddNewIngredientToTheDB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbScaleNewIngredient);
            this.Controls.Add(this.cmbTypesIngredientsListedInDB);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtNameNewIngredient);
            this.Controls.Add(this.lblNewIngredientName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewIngredientToTheDB";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAddNewIngredientToTheDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameNewIngredient;
        private System.Windows.Forms.Label lblNewIngredientName;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbTypesIngredientsListedInDB;
        private System.Windows.Forms.ComboBox cmbScaleNewIngredient;
    }
}