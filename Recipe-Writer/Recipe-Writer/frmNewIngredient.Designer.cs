namespace Recipe_Writer
{
    partial class frmNewIngredient
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
            this.lblNewIngredientName = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.lblQtyIngredient = new System.Windows.Forms.Label();
            this.txtQtyIngredient = new System.Windows.Forms.TextBox();
            this.cmbScalesList = new System.Windows.Forms.ComboBox();
            this.cmbIngredientsList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNewIngredientName
            // 
            this.lblNewIngredientName.AutoSize = true;
            this.lblNewIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewIngredientName.Location = new System.Drawing.Point(45, 36);
            this.lblNewIngredientName.Name = "lblNewIngredientName";
            this.lblNewIngredientName.Size = new System.Drawing.Size(146, 18);
            this.lblNewIngredientName.TabIndex = 5;
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
            this.cmdCancel.Location = new System.Drawing.Point(358, 198);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(34, 32);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Enabled = false;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(413, 198);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(34, 32);
            this.cmdValidate.TabIndex = 4;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // lblQtyIngredient
            // 
            this.lblQtyIngredient.AutoSize = true;
            this.lblQtyIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyIngredient.Location = new System.Drawing.Point(116, 106);
            this.lblQtyIngredient.Name = "lblQtyIngredient";
            this.lblQtyIngredient.Size = new System.Drawing.Size(75, 18);
            this.lblQtyIngredient.TabIndex = 6;
            this.lblQtyIngredient.Text = "Quantité : ";
            this.lblQtyIngredient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQtyIngredient
            // 
            this.txtQtyIngredient.Location = new System.Drawing.Point(206, 106);
            this.txtQtyIngredient.Name = "txtQtyIngredient";
            this.txtQtyIngredient.Size = new System.Drawing.Size(100, 22);
            this.txtQtyIngredient.TabIndex = 1;
            // 
            // cmbScalesList
            // 
            this.cmbScalesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScalesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbScalesList.FormattingEnabled = true;
            this.cmbScalesList.Location = new System.Drawing.Point(326, 106);
            this.cmbScalesList.Name = "cmbScalesList";
            this.cmbScalesList.Size = new System.Drawing.Size(121, 24);
            this.cmbScalesList.TabIndex = 2;
            // 
            // cmbIngredientsList
            // 
            this.cmbIngredientsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngredientsList.FormattingEnabled = true;
            this.cmbIngredientsList.Location = new System.Drawing.Point(206, 36);
            this.cmbIngredientsList.Name = "cmbIngredientsList";
            this.cmbIngredientsList.Size = new System.Drawing.Size(241, 24);
            this.cmbIngredientsList.TabIndex = 7;
            this.cmbIngredientsList.SelectedIndexChanged += new System.EventHandler(this.cmbIngredientsList_SelectedIndexChanged);
            // 
            // frmNewIngredient
            // 
            this.AcceptButton = this.cmdValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(493, 267);
            this.Controls.Add(this.cmbIngredientsList);
            this.Controls.Add(this.cmbScalesList);
            this.Controls.Add(this.txtQtyIngredient);
            this.Controls.Add(this.lblQtyIngredient);
            this.Controls.Add(this.lblNewIngredientName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewIngredient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajout d\'un nouvel ingrédient à la recette";
            this.Load += new System.EventHandler(this.frmNewIngredient_Load);
            this.Move += new System.EventHandler(this.frmNewIngredient_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewIngredientName;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblQtyIngredient;
        private System.Windows.Forms.TextBox txtQtyIngredient;
        private System.Windows.Forms.ComboBox cmbScalesList;
        private System.Windows.Forms.ComboBox cmbIngredientsList;
    }
}