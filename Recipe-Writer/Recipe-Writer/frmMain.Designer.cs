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
            this.pnlInstructions = new System.Windows.Forms.Panel();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.lblPortions = new System.Windows.Forms.Label();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.cmsRecipeResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.editThisRecipesInfos = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.exportThisRecipeToAWebPage = new System.Windows.Forms.ToolStripMenuItem();
            this.planRecipeOn = new System.Windows.Forms.ToolStripMenuItem();
            this.mondayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wednesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thursdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fridayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addIngredientToThisRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedIngredientFromThisRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addInstructionToThisRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseInstructionFontSize = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseInstructionFontSize = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmdingredientSearch = new System.Windows.Forms.Button();
            this.pnlScore = new System.Windows.Forms.Panel();
            this.picScore3 = new System.Windows.Forms.PictureBox();
            this.picScore2 = new System.Windows.Forms.PictureBox();
            this.picScore1 = new System.Windows.Forms.PictureBox();
            this.ttpRecipeReadyToCookStatus = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmdTitleSearch = new System.Windows.Forms.Button();
            this.cmdMealPlanner = new System.Windows.Forms.Button();
            this.cmdInventory = new System.Windows.Forms.Button();
            this.cmdSearchByIngredient = new System.Windows.Forms.Button();
            this.picLowBudget = new System.Windows.Forms.PictureBox();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            this.picRecipeReadyToCookStatus = new System.Windows.Forms.PictureBox();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.picCompletionTime = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            this.cmsRecipeResult.SuspendLayout();
            this.pnlSlideMenu.SuspendLayout();
            this.pnlScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeReadyToCookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompletionTime)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtTitleSearch.Location = new System.Drawing.Point(143, 39);
            this.txtTitleSearch.MaxLength = 200;
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(264, 27);
            this.txtTitleSearch.TabIndex = 1;
            this.txtTitleSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTitleSearch_KeyDown);
            // 
            // pnlInstructions
            // 
            this.pnlInstructions.AutoScroll = true;
            this.pnlInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInstructions.Location = new System.Drawing.Point(79, 280);
            this.pnlInstructions.Name = "pnlInstructions";
            this.pnlInstructions.Size = new System.Drawing.Size(619, 308);
            this.pnlInstructions.TabIndex = 6;
            this.pnlInstructions.Visible = false;
            this.pnlInstructions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlInstructions_MouseDown);
            this.pnlInstructions.MouseEnter += new System.EventHandler(this.pnlInstructions_MouseEnter);
            this.pnlInstructions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlInstructions_MouseMove);
            this.pnlInstructions.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlInstructions_PreviewKeyDown);
            // 
            // nudPersons
            // 
            this.nudPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.nudPersons.Location = new System.Drawing.Point(270, 236);
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
            this.nudPersons.Size = new System.Drawing.Size(42, 27);
            this.nudPersons.TabIndex = 5;
            this.nudPersons.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPersons.Visible = false;
            this.nudPersons.ValueChanged += new System.EventHandler(this.nudPersons_ValueChanged);
            // 
            // lblPortions
            // 
            this.lblPortions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPortions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPortions.Location = new System.Drawing.Point(322, 244);
            this.lblPortions.Name = "lblPortions";
            this.lblPortions.Size = new System.Drawing.Size(77, 22);
            this.lblPortions.TabIndex = 25;
            this.lblPortions.Text = "portions";
            this.lblPortions.Visible = false;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.ContextMenuStrip = this.cmsRecipeResult;
            this.lstSearchResults.Enabled = false;
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 16;
            this.lstSearchResults.Location = new System.Drawing.Point(84, 101);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(378, 84);
            this.lstSearchResults.TabIndex = 3;
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            this.lstSearchResults.DoubleClick += new System.EventHandler(this.lstSearchResults_DoubleClick);
            this.lstSearchResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseMove);
            // 
            // cmsRecipeResult
            // 
            this.cmsRecipeResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRecipeResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRecipe,
            this.editThisRecipesInfos,
            this.deleteThisRecipe,
            this.exportThisRecipeToAWebPage,
            this.planRecipeOn,
            this.toolStripSeparator1,
            this.addIngredientToThisRecipe,
            this.deleteSelectedIngredientFromThisRecipe,
            this.toolStripSeparator2,
            this.addInstructionToThisRecipe,
            this.editSelectedInstruction,
            this.deleteSelectedInstruction,
            this.increaseInstructionFontSize,
            this.decreaseInstructionFontSize});
            this.cmsRecipeResult.Name = "cmsRecipeResult";
            this.cmsRecipeResult.Size = new System.Drawing.Size(418, 356);
            // 
            // newRecipe
            // 
            this.newRecipe.Image = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.newRecipe.Name = "newRecipe";
            this.newRecipe.Size = new System.Drawing.Size(417, 26);
            this.newRecipe.Text = "Nouvelle recette";
            this.newRecipe.Click += new System.EventHandler(this.newRecipeToolStripMenuItem_Click);
            // 
            // editThisRecipesInfos
            // 
            this.editThisRecipesInfos.Image = ((System.Drawing.Image)(resources.GetObject("editThisRecipesInfos.Image")));
            this.editThisRecipesInfos.Name = "editThisRecipesInfos";
            this.editThisRecipesInfos.Size = new System.Drawing.Size(417, 26);
            this.editThisRecipesInfos.Text = "Modifier les infos de base de la recette";
            this.editThisRecipesInfos.Visible = false;
            this.editThisRecipesInfos.Click += new System.EventHandler(this.editThisRecipesInfosToolStripMenuItem_Click);
            // 
            // deleteThisRecipe
            // 
            this.deleteThisRecipe.Image = ((System.Drawing.Image)(resources.GetObject("deleteThisRecipe.Image")));
            this.deleteThisRecipe.Name = "deleteThisRecipe";
            this.deleteThisRecipe.Size = new System.Drawing.Size(417, 26);
            this.deleteThisRecipe.Text = "Supprimer cette recette";
            this.deleteThisRecipe.Visible = false;
            this.deleteThisRecipe.Click += new System.EventHandler(this.deleteThisRecipeToolStripMenuItem_Click);
            // 
            // exportThisRecipeToAWebPage
            // 
            this.exportThisRecipeToAWebPage.Image = global::Recipe_Writer.Properties.Resources.export_db_to_html;
            this.exportThisRecipeToAWebPage.Name = "exportThisRecipeToAWebPage";
            this.exportThisRecipeToAWebPage.Size = new System.Drawing.Size(417, 26);
            this.exportThisRecipeToAWebPage.Text = "Exporter cette recette en une page web";
            this.exportThisRecipeToAWebPage.Visible = false;
            this.exportThisRecipeToAWebPage.Click += new System.EventHandler(this.exportThisRecipeToAWebPageToolStripMenuItem_Click);
            // 
            // planRecipeOn
            // 
            this.planRecipeOn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mondayToolStripMenuItem,
            this.tuesdayToolStripMenuItem,
            this.wednesdayToolStripMenuItem,
            this.thursdayToolStripMenuItem,
            this.fridayToolStripMenuItem,
            this.saturdayToolStripMenuItem,
            this.sundayToolStripMenuItem});
            this.planRecipeOn.Image = global::Recipe_Writer.Properties.Resources.plan_recipe_into_planner;
            this.planRecipeOn.Name = "planRecipeOn";
            this.planRecipeOn.Size = new System.Drawing.Size(417, 26);
            this.planRecipeOn.Text = "Planifier la recette pour le";
            this.planRecipeOn.Visible = false;
            // 
            // mondayToolStripMenuItem
            // 
            this.mondayToolStripMenuItem.Name = "mondayToolStripMenuItem";
            this.mondayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.mondayToolStripMenuItem.Text = "Lundi";
            this.mondayToolStripMenuItem.Click += new System.EventHandler(this.mondayToolStripMenuItem_Click);
            // 
            // tuesdayToolStripMenuItem
            // 
            this.tuesdayToolStripMenuItem.Name = "tuesdayToolStripMenuItem";
            this.tuesdayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.tuesdayToolStripMenuItem.Text = "Mardi";
            this.tuesdayToolStripMenuItem.Click += new System.EventHandler(this.tuesdayToolStripMenuItem_Click);
            // 
            // wednesdayToolStripMenuItem
            // 
            this.wednesdayToolStripMenuItem.Name = "wednesdayToolStripMenuItem";
            this.wednesdayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.wednesdayToolStripMenuItem.Text = "Mercredi";
            this.wednesdayToolStripMenuItem.Click += new System.EventHandler(this.wednesdayToolStripMenuItem_Click);
            // 
            // thursdayToolStripMenuItem
            // 
            this.thursdayToolStripMenuItem.Name = "thursdayToolStripMenuItem";
            this.thursdayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.thursdayToolStripMenuItem.Text = "Jeudi";
            this.thursdayToolStripMenuItem.Click += new System.EventHandler(this.thursdayToolStripMenuItem_Click);
            // 
            // fridayToolStripMenuItem
            // 
            this.fridayToolStripMenuItem.Name = "fridayToolStripMenuItem";
            this.fridayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.fridayToolStripMenuItem.Text = "Vendredi";
            this.fridayToolStripMenuItem.Click += new System.EventHandler(this.fridayToolStripMenuItem_Click);
            // 
            // saturdayToolStripMenuItem
            // 
            this.saturdayToolStripMenuItem.Name = "saturdayToolStripMenuItem";
            this.saturdayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.saturdayToolStripMenuItem.Text = "Samedi";
            this.saturdayToolStripMenuItem.Click += new System.EventHandler(this.saturdayToolStripMenuItem_Click);
            // 
            // sundayToolStripMenuItem
            // 
            this.sundayToolStripMenuItem.Name = "sundayToolStripMenuItem";
            this.sundayToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.sundayToolStripMenuItem.Text = "Dimanche";
            this.sundayToolStripMenuItem.Click += new System.EventHandler(this.sundayToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(414, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // addIngredientToThisRecipe
            // 
            this.addIngredientToThisRecipe.Image = global::Recipe_Writer.Properties.Resources.add_new_ingredient;
            this.addIngredientToThisRecipe.Name = "addIngredientToThisRecipe";
            this.addIngredientToThisRecipe.Size = new System.Drawing.Size(417, 26);
            this.addIngredientToThisRecipe.Text = "Ajouter un ingrédient à cette recette";
            this.addIngredientToThisRecipe.Visible = false;
            this.addIngredientToThisRecipe.Click += new System.EventHandler(this.addIngredientToThisRecipe_Click);
            // 
            // deleteSelectedIngredientFromThisRecipe
            // 
            this.deleteSelectedIngredientFromThisRecipe.Image = global::Recipe_Writer.Properties.Resources.delete;
            this.deleteSelectedIngredientFromThisRecipe.Name = "deleteSelectedIngredientFromThisRecipe";
            this.deleteSelectedIngredientFromThisRecipe.Size = new System.Drawing.Size(417, 26);
            this.deleteSelectedIngredientFromThisRecipe.Text = "Supprimer l\'ingrédient sélectionné de cette recette";
            this.deleteSelectedIngredientFromThisRecipe.Visible = false;
            this.deleteSelectedIngredientFromThisRecipe.Click += new System.EventHandler(this.deleteSelectedIngredientFromThisRecipe_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(414, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // addInstructionToThisRecipe
            // 
            this.addInstructionToThisRecipe.Image = global::Recipe_Writer.Properties.Resources.new_instruction;
            this.addInstructionToThisRecipe.Name = "addInstructionToThisRecipe";
            this.addInstructionToThisRecipe.Size = new System.Drawing.Size(417, 26);
            this.addInstructionToThisRecipe.Text = "Ajouter une instruction à la recette";
            this.addInstructionToThisRecipe.Visible = false;
            this.addInstructionToThisRecipe.Click += new System.EventHandler(this.addInstructionToThisRecipe_Click);
            // 
            // editSelectedInstruction
            // 
            this.editSelectedInstruction.Image = ((System.Drawing.Image)(resources.GetObject("editSelectedInstruction.Image")));
            this.editSelectedInstruction.Name = "editSelectedInstruction";
            this.editSelectedInstruction.Size = new System.Drawing.Size(417, 26);
            this.editSelectedInstruction.Text = "Modifier l\'instruction sélectionnée";
            this.editSelectedInstruction.Visible = false;
            this.editSelectedInstruction.Click += new System.EventHandler(this.editSelectedInstruction_Click);
            // 
            // deleteSelectedInstruction
            // 
            this.deleteSelectedInstruction.Image = global::Recipe_Writer.Properties.Resources.delete;
            this.deleteSelectedInstruction.Name = "deleteSelectedInstruction";
            this.deleteSelectedInstruction.Size = new System.Drawing.Size(417, 26);
            this.deleteSelectedInstruction.Text = "Supprimer l\'instruction sélectionnée";
            this.deleteSelectedInstruction.Visible = false;
            this.deleteSelectedInstruction.Click += new System.EventHandler(this.deleteSelectedInstruction_Click);
            // 
            // increaseInstructionFontSize
            // 
            this.increaseInstructionFontSize.Image = ((System.Drawing.Image)(resources.GetObject("increaseInstructionFontSize.Image")));
            this.increaseInstructionFontSize.Name = "increaseInstructionFontSize";
            this.increaseInstructionFontSize.Size = new System.Drawing.Size(417, 26);
            this.increaseInstructionFontSize.Text = "Augmenter la taille des instructions";
            this.increaseInstructionFontSize.Visible = false;
            this.increaseInstructionFontSize.Click += new System.EventHandler(this.increaseInstructionFontSize_Click);
            // 
            // decreaseInstructionFontSize
            // 
            this.decreaseInstructionFontSize.Image = ((System.Drawing.Image)(resources.GetObject("decreaseInstructionFontSize.Image")));
            this.decreaseInstructionFontSize.Name = "decreaseInstructionFontSize";
            this.decreaseInstructionFontSize.Size = new System.Drawing.Size(417, 26);
            this.decreaseInstructionFontSize.Text = "Diminuer la taille des instructions";
            this.decreaseInstructionFontSize.Visible = false;
            this.decreaseInstructionFontSize.Click += new System.EventHandler(this.decreaseInstructionFontSize_Click);
            // 
            // cmbRecipeIngredients
            // 
            this.cmbRecipeIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRecipeIngredients.FormattingEnabled = true;
            this.cmbRecipeIngredients.Location = new System.Drawing.Point(86, 238);
            this.cmbRecipeIngredients.Name = "cmbRecipeIngredients";
            this.cmbRecipeIngredients.Size = new System.Drawing.Size(173, 24);
            this.cmbRecipeIngredients.TabIndex = 4;
            this.cmbRecipeIngredients.Visible = false;
            this.cmbRecipeIngredients.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeIngredients_SelectedIndexChanged);
            // 
            // lblCompletionTime
            // 
            this.lblCompletionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCompletionTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCompletionTime.Location = new System.Drawing.Point(143, 202);
            this.lblCompletionTime.Name = "lblCompletionTime";
            this.lblCompletionTime.Size = new System.Drawing.Size(81, 23);
            this.lblCompletionTime.TabIndex = 24;
            this.lblCompletionTime.Text = "20 min.";
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
            this.pnlSlideMenu.Controls.Add(this.cmdingredientSearch);
            this.pnlSlideMenu.Location = new System.Drawing.Point(79, 100);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(10, 204);
            this.pnlSlideMenu.TabIndex = 19;
            this.pnlSlideMenu.Visible = false;
            // 
            // chkFilterRecipesForThreeStars
            // 
            this.chkFilterRecipesForThreeStars.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFilterRecipesForThreeStars.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.chkFilterRecipesForThreeStars.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkFilterRecipesForThreeStars.Location = new System.Drawing.Point(204, 159);
            this.chkFilterRecipesForThreeStars.Name = "chkFilterRecipesForThreeStars";
            this.chkFilterRecipesForThreeStars.Size = new System.Drawing.Size(92, 24);
            this.chkFilterRecipesForThreeStars.TabIndex = 15;
            this.chkFilterRecipesForThreeStars.Text = "3 étoiles";
            this.chkFilterRecipesForThreeStars.UseVisualStyleBackColor = true;
            // 
            // chkFilterRecipesForSmallBudget
            // 
            this.chkFilterRecipesForSmallBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkFilterRecipesForSmallBudget.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFilterRecipesForSmallBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.chkFilterRecipesForSmallBudget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkFilterRecipesForSmallBudget.Location = new System.Drawing.Point(28, 159);
            this.chkFilterRecipesForSmallBudget.Name = "chkFilterRecipesForSmallBudget";
            this.chkFilterRecipesForSmallBudget.Size = new System.Drawing.Size(116, 24);
            this.chkFilterRecipesForSmallBudget.TabIndex = 14;
            this.chkFilterRecipesForSmallBudget.Text = "Petit budget";
            this.chkFilterRecipesForSmallBudget.UseVisualStyleBackColor = true;
            // 
            // lblSearchByIngredients
            // 
            this.lblSearchByIngredients.AutoSize = true;
            this.lblSearchByIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSearchByIngredients.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSearchByIngredients.Location = new System.Drawing.Point(134, 9);
            this.lblSearchByIngredients.Name = "lblSearchByIngredients";
            this.lblSearchByIngredients.Size = new System.Drawing.Size(180, 18);
            this.lblSearchByIngredients.TabIndex = 19;
            this.lblSearchByIngredients.Text = "Recherche par ingrédients";
            // 
            // lblSearchIngredient3
            // 
            this.lblSearchIngredient3.AutoSize = true;
            this.lblSearchIngredient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSearchIngredient3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSearchIngredient3.Location = new System.Drawing.Point(25, 110);
            this.lblSearchIngredient3.Name = "lblSearchIngredient3";
            this.lblSearchIngredient3.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient3.TabIndex = 23;
            this.lblSearchIngredient3.Text = "Ingrédient #3 :";
            this.lblSearchIngredient3.Click += new System.EventHandler(this.lblSearchIngredient3_Click);
            // 
            // lblSearchIngredient2
            // 
            this.lblSearchIngredient2.AutoSize = true;
            this.lblSearchIngredient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSearchIngredient2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSearchIngredient2.Location = new System.Drawing.Point(25, 78);
            this.lblSearchIngredient2.Name = "lblSearchIngredient2";
            this.lblSearchIngredient2.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient2.TabIndex = 21;
            this.lblSearchIngredient2.Text = "Ingrédient #2 :";
            this.lblSearchIngredient2.Click += new System.EventHandler(this.lblSearchIngredient2_Click);
            // 
            // lblSearchIngredient1
            // 
            this.lblSearchIngredient1.AutoSize = true;
            this.lblSearchIngredient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSearchIngredient1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSearchIngredient1.Location = new System.Drawing.Point(25, 43);
            this.lblSearchIngredient1.Name = "lblSearchIngredient1";
            this.lblSearchIngredient1.Size = new System.Drawing.Size(99, 18);
            this.lblSearchIngredient1.TabIndex = 20;
            this.lblSearchIngredient1.Text = "Ingrédient #1 :";
            this.lblSearchIngredient1.Click += new System.EventHandler(this.lblSearchIngredient1_Click);
            // 
            // txtSearchIngredient3
            // 
            this.txtSearchIngredient3.Location = new System.Drawing.Point(169, 109);
            this.txtSearchIngredient3.Name = "txtSearchIngredient3";
            this.txtSearchIngredient3.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient3.TabIndex = 13;
            this.txtSearchIngredient3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchIngredient3_PreviewKeyDown);
            // 
            // txtSearchIngredient2
            // 
            this.txtSearchIngredient2.Location = new System.Drawing.Point(169, 74);
            this.txtSearchIngredient2.Name = "txtSearchIngredient2";
            this.txtSearchIngredient2.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient2.TabIndex = 12;
            this.txtSearchIngredient2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchIngredient2_PreviewKeyDown);
            // 
            // txtSearchIngredient1
            // 
            this.txtSearchIngredient1.Location = new System.Drawing.Point(169, 43);
            this.txtSearchIngredient1.Name = "txtSearchIngredient1";
            this.txtSearchIngredient1.Size = new System.Drawing.Size(228, 22);
            this.txtSearchIngredient1.TabIndex = 11;
            this.txtSearchIngredient1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchIngredient1_PreviewKeyDown);
            // 
            // cmdingredientSearch
            // 
            this.cmdingredientSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdingredientSearch.BackgroundImage")));
            this.cmdingredientSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdingredientSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdingredientSearch.FlatAppearance.BorderSize = 0;
            this.cmdingredientSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdingredientSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdingredientSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdingredientSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdingredientSearch.Location = new System.Drawing.Point(357, 143);
            this.cmdingredientSearch.Name = "cmdingredientSearch";
            this.cmdingredientSearch.Size = new System.Drawing.Size(40, 40);
            this.cmdingredientSearch.TabIndex = 16;
            this.cmdingredientSearch.UseVisualStyleBackColor = true;
            this.cmdingredientSearch.Click += new System.EventHandler(this.cmdingredientSearch_Click);
            // 
            // pnlScore
            // 
            this.pnlScore.Controls.Add(this.picScore3);
            this.pnlScore.Controls.Add(this.picScore2);
            this.pnlScore.Controls.Add(this.picScore1);
            this.pnlScore.Location = new System.Drawing.Point(494, 190);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(204, 35);
            this.pnlScore.TabIndex = 17;
            this.pnlScore.Visible = false;
            this.pnlScore.MouseLeave += new System.EventHandler(this.pnlScore_MouseLeave);
            this.pnlScore.MouseHover += new System.EventHandler(this.pnlScore_MouseHover);
            // 
            // picScore3
            // 
            this.picScore3.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picScore3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScore3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picScore3.Location = new System.Drawing.Point(112, 3);
            this.picScore3.Name = "picScore3";
            this.picScore3.Size = new System.Drawing.Size(36, 29);
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
            this.picScore2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScore2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picScore2.Location = new System.Drawing.Point(79, 3);
            this.picScore2.Name = "picScore2";
            this.picScore2.Size = new System.Drawing.Size(36, 29);
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
            this.picScore1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScore1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picScore1.Location = new System.Drawing.Point(46, 3);
            this.picScore1.Name = "picScore1";
            this.picScore1.Size = new System.Drawing.Size(36, 29);
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
            this.cmdTitleSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmdTitleSearch.BackgroundImage = global::Recipe_Writer.Properties.Resources.search;
            this.cmdTitleSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdTitleSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdTitleSearch.FlatAppearance.BorderSize = 0;
            this.cmdTitleSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdTitleSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdTitleSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTitleSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdTitleSearch.Location = new System.Drawing.Point(422, 32);
            this.cmdTitleSearch.Name = "cmdTitleSearch";
            this.cmdTitleSearch.Size = new System.Drawing.Size(40, 39);
            this.cmdTitleSearch.TabIndex = 2;
            this.cmdTitleSearch.UseVisualStyleBackColor = false;
            this.cmdTitleSearch.Click += new System.EventHandler(this.cmdTitleSearch_Click);
            // 
            // cmdMealPlanner
            // 
            this.cmdMealPlanner.BackgroundImage = global::Recipe_Writer.Properties.Resources.planner;
            this.cmdMealPlanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdMealPlanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMealPlanner.FlatAppearance.BorderSize = 0;
            this.cmdMealPlanner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdMealPlanner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdMealPlanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMealPlanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmdMealPlanner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdMealPlanner.Location = new System.Drawing.Point(9, 217);
            this.cmdMealPlanner.Name = "cmdMealPlanner";
            this.cmdMealPlanner.Size = new System.Drawing.Size(60, 50);
            this.cmdMealPlanner.TabIndex = 9;
            this.cmdMealPlanner.UseVisualStyleBackColor = true;
            this.cmdMealPlanner.Click += new System.EventHandler(this.cmdMealPlanner_Click);
            this.cmdMealPlanner.MouseEnter += new System.EventHandler(this.cmdMealPlanner_MouseEnter);
            this.cmdMealPlanner.MouseLeave += new System.EventHandler(this.cmdMealPlanner_MouseLeave);
            // 
            // cmdInventory
            // 
            this.cmdInventory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdInventory.BackgroundImage")));
            this.cmdInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdInventory.FlatAppearance.BorderSize = 0;
            this.cmdInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmdInventory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdInventory.Location = new System.Drawing.Point(9, 159);
            this.cmdInventory.Name = "cmdInventory";
            this.cmdInventory.Size = new System.Drawing.Size(60, 50);
            this.cmdInventory.TabIndex = 8;
            this.cmdInventory.UseVisualStyleBackColor = true;
            this.cmdInventory.Click += new System.EventHandler(this.cmdInventory_Click);
            this.cmdInventory.MouseEnter += new System.EventHandler(this.cmdInventory_MouseEnter);
            this.cmdInventory.MouseLeave += new System.EventHandler(this.cmdInventory_MouseLeave);
            // 
            // cmdSearchByIngredient
            // 
            this.cmdSearchByIngredient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSearchByIngredient.BackgroundImage")));
            this.cmdSearchByIngredient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSearchByIngredient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearchByIngredient.FlatAppearance.BorderSize = 0;
            this.cmdSearchByIngredient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdSearchByIngredient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdSearchByIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSearchByIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmdSearchByIngredient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSearchByIngredient.Location = new System.Drawing.Point(11, 98);
            this.cmdSearchByIngredient.Name = "cmdSearchByIngredient";
            this.cmdSearchByIngredient.Size = new System.Drawing.Size(60, 50);
            this.cmdSearchByIngredient.TabIndex = 7;
            this.cmdSearchByIngredient.UseVisualStyleBackColor = true;
            this.cmdSearchByIngredient.Click += new System.EventHandler(this.cmdSearchByIngredient_Click);
            this.cmdSearchByIngredient.MouseEnter += new System.EventHandler(this.cmdSearchByIngredient_MouseEnter);
            this.cmdSearchByIngredient.MouseLeave += new System.EventHandler(this.cmdSearchByIngredient_MouseLeave);
            // 
            // picLowBudget
            // 
            this.picLowBudget.BackgroundImage = global::Recipe_Writer.Properties.Resources.lowBudget;
            this.picLowBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLowBudget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picLowBudget.Location = new System.Drawing.Point(455, 234);
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
            this.picRecipe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picRecipe.Location = new System.Drawing.Point(494, 29);
            this.picRecipe.Name = "picRecipe";
            this.picRecipe.Size = new System.Drawing.Size(204, 153);
            this.picRecipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRecipe.TabIndex = 2;
            this.picRecipe.TabStop = false;
            this.picRecipe.Visible = false;
            this.picRecipe.Click += new System.EventHandler(this.picRecipe_Click);
            // 
            // cmdNewRecipe
            // 
            this.cmdNewRecipe.BackgroundImage = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.cmdNewRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdNewRecipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNewRecipe.FlatAppearance.BorderSize = 0;
            this.cmdNewRecipe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdNewRecipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdNewRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNewRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmdNewRecipe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdNewRecipe.Location = new System.Drawing.Point(84, 32);
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.cmdNewRecipe.Size = new System.Drawing.Size(40, 40);
            this.cmdNewRecipe.TabIndex = 0;
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            this.cmdNewRecipe.Click += new System.EventHandler(this.cmdNewRecipe_Click);
            // 
            // picRecipeReadyToCookStatus
            // 
            this.picRecipeReadyToCookStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picRecipeReadyToCookStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picRecipeReadyToCookStatus.Location = new System.Drawing.Point(409, 231);
            this.picRecipeReadyToCookStatus.Name = "picRecipeReadyToCookStatus";
            this.picRecipeReadyToCookStatus.Size = new System.Drawing.Size(31, 35);
            this.picRecipeReadyToCookStatus.TabIndex = 28;
            this.picRecipeReadyToCookStatus.TabStop = false;
            this.picRecipeReadyToCookStatus.MouseHover += new System.EventHandler(this.picRecipeReadyToCookStatus_MouseHover);
            // 
            // cmdSettings
            // 
            this.cmdSettings.BackgroundImage = global::Recipe_Writer.Properties.Resources.settings;
            this.cmdSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSettings.FlatAppearance.BorderSize = 0;
            this.cmdSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cmdSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmdSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettings.Location = new System.Drawing.Point(8, 280);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(60, 50);
            this.cmdSettings.TabIndex = 10;
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            this.cmdSettings.MouseEnter += new System.EventHandler(this.cmdSettings_MouseEnter);
            this.cmdSettings.MouseLeave += new System.EventHandler(this.cmdSettings_MouseLeave);
            // 
            // picCompletionTime
            // 
            this.picCompletionTime.BackgroundImage = global::Recipe_Writer.Properties.Resources.recipeCooked;
            this.picCompletionTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picCompletionTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picCompletionTime.Location = new System.Drawing.Point(102, 192);
            this.picCompletionTime.Name = "picCompletionTime";
            this.picCompletionTime.Size = new System.Drawing.Size(35, 30);
            this.picCompletionTime.TabIndex = 12;
            this.picCompletionTime.TabStop = false;
            this.picCompletionTime.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(727, 600);
            this.ContextMenuStrip = this.cmsRecipeResult;
            this.Controls.Add(this.pnlSlideMenu);
            this.Controls.Add(this.cmdMealPlanner);
            this.Controls.Add(this.cmdInventory);
            this.Controls.Add(this.cmdSearchByIngredient);
            this.Controls.Add(this.pnlScore);
            this.Controls.Add(this.picCompletionTime);
            this.Controls.Add(this.picLowBudget);
            this.Controls.Add(this.cmbRecipeIngredients);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.nudPersons);
            this.Controls.Add(this.lblCompletionTime);
            this.Controls.Add(this.lblPortions);
            this.Controls.Add(this.pnlInstructions);
            this.Controls.Add(this.picRecipe);
            this.Controls.Add(this.cmdNewRecipe);
            this.Controls.Add(this.cmdTitleSearch);
            this.Controls.Add(this.txtTitleSearch);
            this.Controls.Add(this.picRecipeReadyToCookStatus);
            this.Controls.Add(this.cmdSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe Writer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            this.cmsRecipeResult.ResumeLayout(false);
            this.pnlSlideMenu.ResumeLayout(false);
            this.pnlSlideMenu.PerformLayout();
            this.pnlScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScore3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLowBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipeReadyToCookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompletionTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlInstructions;
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
        private System.Windows.Forms.Button cmdingredientSearch;
        private System.Windows.Forms.NumericUpDown nudPersons;
        private System.Windows.Forms.ContextMenuStrip cmsRecipeResult;
        private System.Windows.Forms.ToolStripMenuItem newRecipe;
        private System.Windows.Forms.ToolStripMenuItem editThisRecipesInfos;
        private System.Windows.Forms.ToolStripMenuItem deleteThisRecipe;
        private System.Windows.Forms.ToolStripMenuItem exportThisRecipeToAWebPage;
        public System.Windows.Forms.TextBox txtTitleSearch;
        public System.Windows.Forms.ComboBox cmbRecipeIngredients;
        private System.Windows.Forms.PictureBox picLowBudget;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.PictureBox picScore3;
        private System.Windows.Forms.PictureBox picScore2;
        private System.Windows.Forms.PictureBox picScore1;
        private System.Windows.Forms.ToolStripMenuItem planRecipeOn;
        private System.Windows.Forms.ToolStripMenuItem mondayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tuesdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wednesdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thursdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fridayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saturdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sundayToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkFilterRecipesForThreeStars;
        private System.Windows.Forms.PictureBox picRecipeReadyToCookStatus;
        private System.Windows.Forms.ToolTip ttpRecipeReadyToCookStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addIngredientToThisRecipe;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedIngredientFromThisRecipe;
        private System.Windows.Forms.Button cmdSearchByIngredient;
        private System.Windows.Forms.Button cmdInventory;
        private System.Windows.Forms.Button cmdMealPlanner;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.Button cmdTitleSearch;
        private System.Windows.Forms.PictureBox picCompletionTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addInstructionToThisRecipe;
        private System.Windows.Forms.ToolStripMenuItem editSelectedInstruction;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedInstruction;
        private System.Windows.Forms.ToolStripMenuItem increaseInstructionFontSize;
        private System.Windows.Forms.ToolStripMenuItem decreaseInstructionFontSize;
    }
}

