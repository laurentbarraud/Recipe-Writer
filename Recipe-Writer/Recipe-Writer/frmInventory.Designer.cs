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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
            this.cmdValidate = new System.Windows.Forms.Button();
            this.tabInventoryIngredients = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTypeIngredient2 = new System.Windows.Forms.Label();
            this.lblTypeIngredient1 = new System.Windows.Forms.Label();
            this.pnlIngredientsType2Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType2Available = new System.Windows.Forms.ListBox();
            this.pnlIngredientsType1Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType1Available = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTypeIngredient4 = new System.Windows.Forms.Label();
            this.lblTypeIngredient3 = new System.Windows.Forms.Label();
            this.pnlIngredientsType4Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType4Available = new System.Windows.Forms.ListBox();
            this.pnlIngredientsType3Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType3Available = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlIngredientsType5Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType5Available = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pnlIngredientsType6Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType6Available = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pnlIngredientsType7Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType7Available = new System.Windows.Forms.ListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pnlIngredientsType8Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType8Available = new System.Windows.Forms.ListBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.pnlIngredientsType9Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType9Available = new System.Windows.Forms.ListBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.pnlIngredientsType10Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType10Available = new System.Windows.Forms.ListBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lblTypeIngredient12 = new System.Windows.Forms.Label();
            this.lblTypeIngredient11 = new System.Windows.Forms.Label();
            this.pnlIngredientsType12Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType12Available = new System.Windows.Forms.ListBox();
            this.pnlIngredientsType11Status = new System.Windows.Forms.Panel();
            this.lstIngredientsType11Available = new System.Windows.Forms.ListBox();
            this.lblNbOfIngredientsStored = new System.Windows.Forms.Label();
            this.cmdAddNewIngredientIntoDB = new System.Windows.Forms.Button();
            this.tabInventoryIngredients.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdValidate
            // 
            this.cmdValidate.BackgroundImage = global::Recipe_Writer.Properties.Resources.validate;
            this.cmdValidate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdValidate.FlatAppearance.BorderSize = 0;
            this.cmdValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdValidate.Location = new System.Drawing.Point(473, 446);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(34, 32);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // tabInventoryIngredients
            // 
            this.tabInventoryIngredients.Controls.Add(this.tabPage1);
            this.tabInventoryIngredients.Controls.Add(this.tabPage2);
            this.tabInventoryIngredients.Controls.Add(this.tabPage3);
            this.tabInventoryIngredients.Controls.Add(this.tabPage4);
            this.tabInventoryIngredients.Controls.Add(this.tabPage5);
            this.tabInventoryIngredients.Controls.Add(this.tabPage6);
            this.tabInventoryIngredients.Controls.Add(this.tabPage7);
            this.tabInventoryIngredients.Controls.Add(this.tabPage8);
            this.tabInventoryIngredients.Controls.Add(this.tabPage9);
            this.tabInventoryIngredients.Location = new System.Drawing.Point(13, 13);
            this.tabInventoryIngredients.Multiline = true;
            this.tabInventoryIngredients.Name = "tabInventoryIngredients";
            this.tabInventoryIngredients.SelectedIndex = 0;
            this.tabInventoryIngredients.Size = new System.Drawing.Size(882, 416);
            this.tabInventoryIngredients.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTypeIngredient2);
            this.tabPage1.Controls.Add(this.lblTypeIngredient1);
            this.tabPage1.Controls.Add(this.pnlIngredientsType2Status);
            this.tabPage1.Controls.Add(this.lstIngredientsType2Available);
            this.tabPage1.Controls.Add(this.pnlIngredientsType1Status);
            this.tabPage1.Controls.Add(this.lstIngredientsType1Available);
            this.tabPage1.Location = new System.Drawing.Point(4, 46);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Viandes/Poissons/Crustacés";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTypeIngredient2
            // 
            this.lblTypeIngredient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeIngredient2.Location = new System.Drawing.Point(435, 13);
            this.lblTypeIngredient2.Name = "lblTypeIngredient2";
            this.lblTypeIngredient2.Size = new System.Drawing.Size(430, 20);
            this.lblTypeIngredient2.TabIndex = 7;
            this.lblTypeIngredient2.Text = "Poissons et crustacés";
            this.lblTypeIngredient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeIngredient1
            // 
            this.lblTypeIngredient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeIngredient1.Location = new System.Drawing.Point(3, 13);
            this.lblTypeIngredient1.Name = "lblTypeIngredient1";
            this.lblTypeIngredient1.Size = new System.Drawing.Size(430, 20);
            this.lblTypeIngredient1.TabIndex = 6;
            this.lblTypeIngredient1.Text = "Viandes";
            this.lblTypeIngredient1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlIngredientsType2Status
            // 
            this.pnlIngredientsType2Status.AutoScroll = true;
            this.pnlIngredientsType2Status.Location = new System.Drawing.Point(660, 46);
            this.pnlIngredientsType2Status.Name = "pnlIngredientsType2Status";
            this.pnlIngredientsType2Status.Size = new System.Drawing.Size(206, 317);
            this.pnlIngredientsType2Status.TabIndex = 5;
            // 
            // lstIngredientsType2Available
            // 
            this.lstIngredientsType2Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType2Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType2Available.FormattingEnabled = true;
            this.lstIngredientsType2Available.ItemHeight = 20;
            this.lstIngredientsType2Available.Location = new System.Drawing.Point(439, 46);
            this.lstIngredientsType2Available.Name = "lstIngredientsType2Available";
            this.lstIngredientsType2Available.Size = new System.Drawing.Size(215, 320);
            this.lstIngredientsType2Available.TabIndex = 4;
            // 
            // pnlIngredientsType1Status
            // 
            this.pnlIngredientsType1Status.AutoScroll = true;
            this.pnlIngredientsType1Status.Location = new System.Drawing.Point(227, 46);
            this.pnlIngredientsType1Status.Name = "pnlIngredientsType1Status";
            this.pnlIngredientsType1Status.Size = new System.Drawing.Size(206, 317);
            this.pnlIngredientsType1Status.TabIndex = 3;
            // 
            // lstIngredientsType1Available
            // 
            this.lstIngredientsType1Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType1Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType1Available.FormattingEnabled = true;
            this.lstIngredientsType1Available.ItemHeight = 20;
            this.lstIngredientsType1Available.Location = new System.Drawing.Point(6, 46);
            this.lstIngredientsType1Available.Name = "lstIngredientsType1Available";
            this.lstIngredientsType1Available.Size = new System.Drawing.Size(215, 320);
            this.lstIngredientsType1Available.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblTypeIngredient4);
            this.tabPage2.Controls.Add(this.lblTypeIngredient3);
            this.tabPage2.Controls.Add(this.pnlIngredientsType4Status);
            this.tabPage2.Controls.Add(this.lstIngredientsType4Available);
            this.tabPage2.Controls.Add(this.pnlIngredientsType3Status);
            this.tabPage2.Controls.Add(this.lstIngredientsType3Available);
            this.tabPage2.Location = new System.Drawing.Point(4, 46);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fruits/Légumes/Légumineuses/Champignons";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblTypeIngredient4
            // 
            this.lblTypeIngredient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeIngredient4.Location = new System.Drawing.Point(438, 7);
            this.lblTypeIngredient4.Name = "lblTypeIngredient4";
            this.lblTypeIngredient4.Size = new System.Drawing.Size(430, 20);
            this.lblTypeIngredient4.TabIndex = 11;
            this.lblTypeIngredient4.Text = "Légumes légumineuses et champignons";
            this.lblTypeIngredient4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeIngredient3
            // 
            this.lblTypeIngredient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeIngredient3.Location = new System.Drawing.Point(6, 7);
            this.lblTypeIngredient3.Name = "lblTypeIngredient3";
            this.lblTypeIngredient3.Size = new System.Drawing.Size(430, 20);
            this.lblTypeIngredient3.TabIndex = 10;
            this.lblTypeIngredient3.Text = "Fruits";
            this.lblTypeIngredient3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlIngredientsType4Status
            // 
            this.pnlIngredientsType4Status.AutoScroll = true;
            this.pnlIngredientsType4Status.Location = new System.Drawing.Point(661, 30);
            this.pnlIngredientsType4Status.Name = "pnlIngredientsType4Status";
            this.pnlIngredientsType4Status.Size = new System.Drawing.Size(206, 320);
            this.pnlIngredientsType4Status.TabIndex = 9;
            // 
            // lstIngredientsType4Available
            // 
            this.lstIngredientsType4Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType4Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType4Available.FormattingEnabled = true;
            this.lstIngredientsType4Available.ItemHeight = 20;
            this.lstIngredientsType4Available.Location = new System.Drawing.Point(440, 33);
            this.lstIngredientsType4Available.Name = "lstIngredientsType4Available";
            this.lstIngredientsType4Available.Size = new System.Drawing.Size(215, 320);
            this.lstIngredientsType4Available.TabIndex = 8;
            // 
            // pnlIngredientsType3Status
            // 
            this.pnlIngredientsType3Status.AutoScroll = true;
            this.pnlIngredientsType3Status.Location = new System.Drawing.Point(228, 30);
            this.pnlIngredientsType3Status.Name = "pnlIngredientsType3Status";
            this.pnlIngredientsType3Status.Size = new System.Drawing.Size(206, 320);
            this.pnlIngredientsType3Status.TabIndex = 7;
            // 
            // lstIngredientsType3Available
            // 
            this.lstIngredientsType3Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType3Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType3Available.FormattingEnabled = true;
            this.lstIngredientsType3Available.ItemHeight = 20;
            this.lstIngredientsType3Available.Location = new System.Drawing.Point(7, 33);
            this.lstIngredientsType3Available.Name = "lstIngredientsType3Available";
            this.lstIngredientsType3Available.Size = new System.Drawing.Size(215, 320);
            this.lstIngredientsType3Available.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pnlIngredientsType5Status);
            this.tabPage3.Controls.Add(this.lstIngredientsType5Available);
            this.tabPage3.Location = new System.Drawing.Point(4, 46);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(874, 366);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Produits laitiers/Oeufs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlIngredientsType5Status
            // 
            this.pnlIngredientsType5Status.AutoScroll = true;
            this.pnlIngredientsType5Status.Location = new System.Drawing.Point(445, 13);
            this.pnlIngredientsType5Status.Name = "pnlIngredientsType5Status";
            this.pnlIngredientsType5Status.Size = new System.Drawing.Size(206, 337);
            this.pnlIngredientsType5Status.TabIndex = 9;
            // 
            // lstIngredientsType5Available
            // 
            this.lstIngredientsType5Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType5Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType5Available.FormattingEnabled = true;
            this.lstIngredientsType5Available.ItemHeight = 20;
            this.lstIngredientsType5Available.Location = new System.Drawing.Point(224, 13);
            this.lstIngredientsType5Available.Name = "lstIngredientsType5Available";
            this.lstIngredientsType5Available.Size = new System.Drawing.Size(215, 340);
            this.lstIngredientsType5Available.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pnlIngredientsType6Status);
            this.tabPage4.Controls.Add(this.lstIngredientsType6Available);
            this.tabPage4.Location = new System.Drawing.Point(4, 46);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(874, 366);
            this.tabPage4.TabIndex = 8;
            this.tabPage4.Text = "Céréales/Féculents";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pnlIngredientsType6Status
            // 
            this.pnlIngredientsType6Status.AutoScroll = true;
            this.pnlIngredientsType6Status.Location = new System.Drawing.Point(445, 13);
            this.pnlIngredientsType6Status.Name = "pnlIngredientsType6Status";
            this.pnlIngredientsType6Status.Size = new System.Drawing.Size(206, 337);
            this.pnlIngredientsType6Status.TabIndex = 11;
            // 
            // lstIngredientsType6Available
            // 
            this.lstIngredientsType6Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType6Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType6Available.FormattingEnabled = true;
            this.lstIngredientsType6Available.ItemHeight = 20;
            this.lstIngredientsType6Available.Location = new System.Drawing.Point(224, 13);
            this.lstIngredientsType6Available.Name = "lstIngredientsType6Available";
            this.lstIngredientsType6Available.Size = new System.Drawing.Size(215, 340);
            this.lstIngredientsType6Available.TabIndex = 10;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pnlIngredientsType7Status);
            this.tabPage5.Controls.Add(this.lstIngredientsType7Available);
            this.tabPage5.Location = new System.Drawing.Point(4, 46);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(874, 366);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Epices/Herbes/Condiments";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pnlIngredientsType7Status
            // 
            this.pnlIngredientsType7Status.AutoScroll = true;
            this.pnlIngredientsType7Status.Location = new System.Drawing.Point(445, 13);
            this.pnlIngredientsType7Status.Name = "pnlIngredientsType7Status";
            this.pnlIngredientsType7Status.Size = new System.Drawing.Size(206, 337);
            this.pnlIngredientsType7Status.TabIndex = 13;
            // 
            // lstIngredientsType7Available
            // 
            this.lstIngredientsType7Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType7Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType7Available.FormattingEnabled = true;
            this.lstIngredientsType7Available.ItemHeight = 20;
            this.lstIngredientsType7Available.Location = new System.Drawing.Point(224, 13);
            this.lstIngredientsType7Available.Name = "lstIngredientsType7Available";
            this.lstIngredientsType7Available.Size = new System.Drawing.Size(215, 340);
            this.lstIngredientsType7Available.TabIndex = 12;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pnlIngredientsType8Status);
            this.tabPage6.Controls.Add(this.lstIngredientsType8Available);
            this.tabPage6.Location = new System.Drawing.Point(4, 46);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(874, 366);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Noix/Graines";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pnlIngredientsType8Status
            // 
            this.pnlIngredientsType8Status.AutoScroll = true;
            this.pnlIngredientsType8Status.Location = new System.Drawing.Point(445, 13);
            this.pnlIngredientsType8Status.Name = "pnlIngredientsType8Status";
            this.pnlIngredientsType8Status.Size = new System.Drawing.Size(206, 337);
            this.pnlIngredientsType8Status.TabIndex = 15;
            // 
            // lstIngredientsType8Available
            // 
            this.lstIngredientsType8Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType8Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType8Available.FormattingEnabled = true;
            this.lstIngredientsType8Available.ItemHeight = 20;
            this.lstIngredientsType8Available.Location = new System.Drawing.Point(224, 13);
            this.lstIngredientsType8Available.Name = "lstIngredientsType8Available";
            this.lstIngredientsType8Available.Size = new System.Drawing.Size(215, 340);
            this.lstIngredientsType8Available.TabIndex = 14;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.pnlIngredientsType9Status);
            this.tabPage7.Controls.Add(this.lstIngredientsType9Available);
            this.tabPage7.Location = new System.Drawing.Point(4, 46);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(874, 366);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Huiles/Graisses";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // pnlIngredientsType9Status
            // 
            this.pnlIngredientsType9Status.AutoScroll = true;
            this.pnlIngredientsType9Status.Location = new System.Drawing.Point(445, 13);
            this.pnlIngredientsType9Status.Name = "pnlIngredientsType9Status";
            this.pnlIngredientsType9Status.Size = new System.Drawing.Size(206, 337);
            this.pnlIngredientsType9Status.TabIndex = 17;
            // 
            // lstIngredientsType9Available
            // 
            this.lstIngredientsType9Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType9Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType9Available.FormattingEnabled = true;
            this.lstIngredientsType9Available.ItemHeight = 20;
            this.lstIngredientsType9Available.Location = new System.Drawing.Point(224, 13);
            this.lstIngredientsType9Available.Name = "lstIngredientsType9Available";
            this.lstIngredientsType9Available.Size = new System.Drawing.Size(215, 340);
            this.lstIngredientsType9Available.TabIndex = 16;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.pnlIngredientsType10Status);
            this.tabPage8.Controls.Add(this.lstIngredientsType10Available);
            this.tabPage8.Location = new System.Drawing.Point(4, 46);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(874, 366);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Produits boulangerie/pâtisserie";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // pnlIngredientsType10Status
            // 
            this.pnlIngredientsType10Status.AutoScroll = true;
            this.pnlIngredientsType10Status.Location = new System.Drawing.Point(445, 13);
            this.pnlIngredientsType10Status.Name = "pnlIngredientsType10Status";
            this.pnlIngredientsType10Status.Size = new System.Drawing.Size(206, 337);
            this.pnlIngredientsType10Status.TabIndex = 19;
            // 
            // lstIngredientsType10Available
            // 
            this.lstIngredientsType10Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType10Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType10Available.FormattingEnabled = true;
            this.lstIngredientsType10Available.ItemHeight = 20;
            this.lstIngredientsType10Available.Location = new System.Drawing.Point(224, 13);
            this.lstIngredientsType10Available.Name = "lstIngredientsType10Available";
            this.lstIngredientsType10Available.Size = new System.Drawing.Size(215, 340);
            this.lstIngredientsType10Available.TabIndex = 18;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.lblTypeIngredient12);
            this.tabPage9.Controls.Add(this.lblTypeIngredient11);
            this.tabPage9.Controls.Add(this.pnlIngredientsType12Status);
            this.tabPage9.Controls.Add(this.lstIngredientsType12Available);
            this.tabPage9.Controls.Add(this.pnlIngredientsType11Status);
            this.tabPage9.Controls.Add(this.lstIngredientsType11Available);
            this.tabPage9.Location = new System.Drawing.Point(4, 46);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(874, 366);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "Alcool/spiritueux/sauces/eau";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // lblTypeIngredient12
            // 
            this.lblTypeIngredient12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeIngredient12.Location = new System.Drawing.Point(436, 10);
            this.lblTypeIngredient12.Name = "lblTypeIngredient12";
            this.lblTypeIngredient12.Size = new System.Drawing.Size(430, 20);
            this.lblTypeIngredient12.TabIndex = 13;
            this.lblTypeIngredient12.Text = "Sauces et eau";
            this.lblTypeIngredient12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeIngredient11
            // 
            this.lblTypeIngredient11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeIngredient11.Location = new System.Drawing.Point(4, 10);
            this.lblTypeIngredient11.Name = "lblTypeIngredient11";
            this.lblTypeIngredient11.Size = new System.Drawing.Size(430, 20);
            this.lblTypeIngredient11.TabIndex = 12;
            this.lblTypeIngredient11.Text = "Alcool et spiritueux";
            this.lblTypeIngredient11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlIngredientsType12Status
            // 
            this.pnlIngredientsType12Status.AutoScroll = true;
            this.pnlIngredientsType12Status.Location = new System.Drawing.Point(661, 53);
            this.pnlIngredientsType12Status.Name = "pnlIngredientsType12Status";
            this.pnlIngredientsType12Status.Size = new System.Drawing.Size(206, 297);
            this.pnlIngredientsType12Status.TabIndex = 9;
            // 
            // lstIngredientsType12Available
            // 
            this.lstIngredientsType12Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType12Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType12Available.FormattingEnabled = true;
            this.lstIngredientsType12Available.ItemHeight = 20;
            this.lstIngredientsType12Available.Location = new System.Drawing.Point(440, 53);
            this.lstIngredientsType12Available.Name = "lstIngredientsType12Available";
            this.lstIngredientsType12Available.Size = new System.Drawing.Size(215, 300);
            this.lstIngredientsType12Available.TabIndex = 8;
            // 
            // pnlIngredientsType11Status
            // 
            this.pnlIngredientsType11Status.AutoScroll = true;
            this.pnlIngredientsType11Status.Location = new System.Drawing.Point(228, 53);
            this.pnlIngredientsType11Status.Name = "pnlIngredientsType11Status";
            this.pnlIngredientsType11Status.Size = new System.Drawing.Size(206, 297);
            this.pnlIngredientsType11Status.TabIndex = 7;
            // 
            // lstIngredientsType11Available
            // 
            this.lstIngredientsType11Available.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIngredientsType11Available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIngredientsType11Available.FormattingEnabled = true;
            this.lstIngredientsType11Available.ItemHeight = 20;
            this.lstIngredientsType11Available.Location = new System.Drawing.Point(7, 53);
            this.lstIngredientsType11Available.Name = "lstIngredientsType11Available";
            this.lstIngredientsType11Available.Size = new System.Drawing.Size(215, 300);
            this.lstIngredientsType11Available.TabIndex = 6;
            // 
            // lblNbOfIngredientsStored
            // 
            this.lblNbOfIngredientsStored.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbOfIngredientsStored.Location = new System.Drawing.Point(622, 450);
            this.lblNbOfIngredientsStored.Name = "lblNbOfIngredientsStored";
            this.lblNbOfIngredientsStored.Size = new System.Drawing.Size(269, 23);
            this.lblNbOfIngredientsStored.TabIndex = 4;
            this.lblNbOfIngredientsStored.Text = "Nombre d\'ingrédients stockés : ";
            // 
            // cmdAddNewIngredientIntoDB
            // 
            this.cmdAddNewIngredientIntoDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdAddNewIngredientIntoDB.BackgroundImage")));
            this.cmdAddNewIngredientIntoDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdAddNewIngredientIntoDB.FlatAppearance.BorderSize = 0;
            this.cmdAddNewIngredientIntoDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddNewIngredientIntoDB.Location = new System.Drawing.Point(399, 444);
            this.cmdAddNewIngredientIntoDB.Name = "cmdAddNewIngredientIntoDB";
            this.cmdAddNewIngredientIntoDB.Size = new System.Drawing.Size(40, 35);
            this.cmdAddNewIngredientIntoDB.TabIndex = 25;
            this.cmdAddNewIngredientIntoDB.UseVisualStyleBackColor = true;
            this.cmdAddNewIngredientIntoDB.Click += new System.EventHandler(this.cmdAddNewIngredientIntoDB_Click);
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 486);
            this.Controls.Add(this.cmdAddNewIngredientIntoDB);
            this.Controls.Add(this.lblNbOfIngredientsStored);
            this.Controls.Add(this.tabInventoryIngredients);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventaire des ingrédients";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventory_FormClosed);
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.tabInventoryIngredients.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.TabControl tabInventoryIngredients;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlIngredientsType1Status;
        private System.Windows.Forms.ListBox lstIngredientsType1Available;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pnlIngredientsType2Status;
        private System.Windows.Forms.ListBox lstIngredientsType2Available;
        private System.Windows.Forms.Panel pnlIngredientsType4Status;
        private System.Windows.Forms.ListBox lstIngredientsType4Available;
        private System.Windows.Forms.Panel pnlIngredientsType3Status;
        private System.Windows.Forms.ListBox lstIngredientsType3Available;
        private System.Windows.Forms.Panel pnlIngredientsType5Status;
        private System.Windows.Forms.ListBox lstIngredientsType5Available;
        private System.Windows.Forms.Panel pnlIngredientsType6Status;
        private System.Windows.Forms.ListBox lstIngredientsType6Available;
        private System.Windows.Forms.Panel pnlIngredientsType7Status;
        private System.Windows.Forms.ListBox lstIngredientsType7Available;
        private System.Windows.Forms.Panel pnlIngredientsType8Status;
        private System.Windows.Forms.ListBox lstIngredientsType8Available;
        private System.Windows.Forms.Panel pnlIngredientsType9Status;
        private System.Windows.Forms.ListBox lstIngredientsType9Available;
        private System.Windows.Forms.Panel pnlIngredientsType10Status;
        private System.Windows.Forms.ListBox lstIngredientsType10Available;
        private System.Windows.Forms.Panel pnlIngredientsType12Status;
        private System.Windows.Forms.ListBox lstIngredientsType12Available;
        private System.Windows.Forms.Panel pnlIngredientsType11Status;
        private System.Windows.Forms.ListBox lstIngredientsType11Available;
        private System.Windows.Forms.Label lblNbOfIngredientsStored;
        private System.Windows.Forms.Label lblTypeIngredient1;
        private System.Windows.Forms.Label lblTypeIngredient2;
        private System.Windows.Forms.Label lblTypeIngredient4;
        private System.Windows.Forms.Label lblTypeIngredient3;
        private System.Windows.Forms.Label lblTypeIngredient12;
        private System.Windows.Forms.Label lblTypeIngredient11;
        private System.Windows.Forms.Button cmdAddNewIngredientIntoDB;
    }
}