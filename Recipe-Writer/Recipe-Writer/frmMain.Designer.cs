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
            this.editThisRecipesBasicInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addIngredientToThisRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteIngredientFromThisRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbRecipeIngredients = new System.Windows.Forms.ComboBox();
            this.lblCompletionTime = new System.Windows.Forms.Label();
            this.ofdAssociatedImage = new System.Windows.Forms.OpenFileDialog();
            this.pnlSlideMenu = new System.Windows.Forms.Panel();
            this.chkFilterRecipesForThreeStars = new System.Windows.Forms.CheckBox();
            this.chkFilterRecipesForSmallBudget = new System.Windows.Forms.CheckBox();
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
            this.ttpRecipeReadyToCookStatus = new System.Windows.Forms.ToolTip(this.components);
            this.cmdTitleSearch = new System.Windows.Forms.Button();
            this.picSettings = new System.Windows.Forms.PictureBox();
            this.picMealPlanner = new System.Windows.Forms.PictureBox();
            this.picSearchByIngredient = new System.Windows.Forms.PictureBox();
            this.picInventory = new System.Windows.Forms.PictureBox();
            this.cmdAddInstruction = new System.Windows.Forms.Button();
            this.picLowBudget = new System.Windows.Forms.PictureBox();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            this.picRecipeReadyToCookStatus = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            this.cmsRecipeResult.SuspendLayout();
            this.pnlSlideMenu.SuspendLayout();
            this.pnlScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMealPlanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchByIngredient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeReadyToCookStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(167, 39);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(427, 27);
            this.txtTitleSearch.TabIndex = 0;
            this.txtTitleSearch.Enter += new System.EventHandler(this.txtTitleSearch_Enter);
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.Location = new System.Drawing.Point(91, 87);
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
            this.pnlInstructions.Size = new System.Drawing.Size(863, 354);
            this.pnlInstructions.TabIndex = 17;
            // 
            // nudPersons
            // 
            this.nudPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPersons.Location = new System.Drawing.Point(104, 224);
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
            this.lblPortions.Location = new System.Drawing.Point(156, 231);
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
            this.lstSearchResults.Location = new System.Drawing.Point(91, 117);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(562, 84);
            this.lstSearchResults.TabIndex = 4;
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            this.lstSearchResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseMove);
            // 
            // cmsRecipeResult
            // 
            this.cmsRecipeResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRecipeResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRecipeToolStripMenuItem,
            this.editThisRecipesBasicInfosToolStripMenuItem,
            this.deleteThisRecipeToolStripMenuItem,
            this.exportThisRecipeToAWebPageToolStripMenuItem,
            this.PlanRecipeOn,
            this.toolStripSeparator1,
            this.addIngredientToThisRecipe,
            this.deleteIngredientFromThisRecipe});
            this.cmsRecipeResult.Name = "cmsRecipeResult";
            this.cmsRecipeResult.Size = new System.Drawing.Size(418, 192);
            // 
            // newRecipeToolStripMenuItem
            // 
            this.newRecipeToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.newRecipeToolStripMenuItem.Name = "newRecipeToolStripMenuItem";
            this.newRecipeToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.newRecipeToolStripMenuItem.Text = "Nouvelle recette";
            this.newRecipeToolStripMenuItem.Click += new System.EventHandler(this.newRecipeToolStripMenuItem_Click);
            // 
            // editThisRecipesBasicInfosToolStripMenuItem
            // 
            this.editThisRecipesBasicInfosToolStripMenuItem.Enabled = false;
            this.editThisRecipesBasicInfosToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.edit_recipe_title;
            this.editThisRecipesBasicInfosToolStripMenuItem.Name = "editThisRecipesBasicInfosToolStripMenuItem";
            this.editThisRecipesBasicInfosToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.editThisRecipesBasicInfosToolStripMenuItem.Text = "Modifier les infos de base de la recette";
            this.editThisRecipesBasicInfosToolStripMenuItem.Click += new System.EventHandler(this.editThisRecipesBasicInfosToolStripMenuItem_Click);
            // 
            // deleteThisRecipeToolStripMenuItem
            // 
            this.deleteThisRecipeToolStripMenuItem.Enabled = false;
            this.deleteThisRecipeToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.delete_recipe;
            this.deleteThisRecipeToolStripMenuItem.Name = "deleteThisRecipeToolStripMenuItem";
            this.deleteThisRecipeToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.deleteThisRecipeToolStripMenuItem.Text = "Supprimer cette recette";
            this.deleteThisRecipeToolStripMenuItem.Click += new System.EventHandler(this.deleteThisRecipeToolStripMenuItem_Click);
            // 
            // exportThisRecipeToAWebPageToolStripMenuItem
            // 
            this.exportThisRecipeToAWebPageToolStripMenuItem.Enabled = false;
            this.exportThisRecipeToAWebPageToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.export_to_html;
            this.exportThisRecipeToAWebPageToolStripMenuItem.Name = "exportThisRecipeToAWebPageToolStripMenuItem";
            this.exportThisRecipeToAWebPageToolStripMenuItem.Size = new System.Drawing.Size(417, 26);
            this.exportThisRecipeToAWebPageToolStripMenuItem.Text = "Exporter cette recette en une page web";
            this.exportThisRecipeToAWebPageToolStripMenuItem.Click += new System.EventHandler(this.exportThisRecipeToAWebPageToolStripMenuItem_Click);
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
            this.PlanRecipeOn.Enabled = false;
            this.PlanRecipeOn.Image = global::Recipe_Writer.Properties.Resources.plan__recipe_into_planner;
            this.PlanRecipeOn.Name = "PlanRecipeOn";
            this.PlanRecipeOn.Size = new System.Drawing.Size(417, 26);
            this.PlanRecipeOn.Text = "Planifier la recette pour le";
            // 
            // lundiToolStripMenuItem
            // 
            this.lundiToolStripMenuItem.Name = "lundiToolStripMenuItem";
            this.lundiToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.lundiToolStripMenuItem.Text = "Lundi";
            this.lundiToolStripMenuItem.Click += new System.EventHandler(this.lundiToolStripMenuItem_Click);
            // 
            // mardiToolStripMenuItem
            // 
            this.mardiToolStripMenuItem.Name = "mardiToolStripMenuItem";
            this.mardiToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.mardiToolStripMenuItem.Text = "Mardi";
            this.mardiToolStripMenuItem.Click += new System.EventHandler(this.mardiToolStripMenuItem_Click);
            // 
            // mercrediToolStripMenuItem
            // 
            this.mercrediToolStripMenuItem.Name = "mercrediToolStripMenuItem";
            this.mercrediToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.mercrediToolStripMenuItem.Text = "Mercredi";
            this.mercrediToolStripMenuItem.Click += new System.EventHandler(this.mercrediToolStripMenuItem_Click);
            // 
            // jeudiToolStripMenuItem
            // 
            this.jeudiToolStripMenuItem.Name = "jeudiToolStripMenuItem";
            this.jeudiToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.jeudiToolStripMenuItem.Text = "Jeudi";
            this.jeudiToolStripMenuItem.Click += new System.EventHandler(this.jeudiToolStripMenuItem_Click);
            // 
            // vendrediToolStripMenuItem
            // 
            this.vendrediToolStripMenuItem.Name = "vendrediToolStripMenuItem";
            this.vendrediToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.vendrediToolStripMenuItem.Text = "Vendredi";
            this.vendrediToolStripMenuItem.Click += new System.EventHandler(this.vendrediToolStripMenuItem_Click);
            // 
            // samediToolStripMenuItem
            // 
            this.samediToolStripMenuItem.Name = "samediToolStripMenuItem";
            this.samediToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.samediToolStripMenuItem.Text = "Samedi";
            this.samediToolStripMenuItem.Click += new System.EventHandler(this.samediToolStripMenuItem_Click);
            // 
            // dimancheToolStripMenuItem
            // 
            this.dimancheToolStripMenuItem.Name = "dimancheToolStripMenuItem";
            this.dimancheToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.dimancheToolStripMenuItem.Text = "Dimanche";
            this.dimancheToolStripMenuItem.Click += new System.EventHandler(this.dimancheToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(414, 6);
            // 
            // addIngredientToThisRecipe
            // 
            this.addIngredientToThisRecipe.Enabled = false;
            this.addIngredientToThisRecipe.Name = "addIngredientToThisRecipe";
            this.addIngredientToThisRecipe.Size = new System.Drawing.Size(417, 26);
            this.addIngredientToThisRecipe.Text = "Ajouter un ingrédient à cette recette";
            this.addIngredientToThisRecipe.Click += new System.EventHandler(this.addIngredientToThisRecipe_Click);
            // 
            // deleteIngredientFromThisRecipe
            // 
            this.deleteIngredientFromThisRecipe.Enabled = false;
            this.deleteIngredientFromThisRecipe.Name = "deleteIngredientFromThisRecipe";
            this.deleteIngredientFromThisRecipe.Size = new System.Drawing.Size(417, 26);
            this.deleteIngredientFromThisRecipe.Text = "Supprimer l\'ingrédient sélectionné de cette recette";
            this.deleteIngredientFromThisRecipe.Click += new System.EventHandler(this.deleteIngredientFromThisRecipe_Click);
            // 
            // cmbRecipeIngredients
            // 
            this.cmbRecipeIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRecipeIngredients.FormattingEnabled = true;
            this.cmbRecipeIngredients.Location = new System.Drawing.Point(234, 228);
            this.cmbRecipeIngredients.Name = "cmbRecipeIngredients";
            this.cmbRecipeIngredients.Size = new System.Drawing.Size(206, 24);
            this.cmbRecipeIngredients.TabIndex = 16;
            this.cmbRecipeIngredients.Visible = false;
            this.cmbRecipeIngredients.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeIngredients_SelectedIndexChanged);
            // 
            // lblCompletionTime
            // 
            this.lblCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletionTime.Location = new System.Drawing.Point(586, 230);
            this.lblCompletionTime.Name = "lblCompletionTime";
            this.lblCompletionTime.Size = new System.Drawing.Size(184, 24);
            this.lblCompletionTime.TabIndex = 10;
            this.lblCompletionTime.Text = "Préparation : 120 minutes";
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
            // pnlSlideMenu
            // 
            this.pnlSlideMenu.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSlideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSlideMenu.Controls.Add(this.chkFilterRecipesForThreeStars);
            this.pnlSlideMenu.Controls.Add(this.chkFilterRecipesForSmallBudget);
            this.pnlSlideMenu.Controls.Add(this.lblSearchByIngredients);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient3);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient2);
            this.pnlSlideMenu.Controls.Add(this.lblSearchIngredient1);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient3);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient2);
            this.pnlSlideMenu.Controls.Add(this.txtSearchIngredient1);
            this.pnlSlideMenu.Controls.Add(this.cmdIngredientsSearch);
            this.pnlSlideMenu.Location = new System.Drawing.Point(73, 116);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(12, 204);
            this.pnlSlideMenu.TabIndex = 19;
            this.pnlSlideMenu.Visible = false;
            // 
            // chkFilterRecipesForThreeStars
            // 
            this.chkFilterRecipesForThreeStars.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFilterRecipesForThreeStars.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFilterRecipesForThreeStars.Location = new System.Drawing.Point(204, 159);
            this.chkFilterRecipesForThreeStars.Name = "chkFilterRecipesForThreeStars";
            this.chkFilterRecipesForThreeStars.Size = new System.Drawing.Size(92, 24);
            this.chkFilterRecipesForThreeStars.TabIndex = 21;
            this.chkFilterRecipesForThreeStars.Text = "3 étoiles";
            this.chkFilterRecipesForThreeStars.UseVisualStyleBackColor = true;
            // 
            // chkFilterRecipesForSmallBudget
            // 
            this.chkFilterRecipesForSmallBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkFilterRecipesForSmallBudget.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFilterRecipesForSmallBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFilterRecipesForSmallBudget.Location = new System.Drawing.Point(28, 159);
            this.chkFilterRecipesForSmallBudget.Name = "chkFilterRecipesForSmallBudget";
            this.chkFilterRecipesForSmallBudget.Size = new System.Drawing.Size(116, 24);
            this.chkFilterRecipesForSmallBudget.TabIndex = 7;
            this.chkFilterRecipesForSmallBudget.Text = "Petit budget";
            this.chkFilterRecipesForSmallBudget.UseVisualStyleBackColor = true;
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
            this.pnlScore.Location = new System.Drawing.Point(784, 242);
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
            this.picScore3.Location = new System.Drawing.Point(113, 1);
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
            this.picScore2.Location = new System.Drawing.Point(80, 1);
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
            this.picScore1.Location = new System.Drawing.Point(47, 1);
            this.picScore1.Name = "picScore1";
            this.picScore1.Size = new System.Drawing.Size(36, 26);
            this.picScore1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScore1.TabIndex = 9;
            this.picScore1.TabStop = false;
            this.picScore1.Visible = false;
            this.picScore1.Click += new System.EventHandler(this.picScore1_Click);
            this.picScore1.MouseHover += new System.EventHandler(this.picScore1_MouseHover);
            // 
            // ttpRecipeReadyToCookStatus
            // 
            this.ttpRecipeReadyToCookStatus.AutoPopDelay = 10000;
            this.ttpRecipeReadyToCookStatus.InitialDelay = 500;
            this.ttpRecipeReadyToCookStatus.ReshowDelay = 500;
            // 
            // cmdTitleSearch
            // 
            this.cmdTitleSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdTitleSearch.BackgroundImage")));
            this.cmdTitleSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdTitleSearch.FlatAppearance.BorderSize = 0;
            this.cmdTitleSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTitleSearch.Location = new System.Drawing.Point(613, 33);
            this.cmdTitleSearch.Name = "cmdTitleSearch";
            this.cmdTitleSearch.Size = new System.Drawing.Size(40, 40);
            this.cmdTitleSearch.TabIndex = 1;
            this.cmdTitleSearch.UseVisualStyleBackColor = true;
            this.cmdTitleSearch.Click += new System.EventHandler(this.cmdTitleSearch_Click);
            // 
            // picSettings
            // 
            this.picSettings.BackgroundImage = global::Recipe_Writer.Properties.Resources.settings;
            this.picSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSettings.Location = new System.Drawing.Point(8, 293);
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
            this.picMealPlanner.Location = new System.Drawing.Point(9, 234);
            this.picMealPlanner.Name = "picMealPlanner";
            this.picMealPlanner.Size = new System.Drawing.Size(60, 50);
            this.picMealPlanner.TabIndex = 27;
            this.picMealPlanner.TabStop = false;
            this.picMealPlanner.Click += new System.EventHandler(this.picMealPlanner_Click);
            this.picMealPlanner.MouseHover += new System.EventHandler(this.picMealPlanner_MouseHover);
            // 
            // picSearchByIngredient
            // 
            this.picSearchByIngredient.BackgroundImage = global::Recipe_Writer.Properties.Resources.ingredients_search;
            this.picSearchByIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSearchByIngredient.Location = new System.Drawing.Point(9, 117);
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
            this.picInventory.Location = new System.Drawing.Point(9, 177);
            this.picInventory.Name = "picInventory";
            this.picInventory.Size = new System.Drawing.Size(60, 50);
            this.picInventory.TabIndex = 24;
            this.picInventory.TabStop = false;
            this.picInventory.Click += new System.EventHandler(this.picInventory_Click);
            this.picInventory.MouseHover += new System.EventHandler(this.picInventory_MouseHover);
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
            this.picLowBudget.Location = new System.Drawing.Point(460, 224);
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
            this.picRecipe.Location = new System.Drawing.Point(784, 38);
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
            this.cmdNewRecipe.Location = new System.Drawing.Point(93, 27);
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.cmdNewRecipe.Size = new System.Drawing.Size(50, 50);
            this.cmdNewRecipe.TabIndex = 2;
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            this.cmdNewRecipe.Click += new System.EventHandler(this.cmdNewRecipe_Click);
            // 
            // picRecipeReadyToCookStatus
            // 
            this.picRecipeReadyToCookStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picRecipeReadyToCookStatus.Location = new System.Drawing.Point(513, 223);
            this.picRecipeReadyToCookStatus.Name = "picRecipeReadyToCookStatus";
            this.picRecipeReadyToCookStatus.Size = new System.Drawing.Size(31, 35);
            this.picRecipeReadyToCookStatus.TabIndex = 28;
            this.picRecipeReadyToCookStatus.TabStop = false;
            this.picRecipeReadyToCookStatus.MouseHover += new System.EventHandler(this.picRecipeReadyToCookStatus_MouseHover);
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdTitleSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 651);
            this.ContextMenuStrip = this.cmsRecipeResult;
            this.Controls.Add(this.pnlSlideMenu);
            this.Controls.Add(this.picSettings);
            this.Controls.Add(this.picMealPlanner);
            this.Controls.Add(this.picSearchByIngredient);
            this.Controls.Add(this.picInventory);
            this.Controls.Add(this.pnlScore);
            this.Controls.Add(this.cmdAddInstruction);
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
            this.Controls.Add(this.picRecipeReadyToCookStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe Writer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            this.cmsRecipeResult.ResumeLayout(false);
            this.pnlSlideMenu.ResumeLayout(false);
            this.pnlSlideMenu.PerformLayout();
            this.pnlScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMealPlanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchByIngredient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeReadyToCookStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlInstructions;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button cmdNewRecipe;
        private System.Windows.Forms.Label lblPortions;
        private System.Windows.Forms.Label lblCompletionTime;
        private System.Windows.Forms.OpenFileDialog ofdAssociatedImage;
        private System.Windows.Forms.Panel pnlSlideMenu;
        private System.Windows.Forms.CheckBox chkFilterRecipesForSmallBudget;
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
        private System.Windows.Forms.ToolStripMenuItem editThisRecipesBasicInfosToolStripMenuItem;
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
        private System.Windows.Forms.CheckBox chkFilterRecipesForThreeStars;
        private System.Windows.Forms.PictureBox picRecipeReadyToCookStatus;
        private System.Windows.Forms.ToolTip ttpRecipeReadyToCookStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addIngredientToThisRecipe;
        private System.Windows.Forms.ToolStripMenuItem deleteIngredientFromThisRecipe;
    }
}

