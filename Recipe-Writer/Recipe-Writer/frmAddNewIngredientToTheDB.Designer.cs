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
            this.txtNewIngredientNameFr = new System.Windows.Forms.TextBox();
            this.lblNewIngredientNameFr = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbTypesIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.cmbScaleNewIngredient = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.txtNewIngredientNameEn = new System.Windows.Forms.TextBox();
            this.lblNewIngredientNameEn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewIngredientNameFr
            // 
            resources.ApplyResources(this.txtNewIngredientNameFr, "txtNewIngredientNameFr");
            this.txtNewIngredientNameFr.Name = "txtNewIngredientNameFr";
    
            // 
            // lblNewIngredientNameFr
            // 
            resources.ApplyResources(this.lblNewIngredientNameFr, "lblNewIngredientNameFr");
            this.lblNewIngredientNameFr.Name = "lblNewIngredientNameFr";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // cmbTypesIngredientsListedInDB
            // 
            this.cmbTypesIngredientsListedInDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypesIngredientsListedInDB.FormattingEnabled = true;
            resources.ApplyResources(this.cmbTypesIngredientsListedInDB, "cmbTypesIngredientsListedInDB");
            this.cmbTypesIngredientsListedInDB.Name = "cmbTypesIngredientsListedInDB";
            // 
            // cmbScaleNewIngredient
            // 
            this.cmbScaleNewIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScaleNewIngredient.FormattingEnabled = true;
            resources.ApplyResources(this.cmbScaleNewIngredient, "cmbScaleNewIngredient");
            this.cmbScaleNewIngredient.Name = "cmbScaleNewIngredient";
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
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // txtNewIngredientNameEn
            // 
            resources.ApplyResources(this.txtNewIngredientNameEn, "txtNewIngredientNameEn");
            this.txtNewIngredientNameEn.Name = "txtNewIngredientNameEn";
        
            // 
            // lblNewIngredientNameEn
            // 
            resources.ApplyResources(this.lblNewIngredientNameEn, "lblNewIngredientNameEn");
            this.lblNewIngredientNameEn.Name = "lblNewIngredientNameEn";
            // 
            // frmAddNewIngredientToTheDB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNewIngredientNameEn);
            this.Controls.Add(this.txtNewIngredientNameEn);
            this.Controls.Add(this.cmbScaleNewIngredient);
            this.Controls.Add(this.cmbTypesIngredientsListedInDB);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtNewIngredientNameFr);
            this.Controls.Add(this.lblNewIngredientNameFr);
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

        private System.Windows.Forms.TextBox txtNewIngredientNameFr;
        private System.Windows.Forms.Label lblNewIngredientNameFr;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbTypesIngredientsListedInDB;
        private System.Windows.Forms.ComboBox cmbScaleNewIngredient;
        private System.Windows.Forms.TextBox txtNewIngredientNameEn;
        private System.Windows.Forms.Label lblNewIngredientNameEn;
    }
}