namespace AZ_Kviz.Forms
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.randomQuestionsCheck = new System.Windows.Forms.CheckBox();
            this.playSoundsCheck = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.practiceModeCheck = new System.Windows.Forms.CheckBox();
            this.endGameAfterWinCheck = new System.Windows.Forms.CheckBox();
            this.allowReplacementsCheck = new System.Windows.Forms.CheckBox();
            this.noPlayerScreenCheck = new System.Windows.Forms.CheckBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.normalQuestionTimeLimitNumeric = new System.Windows.Forms.NumericUpDown();
            this.replacementQuestionTimeLimitNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameTimeLimitNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.playerOneColorPanel = new System.Windows.Forms.Panel();
            this.playerTwoColorPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.showResultsToPlayersCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.normalQuestionTimeLimitNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replacementQuestionTimeLimitNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameTimeLimitNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // randomQuestionsCheck
            // 
            this.randomQuestionsCheck.AutoSize = true;
            this.randomQuestionsCheck.Location = new System.Drawing.Point(8, 4);
            this.randomQuestionsCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.randomQuestionsCheck.Name = "randomQuestionsCheck";
            this.randomQuestionsCheck.Size = new System.Drawing.Size(214, 26);
            this.randomQuestionsCheck.TabIndex = 0;
            this.randomQuestionsCheck.Text = "Náhodný výběr otázek";
            this.toolTip.SetToolTip(this.randomQuestionsCheck, "Výběr otázek bude probíhat náhodně, nikoliv dle čísla uvedeného v políčku.");
            this.randomQuestionsCheck.UseVisualStyleBackColor = true;
            // 
            // playSoundsCheck
            // 
            this.playSoundsCheck.AutoSize = true;
            this.playSoundsCheck.Location = new System.Drawing.Point(8, 41);
            this.playSoundsCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.playSoundsCheck.Name = "playSoundsCheck";
            this.playSoundsCheck.Size = new System.Drawing.Size(160, 26);
            this.playSoundsCheck.TabIndex = 0;
            this.playSoundsCheck.Text = "Přehrávat zvuky";
            this.playSoundsCheck.UseVisualStyleBackColor = true;
            // 
            // practiceModeCheck
            // 
            this.practiceModeCheck.AutoSize = true;
            this.practiceModeCheck.Location = new System.Drawing.Point(8, 151);
            this.practiceModeCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.practiceModeCheck.Name = "practiceModeCheck";
            this.practiceModeCheck.Size = new System.Drawing.Size(189, 26);
            this.practiceModeCheck.TabIndex = 0;
            this.practiceModeCheck.Text = "Procvičovací režim";
            this.toolTip.SetToolTip(this.practiceModeCheck, "V procvičovacím režimu je vypnutá časomíra a bodování.");
            this.practiceModeCheck.UseVisualStyleBackColor = true;
            this.practiceModeCheck.CheckedChanged += new System.EventHandler(this.PracticeModeCheck_CheckedChanged);
            // 
            // endGameAfterWinCheck
            // 
            this.endGameAfterWinCheck.AutoSize = true;
            this.endGameAfterWinCheck.Location = new System.Drawing.Point(8, 76);
            this.endGameAfterWinCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.endGameAfterWinCheck.Name = "endGameAfterWinCheck";
            this.endGameAfterWinCheck.Size = new System.Drawing.Size(198, 26);
            this.endGameAfterWinCheck.TabIndex = 0;
            this.endGameAfterWinCheck.Text = "Ukončit hru při výhře";
            this.toolTip.SetToolTip(this.endGameAfterWinCheck, "Hra bude automaticky ukončena, jakmile jeden z hráčů spojí všechny 3 strany hrací" +
        "ho plánu.");
            // 
            // allowReplacementsCheck
            // 
            this.allowReplacementsCheck.AutoSize = true;
            this.allowReplacementsCheck.Location = new System.Drawing.Point(8, 114);
            this.allowReplacementsCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.allowReplacementsCheck.Name = "allowReplacementsCheck";
            this.allowReplacementsCheck.Size = new System.Drawing.Size(222, 26);
            this.allowReplacementsCheck.TabIndex = 0;
            this.allowReplacementsCheck.Text = "Povolit náhradní otázky";
            this.allowReplacementsCheck.UseVisualStyleBackColor = true;
            // 
            // noPlayerScreenCheck
            // 
            this.noPlayerScreenCheck.AutoSize = true;
            this.noPlayerScreenCheck.Location = new System.Drawing.Point(8, 188);
            this.noPlayerScreenCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.noPlayerScreenCheck.Name = "noPlayerScreenCheck";
            this.noPlayerScreenCheck.Size = new System.Drawing.Size(229, 26);
            this.noPlayerScreenCheck.TabIndex = 0;
            this.noPlayerScreenCheck.Text = "Vypnout hráčský pohled";
            this.noPlayerScreenCheck.UseVisualStyleBackColor = true;
            this.noPlayerScreenCheck.CheckedChanged += new System.EventHandler(this.NoPlayerScreenCheck_CheckedChanged);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.okButton.Location = new System.Drawing.Point(492, 213);
            this.okButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(118, 44);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(365, 213);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(118, 44);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // normalQuestionTimeLimitNumeric
            // 
            this.normalQuestionTimeLimitNumeric.AutoSize = true;
            this.normalQuestionTimeLimitNumeric.Location = new System.Drawing.Point(284, 7);
            this.normalQuestionTimeLimitNumeric.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.normalQuestionTimeLimitNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.normalQuestionTimeLimitNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.normalQuestionTimeLimitNumeric.Name = "normalQuestionTimeLimitNumeric";
            this.normalQuestionTimeLimitNumeric.Size = new System.Drawing.Size(90, 29);
            this.normalQuestionTimeLimitNumeric.TabIndex = 2;
            this.normalQuestionTimeLimitNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // replacementQuestionTimeLimitNumeric
            // 
            this.replacementQuestionTimeLimitNumeric.AutoSize = true;
            this.replacementQuestionTimeLimitNumeric.Location = new System.Drawing.Point(284, 50);
            this.replacementQuestionTimeLimitNumeric.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.replacementQuestionTimeLimitNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.replacementQuestionTimeLimitNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.replacementQuestionTimeLimitNumeric.Name = "replacementQuestionTimeLimitNumeric";
            this.replacementQuestionTimeLimitNumeric.Size = new System.Drawing.Size(90, 29);
            this.replacementQuestionTimeLimitNumeric.TabIndex = 3;
            this.replacementQuestionTimeLimitNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Čas na normální otázku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Čas na náhradní otázku";
            // 
            // gameTimeLimitNumeric
            // 
            this.gameTimeLimitNumeric.AutoSize = true;
            this.gameTimeLimitNumeric.Location = new System.Drawing.Point(284, 92);
            this.gameTimeLimitNumeric.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gameTimeLimitNumeric.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.gameTimeLimitNumeric.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.gameTimeLimitNumeric.Name = "gameTimeLimitNumeric";
            this.gameTimeLimitNumeric.Size = new System.Drawing.Size(90, 29);
            this.gameTimeLimitNumeric.TabIndex = 3;
            this.gameTimeLimitNumeric.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Časový limit hry(sekundy)";
            // 
            // playerOneColorPanel
            // 
            this.playerOneColorPanel.AutoSize = true;
            this.playerOneColorPanel.Location = new System.Drawing.Point(284, 135);
            this.playerOneColorPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.playerOneColorPanel.Name = "playerOneColorPanel";
            this.playerOneColorPanel.Size = new System.Drawing.Size(90, 31);
            this.playerOneColorPanel.TabIndex = 5;
            this.playerOneColorPanel.Click += new System.EventHandler(this.PlayerOneColorPanel_Click);
            // 
            // playerTwoColorPanel
            // 
            this.playerTwoColorPanel.AutoSize = true;
            this.playerTwoColorPanel.Location = new System.Drawing.Point(284, 175);
            this.playerTwoColorPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.playerTwoColorPanel.Name = "playerTwoColorPanel";
            this.playerTwoColorPanel.Size = new System.Drawing.Size(90, 31);
            this.playerTwoColorPanel.TabIndex = 5;
            this.playerTwoColorPanel.Click += new System.EventHandler(this.PlayerOneColorPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Výchozí barva hráče 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 183);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Výchozí barva hráče 2";
            // 
            // showResultsToPlayersCheck
            // 
            this.showResultsToPlayersCheck.AutoSize = true;
            this.showResultsToPlayersCheck.Location = new System.Drawing.Point(8, 224);
            this.showResultsToPlayersCheck.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.showResultsToPlayersCheck.Name = "showResultsToPlayersCheck";
            this.showResultsToPlayersCheck.Size = new System.Drawing.Size(241, 26);
            this.showResultsToPlayersCheck.TabIndex = 0;
            this.showResultsToPlayersCheck.Text = "Zobrazit hráčům výsledky\r\n";
            this.showResultsToPlayersCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 265);
            this.ControlBox = false;
            this.Controls.Add(this.playerTwoColorPanel);
            this.Controls.Add(this.playerOneColorPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameTimeLimitNumeric);
            this.Controls.Add(this.replacementQuestionTimeLimitNumeric);
            this.Controls.Add(this.normalQuestionTimeLimitNumeric);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.showResultsToPlayersCheck);
            this.Controls.Add(this.noPlayerScreenCheck);
            this.Controls.Add(this.practiceModeCheck);
            this.Controls.Add(this.allowReplacementsCheck);
            this.Controls.Add(this.endGameAfterWinCheck);
            this.Controls.Add(this.playSoundsCheck);
            this.Controls.Add(this.randomQuestionsCheck);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(625, 294);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(625, 294);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nastavení aplikace";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.normalQuestionTimeLimitNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replacementQuestionTimeLimitNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameTimeLimitNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox randomQuestionsCheck;
        private System.Windows.Forms.CheckBox playSoundsCheck;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox allowReplacementsCheck;
        private System.Windows.Forms.CheckBox practiceModeCheck;
        private System.Windows.Forms.CheckBox noPlayerScreenCheck;
        private System.Windows.Forms.CheckBox endGameAfterWinCheck;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown normalQuestionTimeLimitNumeric;
        private System.Windows.Forms.NumericUpDown replacementQuestionTimeLimitNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown gameTimeLimitNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel playerOneColorPanel;
        private System.Windows.Forms.Panel playerTwoColorPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox showResultsToPlayersCheck;
    }
}