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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importExportMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.importButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exportButton = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.normalQuestionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).BeginInit();
            this.replacementQuestionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplacement)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.cancelButton,
            this.toolStripSeparator1,
            this.importExportMenu});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1169, 29);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // saveButton
            // 
            this.saveButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(60, 26);
            this.saveButton.Text = "Uložit";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(61, 26);
            this.cancelButton.Text = "Zrušit";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // importExportMenu
            // 
            this.importExportMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.importExportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importButton,
            this.exportButton});
            this.importExportMenu.Image = ((System.Drawing.Image)(resources.GetObject("importExportMenu.Image")));
            this.importExportMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importExportMenu.Name = "importExportMenu";
            this.importExportMenu.Size = new System.Drawing.Size(138, 26);
            this.importExportMenu.Text = "Import/Export";
            // 
            // importButton
            // 
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(135, 26);
            this.importButton.Text = "Import";
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(135, 26);
            this.exportButton.Text = "Export";
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.normalQuestionsPage);
            this.tabControl.Controls.Add(this.replacementQuestionsPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 29);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1169, 584);
            this.tabControl.TabIndex = 1;
            // 
            // normalQuestionsPage
            // 
            this.normalQuestionsPage.Controls.Add(this.dgvNormal);
            this.normalQuestionsPage.Location = new System.Drawing.Point(4, 31);
            this.normalQuestionsPage.Name = "normalQuestionsPage";
            this.normalQuestionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.normalQuestionsPage.Size = new System.Drawing.Size(1161, 549);
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
            this.dgvNormal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNormal.Size = new System.Drawing.Size(1155, 543);
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
            this.replacementQuestionsPage.Size = new System.Drawing.Size(1161, 549);
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
            this.dgvReplacement.Size = new System.Drawing.Size(1155, 543);
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
            // QuestionsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 613);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionsEditorForm";
            this.Text = "Editor otázek";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionsEditorForm_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.normalQuestionsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNormal)).EndInit();
            this.replacementQuestionsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplacement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage normalQuestionsPage;
        private System.Windows.Forms.TabPage replacementQuestionsPage;
        private System.Windows.Forms.DataGridView dgvNormal;
        private System.Windows.Forms.DataGridView dgvReplacement;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalAnswer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton importExportMenu;
        private System.Windows.Forms.ToolStripMenuItem importButton;
        private System.Windows.Forms.ToolStripMenuItem exportButton;
    }
}