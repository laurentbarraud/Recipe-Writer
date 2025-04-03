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
            this.lblHowToUse = new System.Windows.Forms.Label();
            this.lblMondayRecipe = new System.Windows.Forms.Label();
            this.lblTuesdayRecipe = new System.Windows.Forms.Label();
            this.lblWednesdayRecipe = new System.Windows.Forms.Label();
            this.lblThursdayRecipe = new System.Windows.Forms.Label();
            this.lblFridayRecipe = new System.Windows.Forms.Label();
            this.lblSaturdayRecipe = new System.Windows.Forms.Label();
            this.lblSundayRecipe = new System.Windows.Forms.Label();
            this.lblMondayText = new System.Windows.Forms.Label();
            this.lblTuesdayText = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblSunday = new System.Windows.Forms.Label();
            this.cmdMondayCooked = new System.Windows.Forms.Button();
            this.cmdSaturdayCancelled = new System.Windows.Forms.Button();
            this.cmdFridayCancelled = new System.Windows.Forms.Button();
            this.cmdThursdayCancelled = new System.Windows.Forms.Button();
            this.cmdSundayCancelled = new System.Windows.Forms.Button();
            this.cmdWednesdayCancelled = new System.Windows.Forms.Button();
            this.cmdTuesdayCancelled = new System.Windows.Forms.Button();
            this.cmdMondayCancelled = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.cmdTuesdayCooked = new System.Windows.Forms.Button();
            this.cmdWednesdayCooked = new System.Windows.Forms.Button();
            this.cmdThursdayCooked = new System.Windows.Forms.Button();
            this.cmdFridayCooked = new System.Windows.Forms.Button();
            this.cmdSaturdayCooked = new System.Windows.Forms.Button();
            this.cmdSundayCooked = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHowToUse
            // 
            this.lblHowToUse.Location = new System.Drawing.Point(233, 313);
            this.lblHowToUse.Name = "lblHowToUse";
            this.lblHowToUse.Size = new System.Drawing.Size(315, 48);
            this.lblHowToUse.TabIndex = 29;
            this.lblHowToUse.Text = "Glissez-déposez un titre de recette dans la case de votre choix ou sélectionnez u" +
    "n titre et double-cliquez sur une case vide pour l\'affecter.";
            // 
            // lblMondayRecipe
            // 
            this.lblMondayRecipe.AllowDrop = true;
            this.lblMondayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMondayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMondayRecipe.Location = new System.Drawing.Point(36, 46);
            this.lblMondayRecipe.Name = "lblMondayRecipe";
            this.lblMondayRecipe.Size = new System.Drawing.Size(167, 64);
            this.lblMondayRecipe.TabIndex = 0;
            this.lblMondayRecipe.TextChanged += new System.EventHandler(this.lblMondayRecipe_TextChanged);
            this.lblMondayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblMondayRecipe_DragDrop);
            this.lblMondayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblMondayRecipe_DragEnter);
            this.lblMondayRecipe.DoubleClick += new System.EventHandler(this.lblMondayRecipe_DoubleClick);
            // 
            // lblTuesdayRecipe
            // 
            this.lblTuesdayRecipe.AllowDrop = true;
            this.lblTuesdayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTuesdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesdayRecipe.Location = new System.Drawing.Point(211, 45);
            this.lblTuesdayRecipe.Name = "lblTuesdayRecipe";
            this.lblTuesdayRecipe.Size = new System.Drawing.Size(166, 64);
            this.lblTuesdayRecipe.TabIndex = 3;
            this.lblTuesdayRecipe.TextChanged += new System.EventHandler(this.lblTuesdayRecipe_TextChanged);
            this.lblTuesdayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTuesdayRecipe_DragDrop);
            this.lblTuesdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblTuesdayRecipe_DragEnter);
            this.lblTuesdayRecipe.DoubleClick += new System.EventHandler(this.lblTuesdayRecipe_DoubleClick);
            // 
            // lblWednesdayRecipe
            // 
            this.lblWednesdayRecipe.AllowDrop = true;
            this.lblWednesdayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWednesdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesdayRecipe.Location = new System.Drawing.Point(382, 46);
            this.lblWednesdayRecipe.Name = "lblWednesdayRecipe";
            this.lblWednesdayRecipe.Size = new System.Drawing.Size(166, 64);
            this.lblWednesdayRecipe.TabIndex = 6;
            this.lblWednesdayRecipe.TextChanged += new System.EventHandler(this.lblWednesdayRecipe_TextChanged);
            this.lblWednesdayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblWednesdayRecipe_DragDrop);
            this.lblWednesdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblWednesdayRecipe_DragEnter);
            this.lblWednesdayRecipe.DoubleClick += new System.EventHandler(this.lblWednesdayRecipe_DoubleClick);
            // 
            // lblThursdayRecipe
            // 
            this.lblThursdayRecipe.AllowDrop = true;
            this.lblThursdayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThursdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursdayRecipe.Location = new System.Drawing.Point(37, 179);
            this.lblThursdayRecipe.Name = "lblThursdayRecipe";
            this.lblThursdayRecipe.Size = new System.Drawing.Size(166, 63);
            this.lblThursdayRecipe.TabIndex = 9;
            this.lblThursdayRecipe.TextChanged += new System.EventHandler(this.lblThursdayRecipe_TextChanged);
            this.lblThursdayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblThursdayRecipe_DragDrop);
            this.lblThursdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblThursdayRecipe_DragEnter);
            this.lblThursdayRecipe.DoubleClick += new System.EventHandler(this.lblThursdayRecipe_DoubleClick);
            // 
            // lblFridayRecipe
            // 
            this.lblFridayRecipe.AllowDrop = true;
            this.lblFridayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFridayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFridayRecipe.Location = new System.Drawing.Point(211, 179);
            this.lblFridayRecipe.Name = "lblFridayRecipe";
            this.lblFridayRecipe.Size = new System.Drawing.Size(166, 63);
            this.lblFridayRecipe.TabIndex = 12;
            this.lblFridayRecipe.TextChanged += new System.EventHandler(this.lblFridayRecipe_TextChanged);
            this.lblFridayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblFridayRecipe_DragDrop);
            this.lblFridayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblFridayRecipe_DragEnter);
            this.lblFridayRecipe.DoubleClick += new System.EventHandler(this.lblFridayRecipe_DoubleClick);
            // 
            // lblSaturdayRecipe
            // 
            this.lblSaturdayRecipe.AllowDrop = true;
            this.lblSaturdayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaturdayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturdayRecipe.Location = new System.Drawing.Point(382, 179);
            this.lblSaturdayRecipe.Name = "lblSaturdayRecipe";
            this.lblSaturdayRecipe.Size = new System.Drawing.Size(166, 63);
            this.lblSaturdayRecipe.TabIndex = 15;
            this.lblSaturdayRecipe.TextChanged += new System.EventHandler(this.lblSaturdayRecipe_TextChanged);
            this.lblSaturdayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblSaturdayRecipe_DragDrop);
            this.lblSaturdayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblSaturdayRecipe_DragEnter);
            this.lblSaturdayRecipe.DoubleClick += new System.EventHandler(this.lblSaturdayRecipe_DoubleClick);
            // 
            // lblSundayRecipe
            // 
            this.lblSundayRecipe.AllowDrop = true;
            this.lblSundayRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSundayRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSundayRecipe.Location = new System.Drawing.Point(37, 313);
            this.lblSundayRecipe.Name = "lblSundayRecipe";
            this.lblSundayRecipe.Size = new System.Drawing.Size(166, 63);
            this.lblSundayRecipe.TabIndex = 18;
            this.lblSundayRecipe.TextChanged += new System.EventHandler(this.lblSundayRecipe_TextChanged);
            this.lblSundayRecipe.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblSundayRecipe_DragDrop);
            this.lblSundayRecipe.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblSundayRecipe_DragEnter);
            this.lblSundayRecipe.DoubleClick += new System.EventHandler(this.lblSundayRecipe_DoubleClick);
            // 
            // lblMondayText
            // 
            this.lblMondayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMondayText.Location = new System.Drawing.Point(35, 14);
            this.lblMondayText.Name = "lblMondayText";
            this.lblMondayText.Size = new System.Drawing.Size(168, 23);
            this.lblMondayText.TabIndex = 22;
            this.lblMondayText.Text = "Lundi";
            this.lblMondayText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTuesdayText
            // 
            this.lblTuesdayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesdayText.Location = new System.Drawing.Point(212, 14);
            this.lblTuesdayText.Name = "lblTuesdayText";
            this.lblTuesdayText.Size = new System.Drawing.Size(168, 23);
            this.lblTuesdayText.TabIndex = 23;
            this.lblTuesdayText.Text = "Mardi";
            this.lblTuesdayText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWednesday
            // 
            this.lblWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesday.Location = new System.Drawing.Point(381, 14);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(168, 23);
            this.lblWednesday.TabIndex = 24;
            this.lblWednesday.Text = "Mercredi";
            this.lblWednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThursday
            // 
            this.lblThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursday.Location = new System.Drawing.Point(33, 145);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(168, 23);
            this.lblThursday.TabIndex = 25;
            this.lblThursday.Text = "Jeudi";
            this.lblThursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFriday
            // 
            this.lblFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriday.Location = new System.Drawing.Point(208, 145);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(168, 23);
            this.lblFriday.TabIndex = 26;
            this.lblFriday.Text = "Vendredi";
            this.lblFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaturday
            // 
            this.lblSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturday.Location = new System.Drawing.Point(380, 145);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(168, 23);
            this.lblSaturday.TabIndex = 27;
            this.lblSaturday.Text = "Samedi";
            this.lblSaturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSunday
            // 
            this.lblSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunday.Location = new System.Drawing.Point(35, 273);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(168, 23);
            this.lblSunday.TabIndex = 28;
            this.lblSunday.Text = "Dimanche";
            this.lblSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdMondayCooked
            // 
            this.cmdMondayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdMondayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdMondayCooked.FlatAppearance.BorderSize = 0;
            this.cmdMondayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMondayCooked.Location = new System.Drawing.Point(126, 113);
            this.cmdMondayCooked.Name = "cmdMondayCooked";
            this.cmdMondayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdMondayCooked.TabIndex = 2;
            this.cmdMondayCooked.UseVisualStyleBackColor = true;
            this.cmdMondayCooked.Visible = false;
            this.cmdMondayCooked.Click += new System.EventHandler(this.cmdMondayCooked_Click);
            // 
            // cmdSaturdayCancelled
            // 
            this.cmdSaturdayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdSaturdayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSaturdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdSaturdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaturdayCancelled.Location = new System.Drawing.Point(382, 244);
            this.cmdSaturdayCancelled.Name = "cmdSaturdayCancelled";
            this.cmdSaturdayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdSaturdayCancelled.TabIndex = 16;
            this.cmdSaturdayCancelled.UseVisualStyleBackColor = true;
            this.cmdSaturdayCancelled.Visible = false;
            this.cmdSaturdayCancelled.Click += new System.EventHandler(this.cmdSaturdayCancelled_Click);
            // 
            // cmdFridayCancelled
            // 
            this.cmdFridayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdFridayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdFridayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdFridayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFridayCancelled.Location = new System.Drawing.Point(212, 244);
            this.cmdFridayCancelled.Name = "cmdFridayCancelled";
            this.cmdFridayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdFridayCancelled.TabIndex = 13;
            this.cmdFridayCancelled.UseVisualStyleBackColor = true;
            this.cmdFridayCancelled.Visible = false;
            this.cmdFridayCancelled.Click += new System.EventHandler(this.cmdFridayCancelled_Click);
            // 
            // cmdThursdayCancelled
            // 
            this.cmdThursdayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdThursdayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdThursdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdThursdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdThursdayCancelled.Location = new System.Drawing.Point(35, 245);
            this.cmdThursdayCancelled.Name = "cmdThursdayCancelled";
            this.cmdThursdayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdThursdayCancelled.TabIndex = 10;
            this.cmdThursdayCancelled.UseVisualStyleBackColor = true;
            this.cmdThursdayCancelled.Visible = false;
            this.cmdThursdayCancelled.Click += new System.EventHandler(this.cmdThursdayCancelled_Click);
            // 
            // cmdSundayCancelled
            // 
            this.cmdSundayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdSundayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSundayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdSundayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSundayCancelled.Location = new System.Drawing.Point(35, 377);
            this.cmdSundayCancelled.Name = "cmdSundayCancelled";
            this.cmdSundayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdSundayCancelled.TabIndex = 19;
            this.cmdSundayCancelled.UseVisualStyleBackColor = true;
            this.cmdSundayCancelled.Visible = false;
            this.cmdSundayCancelled.Click += new System.EventHandler(this.cmdSundayCancelled_Click);
            // 
            // cmdWednesdayCancelled
            // 
            this.cmdWednesdayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdWednesdayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdWednesdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdWednesdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdWednesdayCancelled.Location = new System.Drawing.Point(382, 112);
            this.cmdWednesdayCancelled.Name = "cmdWednesdayCancelled";
            this.cmdWednesdayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdWednesdayCancelled.TabIndex = 7;
            this.cmdWednesdayCancelled.UseVisualStyleBackColor = true;
            this.cmdWednesdayCancelled.Visible = false;
            this.cmdWednesdayCancelled.Click += new System.EventHandler(this.cmdWednesdayCancelled_Click);
            // 
            // cmdTuesdayCancelled
            // 
            this.cmdTuesdayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdTuesdayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdTuesdayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdTuesdayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTuesdayCancelled.Location = new System.Drawing.Point(212, 112);
            this.cmdTuesdayCancelled.Name = "cmdTuesdayCancelled";
            this.cmdTuesdayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdTuesdayCancelled.TabIndex = 4;
            this.cmdTuesdayCancelled.UseVisualStyleBackColor = true;
            this.cmdTuesdayCancelled.Visible = false;
            this.cmdTuesdayCancelled.Click += new System.EventHandler(this.cmdTuesdayCancelled_Click);
            // 
            // cmdMondayCancelled
            // 
            this.cmdMondayCancelled.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdMondayCancelled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdMondayCancelled.FlatAppearance.BorderSize = 0;
            this.cmdMondayCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMondayCancelled.Location = new System.Drawing.Point(35, 113);
            this.cmdMondayCancelled.Name = "cmdMondayCancelled";
            this.cmdMondayCancelled.Size = new System.Drawing.Size(72, 25);
            this.cmdMondayCancelled.TabIndex = 1;
            this.cmdMondayCancelled.UseVisualStyleBackColor = true;
            this.cmdMondayCancelled.Visible = false;
            this.cmdMondayCancelled.Click += new System.EventHandler(this.cmdMondayCancelled_Click);
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(453, 370);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(47, 44);
            this.cmdValidate.TabIndex = 21;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // cmdTuesdayCooked
            // 
            this.cmdTuesdayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdTuesdayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdTuesdayCooked.FlatAppearance.BorderSize = 0;
            this.cmdTuesdayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTuesdayCooked.Location = new System.Drawing.Point(307, 112);
            this.cmdTuesdayCooked.Name = "cmdTuesdayCooked";
            this.cmdTuesdayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdTuesdayCooked.TabIndex = 5;
            this.cmdTuesdayCooked.UseVisualStyleBackColor = true;
            this.cmdTuesdayCooked.Visible = false;
            this.cmdTuesdayCooked.Click += new System.EventHandler(this.cmdTuesdayCooked_Click);
            // 
            // cmdWednesdayCooked
            // 
            this.cmdWednesdayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdWednesdayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdWednesdayCooked.FlatAppearance.BorderSize = 0;
            this.cmdWednesdayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdWednesdayCooked.Location = new System.Drawing.Point(477, 113);
            this.cmdWednesdayCooked.Name = "cmdWednesdayCooked";
            this.cmdWednesdayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdWednesdayCooked.TabIndex = 8;
            this.cmdWednesdayCooked.UseVisualStyleBackColor = true;
            this.cmdWednesdayCooked.Visible = false;
            this.cmdWednesdayCooked.Click += new System.EventHandler(this.cmdWednesdayCooked_Click);
            // 
            // cmdThursdayCooked
            // 
            this.cmdThursdayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdThursdayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdThursdayCooked.FlatAppearance.BorderSize = 0;
            this.cmdThursdayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdThursdayCooked.Location = new System.Drawing.Point(131, 244);
            this.cmdThursdayCooked.Name = "cmdThursdayCooked";
            this.cmdThursdayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdThursdayCooked.TabIndex = 11;
            this.cmdThursdayCooked.UseVisualStyleBackColor = true;
            this.cmdThursdayCooked.Visible = false;
            this.cmdThursdayCooked.Click += new System.EventHandler(this.cmdThursdayCooked_Click);
            // 
            // cmdFridayCooked
            // 
            this.cmdFridayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdFridayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdFridayCooked.FlatAppearance.BorderSize = 0;
            this.cmdFridayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFridayCooked.Location = new System.Drawing.Point(307, 244);
            this.cmdFridayCooked.Name = "cmdFridayCooked";
            this.cmdFridayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdFridayCooked.TabIndex = 14;
            this.cmdFridayCooked.UseVisualStyleBackColor = true;
            this.cmdFridayCooked.Visible = false;
            this.cmdFridayCooked.Click += new System.EventHandler(this.cmdFridayCooked_Click);
            // 
            // cmdSaturdayCooked
            // 
            this.cmdSaturdayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdSaturdayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSaturdayCooked.FlatAppearance.BorderSize = 0;
            this.cmdSaturdayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaturdayCooked.Location = new System.Drawing.Point(476, 245);
            this.cmdSaturdayCooked.Name = "cmdSaturdayCooked";
            this.cmdSaturdayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdSaturdayCooked.TabIndex = 17;
            this.cmdSaturdayCooked.UseVisualStyleBackColor = true;
            this.cmdSaturdayCooked.Visible = false;
            this.cmdSaturdayCooked.Click += new System.EventHandler(this.cmdSaturdayCooked_Click);
            // 
            // cmdSundayCooked
            // 
            this.cmdSundayCooked.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.cmdSundayCooked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSundayCooked.FlatAppearance.BorderSize = 0;
            this.cmdSundayCooked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSundayCooked.Location = new System.Drawing.Point(131, 377);
            this.cmdSundayCooked.Name = "cmdSundayCooked";
            this.cmdSundayCooked.Size = new System.Drawing.Size(72, 25);
            this.cmdSundayCooked.TabIndex = 20;
            this.cmdSundayCooked.UseVisualStyleBackColor = true;
            this.cmdSundayCooked.Visible = false;
            this.cmdSundayCooked.Click += new System.EventHandler(this.cmdSundayCooked_Click);
            // 
            // frmMealPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 425);
            this.Controls.Add(this.cmdSundayCooked);
            this.Controls.Add(this.cmdSaturdayCooked);
            this.Controls.Add(this.cmdFridayCooked);
            this.Controls.Add(this.cmdThursdayCooked);
            this.Controls.Add(this.cmdWednesdayCooked);
            this.Controls.Add(this.cmdTuesdayCooked);
            this.Controls.Add(this.cmdMondayCooked);
            this.Controls.Add(this.cmdSaturdayCancelled);
            this.Controls.Add(this.cmdFridayCancelled);
            this.Controls.Add(this.cmdThursdayCancelled);
            this.Controls.Add(this.cmdSundayCancelled);
            this.Controls.Add(this.cmdWednesdayCancelled);
            this.Controls.Add(this.cmdTuesdayCancelled);
            this.Controls.Add(this.cmdMondayCancelled);
            this.Controls.Add(this.lblSunday);
            this.Controls.Add(this.lblSaturday);
            this.Controls.Add(this.lblFriday);
            this.Controls.Add(this.lblThursday);
            this.Controls.Add(this.lblWednesday);
            this.Controls.Add(this.lblTuesdayText);
            this.Controls.Add(this.lblMondayText);
            this.Controls.Add(this.lblSundayRecipe);
            this.Controls.Add(this.lblSaturdayRecipe);
            this.Controls.Add(this.lblFridayRecipe);
            this.Controls.Add(this.lblThursdayRecipe);
            this.Controls.Add(this.lblWednesdayRecipe);
            this.Controls.Add(this.lblTuesdayRecipe);
            this.Controls.Add(this.lblMondayRecipe);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.lblHowToUse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMealPlanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Planificateur de repas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMealPlanner_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblHowToUse;
        private System.Windows.Forms.Label lblMondayRecipe;
        private System.Windows.Forms.Label lblTuesdayRecipe;
        private System.Windows.Forms.Label lblWednesdayRecipe;
        private System.Windows.Forms.Label lblThursdayRecipe;
        private System.Windows.Forms.Label lblFridayRecipe;
        private System.Windows.Forms.Label lblSaturdayRecipe;
        private System.Windows.Forms.Label lblSundayRecipe;
        private System.Windows.Forms.Label lblMondayText;
        private System.Windows.Forms.Label lblTuesdayText;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.Button cmdMondayCancelled;
        private System.Windows.Forms.Button cmdTuesdayCancelled;
        private System.Windows.Forms.Button cmdWednesdayCancelled;
        private System.Windows.Forms.Button cmdSundayCancelled;
        private System.Windows.Forms.Button cmdSaturdayCancelled;
        private System.Windows.Forms.Button cmdFridayCancelled;
        private System.Windows.Forms.Button cmdThursdayCancelled;
        private System.Windows.Forms.Button cmdMondayCooked;
        private System.Windows.Forms.Button cmdTuesdayCooked;
        private System.Windows.Forms.Button cmdWednesdayCooked;
        private System.Windows.Forms.Button cmdThursdayCooked;
        private System.Windows.Forms.Button cmdFridayCooked;
        private System.Windows.Forms.Button cmdSaturdayCooked;
        private System.Windows.Forms.Button cmdSundayCooked;
    }
}