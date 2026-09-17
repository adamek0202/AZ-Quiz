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
            this.randomQuestionsCheck.Location = new System.Drawing.Point(5, 3);
            this.randomQuestionsCheck.Name = "randomQuestionsCheck";
            this.randomQuestionsCheck.Size = new System.Drawing.Size(144, 19);
            this.randomQuestionsCheck.TabIndex = 0;
            this.randomQuestionsCheck.Text = "Náhodný výběr otázek";
            this.toolTip.SetToolTip(this.randomQuestionsCheck, "Výběr otázek bude probíhat náhodně, nikoliv dle čísla uvedeného v políčku.");
            this.randomQuestionsCheck.UseVisualStyleBackColor = true;
            // 
            // playSoundsCheck
            // 
            this.playSoundsCheck.AutoSize = true;
            this.playSoundsCheck.Location = new System.Drawing.Point(5, 28);
            this.playSoundsCheck.Name = "playSoundsCheck";
            this.playSoundsCheck.Size = new System.Drawing.Size(109, 19);
            this.playSoundsCheck.TabIndex = 0;
            this.playSoundsCheck.Text = "Přehrávat zvuky";
            this.playSoundsCheck.UseVisualStyleBackColor = true;
            // 
            // practiceModeCheck
            // 
            this.practiceModeCheck.AutoSize = true;
            this.practiceModeCheck.Location = new System.Drawing.Point(5, 103);
            this.practiceModeCheck.Name = "practiceModeCheck";
            this.practiceModeCheck.Size = new System.Drawing.Size(125, 19);
            this.practiceModeCheck.TabIndex = 0;
            this.practiceModeCheck.Text = "Procvičovací režim";
            this.toolTip.SetToolTip(this.practiceModeCheck, "V procvičovacím režimu je vypnutá časomíra a bodování.");
            this.practiceModeCheck.UseVisualStyleBackColor = true;
            this.practiceModeCheck.CheckedChanged += new System.EventHandler(this.PracticeModeCheck_CheckedChanged);
            // 
            // endGameAfterWinCheck
            // 
            this.endGameAfterWinCheck.AutoSize = true;
            this.endGameAfterWinCheck.Location = new System.Drawing.Point(5, 52);
            this.endGameAfterWinCheck.Name = "endGameAfterWinCheck";
            this.endGameAfterWinCheck.Size = new System.Drawing.Size(137, 19);
            this.endGameAfterWinCheck.TabIndex = 0;
            this.endGameAfterWinCheck.Text = "Ukončit hru při výhře";
            this.toolTip.SetToolTip(this.endGameAfterWinCheck, "Hra bude automaticky ukončena, jakmile jeden z hráčů spojí všechny 3 strany hrací" +
        "ho plánu.");
            this.endGameAfterWinCheck.CheckedChanged += new System.EventHandler(this.RandomQuestionsCheck_CheckedChanged);
            // 
            // allowReplacementsCheck
            // 
            this.allowReplacementsCheck.AutoSize = true;
            this.allowReplacementsCheck.Location = new System.Drawing.Point(5, 78);
            this.allowReplacementsCheck.Name = "allowReplacementsCheck";
            this.allowReplacementsCheck.Size = new System.Drawing.Size(150, 19);
            this.allowReplacementsCheck.TabIndex = 0;
            this.allowReplacementsCheck.Text = "Povolit náhradní otázky";
            this.allowReplacementsCheck.UseVisualStyleBackColor = true;
            // 
            // noPlayerScreenCheck
            // 
            this.noPlayerScreenCheck.AutoSize = true;
            this.noPlayerScreenCheck.Location = new System.Drawing.Point(5, 128);
            this.noPlayerScreenCheck.Name = "noPlayerScreenCheck";
            this.noPlayerScreenCheck.Size = new System.Drawing.Size(154, 19);
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
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.okButton.Location = new System.Drawing.Point(313, 145);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 30);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(232, 145);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // normalQuestionTimeLimitNumeric
            // 
            this.normalQuestionTimeLimitNumeric.Location = new System.Drawing.Point(181, 5);
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
            this.normalQuestionTimeLimitNumeric.Size = new System.Drawing.Size(57, 23);
            this.normalQuestionTimeLimitNumeric.TabIndex = 2;
            this.normalQuestionTimeLimitNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // replacementQuestionTimeLimitNumeric
            // 
            this.replacementQuestionTimeLimitNumeric.Location = new System.Drawing.Point(181, 34);
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
            this.replacementQuestionTimeLimitNumeric.Size = new System.Drawing.Size(57, 23);
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
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Čas na normální otázku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Čas na náhradní otázku";
            // 
            // gameTimeLimitNumeric
            // 
            this.gameTimeLimitNumeric.Location = new System.Drawing.Point(181, 63);
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
            this.gameTimeLimitNumeric.Size = new System.Drawing.Size(57, 23);
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
            this.label3.Location = new System.Drawing.Point(244, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Časový limit hry(sekundy)";
            // 
            // playerOneColorPanel
            // 
            this.playerOneColorPanel.Location = new System.Drawing.Point(181, 92);
            this.playerOneColorPanel.Name = "playerOneColorPanel";
            this.playerOneColorPanel.Size = new System.Drawing.Size(57, 21);
            this.playerOneColorPanel.TabIndex = 5;
            this.playerOneColorPanel.Click += new System.EventHandler(this.PlayerOneColorPanel_Click);
            // 
            // playerTwoColorPanel
            // 
            this.playerTwoColorPanel.Location = new System.Drawing.Point(181, 119);
            this.playerTwoColorPanel.Name = "playerTwoColorPanel";
            this.playerTwoColorPanel.Size = new System.Drawing.Size(57, 21);
            this.playerTwoColorPanel.TabIndex = 5;
            this.playerTwoColorPanel.Click += new System.EventHandler(this.PlayerOneColorPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Výchozí barva hráče 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Výchozí barva hráče 2";
            // 
            // showResultsToPlayersCheck
            // 
            this.showResultsToPlayersCheck.AutoSize = true;
            this.showResultsToPlayersCheck.Location = new System.Drawing.Point(5, 153);
            this.showResultsToPlayersCheck.Name = "showResultsToPlayersCheck";
            this.showResultsToPlayersCheck.Size = new System.Drawing.Size(161, 19);
            this.showResultsToPlayersCheck.TabIndex = 0;
            this.showResultsToPlayersCheck.Text = "Zobrazit hráčům výsledky\r\n";
            this.showResultsToPlayersCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 181);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 210);
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