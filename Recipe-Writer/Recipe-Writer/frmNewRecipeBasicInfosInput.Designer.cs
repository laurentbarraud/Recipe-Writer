namespace Recipe_Writer
{
    partial class frmNewRecipeInfosInput
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
            this.txtNewRecipeTitle = new System.Windows.Forms.TextBox();
            this.lblRecipeTitle = new System.Windows.Forms.Label();
            this.txtNewRecipeCompletionTime = new System.Windows.Forms.TextBox();
            this.lblRecipeCompletionTime = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.chkLowBudget = new System.Windows.Forms.CheckBox();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewRecipeTitle
            // 
            this.txtNewRecipeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNewRecipeTitle.Location = new System.Drawing.Point(95, 50);
            this.txtNewRecipeTitle.MaxLength = 500;
            this.txtNewRecipeTitle.Name = "txtNewRecipeTitle";
            this.txtNewRecipeTitle.Size = new System.Drawing.Size(349, 24);
            this.txtNewRecipeTitle.TabIndex = 0;
            // 
            // lblRecipeTitle
            // 
            this.lblRecipeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRecipeTitle.Location = new System.Drawing.Point(40, 54);
            this.lblRecipeTitle.Name = "lblRecipeTitle";
            this.lblRecipeTitle.Size = new System.Drawing.Size(50, 18);
            this.lblRecipeTitle.TabIndex = 5;
            this.lblRecipeTitle.Text = "Titre :";
            this.lblRecipeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNewRecipeCompletionTime
            // 
            this.txtNewRecipeCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNewRecipeCompletionTime.Location = new System.Drawing.Point(311, 106);
            this.txtNewRecipeCompletionTime.MaxLength = 3;
            this.txtNewRecipeCompletionTime.Name = "txtNewRecipeCompletionTime";
            this.txtNewRecipeCompletionTime.Size = new System.Drawing.Size(61, 24);
            this.txtNewRecipeCompletionTime.TabIndex = 1;
            // 
            // lblRecipeCompletionTime
            // 
            this.lblRecipeCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRecipeCompletionTime.Location = new System.Drawing.Point(120, 109);
            this.lblRecipeCompletionTime.Name = "lblRecipeCompletionTime";
            this.lblRecipeCompletionTime.Size = new System.Drawing.Size(185, 21);
            this.lblRecipeCompletionTime.TabIndex = 6;
            this.lblRecipeCompletionTime.Text = "Temps de réalisation :";
            this.lblRecipeCompletionTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinutes
            // 
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMinutes.Location = new System.Drawing.Point(384, 110);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(60, 18);
            this.lblMinutes.TabIndex = 7;
            this.lblMinutes.Text = "minutes";
            this.lblMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkLowBudget
            // 
            this.chkLowBudget.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLowBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkLowBudget.Location = new System.Drawing.Point(254, 161);
            this.chkLowBudget.Name = "chkLowBudget";
            this.chkLowBudget.Size = new System.Drawing.Size(179, 24);
            this.chkLowBudget.TabIndex = 2;
            this.chkLowBudget.Text = "Pour petit budget";
            this.chkLowBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLowBudget.UseVisualStyleBackColor = true;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(398, 218);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(40, 32);
            this.cmdValidate.TabIndex = 4;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDelete.CausesValidation = false;
            this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Location = new System.Drawing.Point(343, 218);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(40, 32);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmNewRecipeInfosInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cmdDelete;
            this.ClientSize = new System.Drawing.Size(493, 267);
            this.Controls.Add(this.chkLowBudget);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblRecipeCompletionTime);
            this.Controls.Add(this.lblRecipeTitle);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.txtNewRecipeCompletionTime);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewRecipeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewRecipeInfosInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrer les infos de base pour la nouvelle recette";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.TextBox txtNewRecipeTitle;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Label lblRecipeTitle;
        private System.Windows.Forms.TextBox txtNewRecipeCompletionTime;
        private System.Windows.Forms.Label lblRecipeCompletionTime;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.CheckBox chkLowBudget;
    }
}