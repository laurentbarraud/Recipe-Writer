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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.pnlInstructions = new System.Windows.Forms.Panel();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.lblPortions = new System.Windows.Forms.Label();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.cmsRecipeResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newRecipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editThisRecipesTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisRecipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportThisRecipeToAWebPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlanRecipeOn = new System.Windows.Forms.ToolStripMenuItem();
            this.lundiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mardiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mercrediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jeudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendrediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimancheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbRecipeIngredients = new System.Windows.Forms.ComboBox();
            this.lblCompletionTime = new System.Windows.Forms.Label();
            this.ofdAssociatedImage = new System.Windows.Forms.OpenFileDialog();
            this.picSearchByIngredient = new System.Windows.Forms.PictureBox();
            this.picInventory = new System.Windows.Forms.PictureBox();
            this.pnlSlideMenu = new System.Windows.Forms.Panel();
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
            this.picLowBudget = new System.Windows.Forms.PictureBox();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            this.picSettings = new System.Windows.Forms.PictureBox();
            this.picMealPlanner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            this.cmsRecipeResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchByIngredient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventory)).BeginInit();
            this.pnlSlideMenu.SuspendLayout();
            this.pnlScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMealPlanner)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(168, 39);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(518, 27);
            this.txtTitleSearch.TabIndex = 0;
            this.txtTitleSearch.Enter += new System.EventHandler(this.txtTitleSearch_Enter);
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.Location = new System.Drawing.Point(91, 98);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(208, 28);
            this.lblSearchResults.TabIndex = 0;
            this.lblSearchResults.Text = "Résultats de la recherche :";
            // 
            // pnlInstructions
            // 
            this.pnlInstructions.AutoScroll = true;
            this.pnlInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInstructions.Location = new System.Drawing.Point(91, 276);
            this.pnlInstructions.Name = "pnlInstructions";
            this.pnlInstructions.Size = new System.Drawing.Size(880, 354);
            this.pnlInstructions.TabIndex = 17;
            // 
            // nudPersons
            // 
            this.nudPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPersons.Location = new System.Drawing.Point(94, 225);
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
            this.lblPortions.Location = new System.Drawing.Point(146, 231);
            this.lblPortions.Name = "lblPortions";
            this.lblPortions.Size = new System.Drawing.Size(62, 18);
            this.lblPortions.TabIndex = 10;
            this.lblPortions.Text = "portions";
            this.lblPortions.Visible = false;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.ContextMenuStrip = this.cmsRecipeResult;
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 16;
            this.lstSearchResults.Location = new System.Drawing.Point(91, 128);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(595, 84);
            this.lstSearchResults.TabIndex = 4;
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            this.lstSearchResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseMove);
            // 
            // cmsRecipeResult
            // 
            this.cmsRecipeResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRecipeResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRecipeToolStripMenuItem,
            this.editThisRecipesTitleToolStripMenuItem,
            this.deleteThisRecipeToolStripMenuItem,
            this.exportThisRecipeToAWebPageToolStripMenuItem,
            this.PlanRecipeOn});
            this.cmsRecipeResult.Name = "cmsRecipeResult";
            this.cmsRecipeResult.Size = new System.Drawing.Size(344, 134);
            // 
            // newRecipeToolStripMenuItem
            // 
            this.newRecipeToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.newRecipeToolStripMenuItem.Name = "newRecipeToolStripMenuItem";
            this.newRecipeToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.newRecipeToolStripMenuItem.Text = "Nouvelle recette";
            this.newRecipeToolStripMenuItem.Click += new System.EventHandler(this.nouvelleRecetteToolStripMenuItem_Click);
            // 
            // editThisRecipesTitleToolStripMenuItem
            // 
            this.editThisRecipesTitleToolStripMenuItem.Enabled = false;
            this.editThisRecipesTitleToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.edit_recipe_title;
            this.editThisRecipesTitleToolStripMenuItem.Name = "editThisRecipesTitleToolStripMenuItem";
            this.editThisRecipesTitleToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.editThisRecipesTitleToolStripMenuItem.Text = "Modifier le titre de cette recette";
            this.editThisRecipesTitleToolStripMenuItem.Click += new System.EventHandler(this.modifierLeTitreDeCetteRecetteToolStripMenuItem_Click);
            // 
            // deleteThisRecipeToolStripMenuItem
            // 
            this.deleteThisRecipeToolStripMenuItem.Enabled = false;
            this.deleteThisRecipeToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.delete_recipe;
            this.deleteThisRecipeToolStripMenuItem.Name = "deleteThisRecipeToolStripMenuItem";
            this.deleteThisRecipeToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.deleteThisRecipeToolStripMenuItem.Text = "Supprimer cette recette";
            // 
            // exportThisRecipeToAWebPageToolStripMenuItem
            // 
            this.exportThisRecipeToAWebPageToolStripMenuItem.Enabled = false;
            this.exportThisRecipeToAWebPageToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.export_to_html;
            this.exportThisRecipeToAWebPageToolStripMenuItem.Name = "exportThisRecipeToAWebPageToolStripMenuItem";
            this.exportThisRecipeToAWebPageToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.exportThisRecipeToAWebPageToolStripMenuItem.Text = "Exporter cette recette en une page web";
            // 
            // PlanRecipeOn
            // 
            this.PlanRecipeOn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lundiToolStripMenuItem,
            this.mardiToolStripMenuItem,
            this.mercrediToolStripMenuItem,
            this.jeudiToolStripMenuItem,
            this.vendrediToolStripMenuItem,
            this.samediToolStripMenuItem,
            this.dimancheToolStripMenuItem});
            this.PlanRecipeOn.Name = "PlanRecipeOn";
            this.PlanRecipeOn.Size = new System.Drawing.Size(343, 26);
            this.PlanRecipeOn.Text = "Planifier la recette pour le";
            // 
            // lundiToolStripMenuItem
            // 
            this.lundiToolStripMenuItem.Name = "lundiToolStripMenuItem";
            this.lundiToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.lundiToolStripMenuItem.Text = "Lundi";
            // 
            // mardiToolStripMenuItem
            // 
            this.mardiToolStripMenuItem.Name = "mardiToolStripMenuItem";
            this.mardiToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.mardiToolStripMenuItem.Text = "Mardi";
            // 
            // mercrediToolStripMenuItem
            // 
            this.mercrediToolStripMenuItem.Name = "mercrediToolStripMenuItem";
            this.mercrediToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.mercrediToolStripMenuItem.Text = "Mercredi";
            // 
            // jeudiToolStripMenuItem
            // 
            this.jeudiToolStripMenuItem.Name = "jeudiToolStripMenuItem";
            this.jeudiToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.jeudiToolStripMenuItem.Text = "Jeudi";
            // 
            // vendrediToolStripMenuItem
            // 
            this.vendrediToolStripMenuItem.Name = "vendrediToolStripMenuItem";
            this.vendrediToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.vendrediToolStripMenuItem.Text = "Vendredi";
            // 
            // samediToolStripMenuItem
            // 
            this.samediToolStripMenuItem.Name = "samediToolStripMenuItem";
            this.samediToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.samediToolStripMenuItem.Text = "Samedi";
            // 
            // dimancheToolStripMenuItem
            // 
            this.dimancheToolStripMenuItem.Name = "dimancheToolStripMenuItem";
            this.dimancheToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.dimancheToolStripMenuItem.Text = "Dimanche";
            // 
            // cmbRecipeIngredients
            // 
            this.cmbRecipeIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRecipeIngredients.FormattingEnabled = true;
            this.cmbRecipeIngredients.Location = new System.Drawing.Point(279, 227);
            this.cmbRecipeIngredients.Name = "cmbRecipeIngredients";
            this.cmbRecipeIngredients.Size = new System.Drawing.Size(221, 24);
            this.cmbRecipeIngredients.TabIndex = 16;
            this.cmbRecipeIngredients.Visible = false;
            this.cmbRecipeIngredients.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeIngredients_SelectedIndexChanged);
            // 
            // lblCompletionTime
            // 
            this.lblCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletionTime.Location = new System.Drawing.Point(512, 229);
            this.lblCompletionTime.Name = "lblCompletionTime";
            this.lblCompletionTime.Size = new System.Drawing.Size(236, 24);
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
            // picSearchByIngredient
            // 
            this.picSearchByIngredient.BackgroundImage = global::Recipe_Writer.Properties.Resources.ingredients_search;
            this.picSearchByIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSearchByIngredient.Location = new System.Drawing.Point(9, 128);
            this.picSearchByIngredient.Name = "picSearchByIngredient";
            this.picSearchByIngredient.Size = new System.Drawing.Size(60, 50);
            this.picSearchByIngredient.TabIndex = 25;
            this.picSearchByIngredient.TabStop = false;
            this.picSearchByIngredient.MouseHover += new System.EventHandler(this.picSearchByIngredient_MouseHover);
            // 
            // picInventory
            // 
            this.picInventory.BackgroundImage = global::Recipe_Writer.Properties.Resources.inventory;
            this.picInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picInventory.Location = new System.Drawing.Point(9, 188);
            this.picInventory.Name = "picInventory";
            this.picInventory.Size = new System.Drawing.Size(60, 50);
            this.picInventory.TabIndex = 24;
            this.picInventory.TabStop = false;
            this.picInventory.Click += new System.EventHandler(this.picInventory_Click);
            this.picInventory.MouseHover += new System.EventHandler(this.picInventory_MouseHover);
            // 
            // pnlSlideMenu
            // 
            this.pnlSlideMenu.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSlideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSlideMenu.Controls.Add(this.chkInverseSearch);
            this.pnlSlideMenu.Controls.Add(this.lblSearchByIngredients);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient3);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient2);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient1);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient3);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient2);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient1);
            this.pnlSlideMenu.Controls.Add(this.cmdIngredientsSearch);
            this.pnlSlideMenu.Location = new System.Drawing.Point(73, 128);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(15, 204);
            this.pnlSlideMenu.TabIndex = 19;
            this.pnlSlideMenu.Visible = false;
            // 
            // chkInverseSearch
            // 
            this.chkInverseSearch.AutoSize = true;
            this.chkInverseSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInverseSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInverseSearch.Location = new System.Drawing.Point(7, 147);
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
            this.lblSearchByIngredients.Location = new System.Drawing.Point(134, 9);
            this.lblSearchByIngredients.Name = "lblSearchByIngredients";
            this.lblSearchByIngredients.Size = new System.Drawing.Size(180, 18);
            this.lblSearchByIngredients.TabIndex = 20;
            this.lblSearchByIngredients.Text = "Recherche par ingrédients";
            // 
            // lblSearchIngredient3
            // 
            this.lblSearchIngredient3.AutoSize = true;
            this.lblSearchIngredient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIngredient3.Location = new System.Drawing.Point(25, 110);
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
            this.lblSearchIngredient2.Location = new System.Drawing.Point(25, 78);
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
            this.lblSearchIngredient1.Location = new System.Drawing.Point(25, 43);
            this.lblSearchIngredient1.Name = "lblSearchIngredient1";
            this.lblSearchIngredient1.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient1.TabIndex = 10;
            this.lblSearchIngredient1.Text = "Ingrédient #1 :";
            this.lblSearchIngredient1.Click += new System.EventHandler(this.lblSearchIngredient1_Click);
            // 
            // txtSearchIngredient3
            // 
            this.txtSearchIngredient3.Location = new System.Drawing.Point(169, 109);
            this.txtSearchIngredient3.Name = "txtSearchIngredient3";
            this.txtSearchIngredient3.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient3.TabIndex = 6;
            // 
            // txtSearchIngredient2
            // 
            this.txtSearchIngredient2.Location = new System.Drawing.Point(169, 74);
            this.txtSearchIngredient2.Name = "txtSearchIngredient2";
            this.txtSearchIngredient2.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient2.TabIndex = 5;
            // 
            // txtSearchIngredient1
            // 
            this.txtSearchIngredient1.Location = new System.Drawing.Point(169, 43);
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
            this.cmdIngredientsSearch.Location = new System.Drawing.Point(357, 143);
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
            this.pnlScore.Location = new System.Drawing.Point(771, 236);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(200, 30);
            this.pnlScore.TabIndex = 25;
            this.pnlScore.Visible = false;
            this.pnlScore.MouseLeave += new System.EventHandler(this.pnlScore_MouseLeave);
            this.pnlScore.MouseHover += new System.EventHandler(this.pnlScore_MouseHover);
            // 
            // picScore3
            // 
            this.picScore3.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picScore3.Location = new System.Drawing.Point(100, 0);
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
            this.picScore2.Location = new System.Drawing.Point(67, 0);
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
            this.picScore1.Location = new System.Drawing.Point(34, 0);
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
            this.cmdTitleSearch.Location = new System.Drawing.Point(708, 33);
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
            this.cmdAddInstruction.Location = new System.Drawing.Point(972, 595);
            this.cmdAddInstruction.Name = "cmdAddInstruction";
            this.cmdAddInstruction.Size = new System.Drawing.Size(40, 35);
            this.cmdAddInstruction.TabIndex = 24;
            this.cmdAddInstruction.UseVisualStyleBackColor = true;
            this.cmdAddInstruction.Visible = false;
            this.cmdAddInstruction.Click += new System.EventHandler(this.cmdAddInstruction_Click);
            // 
            // picLowBudget
            // 
            this.picLowBudget.BackgroundImage = global::Recipe_Writer.Properties.Resources.lowBudget;
            this.picLowBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLowBudget.Location = new System.Drawing.Point(224, 223);
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
            this.picRecipe.Location = new System.Drawing.Point(771, 32);
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
            this.cmdNewRecipe.Location = new System.Drawing.Point(94, 27);
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.cmdNewRecipe.Size = new System.Drawing.Size(50, 50);
            this.cmdNewRecipe.TabIndex = 2;
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            this.cmdNewRecipe.Click += new System.EventHandler(this.cmdNewRecipe_Click);
            // 
            // picSettings
            // 
            this.picSettings.BackgroundImage = global::Recipe_Writer.Properties.Resources.settings;
            this.picSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSettings.Location = new System.Drawing.Point(8, 304);
            this.picSettings.Name = "picSettings";
            this.picSettings.Size = new System.Drawing.Size(60, 50);
            this.picSettings.TabIndex = 26;
            this.picSettings.TabStop = false;
            this.picSettings.Click += new System.EventHandler(this.picSettings_Click);
            this.picSettings.MouseHover += new System.EventHandler(this.picSettings_MouseHover);
            // 
            // picMealPlanner
            // 
            this.picMealPlanner.BackgroundImage = global::Recipe_Writer.Properties.Resources.planner;
            this.picMealPlanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMealPlanner.Location = new System.Drawing.Point(9, 245);
            this.picMealPlanner.Name = "picMealPlanner";
            this.picMealPlanner.Size = new System.Drawing.Size(60, 50);
            this.picMealPlanner.TabIndex = 27;
            this.picMealPlanner.TabStop = false;
            this.picMealPlanner.Click += new System.EventHandler(this.picMealPlanner_Click);
            this.picMealPlanner.MouseHover += new System.EventHandler(this.picMealPlanner_MouseHover);
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdTitleSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 651);
            this.Controls.Add(this.picSettings);
            this.Controls.Add(this.picMealPlanner);
            this.Controls.Add(this.picSearchByIngredient);
            this.Controls.Add(this.picInventory);
            this.Controls.Add(this.pnlScore);
            this.Controls.Add(this.cmdAddInstruction);
            this.Controls.Add(this.pnlSlideMenu);
            this.Controls.Add(this.picLowBudget);
            this.Controls.Add(this.cmbRecipeIngredients);
            this.Controls.Add(this.lstSearchResults);
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
            ((System.ComponentModel.ISupportInitialize)(this.picSearchByIngredient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventory)).EndInit();
            this.pnlSlideMenu.ResumeLayout(false);
            this.pnlSlideMenu.PerformLayout();
            this.pnlScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMealPlanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlInstructions;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button cmdNewRecipe;
        private System.Windows.Forms.Label lblPortions;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.Label lblCompletionTime;
        private System.Windows.Forms.OpenFileDialog ofdAssociatedImage;
        private System.Windows.Forms.Panel pnlSlideMenu;
        private System.Windows.Forms.CheckBox chkInverseSearch;
        private System.Windows.Forms.Label lblSearchByIngredients;
        private System.Windows.Forms.Label lblSearchIngredient3;
        private System.Windows.Forms.Label lblSearchIngredient2;
        private System.Windows.Forms.Label lblSearchIngredient1;
        private System.Windows.Forms.TextBox txtSearchIngredient3;
        private System.Windows.Forms.TextBox txtSearchIngredient2;
        private System.Windows.Forms.TextBox txtSearchIngredient1;
        private System.Windows.Forms.Button cmdIngredientsSearch;
        private System.Windows.Forms.NumericUpDown nudPersons;
        private System.Windows.Forms.ContextMenuStrip cmsRecipeResult;
        private System.Windows.Forms.ToolStripMenuItem newRecipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editThisRecipesTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisRecipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportThisRecipeToAWebPageToolStripMenuItem;
        public System.Windows.Forms.TextBox txtTitleSearch;
        public System.Windows.Forms.ComboBox cmbRecipeIngredients;
        private System.Windows.Forms.PictureBox picLowBudget;
        public System.Windows.Forms.Button cmdTitleSearch;
        private System.Windows.Forms.Button cmdAddInstruction;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.PictureBox picScore3;
        private System.Windows.Forms.PictureBox picScore2;
        private System.Windows.Forms.PictureBox picScore1;
        private System.Windows.Forms.PictureBox picInventory;
        private System.Windows.Forms.PictureBox picSearchByIngredient;
        private System.Windows.Forms.PictureBox picSettings;
        private System.Windows.Forms.PictureBox picMealPlanner;
        private System.Windows.Forms.ToolStripMenuItem PlanRecipeOn;
        private System.Windows.Forms.ToolStripMenuItem lundiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mardiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mercrediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jeudiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendrediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem samediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimancheToolStripMenuItem;
    }
}

