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
            this.pnlSide = new System.Windows.Forms.Panel();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.pnlInstructions = new System.Windows.Forms.Panel();
            this.cmdEditInstruction1 = new System.Windows.Forms.Button();
            this.lblInstruction1 = new System.Windows.Forms.Label();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.lblPortions = new System.Windows.Forms.Label();
            this.chkWritingAssistance = new System.Windows.Forms.CheckBox();
            this.cmdTitleSearch = new System.Windows.Forms.Button();
            this.picScore = new System.Windows.Forms.PictureBox();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.cmdDeleteRecipe = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdExportHtml = new System.Windows.Forms.Button();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbRecipeIngredients = new System.Windows.Forms.ComboBox();
            this.lblComplettionTime = new System.Windows.Forms.Label();
            this.pnlInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSide.Location = new System.Drawing.Point(1, 106);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(68, 578);
            this.pnlSide.TabIndex = 8;
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
            this.pnlInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInstructions.Controls.Add(this.cmdEditInstruction1);
            this.pnlInstructions.Controls.Add(this.lblInstruction1);
            this.pnlInstructions.Location = new System.Drawing.Point(104, 330);
            this.pnlInstructions.Name = "pnlInstructions";
            this.pnlInstructions.Size = new System.Drawing.Size(1056, 354);
            this.pnlInstructions.TabIndex = 4;
            // 
            // cmdEditInstruction1
            // 
            this.cmdEditInstruction1.BackgroundImage = global::Recipe_Writer.Properties.Resources.edit;
            this.cmdEditInstruction1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdEditInstruction1.FlatAppearance.BorderSize = 0;
            this.cmdEditInstruction1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditInstruction1.Location = new System.Drawing.Point(1003, 20);
            this.cmdEditInstruction1.Name = "cmdEditInstruction1";
            this.cmdEditInstruction1.Size = new System.Drawing.Size(30, 30);
            this.cmdEditInstruction1.TabIndex = 13;
            this.cmdEditInstruction1.UseVisualStyleBackColor = true;
            // 
            // lblInstruction1
            // 
            this.lblInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction1.Location = new System.Drawing.Point(18, 15);
            this.lblInstruction1.Name = "lblInstruction1";
            this.lblInstruction1.Size = new System.Drawing.Size(905, 42);
            this.lblInstruction1.TabIndex = 12;
            this.lblInstruction1.Text = "Instruction1";
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
            this.picRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRecipe.Location = new System.Drawing.Point(960, 25);
            this.picRecipe.Name = "picRecipe";
            this.picRecipe.Size = new System.Drawing.Size(200, 200);
            this.picRecipe.TabIndex = 2;
            this.picRecipe.TabStop = false;
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
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(879, 284);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 30);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
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
            this.Controls.Add(this.pnlSide);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe Writer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.Button cmdTitleSearch;
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlInstructions;
        private System.Windows.Forms.Button cmdEditInstruction1;
        private System.Windows.Forms.Label lblInstruction1;
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
    }
}

