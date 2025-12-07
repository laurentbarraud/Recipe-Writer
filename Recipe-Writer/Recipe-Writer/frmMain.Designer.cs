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
            this.mondayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wednesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thursdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fridayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.txtTitleSearch, "txtTitleSearch");
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.txtTitleSearch, resources.GetString("txtTitleSearch.ToolTip"));
            this.txtTitleSearch.Enter += new System.EventHandler(this.txtTitleSearch_Enter);
            // 
            // lblSearchResults
            // 
            resources.ApplyResources(this.lblSearchResults, "lblSearchResults");
            this.lblSearchResults.Name = "lblSearchResults";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblSearchResults, resources.GetString("lblSearchResults.ToolTip"));
            // 
            // pnlInstructions
            // 
            resources.ApplyResources(this.pnlInstructions, "pnlInstructions");
            this.pnlInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInstructions.Name = "pnlInstructions";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.pnlInstructions, resources.GetString("pnlInstructions.ToolTip"));
            // 
            // nudPersons
            // 
            resources.ApplyResources(this.nudPersons, "nudPersons");
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
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.nudPersons, resources.GetString("nudPersons.ToolTip"));
            this.nudPersons.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPersons.ValueChanged += new System.EventHandler(this.nudPersons_ValueChanged);
            // 
            // lblPortions
            // 
            resources.ApplyResources(this.lblPortions, "lblPortions");
            this.lblPortions.Name = "lblPortions";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblPortions, resources.GetString("lblPortions.ToolTip"));
            // 
            // lstSearchResults
            // 
            resources.ApplyResources(this.lstSearchResults, "lstSearchResults");
            this.lstSearchResults.ContextMenuStrip = this.cmsRecipeResult;
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.Name = "lstSearchResults";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lstSearchResults, resources.GetString("lstSearchResults.ToolTip"));
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            this.lstSearchResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseMove);
            // 
            // cmsRecipeResult
            // 
            resources.ApplyResources(this.cmsRecipeResult, "cmsRecipeResult");
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
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.cmsRecipeResult, resources.GetString("cmsRecipeResult.ToolTip"));
            // 
            // newRecipeToolStripMenuItem
            // 
            resources.ApplyResources(this.newRecipeToolStripMenuItem, "newRecipeToolStripMenuItem");
            this.newRecipeToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.newRecipeToolStripMenuItem.Name = "newRecipeToolStripMenuItem";
            this.newRecipeToolStripMenuItem.Click += new System.EventHandler(this.newRecipeToolStripMenuItem_Click);
            // 
            // editThisRecipesBasicInfosToolStripMenuItem
            // 
            resources.ApplyResources(this.editThisRecipesBasicInfosToolStripMenuItem, "editThisRecipesBasicInfosToolStripMenuItem");
            this.editThisRecipesBasicInfosToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.edit_recipe_title;
            this.editThisRecipesBasicInfosToolStripMenuItem.Name = "editThisRecipesBasicInfosToolStripMenuItem";
            this.editThisRecipesBasicInfosToolStripMenuItem.Click += new System.EventHandler(this.editThisRecipesBasicInfosToolStripMenuItem_Click);
            // 
            // deleteThisRecipeToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteThisRecipeToolStripMenuItem, "deleteThisRecipeToolStripMenuItem");
            this.deleteThisRecipeToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.delete_recipe;
            this.deleteThisRecipeToolStripMenuItem.Name = "deleteThisRecipeToolStripMenuItem";
            this.deleteThisRecipeToolStripMenuItem.Click += new System.EventHandler(this.deleteThisRecipeToolStripMenuItem_Click);
            // 
            // exportThisRecipeToAWebPageToolStripMenuItem
            // 
            resources.ApplyResources(this.exportThisRecipeToAWebPageToolStripMenuItem, "exportThisRecipeToAWebPageToolStripMenuItem");
            this.exportThisRecipeToAWebPageToolStripMenuItem.Image = global::Recipe_Writer.Properties.Resources.export_to_html;
            this.exportThisRecipeToAWebPageToolStripMenuItem.Name = "exportThisRecipeToAWebPageToolStripMenuItem";
            this.exportThisRecipeToAWebPageToolStripMenuItem.Click += new System.EventHandler(this.exportThisRecipeToAWebPageToolStripMenuItem_Click);
            // 
            // PlanRecipeOn
            // 
            resources.ApplyResources(this.PlanRecipeOn, "PlanRecipeOn");
            this.PlanRecipeOn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mondayToolStripMenuItem,
            this.tuesdayToolStripMenuItem,
            this.wednesdayToolStripMenuItem,
            this.thursdayToolStripMenuItem,
            this.fridayToolStripMenuItem,
            this.saturdayToolStripMenuItem,
            this.sundayToolStripMenuItem});
            this.PlanRecipeOn.Image = global::Recipe_Writer.Properties.Resources.plan__recipe_into_planner;
            this.PlanRecipeOn.Name = "PlanRecipeOn";
            // 
            // mondayToolStripMenuItem
            // 
            resources.ApplyResources(this.mondayToolStripMenuItem, "mondayToolStripMenuItem");
            this.mondayToolStripMenuItem.Name = "mondayToolStripMenuItem";
            this.mondayToolStripMenuItem.Click += new System.EventHandler(this.mondayToolStripMenuItem_Click);
            // 
            // tuesdayToolStripMenuItem
            // 
            resources.ApplyResources(this.tuesdayToolStripMenuItem, "tuesdayToolStripMenuItem");
            this.tuesdayToolStripMenuItem.Name = "tuesdayToolStripMenuItem";
            this.tuesdayToolStripMenuItem.Click += new System.EventHandler(this.tuesdayToolStripMenuItem_Click);
            // 
            // wednesdayToolStripMenuItem
            // 
            resources.ApplyResources(this.wednesdayToolStripMenuItem, "wednesdayToolStripMenuItem");
            this.wednesdayToolStripMenuItem.Name = "wednesdayToolStripMenuItem";
            this.wednesdayToolStripMenuItem.Click += new System.EventHandler(this.wednesdayToolStripMenuItem_Click);
            // 
            // thursdayToolStripMenuItem
            // 
            resources.ApplyResources(this.thursdayToolStripMenuItem, "thursdayToolStripMenuItem");
            this.thursdayToolStripMenuItem.Name = "thursdayToolStripMenuItem";
            this.thursdayToolStripMenuItem.Click += new System.EventHandler(this.thursdayToolStripMenuItem_Click);
            // 
            // fridayToolStripMenuItem
            // 
            resources.ApplyResources(this.fridayToolStripMenuItem, "fridayToolStripMenuItem");
            this.fridayToolStripMenuItem.Name = "fridayToolStripMenuItem";
            this.fridayToolStripMenuItem.Click += new System.EventHandler(this.fridayToolStripMenuItem_Click);
            // 
            // saturdayToolStripMenuItem
            // 
            resources.ApplyResources(this.saturdayToolStripMenuItem, "saturdayToolStripMenuItem");
            this.saturdayToolStripMenuItem.Name = "saturdayToolStripMenuItem";
            this.saturdayToolStripMenuItem.Click += new System.EventHandler(this.saturdayToolStripMenuItem_Click);
            // 
            // sundayToolStripMenuItem
            // 
            resources.ApplyResources(this.sundayToolStripMenuItem, "sundayToolStripMenuItem");
            this.sundayToolStripMenuItem.Name = "sundayToolStripMenuItem";
            this.sundayToolStripMenuItem.Click += new System.EventHandler(this.sundayToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // addIngredientToThisRecipe
            // 
            resources.ApplyResources(this.addIngredientToThisRecipe, "addIngredientToThisRecipe");
            this.addIngredientToThisRecipe.Name = "addIngredientToThisRecipe";
            this.addIngredientToThisRecipe.Click += new System.EventHandler(this.addIngredientToThisRecipe_Click);
            // 
            // deleteIngredientFromThisRecipe
            // 
            resources.ApplyResources(this.deleteIngredientFromThisRecipe, "deleteIngredientFromThisRecipe");
            this.deleteIngredientFromThisRecipe.Name = "deleteIngredientFromThisRecipe";
            this.deleteIngredientFromThisRecipe.Click += new System.EventHandler(this.deleteIngredientFromThisRecipe_Click);
            // 
            // cmbRecipeIngredients
            // 
            resources.ApplyResources(this.cmbRecipeIngredients, "cmbRecipeIngredients");
            this.cmbRecipeIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeIngredients.FormattingEnabled = true;
            this.cmbRecipeIngredients.Name = "cmbRecipeIngredients";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.cmbRecipeIngredients, resources.GetString("cmbRecipeIngredients.ToolTip"));
            this.cmbRecipeIngredients.SelectedIndexChanged += new System.EventHandler(this.cmbRecipeIngredients_SelectedIndexChanged);
            // 
            // lblCompletionTime
            // 
            resources.ApplyResources(this.lblCompletionTime, "lblCompletionTime");
            this.lblCompletionTime.Name = "lblCompletionTime";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblCompletionTime, resources.GetString("lblCompletionTime.ToolTip"));
            // 
            // ofdAssociatedImage
            // 
            this.ofdAssociatedImage.DefaultExt = "\"Tous les types d\'images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff\"";
            this.ofdAssociatedImage.FileName = "openFileDialog1";
            resources.ApplyResources(this.ofdAssociatedImage, "ofdAssociatedImage");
            this.ofdAssociatedImage.FilterIndex = 6;
            this.ofdAssociatedImage.InitialDirectory = "@\"C:\\\"";
            // 
            // pnlSlideMenu
            // 
            resources.ApplyResources(this.pnlSlideMenu, "pnlSlideMenu");
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
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.pnlSlideMenu, resources.GetString("pnlSlideMenu.ToolTip"));
            // 
            // chkFilterRecipesForThreeStars
            // 
            resources.ApplyResources(this.chkFilterRecipesForThreeStars, "chkFilterRecipesForThreeStars");
            this.chkFilterRecipesForThreeStars.Name = "chkFilterRecipesForThreeStars";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.chkFilterRecipesForThreeStars, resources.GetString("chkFilterRecipesForThreeStars.ToolTip"));
            this.chkFilterRecipesForThreeStars.UseVisualStyleBackColor = true;
            // 
            // chkFilterRecipesForSmallBudget
            // 
            resources.ApplyResources(this.chkFilterRecipesForSmallBudget, "chkFilterRecipesForSmallBudget");
            this.chkFilterRecipesForSmallBudget.Name = "chkFilterRecipesForSmallBudget";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.chkFilterRecipesForSmallBudget, resources.GetString("chkFilterRecipesForSmallBudget.ToolTip"));
            this.chkFilterRecipesForSmallBudget.UseVisualStyleBackColor = true;
            // 
            // lblSearchByIngredients
            // 
            resources.ApplyResources(this.lblSearchByIngredients, "lblSearchByIngredients");
            this.lblSearchByIngredients.Name = "lblSearchByIngredients";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblSearchByIngredients, resources.GetString("lblSearchByIngredients.ToolTip"));
            // 
            // lblSearchIngredient3
            // 
            resources.ApplyResources(this.lblSearchIngredient3, "lblSearchIngredient3");
            this.lblSearchIngredient3.Name = "lblSearchIngredient3";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblSearchIngredient3, resources.GetString("lblSearchIngredient3.ToolTip"));
            this.lblSearchIngredient3.Click += new System.EventHandler(this.lblSearchIngredient3_Click);
            // 
            // lblSearchIngredient2
            // 
            resources.ApplyResources(this.lblSearchIngredient2, "lblSearchIngredient2");
            this.lblSearchIngredient2.Name = "lblSearchIngredient2";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblSearchIngredient2, resources.GetString("lblSearchIngredient2.ToolTip"));
            this.lblSearchIngredient2.Click += new System.EventHandler(this.lblSearchIngredient2_Click);
            // 
            // lblSearchIngredient1
            // 
            resources.ApplyResources(this.lblSearchIngredient1, "lblSearchIngredient1");
            this.lblSearchIngredient1.Name = "lblSearchIngredient1";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.lblSearchIngredient1, resources.GetString("lblSearchIngredient1.ToolTip"));
            this.lblSearchIngredient1.Click += new System.EventHandler(this.lblSearchIngredient1_Click);
            // 
            // txtSearchIngredient3
            // 
            resources.ApplyResources(this.txtSearchIngredient3, "txtSearchIngredient3");
            this.txtSearchIngredient3.Name = "txtSearchIngredient3";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.txtSearchIngredient3, resources.GetString("txtSearchIngredient3.ToolTip"));
            // 
            // txtSearchIngredient2
            // 
            resources.ApplyResources(this.txtSearchIngredient2, "txtSearchIngredient2");
            this.txtSearchIngredient2.Name = "txtSearchIngredient2";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.txtSearchIngredient2, resources.GetString("txtSearchIngredient2.ToolTip"));
            // 
            // txtSearchIngredient1
            // 
            resources.ApplyResources(this.txtSearchIngredient1, "txtSearchIngredient1");
            this.txtSearchIngredient1.Name = "txtSearchIngredient1";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.txtSearchIngredient1, resources.GetString("txtSearchIngredient1.ToolTip"));
            // 
            // cmdIngredientsSearch
            // 
            resources.ApplyResources(this.cmdIngredientsSearch, "cmdIngredientsSearch");
            this.cmdIngredientsSearch.FlatAppearance.BorderSize = 0;
            this.cmdIngredientsSearch.Name = "cmdIngredientsSearch";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.cmdIngredientsSearch, resources.GetString("cmdIngredientsSearch.ToolTip"));
            this.cmdIngredientsSearch.UseVisualStyleBackColor = true;
            this.cmdIngredientsSearch.Click += new System.EventHandler(this.cmdIngredientsSearch_Click);
            // 
            // pnlScore
            // 
            resources.ApplyResources(this.pnlScore, "pnlScore");
            this.pnlScore.Controls.Add(this.picScore3);
            this.pnlScore.Controls.Add(this.picScore2);
            this.pnlScore.Controls.Add(this.picScore1);
            this.pnlScore.Name = "pnlScore";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.pnlScore, resources.GetString("pnlScore.ToolTip"));
            this.pnlScore.MouseLeave += new System.EventHandler(this.pnlScore_MouseLeave);
            this.pnlScore.MouseHover += new System.EventHandler(this.pnlScore_MouseHover);
            // 
            // picScore3
            // 
            resources.ApplyResources(this.picScore3, "picScore3");
            this.picScore3.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore3.Name = "picScore3";
            this.picScore3.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picScore3, resources.GetString("picScore3.ToolTip"));
            this.picScore3.Click += new System.EventHandler(this.picScore3_Click);
            this.picScore3.MouseHover += new System.EventHandler(this.picScore3_MouseHover);
            // 
            // picScore2
            // 
            resources.ApplyResources(this.picScore2, "picScore2");
            this.picScore2.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore2.Name = "picScore2";
            this.picScore2.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picScore2, resources.GetString("picScore2.ToolTip"));
            this.picScore2.Click += new System.EventHandler(this.picScore2_Click);
            this.picScore2.MouseHover += new System.EventHandler(this.picScore2_MouseHover);
            // 
            // picScore1
            // 
            resources.ApplyResources(this.picScore1, "picScore1");
            this.picScore1.BackgroundImage = global::Recipe_Writer.Properties.Resources._1_star_disabled;
            this.picScore1.Name = "picScore1";
            this.picScore1.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picScore1, resources.GetString("picScore1.ToolTip"));
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
            resources.ApplyResources(this.cmdTitleSearch, "cmdTitleSearch");
            this.cmdTitleSearch.FlatAppearance.BorderSize = 0;
            this.cmdTitleSearch.Name = "cmdTitleSearch";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.cmdTitleSearch, resources.GetString("cmdTitleSearch.ToolTip"));
            this.cmdTitleSearch.UseVisualStyleBackColor = true;
            this.cmdTitleSearch.Click += new System.EventHandler(this.cmdTitleSearch_Click);
            // 
            // picSettings
            // 
            resources.ApplyResources(this.picSettings, "picSettings");
            this.picSettings.BackgroundImage = global::Recipe_Writer.Properties.Resources.settings;
            this.picSettings.Name = "picSettings";
            this.picSettings.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picSettings, resources.GetString("picSettings.ToolTip"));
            this.picSettings.Click += new System.EventHandler(this.picSettings_Click);
            this.picSettings.MouseHover += new System.EventHandler(this.picSettings_MouseHover);
            // 
            // picMealPlanner
            // 
            resources.ApplyResources(this.picMealPlanner, "picMealPlanner");
            this.picMealPlanner.BackgroundImage = global::Recipe_Writer.Properties.Resources.planner;
            this.picMealPlanner.Name = "picMealPlanner";
            this.picMealPlanner.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picMealPlanner, resources.GetString("picMealPlanner.ToolTip"));
            this.picMealPlanner.Click += new System.EventHandler(this.picMealPlanner_Click);
            this.picMealPlanner.MouseHover += new System.EventHandler(this.picMealPlanner_MouseHover);
            // 
            // picSearchByIngredient
            // 
            resources.ApplyResources(this.picSearchByIngredient, "picSearchByIngredient");
            this.picSearchByIngredient.BackgroundImage = global::Recipe_Writer.Properties.Resources.ingredients_search;
            this.picSearchByIngredient.Name = "picSearchByIngredient";
            this.picSearchByIngredient.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picSearchByIngredient, resources.GetString("picSearchByIngredient.ToolTip"));
            this.picSearchByIngredient.MouseHover += new System.EventHandler(this.picSearchByIngredient_MouseHover);
            // 
            // picInventory
            // 
            resources.ApplyResources(this.picInventory, "picInventory");
            this.picInventory.BackgroundImage = global::Recipe_Writer.Properties.Resources.inventory;
            this.picInventory.Name = "picInventory";
            this.picInventory.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picInventory, resources.GetString("picInventory.ToolTip"));
            this.picInventory.Click += new System.EventHandler(this.picInventory_Click);
            this.picInventory.MouseHover += new System.EventHandler(this.picInventory_MouseHover);
            // 
            // cmdAddInstruction
            // 
            resources.ApplyResources(this.cmdAddInstruction, "cmdAddInstruction");
            this.cmdAddInstruction.FlatAppearance.BorderSize = 0;
            this.cmdAddInstruction.Name = "cmdAddInstruction";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.cmdAddInstruction, resources.GetString("cmdAddInstruction.ToolTip"));
            this.cmdAddInstruction.UseVisualStyleBackColor = true;
            this.cmdAddInstruction.Click += new System.EventHandler(this.cmdAddInstruction_Click);
            // 
            // picLowBudget
            // 
            resources.ApplyResources(this.picLowBudget, "picLowBudget");
            this.picLowBudget.BackgroundImage = global::Recipe_Writer.Properties.Resources.lowBudget;
            this.picLowBudget.Name = "picLowBudget";
            this.picLowBudget.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picLowBudget, resources.GetString("picLowBudget.ToolTip"));
            // 
            // picRecipe
            // 
            resources.ApplyResources(this.picRecipe, "picRecipe");
            this.picRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRecipe.Name = "picRecipe";
            this.picRecipe.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picRecipe, resources.GetString("picRecipe.ToolTip"));
            this.picRecipe.Click += new System.EventHandler(this.picRecipe_Click);
            // 
            // cmdNewRecipe
            // 
            resources.ApplyResources(this.cmdNewRecipe, "cmdNewRecipe");
            this.cmdNewRecipe.BackgroundImage = global::Recipe_Writer.Properties.Resources.new_recipe;
            this.cmdNewRecipe.FlatAppearance.BorderSize = 0;
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.cmdNewRecipe, resources.GetString("cmdNewRecipe.ToolTip"));
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            this.cmdNewRecipe.Click += new System.EventHandler(this.cmdNewRecipe_Click);
            // 
            // picRecipeReadyToCookStatus
            // 
            resources.ApplyResources(this.picRecipeReadyToCookStatus, "picRecipeReadyToCookStatus");
            this.picRecipeReadyToCookStatus.Name = "picRecipeReadyToCookStatus";
            this.picRecipeReadyToCookStatus.TabStop = false;
            this.ttpRecipeReadyToCookStatus.SetToolTip(this.picRecipeReadyToCookStatus, resources.GetString("picRecipeReadyToCookStatus.ToolTip"));
            this.picRecipeReadyToCookStatus.MouseHover += new System.EventHandler(this.picRecipeReadyToCookStatus_MouseHover);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdTitleSearch;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
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
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ttpRecipeReadyToCookStatus.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        private System.Windows.Forms.ToolStripMenuItem deleteIngredientFromThisRecipe;
    }
}

