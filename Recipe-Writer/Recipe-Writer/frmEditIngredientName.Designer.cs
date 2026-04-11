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
            this.txtNewNameOfIngredient = new System.Windows.Forms.TextBox();
            this.lblNewIngredientName = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewNameOfIngredient
            // 
            this.txtNewNameOfIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNewNameOfIngredient.Location = new System.Drawing.Point(32, 67);
            this.txtNewNameOfIngredient.Name = "txtNewNameOfIngredient";
            this.txtNewNameOfIngredient.Size = new System.Drawing.Size(432, 24);
            this.txtNewNameOfIngredient.TabIndex = 0;
            // 
            // lblNewIngredientName
            // 
            this.lblNewIngredientName.AutoSize = true;
            this.lblNewIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNewIngredientName.Location = new System.Drawing.Point(29, 24);
            this.lblNewIngredientName.Name = "lblNewIngredientName";
            this.lblNewIngredientName.Size = new System.Drawing.Size(183, 18);
            this.lblNewIngredientName.TabIndex = 3;
            this.lblNewIngredientName.Text = "Nom du nouvel ingrédient :";
            this.lblNewIngredientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(413, 169);
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
            this.cmdDelete.Location = new System.Drawing.Point(358, 169);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(40, 32);
            this.cmdDelete.TabIndex = 1;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmEditIngredientName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(493, 224);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewNameOfIngredient);
            this.Controls.Add(this.lblNewIngredientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditIngredientName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier le nom d\'un ingrédient";
            this.Load += new System.EventHandler(this.frmEditIngredientName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.TextBox txtNewNameOfIngredient;
        private System.Windows.Forms.Label lblNewIngredientName;
    }
}