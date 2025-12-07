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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewRecipeBasicInfosInput));
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
            resources.ApplyResources(this.txtNewRecipeTitle, "txtNewRecipeTitle");
            this.txtNewRecipeTitle.Name = "txtNewRecipeTitle";
            // 
            // lblNewRecipeTitle
            // 
            resources.ApplyResources(this.lblNewRecipeTitle, "lblNewRecipeTitle");
            this.lblNewRecipeTitle.Name = "lblNewRecipeTitle";
            // 
            // txtNewRecipeCompletionTime
            // 
            resources.ApplyResources(this.txtNewRecipeCompletionTime, "txtNewRecipeCompletionTime");
            this.txtNewRecipeCompletionTime.Name = "txtNewRecipeCompletionTime";
            // 
            // lblNewRecipeCompletionTime
            // 
            resources.ApplyResources(this.lblNewRecipeCompletionTime, "lblNewRecipeCompletionTime");
            this.lblNewRecipeCompletionTime.Name = "lblNewRecipeCompletionTime";
            // 
            // lblMinutes
            // 
            resources.ApplyResources(this.lblMinutes, "lblMinutes");
            this.lblMinutes.Name = "lblMinutes";
            // 
            // chkLowBudget
            // 
            resources.ApplyResources(this.chkLowBudget, "chkLowBudget");
            this.chkLowBudget.Name = "chkLowBudget";
            this.chkLowBudget.UseVisualStyleBackColor = true;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.CausesValidation = false;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmNewRecipeBasicInfosInput
            // 
            this.AcceptButton = this.cmdValidate;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.chkLowBudget);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblNewRecipeCompletionTime);
            this.Controls.Add(this.lblNewRecipeTitle);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtNewRecipeCompletionTime);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewRecipeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewRecipeBasicInfosInput";
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