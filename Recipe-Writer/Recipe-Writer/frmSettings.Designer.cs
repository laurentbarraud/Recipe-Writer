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
            this.lblAppLanguage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmbAppLanguage = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfosLicence
            // 
            this.lblInfosLicence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInfosLicence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfosLicence.Location = new System.Drawing.Point(13, 30);
            this.lblInfosLicence.Name = "lblInfosLicence";
            this.lblInfosLicence.Size = new System.Drawing.Size(388, 234);
            this.lblInfosLicence.TabIndex = 3;
            this.lblInfosLicence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppLanguage
            // 
            this.lblAppLanguage.Location = new System.Drawing.Point(116, 291);
            this.lblAppLanguage.Name = "lblAppLanguage";
            this.lblAppLanguage.Size = new System.Drawing.Size(173, 23);
            this.lblAppLanguage.TabIndex = 4;
            this.lblAppLanguage.Text = "Langue de l\'application :";
            this.lblAppLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Recipe_Writer.Properties.Resources.app_language;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(129, 367);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 71);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.Location = new System.Drawing.Point(339, 376);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(44, 43);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmbAppLanguage
            // 
            this.cmbAppLanguage.FormattingEnabled = true;
            this.cmbAppLanguage.Items.AddRange(new object[] {
            "anglais",
            "français"});
            this.cmbAppLanguage.Location = new System.Drawing.Point(116, 329);
            this.cmbAppLanguage.Name = "cmbAppLanguage";
            this.cmbAppLanguage.Size = new System.Drawing.Size(173, 24);
            this.cmbAppLanguage.TabIndex = 6;
            this.cmbAppLanguage.SelectedValueChanged += new System.EventHandler(this.cmbAppLanguage_SelectedValueChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.cmbAppLanguage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAppLanguage);
            this.Controls.Add(this.lblInfosLicence);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A propos de Recipe-Writer";
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