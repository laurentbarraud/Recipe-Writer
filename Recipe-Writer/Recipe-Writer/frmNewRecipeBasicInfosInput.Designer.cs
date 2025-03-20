namespace Recipe_Writer
{
    partial class frmNewRecipeBasicInfosInput
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
            this.lblNewRecipeTitle = new System.Windows.Forms.Label();
            this.txtNewRecipeCompletionTime = new System.Windows.Forms.TextBox();
            this.lblNewRecipeCompletionTime = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.chkLowBudget = new System.Windows.Forms.CheckBox();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewRecipeTitle
            // 
            this.txtNewRecipeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewRecipeTitle.Location = new System.Drawing.Point(95, 50);
            this.txtNewRecipeTitle.MaxLength = 500;
            this.txtNewRecipeTitle.Name = "txtNewRecipeTitle";
            this.txtNewRecipeTitle.Size = new System.Drawing.Size(349, 24);
            this.txtNewRecipeTitle.TabIndex = 0;
            // 
            // lblNewRecipeTitle
            // 
            this.lblNewRecipeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewRecipeTitle.Location = new System.Drawing.Point(40, 54);
            this.lblNewRecipeTitle.Name = "lblNewRecipeTitle";
            this.lblNewRecipeTitle.Size = new System.Drawing.Size(50, 18);
            this.lblNewRecipeTitle.TabIndex = 5;
            this.lblNewRecipeTitle.Text = "Titre :";
            this.lblNewRecipeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNewRecipeCompletionTime
            // 
            this.txtNewRecipeCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewRecipeCompletionTime.Location = new System.Drawing.Point(311, 106);
            this.txtNewRecipeCompletionTime.MaxLength = 3;
            this.txtNewRecipeCompletionTime.Name = "txtNewRecipeCompletionTime";
            this.txtNewRecipeCompletionTime.Size = new System.Drawing.Size(61, 24);
            this.txtNewRecipeCompletionTime.TabIndex = 1;
            // 
            // lblNewRecipeCompletionTime
            // 
            this.lblNewRecipeCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewRecipeCompletionTime.Location = new System.Drawing.Point(120, 109);
            this.lblNewRecipeCompletionTime.Name = "lblNewRecipeCompletionTime";
            this.lblNewRecipeCompletionTime.Size = new System.Drawing.Size(185, 21);
            this.lblNewRecipeCompletionTime.TabIndex = 6;
            this.lblNewRecipeCompletionTime.Text = "Temps de réalisation :";
            this.lblNewRecipeCompletionTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinutes
            // 
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.chkLowBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmdValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(408, 218);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(34, 32);
            this.cmdValidate.TabIndex = 4;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdCancel.CausesValidation = false;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(353, 218);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(34, 32);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmNewRecipeBasicInfosInput
            // 
            this.AcceptButton = this.cmdValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(493, 267);
            this.Controls.Add(this.chkLowBudget);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblNewRecipeCompletionTime);
            this.Controls.Add(this.lblNewRecipeTitle);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtNewRecipeCompletionTime);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewRecipeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewRecipeBasicInfosInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrez les infos de base pour la nouvelle recette";
            this.Move += new System.EventHandler(this.frmNewRecipeBasicInfosInput_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.TextBox txtNewRecipeTitle;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblNewRecipeTitle;
        private System.Windows.Forms.TextBox txtNewRecipeCompletionTime;
        private System.Windows.Forms.Label lblNewRecipeCompletionTime;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.CheckBox chkLowBudget;
    }
}