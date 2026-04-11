namespace Recipe_Writer
{
    partial class frmNewInstruction
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
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtNewInstruction = new System.Windows.Forms.TextBox();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInstruction.Location = new System.Drawing.Point(29, 28);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(88, 18);
            this.lblInstruction.TabIndex = 3;
            this.lblInstruction.Text = "Instruction : ";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewInstruction
            // 
            this.txtNewInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNewInstruction.Location = new System.Drawing.Point(32, 71);
            this.txtNewInstruction.Multiline = true;
            this.txtNewInstruction.Name = "txtNewInstruction";
            this.txtNewInstruction.Size = new System.Drawing.Size(432, 71);
            this.txtNewInstruction.TabIndex = 0;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(418, 173);
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
            this.cmdDelete.Location = new System.Drawing.Point(363, 173);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(40, 32);
            this.cmdDelete.TabIndex = 1;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmNewInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cmdDelete;
            this.ClientSize = new System.Drawing.Size(493, 224);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewInstruction);
            this.Controls.Add(this.lblInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewInstruction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter une nouvelle instruction à cette recette";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtNewInstruction;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdValidate;
    }
}