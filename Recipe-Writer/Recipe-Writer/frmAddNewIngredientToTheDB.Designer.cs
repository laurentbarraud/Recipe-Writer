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
            this.txtNameNewIngredient = new System.Windows.Forms.TextBox();
            this.lblNewIngredientName = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbTypesIngredientsListedInDB = new System.Windows.Forms.ComboBox();
            this.cmbScaleNewIngredient = new System.Windows.Forms.ComboBox();
            this.lblScale = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNameNewIngredient
            // 
            this.txtNameNewIngredient.Location = new System.Drawing.Point(206, 41);
            this.txtNameNewIngredient.Name = "txtNameNewIngredient";
            this.txtNameNewIngredient.Size = new System.Drawing.Size(192, 22);
            this.txtNameNewIngredient.TabIndex = 6;
            // 
            // lblNewIngredientName
            // 
            this.lblNewIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewIngredientName.Location = new System.Drawing.Point(12, 42);
            this.lblNewIngredientName.Name = "lblNewIngredientName";
            this.lblNewIngredientName.Size = new System.Drawing.Size(166, 21);
            this.lblNewIngredientName.TabIndex = 9;
            this.lblNewIngredientName.Text = "Nom de l\'ingrédient : ";
            this.lblNewIngredientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(408, 154);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(34, 32);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(463, 154);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(34, 32);
            this.cmdValidate.TabIndex = 8;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(32, 93);
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
            this.cmbTypesIngredientsListedInDB.Location = new System.Drawing.Point(206, 92);
            this.cmbTypesIngredientsListedInDB.Name = "cmbTypesIngredientsListedInDB";
            this.cmbTypesIngredientsListedInDB.Size = new System.Drawing.Size(296, 24);
            this.cmbTypesIngredientsListedInDB.TabIndex = 11;
            // 
            // cmbScaleNewIngredient
            // 
            this.cmbScaleNewIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScaleNewIngredient.FormattingEnabled = true;
            this.cmbScaleNewIngredient.Location = new System.Drawing.Point(416, 41);
            this.cmbScaleNewIngredient.Name = "cmbScaleNewIngredient";
            this.cmbScaleNewIngredient.Size = new System.Drawing.Size(86, 24);
            this.cmbScaleNewIngredient.TabIndex = 12;
            // 
            // lblScale
            // 
            this.lblScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScale.Location = new System.Drawing.Point(390, 9);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(143, 29);
            this.lblScale.TabIndex = 13;
            this.lblScale.Text = "Unité de mesure";
            this.lblScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddNewIngredientToTheDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 200);
            this.Controls.Add(this.lblScale);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajout d\'un nouvel ingrédient dans la base";
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
        private System.Windows.Forms.Label lblScale;
    }
}