namespace Recipe_Writer
{
    partial class frmEditIngredientName
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
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmbScaleIngredient = new System.Windows.Forms.ComboBox();
            this.cmbTypesIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.lblTypeIngredient = new System.Windows.Forms.Label();
            this.txtIngredientNameEs = new System.Windows.Forms.TextBox();
            this.lblIngredientNameEs = new System.Windows.Forms.Label();
            this.lblIngredientNameEn = new System.Windows.Forms.Label();
            this.txtIngredientNameEn = new System.Windows.Forms.TextBox();
            this.txtIngredientNameFr = new System.Windows.Forms.TextBox();
            this.lblIngredientNameFr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(512, 184);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(40, 32);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Location = new System.Drawing.Point(457, 184);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(40, 32);
            this.cmdDelete.TabIndex = 1;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmbScaleIngredient
            // 
            this.cmbScaleIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScaleIngredient.FormattingEnabled = true;
            this.cmbScaleIngredient.Location = new System.Drawing.Point(450, 61);
            this.cmbScaleIngredient.Name = "cmbScaleIngredient";
            this.cmbScaleIngredient.Size = new System.Drawing.Size(107, 24);
            this.cmbScaleIngredient.TabIndex = 15;
            // 
            // cmbTypesIngredientsListedInDB
            // 
            this.cmbTypesIngredientsListedInDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypesIngredientsListedInDB.FormattingEnabled = true;
            this.cmbTypesIngredientsListedInDB.Location = new System.Drawing.Point(240, 134);
            this.cmbTypesIngredientsListedInDB.Name = "cmbTypesIngredientsListedInDB";
            this.cmbTypesIngredientsListedInDB.Size = new System.Drawing.Size(317, 24);
            this.cmbTypesIngredientsListedInDB.TabIndex = 14;
            // 
            // lblTypeIngredient
            // 
            this.lblTypeIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTypeIngredient.Location = new System.Drawing.Point(66, 135);
            this.lblTypeIngredient.Name = "lblTypeIngredient";
            this.lblTypeIngredient.Size = new System.Drawing.Size(146, 18);
            this.lblTypeIngredient.TabIndex = 13;
            this.lblTypeIngredient.Text = "Type : ";
            this.lblTypeIngredient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIngredientNameEs
            // 
            this.txtIngredientNameEs.Location = new System.Drawing.Point(240, 89);
            this.txtIngredientNameEs.Name = "txtIngredientNameEs";
            this.txtIngredientNameEs.Size = new System.Drawing.Size(192, 22);
            this.txtIngredientNameEs.TabIndex = 22;
            // 
            // lblIngredientNameEs
            // 
            this.lblIngredientNameEs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblIngredientNameEs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIngredientNameEs.Location = new System.Drawing.Point(18, 90);
            this.lblIngredientNameEs.Name = "lblIngredientNameEs";
            this.lblIngredientNameEs.Size = new System.Drawing.Size(216, 21);
            this.lblIngredientNameEs.TabIndex = 21;
            this.lblIngredientNameEs.Text = "Nom de l\'ingrédient (Es) :";
            this.lblIngredientNameEs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIngredientNameEn
            // 
            this.lblIngredientNameEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblIngredientNameEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIngredientNameEn.Location = new System.Drawing.Point(15, 64);
            this.lblIngredientNameEn.Name = "lblIngredientNameEn";
            this.lblIngredientNameEn.Size = new System.Drawing.Size(219, 22);
            this.lblIngredientNameEn.TabIndex = 20;
            this.lblIngredientNameEn.Text = "Nom de l\'ingrédient (En) :";
            this.lblIngredientNameEn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIngredientNameEn
            // 
            this.txtIngredientNameEn.Location = new System.Drawing.Point(240, 64);
            this.txtIngredientNameEn.Name = "txtIngredientNameEn";
            this.txtIngredientNameEn.Size = new System.Drawing.Size(192, 22);
            this.txtIngredientNameEn.TabIndex = 19;
            // 
            // txtIngredientNameFr
            // 
            this.txtIngredientNameFr.Location = new System.Drawing.Point(240, 39);
            this.txtIngredientNameFr.Name = "txtIngredientNameFr";
            this.txtIngredientNameFr.Size = new System.Drawing.Size(192, 22);
            this.txtIngredientNameFr.TabIndex = 17;
            // 
            // lblIngredientNameFr
            // 
            this.lblIngredientNameFr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblIngredientNameFr.Location = new System.Drawing.Point(12, 40);
            this.lblIngredientNameFr.Name = "lblIngredientNameFr";
            this.lblIngredientNameFr.Size = new System.Drawing.Size(222, 24);
            this.lblIngredientNameFr.TabIndex = 18;
            this.lblIngredientNameFr.Text = "Nom de l\'ingrédient (Fr) : ";
            this.lblIngredientNameFr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmEditIngredientName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cmdDelete;
            this.ClientSize = new System.Drawing.Size(623, 240);
            this.Controls.Add(this.txtIngredientNameEs);
            this.Controls.Add(this.lblIngredientNameEs);
            this.Controls.Add(this.lblIngredientNameEn);
            this.Controls.Add(this.txtIngredientNameEn);
            this.Controls.Add(this.txtIngredientNameFr);
            this.Controls.Add(this.lblIngredientNameFr);
            this.Controls.Add(this.cmbScaleIngredient);
            this.Controls.Add(this.cmbTypesIngredientsListedInDB);
            this.Controls.Add(this.lblTypeIngredient);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditIngredientName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier le nom d\'un ingrédient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.ComboBox cmbScaleIngredient;
        private System.Windows.Forms.ComboBox cmbTypesIngredientsListedInDB;
        private System.Windows.Forms.Label lblTypeIngredient;
        private System.Windows.Forms.TextBox txtIngredientNameEs;
        private System.Windows.Forms.Label lblIngredientNameEs;
        private System.Windows.Forms.Label lblIngredientNameEn;
        private System.Windows.Forms.TextBox txtIngredientNameEn;
        private System.Windows.Forms.TextBox txtIngredientNameFr;
        private System.Windows.Forms.Label lblIngredientNameFr;
    }
}