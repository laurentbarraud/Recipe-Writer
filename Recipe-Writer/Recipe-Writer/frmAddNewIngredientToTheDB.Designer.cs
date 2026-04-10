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
            this.txtNewIngredientNameFr = new System.Windows.Forms.TextBox();
            this.lblNewIngredientNameFr = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbTypesIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.cmbScaleNewIngredient = new System.Windows.Forms.ComboBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.txtNewIngredientNameEn = new System.Windows.Forms.TextBox();
            this.lblNewIngredientNameEn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewIngredientNameFr
            // 
            this.txtNewIngredientNameFr.Location = new System.Drawing.Point(206, 41);
            this.txtNewIngredientNameFr.Name = "txtNewIngredientNameFr";
            this.txtNewIngredientNameFr.Size = new System.Drawing.Size(192, 22);
            this.txtNewIngredientNameFr.TabIndex = 6;
            // 
            // lblNewIngredientNameFr
            // 
            this.lblNewIngredientNameFr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNewIngredientNameFr.Location = new System.Drawing.Point(12, 42);
            this.lblNewIngredientNameFr.Name = "lblNewIngredientNameFr";
            this.lblNewIngredientNameFr.Size = new System.Drawing.Size(188, 21);
            this.lblNewIngredientNameFr.TabIndex = 9;
            this.lblNewIngredientNameFr.Text = "Nom de l\'ingrédient (Fr) ";
            this.lblNewIngredientNameFr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblType.Location = new System.Drawing.Point(32, 105);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(146, 18);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Type : ";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTypesIngredientsListedInDB
            // 
            this.cmbTypesIngredientsListedInDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypesIngredientsListedInDB.FormattingEnabled = true;
            this.cmbTypesIngredientsListedInDB.Location = new System.Drawing.Point(206, 104);
            this.cmbTypesIngredientsListedInDB.Name = "cmbTypesIngredientsListedInDB";
            this.cmbTypesIngredientsListedInDB.Size = new System.Drawing.Size(317, 24);
            this.cmbTypesIngredientsListedInDB.TabIndex = 11;
            // 
            // cmbScaleNewIngredient
            // 
            this.cmbScaleNewIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScaleNewIngredient.FormattingEnabled = true;
            this.cmbScaleNewIngredient.Location = new System.Drawing.Point(416, 50);
            this.cmbScaleNewIngredient.Name = "cmbScaleNewIngredient";
            this.cmbScaleNewIngredient.Size = new System.Drawing.Size(107, 24);
            this.cmbScaleNewIngredient.TabIndex = 12;
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Location = new System.Drawing.Point(423, 154);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(40, 32);
            this.cmdDelete.TabIndex = 7;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(478, 154);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(40, 32);
            this.cmdValidate.TabIndex = 8;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // txtNewIngredientNameEn
            // 
            this.txtNewIngredientNameEn.Location = new System.Drawing.Point(206, 64);
            this.txtNewIngredientNameEn.Name = "txtNewIngredientNameEn";
            this.txtNewIngredientNameEn.Size = new System.Drawing.Size(192, 22);
            this.txtNewIngredientNameEn.TabIndex = 13;
            // 
            // lblNewIngredientNameEn
            // 
            this.lblNewIngredientNameEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNewIngredientNameEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNewIngredientNameEn.Location = new System.Drawing.Point(12, 66);
            this.lblNewIngredientNameEn.Name = "lblNewIngredientNameEn";
            this.lblNewIngredientNameEn.Size = new System.Drawing.Size(188, 21);
            this.lblNewIngredientNameEn.TabIndex = 14;
            this.lblNewIngredientNameEn.Text = "Nom de l\'ingrédient (En) ";
            this.lblNewIngredientNameEn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAddNewIngredientToTheDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(592, 200);
            this.Controls.Add(this.lblNewIngredientNameEn);
            this.Controls.Add(this.txtNewIngredientNameEn);
            this.Controls.Add(this.cmbScaleNewIngredient);
            this.Controls.Add(this.cmbTypesIngredientsListedInDB);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtNewIngredientNameFr);
            this.Controls.Add(this.lblNewIngredientNameFr);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewIngredientToTheDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajout d\'un nouvel ingrédient à la base";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAddNewIngredientToTheDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewIngredientNameFr;
        private System.Windows.Forms.Label lblNewIngredientNameFr;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbTypesIngredientsListedInDB;
        private System.Windows.Forms.ComboBox cmbScaleNewIngredient;
        private System.Windows.Forms.TextBox txtNewIngredientNameEn;
        private System.Windows.Forms.Label lblNewIngredientNameEn;
    }
}