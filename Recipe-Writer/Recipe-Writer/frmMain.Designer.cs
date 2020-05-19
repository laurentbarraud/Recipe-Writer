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
            this.pnlSide = new System.Windows.Forms.Panel();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.cmdTitleSearch = new System.Windows.Forms.Button();
            this.picRecipe = new System.Windows.Forms.PictureBox();
            this.pnlSearchResults = new System.Windows.Forms.Panel();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.pnlInstructions = new System.Windows.Forms.Panel();
            this.cmdEditInstruction4 = new System.Windows.Forms.Button();
            this.cmdEditInstruction3 = new System.Windows.Forms.Button();
            this.cmdEditInstruction5 = new System.Windows.Forms.Button();
            this.cmdEditInstruction2 = new System.Windows.Forms.Button();
            this.cmdEditInstruction1 = new System.Windows.Forms.Button();
            this.lblInstruction5 = new System.Windows.Forms.Label();
            this.lblInstruction4 = new System.Windows.Forms.Label();
            this.lblbInstruction3 = new System.Windows.Forms.Label();
            this.lblInstruction2 = new System.Windows.Forms.Label();
            this.lblInstruction1 = new System.Windows.Forms.Label();
            this.cmdNewRecipe = new System.Windows.Forms.Button();
            this.cmdDeleteRecipe = new System.Windows.Forms.Button();
            this.pnlIngredients = new System.Windows.Forms.Panel();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.picScore = new System.Windows.Forms.PictureBox();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.lblPortions = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdExportHtml = new System.Windows.Forms.Button();
            this.chkWritingAssistance = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            this.pnlSearchResults.SuspendLayout();
            this.pnlInstructions.SuspendLayout();
            this.pnlIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSide.Location = new System.Drawing.Point(1, 106);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(76, 578);
            this.pnlSide.TabIndex = 0;
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(271, 40);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(571, 27);
            this.txtTitleSearch.TabIndex = 0;
            // 
            // cmdTitleSearch
            // 
            this.cmdTitleSearch.Location = new System.Drawing.Point(848, 34);
            this.cmdTitleSearch.Name = "cmdTitleSearch";
            this.cmdTitleSearch.Size = new System.Drawing.Size(50, 40);
            this.cmdTitleSearch.TabIndex = 1;
            this.cmdTitleSearch.UseVisualStyleBackColor = true;
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
            // pnlSearchResults
            // 
            this.pnlSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchResults.Controls.Add(this.lblSearchResults);
            this.pnlSearchResults.Location = new System.Drawing.Point(104, 106);
            this.pnlSearchResults.Name = "pnlSearchResults";
            this.pnlSearchResults.Size = new System.Drawing.Size(814, 105);
            this.pnlSearchResults.TabIndex = 2;
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.Location = new System.Drawing.Point(18, 2);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(264, 26);
            this.lblSearchResults.TabIndex = 0;
            this.lblSearchResults.Text = "Résultats de la recherche :";
            // 
            // pnlInstructions
            // 
            this.pnlInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInstructions.Controls.Add(this.cmdEditInstruction4);
            this.pnlInstructions.Controls.Add(this.cmdEditInstruction3);
            this.pnlInstructions.Controls.Add(this.cmdEditInstruction5);
            this.pnlInstructions.Controls.Add(this.cmdEditInstruction2);
            this.pnlInstructions.Controls.Add(this.cmdEditInstruction1);
            this.pnlInstructions.Controls.Add(this.lblInstruction5);
            this.pnlInstructions.Controls.Add(this.lblInstruction4);
            this.pnlInstructions.Controls.Add(this.lblbInstruction3);
            this.pnlInstructions.Controls.Add(this.lblInstruction2);
            this.pnlInstructions.Controls.Add(this.lblInstruction1);
            this.pnlInstructions.Location = new System.Drawing.Point(104, 330);
            this.pnlInstructions.Name = "pnlInstructions";
            this.pnlInstructions.Size = new System.Drawing.Size(1056, 354);
            this.pnlInstructions.TabIndex = 4;
            // 
            // cmdEditInstruction4
            // 
            this.cmdEditInstruction4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditInstruction4.Location = new System.Drawing.Point(987, 231);
            this.cmdEditInstruction4.Name = "cmdEditInstruction4";
            this.cmdEditInstruction4.Size = new System.Drawing.Size(40, 40);
            this.cmdEditInstruction4.TabIndex = 13;
            this.cmdEditInstruction4.UseVisualStyleBackColor = true;
            // 
            // cmdEditInstruction3
            // 
            this.cmdEditInstruction3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditInstruction3.Location = new System.Drawing.Point(987, 161);
            this.cmdEditInstruction3.Name = "cmdEditInstruction3";
            this.cmdEditInstruction3.Size = new System.Drawing.Size(40, 40);
            this.cmdEditInstruction3.TabIndex = 13;
            this.cmdEditInstruction3.UseVisualStyleBackColor = true;
            // 
            // cmdEditInstruction5
            // 
            this.cmdEditInstruction5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditInstruction5.Location = new System.Drawing.Point(987, 298);
            this.cmdEditInstruction5.Name = "cmdEditInstruction5";
            this.cmdEditInstruction5.Size = new System.Drawing.Size(40, 40);
            this.cmdEditInstruction5.TabIndex = 13;
            this.cmdEditInstruction5.UseVisualStyleBackColor = true;
            // 
            // cmdEditInstruction2
            // 
            this.cmdEditInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditInstruction2.Location = new System.Drawing.Point(987, 90);
            this.cmdEditInstruction2.Name = "cmdEditInstruction2";
            this.cmdEditInstruction2.Size = new System.Drawing.Size(40, 40);
            this.cmdEditInstruction2.TabIndex = 13;
            this.cmdEditInstruction2.UseVisualStyleBackColor = true;
            // 
            // cmdEditInstruction1
            // 
            this.cmdEditInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditInstruction1.Location = new System.Drawing.Point(987, 20);
            this.cmdEditInstruction1.Name = "cmdEditInstruction1";
            this.cmdEditInstruction1.Size = new System.Drawing.Size(40, 40);
            this.cmdEditInstruction1.TabIndex = 13;
            this.cmdEditInstruction1.UseVisualStyleBackColor = true;
            // 
            // lblInstruction5
            // 
            this.lblInstruction5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction5.Location = new System.Drawing.Point(18, 288);
            this.lblInstruction5.Name = "lblInstruction5";
            this.lblInstruction5.Size = new System.Drawing.Size(905, 63);
            this.lblInstruction5.TabIndex = 7;
            this.lblInstruction5.Text = "Instruction5";
            // 
            // lblInstruction4
            // 
            this.lblInstruction4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction4.Location = new System.Drawing.Point(18, 225);
            this.lblInstruction4.Name = "lblInstruction4";
            this.lblInstruction4.Size = new System.Drawing.Size(905, 52);
            this.lblInstruction4.TabIndex = 6;
            this.lblInstruction4.Text = "Instruction4";
            // 
            // lblbInstruction3
            // 
            this.lblbInstruction3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbInstruction3.Location = new System.Drawing.Point(18, 158);
            this.lblbInstruction3.Name = "lblbInstruction3";
            this.lblbInstruction3.Size = new System.Drawing.Size(905, 50);
            this.lblbInstruction3.TabIndex = 5;
            this.lblbInstruction3.Text = "Instruction3";
            // 
            // lblInstruction2
            // 
            this.lblInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction2.Location = new System.Drawing.Point(19, 87);
            this.lblInstruction2.Name = "lblInstruction2";
            this.lblInstruction2.Size = new System.Drawing.Size(905, 53);
            this.lblInstruction2.TabIndex = 4;
            this.lblInstruction2.Text = "Instruction2";
            // 
            // lblInstruction1
            // 
            this.lblInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction1.Location = new System.Drawing.Point(18, 10);
            this.lblInstruction1.Name = "lblInstruction1";
            this.lblInstruction1.Size = new System.Drawing.Size(905, 59);
            this.lblInstruction1.TabIndex = 3;
            this.lblInstruction1.Text = "Instruction1";
            // 
            // cmdNewRecipe
            // 
            this.cmdNewRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewRecipe.Location = new System.Drawing.Point(117, 238);
            this.cmdNewRecipe.Name = "cmdNewRecipe";
            this.cmdNewRecipe.Size = new System.Drawing.Size(112, 30);
            this.cmdNewRecipe.TabIndex = 1;
            this.cmdNewRecipe.Text = "Nouvelle";
            this.cmdNewRecipe.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteRecipe
            // 
            this.cmdDeleteRecipe.Location = new System.Drawing.Point(882, 212);
            this.cmdDeleteRecipe.Name = "cmdDeleteRecipe";
            this.cmdDeleteRecipe.Size = new System.Drawing.Size(36, 30);
            this.cmdDeleteRecipe.TabIndex = 1;
            this.cmdDeleteRecipe.UseVisualStyleBackColor = true;
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIngredients.Controls.Add(this.lblIngredients);
            this.pnlIngredients.Location = new System.Drawing.Point(428, 267);
            this.pnlIngredients.Name = "pnlIngredients";
            this.pnlIngredients.Size = new System.Drawing.Size(490, 63);
            this.pnlIngredients.TabIndex = 5;
            // 
            // lblIngredients
            // 
            this.lblIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.Location = new System.Drawing.Point(13, 7);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(279, 26);
            this.lblIngredients.TabIndex = 0;
            this.lblIngredients.Text = "Liste des ingrédients utilisés :";
            // 
            // picScore
            // 
            this.picScore.Location = new System.Drawing.Point(1007, 231);
            this.picScore.Name = "picScore";
            this.picScore.Size = new System.Drawing.Size(102, 26);
            this.picScore.TabIndex = 6;
            this.picScore.TabStop = false;
            // 
            // nudPersons
            // 
            this.nudPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPersons.Location = new System.Drawing.Point(261, 280);
            this.nudPersons.Name = "nudPersons";
            this.nudPersons.Size = new System.Drawing.Size(46, 27);
            this.nudPersons.TabIndex = 8;
            // 
            // lblPortions
            // 
            this.lblPortions.AutoSize = true;
            this.lblPortions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortions.Location = new System.Drawing.Point(313, 283);
            this.lblPortions.Name = "lblPortions";
            this.lblPortions.Size = new System.Drawing.Size(62, 18);
            this.lblPortions.TabIndex = 7;
            this.lblPortions.Text = "portions";
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(227, 38);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(36, 30);
            this.cmdBack.TabIndex = 1;
            this.cmdBack.UseVisualStyleBackColor = true;
            // 
            // cmdExportHtml
            // 
            this.cmdExportHtml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportHtml.Location = new System.Drawing.Point(117, 279);
            this.cmdExportHtml.Name = "cmdExportHtml";
            this.cmdExportHtml.Size = new System.Drawing.Size(112, 30);
            this.cmdExportHtml.TabIndex = 1;
            this.cmdExportHtml.Text = "Exporter...";
            this.cmdExportHtml.UseVisualStyleBackColor = true;
            // 
            // chkWritingAssistance
            // 
            this.chkWritingAssistance.AutoSize = true;
            this.chkWritingAssistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWritingAssistance.Location = new System.Drawing.Point(261, 245);
            this.chkWritingAssistance.Name = "chkWritingAssistance";
            this.chkWritingAssistance.Size = new System.Drawing.Size(125, 21);
            this.chkWritingAssistance.TabIndex = 9;
            this.chkWritingAssistance.Text = "Aide à la saisie";
            this.chkWritingAssistance.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AcceptButton = this.cmdTitleSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 709);
            this.Controls.Add(this.chkWritingAssistance);
            this.Controls.Add(this.nudPersons);
            this.Controls.Add(this.lblPortions);
            this.Controls.Add(this.picScore);
            this.Controls.Add(this.pnlIngredients);
            this.Controls.Add(this.pnlInstructions);
            this.Controls.Add(this.pnlSearchResults);
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
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            this.pnlSearchResults.ResumeLayout(false);
            this.pnlInstructions.ResumeLayout(false);
            this.pnlIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.Button cmdTitleSearch;
        private System.Windows.Forms.PictureBox picRecipe;
        private System.Windows.Forms.Panel pnlSearchResults;
        private System.Windows.Forms.Panel pnlInstructions;
        private System.Windows.Forms.Button cmdEditInstruction4;
        private System.Windows.Forms.Button cmdEditInstruction3;
        private System.Windows.Forms.Button cmdEditInstruction5;
        private System.Windows.Forms.Button cmdEditInstruction2;
        private System.Windows.Forms.Button cmdEditInstruction1;
        private System.Windows.Forms.Label lblInstruction5;
        private System.Windows.Forms.Label lblInstruction4;
        private System.Windows.Forms.Label lblbInstruction3;
        private System.Windows.Forms.Label lblInstruction2;
        private System.Windows.Forms.Label lblInstruction1;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button cmdNewRecipe;
        private System.Windows.Forms.Button cmdDeleteRecipe;
        private System.Windows.Forms.Panel pnlIngredients;
        private System.Windows.Forms.Label lblIngredients;
        private System.Windows.Forms.PictureBox picScore;
        private System.Windows.Forms.NumericUpDown nudPersons;
        private System.Windows.Forms.Label lblPortions;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdExportHtml;
        private System.Windows.Forms.CheckBox chkWritingAssistance;
    }
}

