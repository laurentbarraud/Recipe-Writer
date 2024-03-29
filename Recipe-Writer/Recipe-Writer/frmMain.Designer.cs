﻿namespace Recipe_Writer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.pnlInstructions = new System.Windows.Forms.Panel();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.lblPortions = new System.Windows.Forms.Label();
            this.chkWritingAssistance = new System.Windows.Forms.CheckBox();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.cmsRecipeResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nouvelleRecetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerCetteRecetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterCetteRecetteEnHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbRecipeIngredients = new System.Windows.Forms.ComboBox();
            this.lblCompletionTime = new System.Windows.Forms.Label();
            this.ofdAssociatedImage = new System.Windows.Forms.OpenFileDialog();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.picSettings = new System.Windows.Forms.PictureBox();
            this.pnlMealsPlanner = new System.Windows.Forms.Panel();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.pnlSearchByIngredients = new System.Windows.Forms.Panel();
            this.pnlSlideMenu = new System.Windows.Forms.Panel();
            this.picClosePanel = new System.Windows.Forms.PictureBox();
            this.chkInverseSearch = new System.Windows.Forms.CheckBox();
            this.lblSearchByIngredients = new System.Windows.Forms.Label();
            this.lblSearchIngredient3 = new System.Windows.Forms.Label();
            this.lblSearchIngredient2 = new System.Windows.Forms.Label();
            this.lblSearchIngredient1 = new System.Windows.Forms.Label();
            this.txtSearchIngredient3 = new System.Windows.Forms.TextBox();
            this.txtSearchIngredient2 = new System.Windows.Forms.TextBox();
            this.txtSearchIngredient1 = new System.Windows.Forms.TextBox();
            this.cmdIngredientsSearch = new System.Windows.Forms.Button();
            this.pnlScore = new System.Windows.Forms.Panel();
            this.picScore3 = new System.Windows.Forms.PictureBox();
            this.picScore2 = new System.Windows.Forms.PictureBox();
            this.picScore1 = new System.Windows.Forms.PictureBox();
            this.cmdTitleSearch = new System.Windows.Forms.Button();
            this.cmdAddInstruction = new System.Windows.Forms.Button();
            this.cmdDeleteIngredient = new System.Windows.Forms.Button();
            this.picMenu = new System.Windows.Forms.PictureBox();
            this.picLowBudget = new System.Windows.Forms.PictureBox();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            this.cmsRecipeResult.SuspendLayout();
            this.pnlSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).BeginInit();
            this.pnlSlideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClosePanel)).BeginInit();
            this.pnlScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(252, 40);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(571, 27);
            this.txtTitleSearch.TabIndex = 0;
            this.txtTitleSearch.Enter += new System.EventHandler(this.txtTitleSearch_Enter);
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.Location = new System.Drawing.Point(104, 98);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(208, 28);
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
            this.pnlInstructions.TabIndex = 17;
            // 
            // nudPersons
            // 
            this.nudPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPersons.Location = new System.Drawing.Point(126, 278);
            this.nudPersons.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPersons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPersons.Name = "nudPersons";
            this.nudPersons.Size = new System.Drawing.Size(46, 27);
            this.nudPersons.TabIndex = 5;
            this.nudPersons.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPersons.Visible = false;
            this.nudPersons.ValueChanged += new System.EventHandler(this.nudPersons_ValueChanged);
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
            this.lblPortions.Visible = false;
            // 
            // chkWritingAssistance
            // 
            this.chkWritingAssistance.AutoSize = true;
            this.chkWritingAssistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWritingAssistance.Location = new System.Drawing.Point(259, 286);
            this.chkWritingAssistance.Name = "chkWritingAssistance";
            this.chkWritingAssistance.Size = new System.Drawing.Size(127, 22);
            this.chkWritingAssistance.TabIndex = 6;
            this.chkWritingAssistance.Text = "Aide à la saisie";
            this.chkWritingAssistance.UseVisualStyleBackColor = true;
            this.chkWritingAssistance.Visible = false;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.ContextMenuStrip = this.cmsRecipeResult;
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 16;
            this.lstSearchResults.Location = new System.Drawing.Point(104, 128);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(814, 84);
            this.lstSearchResults.TabIndex = 4;
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            this.lstSearchResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseMove);
            // 
            // cmsRecipeResult
            // 
            this.cmsRecipeResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRecipeResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouvelleRecetteToolStripMenuItem,
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem,
            this.supprimerCetteRecetteToolStripMenuItem,
            this.exporterCetteRecetteEnHTMLToolStripMenuItem});
            this.cmsRecipeResult.Name = "cmsRecipeResult";
            this.cmsRecipeResult.Size = new System.Drawing.Size(295, 108);
            // 
            // nouvelleRecetteToolStripMenuItem
            // 
            this.nouvelleRecetteToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.nouvelleRecetteToolStripMenuItem.Name = "nouvelleRecetteToolStripMenuItem";
            this.nouvelleRecetteToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            this.nouvelleRecetteToolStripMenuItem.Text = "Nouvelle recette";
            this.nouvelleRecetteToolStripMenuItem.Click += new System.EventHandler(this.nouvelleRecetteToolStripMenuItem_Click);
            // 
            // modifierLeTitreDeCetteRecetteToolStripMenuItem
            // 
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem.Enabled = false;
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.edit_recipe_title;
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem.Name = "modifierLeTitreDeCetteRecetteToolStripMenuItem";
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem.Text = "Modifier le titre de cette recette";
            this.modifierLeTitreDeCetteRecetteToolStripMenuItem.Click += new System.EventHandler(this.modifierLeTitreDeCetteRecetteToolStripMenuItem_Click);
            // 
            // supprimerCetteRecetteToolStripMenuItem
            // 
            this.supprimerCetteRecetteToolStripMenuItem.Enabled = false;
            this.supprimerCetteRecetteToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.delete_recipe;
            this.supprimerCetteRecetteToolStripMenuItem.Name = "supprimerCetteRecetteToolStripMenuItem";
            this.supprimerCetteRecetteToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            this.supprimerCetteRecetteToolStripMenuItem.Text = "Supprimer cette recette";
            // 
            // exporterCetteRecetteEnHTMLToolStripMenuItem
            // 
            this.exporterCetteRecetteEnHTMLToolStripMenuItem.Enabled = false;
            this.exporterCetteRecetteEnHTMLToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.export_to_html;
            this.exporterCetteRecetteEnHTMLToolStripMenuItem.Name = "exporterCetteRecetteEnHTMLToolStripMenuItem";
            this.exporterCetteRecetteEnHTMLToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            this.exporterCetteRecetteEnHTMLToolStripMenuItem.Text = "Exporter cette recette en HTML";
            // 
            // cmbRecipeIngredients
            // 
            this.cmbRecipeIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRecipeIngredients.FormattingEnabled = true;
            this.cmbRecipeIngredients.Location = new System.Drawing.Point(651, 286);
            this.cmbRecipeIngredients.Name = "cmbRecipeIngredients";
            this.cmbRecipeIngredients.Size = new System.Drawing.Size(232, 24);
            this.cmbRecipeIngredients.TabIndex = 16;
            this.cmbRecipeIngredients.Visible = false;
            this.cmbRecipeIngredients.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeIngredients_SelectedIndexChanged);
            // 
            // lblCompletionTime
            // 
            this.lblCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletionTime.Location = new System.Drawing.Point(392, 287);
            this.lblCompletionTime.Name = "lblCompletionTime";
            this.lblCompletionTime.Size = new System.Drawing.Size(253, 24);
            this.lblCompletionTime.TabIndex = 10;
            this.lblCompletionTime.Visible = false;
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
            // pnlSideMenu
            // 
            this.pnlSideMenu.Controls.Add(this.picSettings);
            this.pnlSideMenu.Controls.Add(this.pnlMealsPlanner);
            this.pnlSideMenu.Controls.Add(this.pnlInventory);
            this.pnlSideMenu.Controls.Add(this.pnlSearchByIngredients);
            this.pnlSideMenu.Location = new System.Drawing.Point(1, 184);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(79, 278);
            this.pnlSideMenu.TabIndex = 18;
            this.pnlSideMenu.Visible = false;
            // 
            // picSettings
            // 
            this.picSettings.BackgroundImage = global::Recipe_Writer.Properties.Resources.settings;
            this.picSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSettings.Location = new System.Drawing.Point(8, 218);
            this.picSettings.Name = "picSettings";
            this.picSettings.Size = new System.Drawing.Size(60, 50);
            this.picSettings.TabIndex = 22;
            this.picSettings.TabStop = false;
            this.picSettings.Click += new System.EventHandler(this.picSettings_Click);
            // 
            // pnlMealsPlanner
            // 
            this.pnlMealsPlanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMealsPlanner.BackgroundImage")));
            this.pnlMealsPlanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlMealsPlanner.Location = new System.Drawing.Point(10, 147);
            this.pnlMealsPlanner.Name = "pnlMealsPlanner";
            this.pnlMealsPlanner.Size = new System.Drawing.Size(59, 50);
            this.pnlMealsPlanner.TabIndex = 19;
            this.pnlMealsPlanner.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMealsPlanner_MouseClick);
            this.pnlMealsPlanner.MouseHover += new System.EventHandler(this.pnlMealsPlanner_MouseHover);
            // 
            // pnlInventory
            // 
            this.pnlInventory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlInventory.BackgroundImage")));
            this.pnlInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlInventory.Location = new System.Drawing.Point(10, 84);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(59, 50);
            this.pnlInventory.TabIndex = 20;
            this.pnlInventory.Click += new System.EventHandler(this.pnlInventory_Click);
            this.pnlInventory.MouseHover += new System.EventHandler(this.pnlInventory_MouseHover);
            // 
            // pnlSearchByIngredients
            // 
            this.pnlSearchByIngredients.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSearchByIngredients.BackgroundImage")));
            this.pnlSearchByIngredients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlSearchByIngredients.Location = new System.Drawing.Point(10, 19);
            this.pnlSearchByIngredients.Name = "pnlSearchByIngredients";
            this.pnlSearchByIngredients.Size = new System.Drawing.Size(59, 50);
            this.pnlSearchByIngredients.TabIndex = 21;
            this.pnlSearchByIngredients.MouseHover += new System.EventHandler(this.pnlSearchByIngredients_MouseHover);
            // 
            // pnlSlideMenu
            // 
            this.pnlSlideMenu.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSlideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSlideMenu.Controls.Add(this.picClosePanel);
            this.pnlSlideMenu.Controls.Add(this.chkInverseSearch);
            this.pnlSlideMenu.Controls.Add(this.lblSearchByIngredients);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient3);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient2);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient1);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient3);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient2);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient1);
            this.pnlSlideMenu.Controls.Add(this.cmdIngredientsSearch);
            this.pnlSlideMenu.Location = new System.Drawing.Point(86, 128);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(529, 334);
            this.pnlSlideMenu.TabIndex = 19;
            this.pnlSlideMenu.Visible = false;
            // 
            // picClosePanel
            // 
            this.picClosePanel.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.picClosePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picClosePanel.Location = new System.Drawing.Point(461, 3);
            this.picClosePanel.Name = "picClosePanel";
            this.picClosePanel.Size = new System.Drawing.Size(39, 23);
            this.picClosePanel.TabIndex = 22;
            this.picClosePanel.TabStop = false;
            this.picClosePanel.Click += new System.EventHandler(this.picClosePanel_Click);
            // 
            // chkInverseSearch
            // 
            this.chkInverseSearch.AutoSize = true;
            this.chkInverseSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInverseSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInverseSearch.Location = new System.Drawing.Point(136, 231);
            this.chkInverseSearch.Name = "chkInverseSearch";
            this.chkInverseSearch.Size = new System.Drawing.Size(217, 22);
            this.chkInverseSearch.TabIndex = 7;
            this.chkInverseSearch.Text = "Exclusion de ces ingrédients";
            this.chkInverseSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInverseSearch.UseVisualStyleBackColor = true;
            // 
            // lblSearchByIngredients
            // 
            this.lblSearchByIngredients.AutoSize = true;
            this.lblSearchByIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchByIngredients.Location = new System.Drawing.Point(132, 29);
            this.lblSearchByIngredients.Name = "lblSearchByIngredients";
            this.lblSearchByIngredients.Size = new System.Drawing.Size(180, 18);
            this.lblSearchByIngredients.TabIndex = 20;
            this.lblSearchByIngredients.Text = "Recherche par ingrédients";
            // 
            // lblSearchIngredient3
            // 
            this.lblSearchIngredient3.AutoSize = true;
            this.lblSearchIngredient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIngredient3.Location = new System.Drawing.Point(37, 174);
            this.lblSearchIngredient3.Name = "lblSearchIngredient3";
            this.lblSearchIngredient3.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient3.TabIndex = 13;
            this.lblSearchIngredient3.Text = "Ingrédient #3 :";
            this.lblSearchIngredient3.Click += new System.EventHandler(this.lblSearchIngredient3_Click);
            // 
            // lblSearchIngredient2
            // 
            this.lblSearchIngredient2.AutoSize = true;
            this.lblSearchIngredient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIngredient2.Location = new System.Drawing.Point(38, 129);
            this.lblSearchIngredient2.Name = "lblSearchIngredient2";
            this.lblSearchIngredient2.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient2.TabIndex = 11;
            this.lblSearchIngredient2.Text = "Ingrédient #2 :";
            this.lblSearchIngredient2.Click += new System.EventHandler(this.lblSearchIngredient2_Click);
            // 
            // lblSearchIngredient1
            // 
            this.lblSearchIngredient1.AutoSize = true;
            this.lblSearchIngredient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIngredient1.Location = new System.Drawing.Point(38, 83);
            this.lblSearchIngredient1.Name = "lblSearchIngredient1";
            this.lblSearchIngredient1.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient1.TabIndex = 10;
            this.lblSearchIngredient1.Text = "Ingrédient #1 :";
            this.lblSearchIngredient1.Click += new System.EventHandler(this.lblSearchIngredient1_Click);
            // 
            // txtSearchIngredient3
            // 
            this.txtSearchIngredient3.Location = new System.Drawing.Point(182, 174);
            this.txtSearchIngredient3.Name = "txtSearchIngredient3";
            this.txtSearchIngredient3.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient3.TabIndex = 6;
            // 
            // txtSearchIngredient2
            // 
            this.txtSearchIngredient2.Location = new System.Drawing.Point(182, 129);
            this.txtSearchIngredient2.Name = "txtSearchIngredient2";
            this.txtSearchIngredient2.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient2.TabIndex = 5;
            // 
            // txtSearchIngredient1
            // 
            this.txtSearchIngredient1.Location = new System.Drawing.Point(182, 83);
            this.txtSearchIngredient1.Name = "txtSearchIngredient1";
            this.txtSearchIngredient1.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient1.TabIndex = 4;
            // 
            // cmdIngredientsSearch
            // 
            this.cmdIngredientsSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdIngredientsSearch.BackgroundImage")));
            this.cmdIngredientsSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdIngredientsSearch.FlatAppearance.BorderSize = 0;
            this.cmdIngredientsSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdIngredientsSearch.Location = new System.Drawing.Point(424, 280);
            this.cmdIngredientsSearch.Name = "cmdIngredientsSearch";
            this.cmdIngredientsSearch.Size = new System.Drawing.Size(40, 40);
            this.cmdIngredientsSearch.TabIndex = 9;
            this.cmdIngredientsSearch.UseVisualStyleBackColor = true;
            this.cmdIngredientsSearch.Click += new System.EventHandler(this.cmdIngredientsSearch_Click);
            // 
            // pnlScore
            // 
            this.pnlScore.Controls.Add(this.picScore3);
            this.pnlScore.Controls.Add(this.picScore2);
            this.pnlScore.Controls.Add(this.picScore1);
            this.pnlScore.Location = new System.Drawing.Point(1005, 231);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(111, 30);
            this.pnlScore.TabIndex = 25;
            this.pnlScore.Visible = false;
            this.pnlScore.MouseLeave += new System.EventHandler(this.pnlScore_MouseLeave);
            this.pnlScore.MouseHover += new System.EventHandler(this.pnlScore_MouseHover);
            // 
            // picScore3
            // 
            this.picScore3.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picScore3.Location = new System.Drawing.Point(70, 0);
            this.picScore3.Name = "picScore3";
            this.picScore3.Size = new System.Drawing.Size(36, 26);
            this.picScore3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScore3.TabIndex = 7;
            this.picScore3.TabStop = false;
            this.picScore3.Visible = false;
            this.picScore3.Click += new System.EventHandler(this.picScore3_Click);
            this.picScore3.MouseHover += new System.EventHandler(this.picScore3_MouseHover);
            // 
            // picScore2
            // 
            this.picScore2.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picScore2.Location = new System.Drawing.Point(37, 0);
            this.picScore2.Name = "picScore2";
            this.picScore2.Size = new System.Drawing.Size(36, 26);
            this.picScore2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScore2.TabIndex = 8;
            this.picScore2.TabStop = false;
            this.picScore2.Visible = false;
            this.picScore2.Click += new System.EventHandler(this.picScore2_Click);
            this.picScore2.MouseHover += new System.EventHandler(this.picScore2_MouseHover);
            // 
            // picScore1
            // 
            this.picScore1.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picScore1.Location = new System.Drawing.Point(4, 0);
            this.picScore1.Name = "picScore1";
            this.picScore1.Size = new System.Drawing.Size(36, 26);
            this.picScore1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScore1.TabIndex = 9;
            this.picScore1.TabStop = false;
            this.picScore1.Visible = false;
            this.picScore1.Click += new System.EventHandler(this.picScore1_Click);
            this.picScore1.MouseHover += new System.EventHandler(this.picScore1_MouseHover);
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
            this.cmdTitleSearch.TabIndex = 1;
            this.cmdTitleSearch.UseVisualStyleBackColor = true;
            this.cmdTitleSearch.Click += new System.EventHandler(this.cmdTitleSearch_Click);
            // 
            // cmdAddInstruction
            // 
            this.cmdAddInstruction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdAddInstruction.BackgroundImage")));
            this.cmdAddInstruction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdAddInstruction.FlatAppearance.BorderSize = 0;
            this.cmdAddInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddInstruction.Location = new System.Drawing.Point(1117, 290);
            this.cmdAddInstruction.Name = "cmdAddInstruction";
            this.cmdAddInstruction.Size = new System.Drawing.Size(40, 35);
            this.cmdAddInstruction.TabIndex = 24;
            this.cmdAddInstruction.UseVisualStyleBackColor = true;
            this.cmdAddInstruction.Visible = false;
            this.cmdAddInstruction.Click += new System.EventHandler(this.cmdAddInstruction_Click);
            // 
            // cmdDeleteIngredient
            // 
            this.cmdDeleteIngredient.BackgroundImage = global::Recipe_Writer.Properties.Resources.delete;
            this.cmdDeleteIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdDeleteIngredient.FlatAppearance.BorderSize = 0;
            this.cmdDeleteIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDeleteIngredient.Location = new System.Drawing.Point(893, 284);
            this.cmdDeleteIngredient.Name = "cmdDeleteIngredient";
            this.cmdDeleteIngredient.Size = new System.Drawing.Size(35, 30);
            this.cmdDeleteIngredient.TabIndex = 24;
            this.cmdDeleteIngredient.UseVisualStyleBackColor = true;
            this.cmdDeleteIngredient.Visible = false;
            this.cmdDeleteIngredient.Click += new System.EventHandler(this.cmdDeleteIngredient_Click);
            // 
            // picMenu
            // 
            this.picMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMenu.BackgroundImage")));
            this.picMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMenu.Location = new System.Drawing.Point(10, 125);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(59, 50);
            this.picMenu.TabIndex = 23;
            this.picMenu.TabStop = false;
            this.picMenu.MouseHover += new System.EventHandler(this.picMenu_MouseHover);
            // 
            // picLowBudget
            // 
            this.picLowBudget.BackgroundImage = global::Recipe_Writer.Properties.Resources.lowBudget;
            this.picLowBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLowBudget.Location = new System.Drawing.Point(799, 250);
            this.picLowBudget.Name = "picLowBudget";
            this.picLowBudget.Size = new System.Drawing.Size(35, 30);
            this.picLowBudget.TabIndex = 12;
            this.picLowBudget.TabStop = false;
            this.picLowBudget.Visible = false;
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
            // cmdNewRecipe
            // 
            this.cmdNewRecipe.BackgroundImage = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.cmdNewRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNewRecipe.FlatAppearance.BorderSize = 0;
            this.cmdNewRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNewRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewRecipe.Location = new System.Drawing.Point(181, 27);
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.cmdNewRecipe.Size = new System.Drawing.Size(50, 50);
            this.cmdNewRecipe.TabIndex = 2;
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            this.cmdNewRecipe.Click += new System.EventHandler(this.cmdNewRecipe_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdTitleSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 709);
            this.Controls.Add(this.pnlScore);
            this.Controls.Add(this.cmdAddInstruction);
            this.Controls.Add(this.cmdDeleteIngredient);
            this.Controls.Add(this.picMenu);
            this.Controls.Add(this.pnlSlideMenu);
            this.Controls.Add(this.pnlSideMenu);
            this.Controls.Add(this.picLowBudget);
            this.Controls.Add(this.cmbRecipeIngredients);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.chkWritingAssistance);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.nudPersons);
            this.Controls.Add(this.lblCompletionTime);
            this.Controls.Add(this.lblPortions);
            this.Controls.Add(this.pnlInstructions);
            this.Controls.Add(this.picRecipe);
            this.Controls.Add(this.cmdNewRecipe);
            this.Controls.Add(this.cmdTitleSearch);
            this.Controls.Add(this.txtTitleSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe Writer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            this.cmsRecipeResult.ResumeLayout(false);
            this.pnlSideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).EndInit();
            this.pnlSlideMenu.ResumeLayout(false);
            this.pnlSlideMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClosePanel)).EndInit();
            this.pnlScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlInstructions;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button cmdNewRecipe;
        private System.Windows.Forms.Label lblPortions;
        private System.Windows.Forms.CheckBox chkWritingAssistance;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.Label lblCompletionTime;
        private System.Windows.Forms.OpenFileDialog ofdAssociatedImage;
        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel pnlSlideMenu;
        private System.Windows.Forms.Panel pnlMealsPlanner;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Panel pnlSearchByIngredients;
        private System.Windows.Forms.CheckBox chkInverseSearch;
        private System.Windows.Forms.Label lblSearchByIngredients;
        private System.Windows.Forms.Label lblSearchIngredient3;
        private System.Windows.Forms.Label lblSearchIngredient2;
        private System.Windows.Forms.Label lblSearchIngredient1;
        private System.Windows.Forms.TextBox txtSearchIngredient3;
        private System.Windows.Forms.TextBox txtSearchIngredient2;
        private System.Windows.Forms.TextBox txtSearchIngredient1;
        private System.Windows.Forms.Button cmdIngredientsSearch;
        private System.Windows.Forms.PictureBox picMenu;
        private System.Windows.Forms.NumericUpDown nudPersons;
        private System.Windows.Forms.PictureBox picSettings;
        private System.Windows.Forms.PictureBox picClosePanel;
        private System.Windows.Forms.ContextMenuStrip cmsRecipeResult;
        private System.Windows.Forms.ToolStripMenuItem nouvelleRecetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierLeTitreDeCetteRecetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerCetteRecetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterCetteRecetteEnHTMLToolStripMenuItem;
        public System.Windows.Forms.TextBox txtTitleSearch;
        public System.Windows.Forms.ComboBox cmbRecipeIngredients;
        private System.Windows.Forms.Button cmdDeleteIngredient;
        private System.Windows.Forms.PictureBox picLowBudget;
        public System.Windows.Forms.Button cmdTitleSearch;
        private System.Windows.Forms.Button cmdAddInstruction;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.PictureBox picScore3;
        private System.Windows.Forms.PictureBox picScore2;
        private System.Windows.Forms.PictureBox picScore1;
    }
}

