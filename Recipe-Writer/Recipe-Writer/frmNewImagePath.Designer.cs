﻿namespace Recipe_Writer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewImagePath));
            this.txtNewImagePath = new System.Windows.Forms.TextBox();
            this.lblNewImagePath = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewImagePath
            // 
            resources.ApplyResources(this.txtNewImagePath, "txtNewImagePath");
            this.txtNewImagePath.Name = "txtNewImagePath";
            // 
            // lblNewImagePath
            // 
            resources.ApplyResources(this.lblNewImagePath, "lblNewImagePath");
            this.lblNewImagePath.Name = "lblNewImagePath";
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
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderSize = 0;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmNewImagePath
            // 
            this.AcceptButton = this.cmdValidate;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.lblNewImagePath);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.txtNewImagePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewImagePath";
            this.Move += new System.EventHandler(this.frmNewImagePath_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewImagePath;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblNewImagePath;
    }
}