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
            this.lblAppLanguage = new System.Windows.Forms.Label();
            this.cmbAppLanguage = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdValidate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfosLicence
            // 
            resources.ApplyResources(this.lblInfosLicence, "lblInfosLicence");
            this.lblInfosLicence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInfosLicence.Name = "lblInfosLicence";
            // 
            // lblAppLanguage
            // 
            resources.ApplyResources(this.lblAppLanguage, "lblAppLanguage");
            this.lblAppLanguage.Name = "lblAppLanguage";
            // 
            // cmbAppLanguage
            // 
            resources.ApplyResources(this.cmbAppLanguage, "cmbAppLanguage");
            this.cmbAppLanguage.FormattingEnabled = true;
            this.cmbAppLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbAppLanguage.Items"),
            resources.GetString("cmbAppLanguage.Items1")});
            this.cmbAppLanguage.Name = "cmbAppLanguage";
            this.cmbAppLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbAppLanguage_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = global::Recipe_Writer.Properties.Resources.app_language;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // cmdValidate
            // 
            resources.ApplyResources(this.cmdValidate, "cmdValidate");
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // frmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbAppLanguage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAppLanguage);
            this.Controls.Add(this.lblInfosLicence);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblInfosLicence;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAppLanguage;
        private System.Windows.Forms.ComboBox cmbAppLanguage;
    }
}