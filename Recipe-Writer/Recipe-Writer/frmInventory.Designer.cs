namespace Recipe_Writer
{
    partial class frmInventory
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
            this.cmdValidate = new System.Windows.Forms.Button();
            this.lstIngredientsAvailable = new System.Windows.Forms.ListBox();
            this.pnlIngredientsStatus = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(385, 325);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(34, 32);
            this.cmdValidate.TabIndex = 3;
            this.cmdValidate.UseVisualStyleBackColor = true;
            // 
            // lstIngredientsAvailable
            // 
            this.lstIngredientsAvailable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsAvailable.FormattingEnabled = true;
            this.lstIngredientsAvailable.ItemHeight = 20;
            this.lstIngredientsAvailable.Location = new System.Drawing.Point(21, 32);
            this.lstIngredientsAvailable.Name = "lstIngredientsAvailable";
            this.lstIngredientsAvailable.Size = new System.Drawing.Size(253, 280);
            this.lstIngredientsAvailable.TabIndex = 0;
            // 
            // pnlIngredientsStatus
            // 
            this.pnlIngredientsStatus.AutoScroll = true;
            this.pnlIngredientsStatus.Location = new System.Drawing.Point(280, 32);
            this.pnlIngredientsStatus.Name = "pnlIngredientsStatus";
            this.pnlIngredientsStatus.Size = new System.Drawing.Size(168, 276);
            this.pnlIngredientsStatus.TabIndex = 1;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 378);
            this.Controls.Add(this.pnlIngredientsStatus);
            this.Controls.Add(this.lstIngredientsAvailable);
            this.Controls.Add(this.cmdValidate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventaire des ingrédients";
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.ListBox lstIngredientsAvailable;
        private System.Windows.Forms.Panel pnlIngredientsStatus;
    }
}