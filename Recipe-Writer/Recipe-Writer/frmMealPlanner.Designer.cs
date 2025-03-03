namespace Recipe_Writer
{
    partial class frmMealPlanner
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
            this.cmdMondayCancelled = new System.Windows.Forms.Button();
            this.cmdThursdayCancelled = new System.Windows.Forms.Button();
            this.cmdSundayCancelled = new System.Windows.Forms.Button();
            this.cmdTuesdayCancelled = new System.Windows.Forms.Button();
            this.cmdWednesdayCancelled = new System.Windows.Forms.Button();
            this.cmdFridayCancelled = new System.Windows.Forms.Button();
            this.cmdSaturdayCancelled = new System.Windows.Forms.Button();
            this.lblHowToUse = new System.Windows.Forms.Label();
            this.picTuesdayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.picWednesdayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.picSaturdayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.picMondayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.picThursdayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.picFridayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.picSundayEnoughIngredients = new System.Windows.Forms.PictureBox();
            this.txtMonday = new System.Windows.Forms.TextBox();
            this.txtTuesday = new System.Windows.Forms.TextBox();
            this.txtWednesday = new System.Windows.Forms.TextBox();
            this.txtThursday = new System.Windows.Forms.TextBox();
            this.txtFriday = new System.Windows.Forms.TextBox();
            this.txtSaturday = new System.Windows.Forms.TextBox();
            this.txtSunday = new System.Windows.Forms.TextBox();
            this.lblMondayRecipe = new System.Windows.Forms.Label();
            this.lblTuesdayRecipe = new System.Windows.Forms.Label();
            this.lblWednesdayRecipe = new System.Windows.Forms.Label();
            this.lblThursdayRecipe = new System.Windows.Forms.Label();
            this.lblFridayRecipe = new System.Windows.Forms.Label();
            this.lblSaturdayRecipe = new System.Windows.Forms.Label();
            this.lblSundayRecipe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTuesdayEnoughIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWednesdayEnoughIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaturdayEnoughIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMondayEnoughIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThursdayEnoughIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFridayEnoughIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSundayEnoughIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(446, 338);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(47, 44);
            this.cmdValidate.TabIndex = 29;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdMondayCancelled
            // 
            this.cmdMondayCancelled.Enabled = false;
            this.cmdMondayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdMondayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMondayCancelled.Location = new System.Drawing.Point(24, 113);
            this.cmdMondayCancelled.Name = "cmdMondayCancelled";
            this.cmdMondayCancelled.Size = new System.Drawing.Size(91, 25);
            this.cmdMondayCancelled.TabIndex = 1;
            this.cmdMondayCancelled.Text = "Supprimer";
            this.cmdMondayCancelled.UseVisualStyleBackColor = true;
            this.cmdMondayCancelled.Click += new System.EventHandler(this.cmdMondayCancelled_Click);
            // 
            // cmdThursdayCancelled
            // 
            this.cmdThursdayCancelled.Enabled = false;
            this.cmdThursdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdThursdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdThursdayCancelled.Location = new System.Drawing.Point(24, 246);
            this.cmdThursdayCancelled.Name = "cmdThursdayCancelled";
            this.cmdThursdayCancelled.Size = new System.Drawing.Size(91, 25);
            this.cmdThursdayCancelled.TabIndex = 13;
            this.cmdThursdayCancelled.Text = "Supprimer";
            this.cmdThursdayCancelled.UseVisualStyleBackColor = true;
            this.cmdThursdayCancelled.Click += new System.EventHandler(this.cmdThursdayCancelled_Click);
            // 
            // cmdSundayCancelled
            // 
            this.cmdSundayCancelled.Enabled = false;
            this.cmdSundayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdSundayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSundayCancelled.Location = new System.Drawing.Point(24, 382);
            this.cmdSundayCancelled.Name = "cmdSundayCancelled";
            this.cmdSundayCancelled.Size = new System.Drawing.Size(91, 25);
            this.cmdSundayCancelled.TabIndex = 255;
            this.cmdSundayCancelled.Text = "Supprimer";
            this.cmdSundayCancelled.UseVisualStyleBackColor = true;
            this.cmdSundayCancelled.Click += new System.EventHandler(this.cmdSundayCancelled_Click);
            // 
            // cmdTuesdayCancelled
            // 
            this.cmdTuesdayCancelled.Enabled = false;
            this.cmdTuesdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdTuesdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTuesdayCancelled.Location = new System.Drawing.Point(212, 113);
            this.cmdTuesdayCancelled.Name = "cmdTuesdayCancelled";
            this.cmdTuesdayCancelled.Size = new System.Drawing.Size(90, 25);
            this.cmdTuesdayCancelled.TabIndex = 5;
            this.cmdTuesdayCancelled.Text = "Supprimer";
            this.cmdTuesdayCancelled.UseVisualStyleBackColor = true;
            this.cmdTuesdayCancelled.Click += new System.EventHandler(this.cmdTuesdayCancelled_Click);
            // 
            // cmdWednesdayCancelled
            // 
            this.cmdWednesdayCancelled.Enabled = false;
            this.cmdWednesdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdWednesdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdWednesdayCancelled.Location = new System.Drawing.Point(403, 113);
            this.cmdWednesdayCancelled.Name = "cmdWednesdayCancelled";
            this.cmdWednesdayCancelled.Size = new System.Drawing.Size(90, 25);
            this.cmdWednesdayCancelled.TabIndex = 9;
            this.cmdWednesdayCancelled.Text = "Supprimer";
            this.cmdWednesdayCancelled.UseVisualStyleBackColor = true;
            // 
            // cmdFridayCancelled
            // 
            this.cmdFridayCancelled.Enabled = false;
            this.cmdFridayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdFridayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFridayCancelled.Location = new System.Drawing.Point(212, 245);
            this.cmdFridayCancelled.Name = "cmdFridayCancelled";
            this.cmdFridayCancelled.Size = new System.Drawing.Size(90, 25);
            this.cmdFridayCancelled.TabIndex = 17;
            this.cmdFridayCancelled.Text = "Supprimer";
            this.cmdFridayCancelled.UseVisualStyleBackColor = true;
            this.cmdFridayCancelled.Click += new System.EventHandler(this.cmdFridayCancelled_Click);
            // 
            // cmdSaturdayCancelled
            // 
            this.cmdSaturdayCancelled.Enabled = false;
            this.cmdSaturdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdSaturdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaturdayCancelled.Location = new System.Drawing.Point(403, 245);
            this.cmdSaturdayCancelled.Name = "cmdSaturdayCancelled";
            this.cmdSaturdayCancelled.Size = new System.Drawing.Size(90, 25);
            this.cmdSaturdayCancelled.TabIndex = 21;
            this.cmdSaturdayCancelled.Text = "Supprimer";
            this.cmdSaturdayCancelled.UseVisualStyleBackColor = true;
            this.cmdSaturdayCancelled.Click += new System.EventHandler(this.cmdSaturdayCancelled_Click);
            // 
            // lblHowToUse
            // 
            this.lblHowToUse.Location = new System.Drawing.Point(228, 295);
            this.lblHowToUse.Name = "lblHowToUse";
            this.lblHowToUse.Size = new System.Drawing.Size(324, 40);
            this.lblHowToUse.TabIndex = 28;
            this.lblHowToUse.Text = "Glissez-déposez les titres des recettes dans la case de votre choix.";
            // 
            // picTuesdayEnoughIngredients
            // 
            this.picTuesdayEnoughIngredients.Location = new System.Drawing.Point(363, 14);
            this.picTuesdayEnoughIngredients.Name = "picTuesdayEnoughIngredients";
            this.picTuesdayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picTuesdayEnoughIngredients.TabIndex = 7;
            this.picTuesdayEnoughIngredients.TabStop = false;
            // 
            // picWednesdayEnoughIngredients
            // 
            this.picWednesdayEnoughIngredients.Location = new System.Drawing.Point(554, 12);
            this.picWednesdayEnoughIngredients.Name = "picWednesdayEnoughIngredients";
            this.picWednesdayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picWednesdayEnoughIngredients.TabIndex = 7;
            this.picWednesdayEnoughIngredients.TabStop = false;
            // 
            // picSaturdayEnoughIngredients
            // 
            this.picSaturdayEnoughIngredients.Location = new System.Drawing.Point(554, 145);
            this.picSaturdayEnoughIngredients.Name = "picSaturdayEnoughIngredients";
            this.picSaturdayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picSaturdayEnoughIngredients.TabIndex = 7;
            this.picSaturdayEnoughIngredients.TabStop = false;
            // 
            // picMondayEnoughIngredients
            // 
            this.picMondayEnoughIngredients.Location = new System.Drawing.Point(175, 13);
            this.picMondayEnoughIngredients.Name = "picMondayEnoughIngredients";
            this.picMondayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picMondayEnoughIngredients.TabIndex = 7;
            this.picMondayEnoughIngredients.TabStop = false;
            // 
            // picThursdayEnoughIngredients
            // 
            this.picThursdayEnoughIngredients.Location = new System.Drawing.Point(175, 144);
            this.picThursdayEnoughIngredients.Name = "picThursdayEnoughIngredients";
            this.picThursdayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picThursdayEnoughIngredients.TabIndex = 7;
            this.picThursdayEnoughIngredients.TabStop = false;
            // 
            // picFridayEnoughIngredients
            // 
            this.picFridayEnoughIngredients.Location = new System.Drawing.Point(363, 145);
            this.picFridayEnoughIngredients.Name = "picFridayEnoughIngredients";
            this.picFridayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picFridayEnoughIngredients.TabIndex = 7;
            this.picFridayEnoughIngredients.TabStop = false;
            // 
            // picSundayEnoughIngredients
            // 
            this.picSundayEnoughIngredients.Location = new System.Drawing.Point(175, 280);
            this.picSundayEnoughIngredients.Name = "picSundayEnoughIngredients";
            this.picSundayEnoughIngredients.Size = new System.Drawing.Size(27, 26);
            this.picSundayEnoughIngredients.TabIndex = 7;
            this.picSundayEnoughIngredients.TabStop = false;
            // 
            // txtMonday
            // 
            this.txtMonday.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonday.Location = new System.Drawing.Point(175, 46);
            this.txtMonday.Multiline = true;
            this.txtMonday.Name = "txtMonday";
            this.txtMonday.Size = new System.Drawing.Size(13, 67);
            this.txtMonday.TabIndex = 3;
            this.txtMonday.Text = "Lun";
            this.txtMonday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTuesday
            // 
            this.txtTuesday.BackColor = System.Drawing.SystemColors.Control;
            this.txtTuesday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuesday.Location = new System.Drawing.Point(363, 44);
            this.txtTuesday.Multiline = true;
            this.txtTuesday.Name = "txtTuesday";
            this.txtTuesday.Size = new System.Drawing.Size(13, 67);
            this.txtTuesday.TabIndex = 7;
            this.txtTuesday.Text = "Mar";
            this.txtTuesday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWednesday
            // 
            this.txtWednesday.BackColor = System.Drawing.SystemColors.Control;
            this.txtWednesday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWednesday.Location = new System.Drawing.Point(554, 44);
            this.txtWednesday.Multiline = true;
            this.txtWednesday.Name = "txtWednesday";
            this.txtWednesday.Size = new System.Drawing.Size(13, 67);
            this.txtWednesday.TabIndex = 11;
            this.txtWednesday.Text = "Mer";
            this.txtWednesday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtThursday
            // 
            this.txtThursday.BackColor = System.Drawing.SystemColors.Control;
            this.txtThursday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThursday.Location = new System.Drawing.Point(175, 174);
            this.txtThursday.Multiline = true;
            this.txtThursday.Name = "txtThursday";
            this.txtThursday.Size = new System.Drawing.Size(13, 67);
            this.txtThursday.TabIndex = 15;
            this.txtThursday.Text = "Jeu";
            this.txtThursday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFriday
            // 
            this.txtFriday.BackColor = System.Drawing.SystemColors.Control;
            this.txtFriday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFriday.Location = new System.Drawing.Point(363, 177);
            this.txtFriday.Multiline = true;
            this.txtFriday.Name = "txtFriday";
            this.txtFriday.Size = new System.Drawing.Size(13, 67);
            this.txtFriday.TabIndex = 19;
            this.txtFriday.Text = "Ven";
            this.txtFriday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSaturday
            // 
            this.txtSaturday.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaturday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaturday.Location = new System.Drawing.Point(554, 178);
            this.txtSaturday.Multiline = true;
            this.txtSaturday.Name = "txtSaturday";
            this.txtSaturday.Size = new System.Drawing.Size(13, 67);
            this.txtSaturday.TabIndex = 23;
            this.txtSaturday.Text = "Sam";
            this.txtSaturday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSunday
            // 
            this.txtSunday.BackColor = System.Drawing.SystemColors.Control;
            this.txtSunday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSunday.Location = new System.Drawing.Point(175, 315);
            this.txtSunday.Multiline = true;
            this.txtSunday.Name = "txtSunday";
            this.txtSunday.Size = new System.Drawing.Size(13, 67);
            this.txtSunday.TabIndex = 27;
            this.txtSunday.Text = "Dim";
            this.txtSunday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMondayRecipe
            // 
            this.lblMondayRecipe.AllowDrop = true;
            this.lblMondayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMondayRecipe.Location = new System.Drawing.Point(32, 12);
            this.lblMondayRecipe.Name = "lblMondayRecipe";
            this.lblMondayRecipe.Size = new System.Drawing.Size(141, 84);
            this.lblMondayRecipe.TabIndex = 0;
            this.lblMondayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblMondayRecipe_DragEnter);
            // 
            // lblTuesdayRecipe
            // 
            this.lblTuesdayRecipe.AllowDrop = true;
            this.lblTuesdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesdayRecipe.Location = new System.Drawing.Point(220, 14);
            this.lblTuesdayRecipe.Name = "lblTuesdayRecipe";
            this.lblTuesdayRecipe.Size = new System.Drawing.Size(141, 82);
            this.lblTuesdayRecipe.TabIndex = 4;
            this.lblTuesdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblTuesdayRecipe_DragEnter);
            // 
            // lblWednesdayRecipe
            // 
            this.lblWednesdayRecipe.AllowDrop = true;
            this.lblWednesdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesdayRecipe.Location = new System.Drawing.Point(411, 12);
            this.lblWednesdayRecipe.Name = "lblWednesdayRecipe";
            this.lblWednesdayRecipe.Size = new System.Drawing.Size(141, 84);
            this.lblWednesdayRecipe.TabIndex = 8;
            this.lblWednesdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblWednesdayRecipe_DragEnter);
            // 
            // lblThursdayRecipe
            // 
            this.lblThursdayRecipe.AllowDrop = true;
            this.lblThursdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursdayRecipe.Location = new System.Drawing.Point(32, 144);
            this.lblThursdayRecipe.Name = "lblThursdayRecipe";
            this.lblThursdayRecipe.Size = new System.Drawing.Size(141, 83);
            this.lblThursdayRecipe.TabIndex = 12;
            this.lblThursdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblThursdayRecipe_DragEnter);
            // 
            // lblFridayRecipe
            // 
            this.lblFridayRecipe.AllowDrop = true;
            this.lblFridayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFridayRecipe.Location = new System.Drawing.Point(220, 145);
            this.lblFridayRecipe.Name = "lblFridayRecipe";
            this.lblFridayRecipe.Size = new System.Drawing.Size(141, 82);
            this.lblFridayRecipe.TabIndex = 16;
            this.lblFridayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblFridayRecipe_DragEnter);
            // 
            // lblSaturdayRecipe
            // 
            this.lblSaturdayRecipe.AllowDrop = true;
            this.lblSaturdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturdayRecipe.Location = new System.Drawing.Point(411, 145);
            this.lblSaturdayRecipe.Name = "lblSaturdayRecipe";
            this.lblSaturdayRecipe.Size = new System.Drawing.Size(141, 82);
            this.lblSaturdayRecipe.TabIndex = 20;
            this.lblSaturdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblSaturdayRecipe_DragEnter);
            // 
            // lblSundayRecipe
            // 
            this.lblSundayRecipe.AllowDrop = true;
            this.lblSundayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSundayRecipe.Location = new System.Drawing.Point(32, 280);
            this.lblSundayRecipe.Name = "lblSundayRecipe";
            this.lblSundayRecipe.Size = new System.Drawing.Size(141, 80);
            this.lblSundayRecipe.TabIndex = 24;
            this.lblSundayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblSundayRecipe_DragEnter);
            // 
            // frmMealPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 417);
            this.Controls.Add(this.cmdSundayCancelled);
            this.Controls.Add(this.cmdThursdayCancelled);
            this.Controls.Add(this.cmdWednesdayCancelled);
            this.Controls.Add(this.cmdSaturdayCancelled);
            this.Controls.Add(this.cmdFridayCancelled);
            this.Controls.Add(this.cmdTuesdayCancelled);
            this.Controls.Add(this.cmdMondayCancelled);
            this.Controls.Add(this.lblSundayRecipe);
            this.Controls.Add(this.lblSaturdayRecipe);
            this.Controls.Add(this.lblFridayRecipe);
            this.Controls.Add(this.lblThursdayRecipe);
            this.Controls.Add(this.lblWednesdayRecipe);
            this.Controls.Add(this.lblTuesdayRecipe);
            this.Controls.Add(this.lblMondayRecipe);
            this.Controls.Add(this.txtSunday);
            this.Controls.Add(this.txtSaturday);
            this.Controls.Add(this.txtFriday);
            this.Controls.Add(this.txtThursday);
            this.Controls.Add(this.txtWednesday);
            this.Controls.Add(this.txtTuesday);
            this.Controls.Add(this.txtMonday);
            this.Controls.Add(this.picFridayEnoughIngredients);
            this.Controls.Add(this.picSaturdayEnoughIngredients);
            this.Controls.Add(this.picSundayEnoughIngredients);
            this.Controls.Add(this.picThursdayEnoughIngredients);
            this.Controls.Add(this.picWednesdayEnoughIngredients);
            this.Controls.Add(this.picMondayEnoughIngredients);
            this.Controls.Add(this.picTuesdayEnoughIngredients);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.lblHowToUse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMealPlanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Planificateur de repas";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMealPlanner_FormClosed);
            this.Load += new System.EventHandler(this.frmMealPlanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTuesdayEnoughIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWednesdayEnoughIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaturdayEnoughIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMondayEnoughIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThursdayEnoughIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFridayEnoughIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSundayEnoughIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Button cmdMondayCancelled;
        private System.Windows.Forms.Button cmdThursdayCancelled;
        private System.Windows.Forms.Button cmdSundayCancelled;
        private System.Windows.Forms.Button cmdTuesdayCancelled;
        private System.Windows.Forms.Button cmdWednesdayCancelled;
        private System.Windows.Forms.Button cmdFridayCancelled;
        private System.Windows.Forms.Button cmdSaturdayCancelled;
        private System.Windows.Forms.Label lblHowToUse;
        private System.Windows.Forms.PictureBox picTuesdayEnoughIngredients;
        private System.Windows.Forms.PictureBox picWednesdayEnoughIngredients;
        private System.Windows.Forms.PictureBox picSaturdayEnoughIngredients;
        private System.Windows.Forms.PictureBox picMondayEnoughIngredients;
        private System.Windows.Forms.PictureBox picThursdayEnoughIngredients;
        private System.Windows.Forms.PictureBox picFridayEnoughIngredients;
        private System.Windows.Forms.PictureBox picSundayEnoughIngredients;
        private System.Windows.Forms.TextBox txtMonday;
        private System.Windows.Forms.TextBox txtTuesday;
        private System.Windows.Forms.TextBox txtWednesday;
        private System.Windows.Forms.TextBox txtThursday;
        private System.Windows.Forms.TextBox txtFriday;
        private System.Windows.Forms.TextBox txtSaturday;
        private System.Windows.Forms.TextBox txtSunday;
        private System.Windows.Forms.Label lblMondayRecipe;
        private System.Windows.Forms.Label lblTuesdayRecipe;
        private System.Windows.Forms.Label lblWednesdayRecipe;
        private System.Windows.Forms.Label lblThursdayRecipe;
        private System.Windows.Forms.Label lblFridayRecipe;
        private System.Windows.Forms.Label lblSaturdayRecipe;
        private System.Windows.Forms.Label lblSundayRecipe;
    }
}