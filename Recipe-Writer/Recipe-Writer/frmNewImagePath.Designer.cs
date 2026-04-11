namespace Recipe_Writer
{
    partial class frmNewImagePath
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
            this.txtNewImagePath = new System.Windows.Forms.TextBox();
            this.lblImageFilename = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewImagePath
            // 
            this.txtNewImagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNewImagePath.Location = new System.Drawing.Point(41, 80);
            this.txtNewImagePath.Name = "txtNewImagePath";
            this.txtNewImagePath.Size = new System.Drawing.Size(349, 24);
            this.txtNewImagePath.TabIndex = 0;
            // 
            // lblImageFilename
            // 
            this.lblImageFilename.AutoSize = true;
            this.lblImageFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblImageFilename.Location = new System.Drawing.Point(38, 36);
            this.lblImageFilename.Name = "lblImageFilename";
            this.lblImageFilename.Size = new System.Drawing.Size(236, 18);
            this.lblImageFilename.TabIndex = 5;
            this.lblImageFilename.Text = "Nom de fichier à donner à l\'image :";
            this.lblImageFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(420, 129);
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
            this.cmdDelete.Location = new System.Drawing.Point(365, 129);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(40, 32);
            this.cmdDelete.TabIndex = 1;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmNewImagePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cmdDelete;
            this.ClientSize = new System.Drawing.Size(493, 185);
            this.Controls.Add(this.lblImageFilename);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewImagePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewImagePath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrer un nom pour l\'image d\'illustration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewImagePath;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Label lblImageFilename;
    }
}