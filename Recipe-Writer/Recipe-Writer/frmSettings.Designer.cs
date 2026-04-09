namespace Recipe_Writer
{
    partial class frmSettings
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
            this.lblInfosLicence = new System.Windows.Forms.Label();
            this.cmbAppLanguage = new System.Windows.Forms.ComboBox();
            this.lblAppLanguage = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfosLicence
            // 
            this.lblInfosLicence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInfosLicence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInfosLicence.Location = new System.Drawing.Point(13, 9);
            this.lblInfosLicence.Name = "lblInfosLicence";
            this.lblInfosLicence.Size = new System.Drawing.Size(388, 245);
            this.lblInfosLicence.TabIndex = 3;
            this.lblInfosLicence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbAppLanguage
            // 
            this.cmbAppLanguage.FormattingEnabled = true;
            this.cmbAppLanguage.Items.AddRange(new object[] {
            "anglais",
            "français"});
            this.cmbAppLanguage.Location = new System.Drawing.Point(220, 281);
            this.cmbAppLanguage.Name = "cmbAppLanguage";
            this.cmbAppLanguage.Size = new System.Drawing.Size(116, 24);
            this.cmbAppLanguage.TabIndex = 6;
            this.cmbAppLanguage.SelectionChangeCommitted += new System.EventHandler(this.cmbAppLanguage_SelectionChangeCommitted);
            // 
            // lblAppLanguage
            // 
            this.lblAppLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppLanguage.Location = new System.Drawing.Point(16, 282);
            this.lblAppLanguage.Name = "lblAppLanguage";
            this.lblAppLanguage.Size = new System.Drawing.Size(195, 23);
            this.lblAppLanguage.TabIndex = 4;
            this.lblAppLanguage.Text = "Langue de l\'application :";
            this.lblAppLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackColor = System.Drawing.Color.Transparent;
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(193, 329);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(36, 36);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.UseVisualStyleBackColor = false;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            this.cmdValidate.MouseEnter += new System.EventHandler(this.cmdValidate_MouseEnter);
            this.cmdValidate.MouseLeave += new System.EventHandler(this.cmdValidate_MouseLeave);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(422, 387);
            this.Controls.Add(this.cmbAppLanguage);
            this.Controls.Add(this.lblAppLanguage);
            this.Controls.Add(this.lblInfosLicence);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblInfosLicence;
        private System.Windows.Forms.Label lblAppLanguage;
        private System.Windows.Forms.ComboBox cmbAppLanguage;
    }
}