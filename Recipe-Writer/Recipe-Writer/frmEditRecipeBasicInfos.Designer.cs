namespace Recipe_Writer
{
    partial class frmEditRecipeBasicInfos
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.txtRecipeTitleToEdit = new System.Windows.Forms.TextBox();
            this.lblRecipeTitle = new System.Windows.Forms.Label();
            this.chkLowBudget = new System.Windows.Forms.CheckBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblRecipeCompletionTime = new System.Windows.Forms.Label();
            this.txtRecipeCompletionTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(408, 218);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(34, 32);
            this.cmdValidate.TabIndex = 4;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // txtRecipeTitleToEdit
            // 
            this.txtRecipeTitleToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipeTitleToEdit.Location = new System.Drawing.Point(95, 50);
            this.txtRecipeTitleToEdit.MaxLength = 500;
            this.txtRecipeTitleToEdit.Multiline = true;
            this.txtRecipeTitleToEdit.Name = "txtRecipeTitleToEdit";
            this.txtRecipeTitleToEdit.Size = new System.Drawing.Size(349, 24);
            this.txtRecipeTitleToEdit.TabIndex = 0;
            // 
            // lblRecipeTitle
            // 
            this.lblRecipeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeTitle.Location = new System.Drawing.Point(40, 54);
            this.lblRecipeTitle.Name = "lblRecipeTitle";
            this.lblRecipeTitle.Size = new System.Drawing.Size(50, 18);
            this.lblRecipeTitle.TabIndex = 6;
            this.lblRecipeTitle.Text = "Titre :";
            this.lblRecipeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.chkLowBudget.CheckedChanged += new System.EventHandler(this.chkLowBudget_CheckedChanged);
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
            // lblRecipeCompletionTime
            // 
            this.lblRecipeCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeCompletionTime.Location = new System.Drawing.Point(120, 109);
            this.lblRecipeCompletionTime.Name = "lblRecipeCompletionTime";
            this.lblRecipeCompletionTime.Size = new System.Drawing.Size(185, 21);
            this.lblRecipeCompletionTime.TabIndex = 6;
            this.lblRecipeCompletionTime.Text = "Temps de réalisation :";
            this.lblRecipeCompletionTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRecipeCompletionTime
            // 
            this.txtRecipeCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipeCompletionTime.Location = new System.Drawing.Point(311, 106);
            this.txtRecipeCompletionTime.MaxLength = 3;
            this.txtRecipeCompletionTime.Name = "txtRecipeCompletionTime";
            this.txtRecipeCompletionTime.Size = new System.Drawing.Size(61, 24);
            this.txtRecipeCompletionTime.TabIndex = 1;
            // 
            // frmEditRecipeBasicInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 267);
            this.Controls.Add(this.chkLowBudget);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblRecipeCompletionTime);
            this.Controls.Add(this.txtRecipeCompletionTime);
            this.Controls.Add(this.lblRecipeTitle);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtRecipeTitleToEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditRecipeBasicInfos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier les infos de base de la recette";
            this.Load += new System.EventHandler(this.frmEditRecipeTitle_Load);
            this.Move += new System.EventHandler(this.frmEditRecipeTitle_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.TextBox txtRecipeTitleToEdit;
        private System.Windows.Forms.Label lblRecipeTitle;
        private System.Windows.Forms.CheckBox chkLowBudget;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblRecipeCompletionTime;
        private System.Windows.Forms.TextBox txtRecipeCompletionTime;
    }
}