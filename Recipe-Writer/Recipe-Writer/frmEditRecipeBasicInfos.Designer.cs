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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditRecipeBasicInfos));
            this.txtRecipeTitleToEdit = new System.Windows.Forms.TextBox();
            this.lblRecipeTitle = new System.Windows.Forms.Label();
            this.chkLowBudget = new System.Windows.Forms.CheckBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblRecipeCompletionTime = new System.Windows.Forms.Label();
            this.txtRecipeCompletionTime = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRecipeTitleToEdit
            // 
            resources.ApplyResources(this.txtRecipeTitleToEdit, "txtRecipeTitleToEdit");
            this.txtRecipeTitleToEdit.Name = "txtRecipeTitleToEdit";
            // 
            // lblRecipeTitle
            // 
            resources.ApplyResources(this.lblRecipeTitle, "lblRecipeTitle");
            this.lblRecipeTitle.Name = "lblRecipeTitle";
            // 
            // chkLowBudget
            // 
            resources.ApplyResources(this.chkLowBudget, "chkLowBudget");
            this.chkLowBudget.Name = "chkLowBudget";
            this.chkLowBudget.UseVisualStyleBackColor = true;
            this.chkLowBudget.CheckedChanged += new System.EventHandler(this.chkLowBudget_CheckedChanged);
            // 
            // lblMinutes
            // 
            resources.ApplyResources(this.lblMinutes, "lblMinutes");
            this.lblMinutes.Name = "lblMinutes";
            // 
            // lblRecipeCompletionTime
            // 
            resources.ApplyResources(this.lblRecipeCompletionTime, "lblRecipeCompletionTime");
            this.lblRecipeCompletionTime.Name = "lblRecipeCompletionTime";
            // 
            // txtRecipeCompletionTime
            // 
            resources.ApplyResources(this.txtRecipeCompletionTime, "txtRecipeCompletionTime");
            this.txtRecipeCompletionTime.Name = "txtRecipeCompletionTime";
            // 
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdCancel.CausesValidation = false;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdValidate
            // 
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // frmEditRecipeBasicInfos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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