namespace Recipe_Writer
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.picMenu = new System.Windows.Forms.PictureBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlMealsPlanner = new System.Windows.Forms.Panel();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.pnlSearchByIngredients = new System.Windows.Forms.Panel();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.pnlInstructions = new System.Windows.Forms.Panel();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.lblPortions = new System.Windows.Forms.Label();
            this.chkWritingAssistance = new System.Windows.Forms.CheckBox();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.cmbRecipeIngredients = new System.Windows.Forms.ComboBox();
            this.lblComplettionTime = new System.Windows.Forms.Label();
            this.ofdAssociatedImage = new System.Windows.Forms.OpenFileDialog();
            this.cmdTitleSearch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picScore = new System.Windows.Forms.PictureBox();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.cmdDeleteRecipe = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdExportHtml = new System.Windows.Forms.Button();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            this.pnlSideMenu.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSideMenu.Controls.Add(this.pnlMenu);
            this.pnlSideMenu.Location = new System.Drawing.Point(12, 112);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(68, 331);
            this.pnlSideMenu.TabIndex = 8;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.picMenu);
            this.pnlMenu.Controls.Add(this.pnlSettings);
            this.pnlMenu.Controls.Add(this.pnlMealsPlanner);
            this.pnlMenu.Controls.Add(this.pnlInventory);
            this.pnlMenu.Controls.Add(this.pnlSearchByIngredients);
            this.pnlMenu.Location = new System.Drawing.Point(-1, -1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(68, 327);
            this.pnlMenu.TabIndex = 0;
            // 
            // picMenu
            // 
            this.picMenu.BackgroundImage = global::Recipe_Writer.Properties.Resources.side_menu;
            this.picMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMenu.Location = new System.Drawing.Point(5, 9);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(59, 50);
            this.picMenu.TabIndex = 5;
            this.picMenu.TabStop = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSettings.BackgroundImage")));
            this.pnlSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlSettings.Location = new System.Drawing.Point(5, 269);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(59, 50);
            this.pnlSettings.TabIndex = 1;
            // 
            // pnlMealsPlanner
            // 
            this.pnlMealsPlanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMealsPlanner.BackgroundImage")));
            this.pnlMealsPlanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlMealsPlanner.Location = new System.Drawing.Point(5, 203);
            this.pnlMealsPlanner.Name = "pnlMealsPlanner";
            this.pnlMealsPlanner.Size = new System.Drawing.Size(59, 50);
            this.pnlMealsPlanner.TabIndex = 2;
            // 
            // pnlInventory
            // 
            this.pnlInventory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlInventory.BackgroundImage")));
            this.pnlInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlInventory.Location = new System.Drawing.Point(5, 134);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(59, 50);
            this.pnlInventory.TabIndex = 3;
            // 
            // pnlSearchByIngredients
            // 
            this.pnlSearchByIngredients.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSearchByIngredients.BackgroundImage")));
            this.pnlSearchByIngredients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlSearchByIngredients.Location = new System.Drawing.Point(5, 69);
            this.pnlSearchByIngredients.Name = "pnlSearchByIngredients";
            this.pnlSearchByIngredients.Size = new System.Drawing.Size(59, 50);
            this.pnlSearchByIngredients.TabIndex = 4;
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(261, 40);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(571, 27);
            this.txtTitleSearch.TabIndex = 2;
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.Location = new System.Drawing.Point(100, 83);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(264, 26);
            this.lblSearchResults.TabIndex = 0;
            this.lblSearchResults.Text = "Résultats de la recherche :";
            // 
            // pnlInstructions
            // 
            this.pnlInstructions.AutoScroll = true;
            this.pnlInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInstructions.Location = new System.Drawing.Point(104, 330);
            this.pnlInstructions.Name = "pnlInstructions";
            this.pnlInstructions.Size = new System.Drawing.Size(1056, 354);
            this.pnlInstructions.TabIndex = 4;
            // 
            // nudPersons
            // 
            this.nudPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPersons.Location = new System.Drawing.Point(126, 278);
            this.nudPersons.Name = "nudPersons";
            this.nudPersons.Size = new System.Drawing.Size(46, 27);
            this.nudPersons.TabIndex = 5;
            this.nudPersons.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblPortions
            // 
            this.lblPortions.AutoSize = true;
            this.lblPortions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortions.Location = new System.Drawing.Point(178, 287);
            this.lblPortions.Name = "lblPortions";
            this.lblPortions.Size = new System.Drawing.Size(62, 18);
            this.lblPortions.TabIndex = 10;
            this.lblPortions.Text = "portions";
            // 
            // chkWritingAssistance
            // 
            this.chkWritingAssistance.AutoSize = true;
            this.chkWritingAssistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWritingAssistance.Location = new System.Drawing.Point(271, 286);
            this.chkWritingAssistance.Name = "chkWritingAssistance";
            this.chkWritingAssistance.Size = new System.Drawing.Size(127, 22);
            this.chkWritingAssistance.TabIndex = 6;
            this.chkWritingAssistance.Text = "Aide à la saisie";
            this.chkWritingAssistance.UseVisualStyleBackColor = true;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 16;
            this.lstSearchResults.Location = new System.Drawing.Point(104, 112);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(814, 100);
            this.lstSearchResults.TabIndex = 4;
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            // 
            // cmbRecipeIngredients
            // 
            this.cmbRecipeIngredients.FormattingEnabled = true;
            this.cmbRecipeIngredients.Location = new System.Drawing.Point(655, 287);
            this.cmbRecipeIngredients.Name = "cmbRecipeIngredients";
            this.cmbRecipeIngredients.Size = new System.Drawing.Size(199, 24);
            this.cmbRecipeIngredients.TabIndex = 11;
            this.cmbRecipeIngredients.Text = "Liste des ingrédients utilisés";
            // 
            // lblComplettionTime
            // 
            this.lblComplettionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplettionTime.Location = new System.Drawing.Point(410, 287);
            this.lblComplettionTime.Name = "lblComplettionTime";
            this.lblComplettionTime.Size = new System.Drawing.Size(225, 19);
            this.lblComplettionTime.TabIndex = 10;
            this.lblComplettionTime.Text = "Temps de réalisation : ";
            // 
            // ofdAssociatedImage
            // 
            this.ofdAssociatedImage.DefaultExt = "\"Tous les types d\'images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff\"";
            this.ofdAssociatedImage.FileName = "openFileDialog1";
            this.ofdAssociatedImage.Filter = "jpg|*.jpg;*.jpeg|png|*.png|bmp|*.bmp|gif|*.gif|tiff|*.tif;*.tiff|Tous les types d" +
    "\'images|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff";
            this.ofdAssociatedImage.FilterIndex = 6;
            this.ofdAssociatedImage.InitialDirectory = "@\"C:\\\"";
            this.ofdAssociatedImage.Title = "Associer une image d\'illustration à cette recette";
            // 
            // cmdTitleSearch
            // 
            this.cmdTitleSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdTitleSearch.BackgroundImage")));
            this.cmdTitleSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdTitleSearch.FlatAppearance.BorderSize = 0;
            this.cmdTitleSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTitleSearch.Location = new System.Drawing.Point(847, 35);
            this.cmdTitleSearch.Name = "cmdTitleSearch";
            this.cmdTitleSearch.Size = new System.Drawing.Size(40, 40);
            this.cmdTitleSearch.TabIndex = 3;
            this.cmdTitleSearch.UseVisualStyleBackColor = true;
            this.cmdTitleSearch.Click += new System.EventHandler(this.cmdTitleSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(879, 284);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 30);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // picScore
            // 
            this.picScore.Image = global::Recipe_Writer.Properties.Resources._3_stars;
            this.picScore.Location = new System.Drawing.Point(1007, 231);
            this.picScore.Name = "picScore";
            this.picScore.Size = new System.Drawing.Size(102, 26);
            this.picScore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScore.TabIndex = 6;
            this.picScore.TabStop = false;
            // 
            // picRecipe
            // 
            this.picRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRecipe.Location = new System.Drawing.Point(960, 25);
            this.picRecipe.Name = "picRecipe";
            this.picRecipe.Size = new System.Drawing.Size(200, 200);
            this.picRecipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRecipe.TabIndex = 2;
            this.picRecipe.TabStop = false;
            this.picRecipe.Click += new System.EventHandler(this.picRecipe_Click);
            // 
            // cmdDeleteRecipe
            // 
            this.cmdDeleteRecipe.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdDeleteRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDeleteRecipe.FlatAppearance.BorderSize = 0;
            this.cmdDeleteRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDeleteRecipe.Location = new System.Drawing.Point(882, 227);
            this.cmdDeleteRecipe.Name = "cmdDeleteRecipe";
            this.cmdDeleteRecipe.Size = new System.Drawing.Size(30, 30);
            this.cmdDeleteRecipe.TabIndex = 6;
            this.cmdDeleteRecipe.UseVisualStyleBackColor = true;
            // 
            // cmdBack
            // 
            this.cmdBack.BackgroundImage = global::Recipe_Writer.Properties.Resources.previous_recipe;
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(188, 30);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(50, 50);
            this.cmdBack.TabIndex = 1;
            this.cmdBack.UseVisualStyleBackColor = true;
            // 
            // cmdExportHtml
            // 
            this.cmdExportHtml.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExportHtml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdExportHtml.FlatAppearance.BorderSize = 0;
            this.cmdExportHtml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportHtml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportHtml.Image = ((System.Drawing.Image)(resources.GetObject("cmdExportHtml.Image")));
            this.cmdExportHtml.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.cmdExportHtml.Location = new System.Drawing.Point(753, 227);
            this.cmdExportHtml.Name = "cmdExportHtml";
            this.cmdExportHtml.Size = new System.Drawing.Size(121, 30);
            this.cmdExportHtml.TabIndex = 5;
            this.cmdExportHtml.Text = "Exporter";
            this.cmdExportHtml.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdExportHtml.UseVisualStyleBackColor = false;
            // 
            // cmdNewRecipe
            // 
            this.cmdNewRecipe.BackgroundImage = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.cmdNewRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNewRecipe.FlatAppearance.BorderSize = 0;
            this.cmdNewRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNewRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewRecipe.Location = new System.Drawing.Point(127, 30);
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.cmdNewRecipe.Size = new System.Drawing.Size(50, 50);
            this.cmdNewRecipe.TabIndex = 0;
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdTitleSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 709);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbRecipeIngredients);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.chkWritingAssistance);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.nudPersons);
            this.Controls.Add(this.lblComplettionTime);
            this.Controls.Add(this.lblPortions);
            this.Controls.Add(this.picScore);
            this.Controls.Add(this.pnlInstructions);
            this.Controls.Add(this.picRecipe);
            this.Controls.Add(this.cmdDeleteRecipe);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdExportHtml);
            this.Controls.Add(this.cmdNewRecipe);
            this.Controls.Add(this.cmdTitleSearch);
            this.Controls.Add(this.txtTitleSearch);
            this.Controls.Add(this.pnlSideMenu);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe Writer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.Button cmdTitleSearch;
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlInstructions;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button cmdNewRecipe;
        private System.Windows.Forms.Button cmdDeleteRecipe;
        private System.Windows.Forms.PictureBox picScore;
        private System.Windows.Forms.NumericUpDown nudPersons;
        private System.Windows.Forms.Label lblPortions;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdExportHtml;
        private System.Windows.Forms.CheckBox chkWritingAssistance;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbRecipeIngredients;
        private System.Windows.Forms.Label lblComplettionTime;
        private System.Windows.Forms.OpenFileDialog ofdAssociatedImage;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Panel pnlMealsPlanner;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Panel pnlSearchByIngredients;
        private System.Windows.Forms.PictureBox picMenu;
    }
}

