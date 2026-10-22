namespace AZ_Kviz.Forms
{
    partial class QuestionsEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionsEditorForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.normalQuestionsPage = new System.Windows.Forms.TabPage();
            this.dgvNormal = new System.Windows.Forms.DataGridView();
            this.colNormalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNormalText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNormalAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replacementQuestionsPage = new System.Windows.Forms.TabPage();
            this.dgvReplacement = new System.Windows.Forms.DataGridView();
            this.colReplacementId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplacementText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplacementAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteQuestionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAnswersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByQuestionAscendingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByQuestionDescendingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByAnswerAscendingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByAnswerDescendingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCsvMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCsvMenUItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.normalQuestionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).BeginInit();
            this.replacementQuestionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplacement)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.normalQuestionsPage);
            this.tabControl.Controls.Add(this.replacementQuestionsPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 30);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1169, 583);
            this.tabControl.TabIndex = 1;
            // 
            // normalQuestionsPage
            // 
            this.normalQuestionsPage.Controls.Add(this.dgvNormal);
            this.normalQuestionsPage.Location = new System.Drawing.Point(4, 31);
            this.normalQuestionsPage.Name = "normalQuestionsPage";
            this.normalQuestionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.normalQuestionsPage.Size = new System.Drawing.Size(1161, 548);
            this.normalQuestionsPage.TabIndex = 0;
            this.normalQuestionsPage.Text = "Otázky";
            this.normalQuestionsPage.UseVisualStyleBackColor = true;
            // 
            // dgvNormal
            // 
            this.dgvNormal.AllowUserToAddRows = false;
            this.dgvNormal.AllowUserToDeleteRows = false;
            this.dgvNormal.AllowUserToResizeRows = false;
            this.dgvNormal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNormal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNormal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNormalId,
            this.colNormalText,
            this.colNormalAnswer});
            this.dgvNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNormal.EnableHeadersVisualStyles = false;
            this.dgvNormal.Location = new System.Drawing.Point(3, 3);
            this.dgvNormal.MultiSelect = false;
            this.dgvNormal.Name = "dgvNormal";
            this.dgvNormal.RowHeadersVisible = false;
            this.dgvNormal.RowTemplate.Height = 25;
            this.dgvNormal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNormal.Size = new System.Drawing.Size(1155, 542);
            this.dgvNormal.TabIndex = 0;
            // 
            // colNormalId
            // 
            this.colNormalId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNormalId.FillWeight = 50F;
            this.colNormalId.Frozen = true;
            this.colNormalId.HeaderText = "ID";
            this.colNormalId.Name = "colNormalId";
            this.colNormalId.Width = 50;
            // 
            // colNormalText
            // 
            this.colNormalText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNormalText.FillWeight = 111.9289F;
            this.colNormalText.HeaderText = "Otázka";
            this.colNormalText.Name = "colNormalText";
            // 
            // colNormalAnswer
            // 
            this.colNormalAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNormalAnswer.FillWeight = 111.9289F;
            this.colNormalAnswer.HeaderText = "Odpověď";
            this.colNormalAnswer.Name = "colNormalAnswer";
            // 
            // replacementQuestionsPage
            // 
            this.replacementQuestionsPage.Controls.Add(this.dgvReplacement);
            this.replacementQuestionsPage.Location = new System.Drawing.Point(4, 31);
            this.replacementQuestionsPage.Name = "replacementQuestionsPage";
            this.replacementQuestionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.replacementQuestionsPage.Size = new System.Drawing.Size(1161, 548);
            this.replacementQuestionsPage.TabIndex = 1;
            this.replacementQuestionsPage.Text = "Náhradní otázky";
            this.replacementQuestionsPage.UseVisualStyleBackColor = true;
            // 
            // dgvReplacement
            // 
            this.dgvReplacement.AllowUserToAddRows = false;
            this.dgvReplacement.AllowUserToDeleteRows = false;
            this.dgvReplacement.AllowUserToResizeRows = false;
            this.dgvReplacement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReplacement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReplacement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReplacementId,
            this.colReplacementText,
            this.colReplacementAnswer});
            this.dgvReplacement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReplacement.EnableHeadersVisualStyles = false;
            this.dgvReplacement.Location = new System.Drawing.Point(3, 3);
            this.dgvReplacement.Name = "dgvReplacement";
            this.dgvReplacement.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReplacement.RowHeadersVisible = false;
            this.dgvReplacement.Size = new System.Drawing.Size(1155, 542);
            this.dgvReplacement.TabIndex = 0;
            // 
            // colReplacementId
            // 
            this.colReplacementId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colReplacementId.Frozen = true;
            this.colReplacementId.HeaderText = "ID";
            this.colReplacementId.Name = "colReplacementId";
            this.colReplacementId.Width = 50;
            // 
            // colReplacementText
            // 
            this.colReplacementText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReplacementText.HeaderText = "Text otázky";
            this.colReplacementText.Name = "colReplacementText";
            // 
            // colReplacementAnswer
            // 
            this.colReplacementAnswer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReplacementAnswer.HeaderText = "Odpověď";
            this.colReplacementAnswer.Name = "colReplacementAnswer";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editItem,
            this.questionMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1169, 30);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.separator1,
            this.cancelMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(84, 26);
            this.fileMenu.Text = "Soubor";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveMenuItem.Size = new System.Drawing.Size(209, 26);
            this.saveMenuItem.Text = "Uložit";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(206, 6);
            // 
            // cancelMenuItem
            // 
            this.cancelMenuItem.Name = "cancelMenuItem";
            this.cancelMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.cancelMenuItem.Size = new System.Drawing.Size(209, 26);
            this.cancelMenuItem.Text = "Zahodit";
            this.cancelMenuItem.Click += new System.EventHandler(this.CancelMenuItem_Click);
            // 
            // editItem
            // 
            this.editItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMenuItem,
            this.sortMenuItem});
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(80, 26);
            this.editItem.Text = "Úpravy";
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteQuestionsMenuItem,
            this.deleteAnswersMenuItem,
            this.deleteAllMenuItem});
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(151, 26);
            this.deleteMenuItem.Text = "Vymazat";
            // 
            // deleteQuestionsMenuItem
            // 
            this.deleteQuestionsMenuItem.Name = "deleteQuestionsMenuItem";
            this.deleteQuestionsMenuItem.Size = new System.Drawing.Size(241, 26);
            this.deleteQuestionsMenuItem.Text = "Otázky";
            // 
            // deleteAnswersMenuItem
            // 
            this.deleteAnswersMenuItem.Name = "deleteAnswersMenuItem";
            this.deleteAnswersMenuItem.Size = new System.Drawing.Size(241, 26);
            this.deleteAnswersMenuItem.Text = "Odpovědi";
            // 
            // deleteAllMenuItem
            // 
            this.deleteAllMenuItem.Name = "deleteAllMenuItem";
            this.deleteAllMenuItem.Size = new System.Drawing.Size(241, 26);
            this.deleteAllMenuItem.Text = "Otázky + Odpovědi";
            // 
            // sortMenuItem
            // 
            this.sortMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByQuestionAscendingMenuItem,
            this.sortByQuestionDescendingMenuItem,
            this.sortByAnswerAscendingMenuItem,
            this.sortByAnswerDescendingMenuItem});
            this.sortMenuItem.Name = "sortMenuItem";
            this.sortMenuItem.Size = new System.Drawing.Size(151, 26);
            this.sortMenuItem.Text = "Seřadit";
            // 
            // sortByQuestionAscendingMenuItem
            // 
            this.sortByQuestionAscendingMenuItem.Name = "sortByQuestionAscendingMenuItem";
            this.sortByQuestionAscendingMenuItem.Size = new System.Drawing.Size(226, 26);
            this.sortByQuestionAscendingMenuItem.Text = "A-Z dle otázky";
            // 
            // sortByQuestionDescendingMenuItem
            // 
            this.sortByQuestionDescendingMenuItem.Name = "sortByQuestionDescendingMenuItem";
            this.sortByQuestionDescendingMenuItem.Size = new System.Drawing.Size(226, 26);
            this.sortByQuestionDescendingMenuItem.Text = "Z-A dle otázky";
            // 
            // sortByAnswerAscendingMenuItem
            // 
            this.sortByAnswerAscendingMenuItem.Name = "sortByAnswerAscendingMenuItem";
            this.sortByAnswerAscendingMenuItem.Size = new System.Drawing.Size(226, 26);
            this.sortByAnswerAscendingMenuItem.Text = "A-Z dle odpovědi";
            // 
            // sortByAnswerDescendingMenuItem
            // 
            this.sortByAnswerDescendingMenuItem.Name = "sortByAnswerDescendingMenuItem";
            this.sortByAnswerDescendingMenuItem.Size = new System.Drawing.Size(226, 26);
            this.sortByAnswerDescendingMenuItem.Text = "Z-A dle odpovědi";
            // 
            // questionMenu
            // 
            this.questionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCsvMenuItem,
            this.SaveCsvMenUItem});
            this.questionMenu.Name = "questionMenu";
            this.questionMenu.Size = new System.Drawing.Size(79, 26);
            this.questionMenu.Text = "Otázky";
            // 
            // loadCsvMenuItem
            // 
            this.loadCsvMenuItem.Name = "loadCsvMenuItem";
            this.loadCsvMenuItem.Size = new System.Drawing.Size(248, 26);
            this.loadCsvMenuItem.Text = "Načíst ze souboru...";
            this.loadCsvMenuItem.Click += new System.EventHandler(this.LoadCsvMenuItem_Click);
            // 
            // SaveCsvMenUItem
            // 
            this.SaveCsvMenUItem.Name = "SaveCsvMenUItem";
            this.SaveCsvMenUItem.Size = new System.Drawing.Size(248, 26);
            this.SaveCsvMenUItem.Text = "Uložit do souboru...";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenuItem,
            this.toolStripSeparator4,
            this.aboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(108, 26);
            this.helpMenu.Text = "Nápověda";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.ShortcutKeyDisplayString = "F1";
            this.helpMenuItem.Size = new System.Drawing.Size(199, 26);
            this.helpMenuItem.Text = "Nápověda";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(199, 26);
            this.aboutMenuItem.Text = "O Aplikaci";
            // 
            // QuestionsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 613);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionsEditorForm";
            this.Text = "Editor otázek";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionsEditorForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.normalQuestionsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).EndInit();
            this.replacementQuestionsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplacement)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage normalQuestionsPage;
        private System.Windows.Forms.TabPage replacementQuestionsPage;
        private System.Windows.Forms.DataGridView dgvNormal;
        private System.Windows.Forms.DataGridView dgvReplacement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalAnswer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionMenu;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripMenuItem loadCsvMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveCsvMenUItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteQuestionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAnswersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByQuestionAscendingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByQuestionDescendingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByAnswerAscendingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByAnswerDescendingMenuItem;
    }
}