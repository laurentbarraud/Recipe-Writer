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
            this.lblTypeIngredient = new System.Windows.Forms.Label();
            this.cmbTypesIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.cmbScaleNewIngredient = new System.Windows.Forms.ComboBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.txtNewIngredientNameEn = new System.Windows.Forms.TextBox();
            this.lblNewIngredientNameEn = new System.Windows.Forms.Label();
            this.lblNewIngredientNameEs = new System.Windows.Forms.Label();
            this.txtNewIngredientNameEs = new System.Windows.Forms.TextBox();
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
            this.lblNewIngredientNameFr.Text = "Nom de l\'ingrédient (Fr) : ";
            this.lblNewIngredientNameFr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTypeIngredient
            // 
            this.lblTypeIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTypeIngredient.Location = new System.Drawing.Point(32, 139);
            this.lblTypeIngredient.Name = "lblTypeIngredient";
            this.lblTypeIngredient.Size = new System.Drawing.Size(146, 18);
            this.lblTypeIngredient.TabIndex = 10;
            this.lblTypeIngredient.Text = "Type : ";
            this.lblTypeIngredient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTypesIngredientsListedInDB
            // 
            this.cmbTypesIngredientsListedInDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypesIngredientsListedInDB.FormattingEnabled = true;
            this.cmbTypesIngredientsListedInDB.Location = new System.Drawing.Point(206, 138);
            this.cmbTypesIngredientsListedInDB.Name = "cmbTypesIngredientsListedInDB";
            this.cmbTypesIngredientsListedInDB.Size = new System.Drawing.Size(317, 24);
            this.cmbTypesIngredientsListedInDB.TabIndex = 11;
            // 
            // cmbScaleNewIngredient
            // 
            this.cmbScaleNewIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScaleNewIngredient.FormattingEnabled = true;
            this.cmbScaleNewIngredient.Location = new System.Drawing.Point(416, 65);
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
            this.cmdDelete.Location = new System.Drawing.Point(423, 188);
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
            this.cmdValidate.Location = new System.Drawing.Point(478, 188);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(40, 32);
            this.cmdValidate.TabIndex = 8;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // txtNewIngredientNameEn
            // 
            this.txtNewIngredientNameEn.Location = new System.Drawing.Point(206, 66);
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
            this.lblNewIngredientNameEn.Text = "Nom de l\'ingrédient (En) :";
            this.lblNewIngredientNameEn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewIngredientNameEs
            // 
            this.lblNewIngredientNameEs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNewIngredientNameEs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNewIngredientNameEs.Location = new System.Drawing.Point(12, 92);
            this.lblNewIngredientNameEs.Name = "lblNewIngredientNameEs";
            this.lblNewIngredientNameEs.Size = new System.Drawing.Size(188, 21);
            this.lblNewIngredientNameEs.TabIndex = 15;
            this.lblNewIngredientNameEs.Text = "Nom de l\'ingrédient (Es) :";
            this.lblNewIngredientNameEs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewIngredientNameEs
            // 
            this.txtNewIngredientNameEs.Location = new System.Drawing.Point(206, 91);
            this.txtNewIngredientNameEs.Name = "txtNewIngredientNameEs";
            this.txtNewIngredientNameEs.Size = new System.Drawing.Size(192, 22);
            this.txtNewIngredientNameEs.TabIndex = 16;
            // 
            // frmAddNewIngredientToTheDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(592, 240);
            this.Controls.Add(this.txtNewIngredientNameEs);
            this.Controls.Add(this.lblNewIngredientNameEs);
            this.Controls.Add(this.lblNewIngredientNameEn);
            this.Controls.Add(this.txtNewIngredientNameEn);
            this.Controls.Add(this.cmbScaleNewIngredient);
            this.Controls.Add(this.cmbTypesIngredientsListedInDB);
            this.Controls.Add(this.lblTypeIngredient);
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
        private System.Windows.Forms.Label lblTypeIngredient;
        private System.Windows.Forms.ComboBox cmbTypesIngredientsListedInDB;
        private System.Windows.Forms.ComboBox cmbScaleNewIngredient;
        private System.Windows.Forms.TextBox txtNewIngredientNameEn;
        private System.Windows.Forms.Label lblNewIngredientNameEn;
        private System.Windows.Forms.Label lblNewIngredientNameEs;
        private System.Windows.Forms.TextBox txtNewIngredientNameEs;
    }
}