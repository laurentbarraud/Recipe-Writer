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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.lblInfosLicence = new System.Windows.Forms.Label();
            this.cmbAppLanguage = new System.Windows.Forms.ComboBox();
            this.lblAppLanguage = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfosLicence
            // 
            this.lblInfosLicence.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblInfosLicence, "lblInfosLicence");
            this.lblInfosLicence.Name = "lblInfosLicence";
            // 
            // cmbAppLanguage
            // 
            this.cmbAppLanguage.FormattingEnabled = true;
            this.cmbAppLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbAppLanguage.Items"),
            resources.GetString("cmbAppLanguage.Items1")});
            resources.ApplyResources(this.cmbAppLanguage, "cmbAppLanguage");
            this.cmbAppLanguage.Name = "cmbAppLanguage";
            this.cmbAppLanguage.SelectionChangeCommitted += new System.EventHandler(this.cmbAppLanguage_SelectionChangeCommitted);
            // 
            // lblAppLanguage
            // 
            resources.ApplyResources(this.lblAppLanguage, "lblAppLanguage");
            this.lblAppLanguage.Name = "lblAppLanguage";
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackColor = System.Drawing.Color.Transparent;
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = false;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            this.cmdValidate.MouseEnter += new System.EventHandler(this.cmdValidate_MouseEnter);
            this.cmdValidate.MouseLeave += new System.EventHandler(this.cmdValidate_MouseLeave);
            // 
            // frmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cmbAppLanguage);
            this.Controls.Add(this.lblAppLanguage);
            this.Controls.Add(this.lblInfosLicence);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
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