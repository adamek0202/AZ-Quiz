namespace AZ_Kviz.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.playerOneColorPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playerHeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerOneLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerOneScoreLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerOneCorrectBox = new System.Windows.Forms.TextBox();
            this.playerOneIncorrectBox = new System.Windows.Forms.TextBox();
            this.playerOneNameLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerTwoLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerTwoNameLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.playerTwoColorPanel = new System.Windows.Forms.Panel();
            this.playerTwoScoreLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playerTwoIncorrectBox = new System.Windows.Forms.TextBox();
            this.playerTwoCorrectBox = new System.Windows.Forms.TextBox();
            this.gameBoard = new AZ_Kviz.Components.GameBoard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.resetButton = new System.Windows.Forms.Button();
            this.concludeButton = new System.Windows.Forms.Button();
            this.nextPlayerButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.playerHeaderLayout.SuspendLayout();
            this.playerOneLayout.SuspendLayout();
            this.playerOneScoreLayout.SuspendLayout();
            this.playerOneNameLayout.SuspendLayout();
            this.playerTwoLayout.SuspendLayout();
            this.playerTwoNameLayout.SuspendLayout();
            this.playerTwoScoreLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.AutoEllipsis = true;
            this.playerOneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneLabel.Location = new System.Drawing.Point(33, 0);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(201, 30);
            this.playerOneLabel.TabIndex = 2;
            this.playerOneLabel.Text = "Tým 1";
            this.playerOneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // playerOneColorPanel
            // 
            this.playerOneColorPanel.BackColor = System.Drawing.Color.Orange;
            this.playerOneColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneColorPanel.Location = new System.Drawing.Point(3, 3);
            this.playerOneColorPanel.Name = "playerOneColorPanel";
            this.playerOneColorPanel.Size = new System.Drawing.Size(24, 24);
            this.playerOneColorPanel.TabIndex = 6;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.playerHeaderLayout, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gameBoard, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(504, 612);
            this.tableLayoutPanel.TabIndex = 9;
            // 
            // playerHeaderLayout
            // 
            this.playerHeaderLayout.ColumnCount = 2;
            this.playerHeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerHeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerHeaderLayout.Controls.Add(this.playerOneLayout, 0, 0);
            this.playerHeaderLayout.Controls.Add(this.playerTwoLayout, 1, 0);
            this.playerHeaderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerHeaderLayout.Location = new System.Drawing.Point(3, 3);
            this.playerHeaderLayout.Name = "playerHeaderLayout";
            this.playerHeaderLayout.RowCount = 1;
            this.playerHeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerHeaderLayout.Size = new System.Drawing.Size(498, 79);
            this.playerHeaderLayout.TabIndex = 7;
            // 
            // playerOneLayout
            // 
            this.playerOneLayout.ColumnCount = 1;
            this.playerOneLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerOneLayout.Controls.Add(this.playerOneScoreLayout, 0, 1);
            this.playerOneLayout.Controls.Add(this.playerOneNameLayout, 0, 0);
            this.playerOneLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneLayout.Location = new System.Drawing.Point(3, 3);
            this.playerOneLayout.Name = "playerOneLayout";
            this.playerOneLayout.RowCount = 2;
            this.playerOneLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerOneLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerOneLayout.Size = new System.Drawing.Size(243, 73);
            this.playerOneLayout.TabIndex = 7;
            // 
            // playerOneScoreLayout
            // 
            this.playerOneScoreLayout.ColumnCount = 3;
            this.playerOneScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.playerOneScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.playerOneScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerOneScoreLayout.Controls.Add(this.playerOneCorrectBox, 0, 0);
            this.playerOneScoreLayout.Controls.Add(this.playerOneIncorrectBox, 1, 0);
            this.playerOneScoreLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneScoreLayout.Location = new System.Drawing.Point(3, 39);
            this.playerOneScoreLayout.Name = "playerOneScoreLayout";
            this.playerOneScoreLayout.RowCount = 1;
            this.playerOneScoreLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerOneScoreLayout.Size = new System.Drawing.Size(237, 31);
            this.playerOneScoreLayout.TabIndex = 10;
            // 
            // playerOneCorrectBox
            // 
            this.playerOneCorrectBox.BackColor = System.Drawing.Color.Lime;
            this.playerOneCorrectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneCorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneCorrectBox.Location = new System.Drawing.Point(3, 3);
            this.playerOneCorrectBox.Name = "playerOneCorrectBox";
            this.playerOneCorrectBox.ReadOnly = true;
            this.playerOneCorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerOneCorrectBox.TabIndex = 5;
            this.playerOneCorrectBox.Text = "0";
            this.playerOneCorrectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerOneIncorrectBox
            // 
            this.playerOneIncorrectBox.BackColor = System.Drawing.Color.Red;
            this.playerOneIncorrectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneIncorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneIncorrectBox.ForeColor = System.Drawing.Color.White;
            this.playerOneIncorrectBox.Location = new System.Drawing.Point(51, 3);
            this.playerOneIncorrectBox.Name = "playerOneIncorrectBox";
            this.playerOneIncorrectBox.ReadOnly = true;
            this.playerOneIncorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerOneIncorrectBox.TabIndex = 5;
            this.playerOneIncorrectBox.Text = "0";
            this.playerOneIncorrectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerOneNameLayout
            // 
            this.playerOneNameLayout.ColumnCount = 2;
            this.playerOneNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.playerOneNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerOneNameLayout.Controls.Add(this.playerOneColorPanel, 0, 0);
            this.playerOneNameLayout.Controls.Add(this.playerOneLabel, 1, 0);
            this.playerOneNameLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneNameLayout.Location = new System.Drawing.Point(3, 3);
            this.playerOneNameLayout.Name = "playerOneNameLayout";
            this.playerOneNameLayout.RowCount = 1;
            this.playerOneNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerOneNameLayout.Size = new System.Drawing.Size(237, 30);
            this.playerOneNameLayout.TabIndex = 8;
            // 
            // playerTwoLayout
            // 
            this.playerTwoLayout.ColumnCount = 1;
            this.playerTwoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerTwoLayout.Controls.Add(this.playerTwoNameLayout, 0, 0);
            this.playerTwoLayout.Controls.Add(this.playerTwoScoreLayout, 0, 1);
            this.playerTwoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoLayout.Location = new System.Drawing.Point(252, 3);
            this.playerTwoLayout.Name = "playerTwoLayout";
            this.playerTwoLayout.RowCount = 2;
            this.playerTwoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerTwoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerTwoLayout.Size = new System.Drawing.Size(243, 73);
            this.playerTwoLayout.TabIndex = 8;
            // 
            // playerTwoNameLayout
            // 
            this.playerTwoNameLayout.ColumnCount = 2;
            this.playerTwoNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTwoNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.playerTwoNameLayout.Controls.Add(this.playerTwoLabel, 0, 0);
            this.playerTwoNameLayout.Controls.Add(this.playerTwoColorPanel, 1, 0);
            this.playerTwoNameLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoNameLayout.Location = new System.Drawing.Point(3, 3);
            this.playerTwoNameLayout.Name = "playerTwoNameLayout";
            this.playerTwoNameLayout.RowCount = 1;
            this.playerTwoNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTwoNameLayout.Size = new System.Drawing.Size(237, 30);
            this.playerTwoNameLayout.TabIndex = 7;
            // 
            // playerTwoLabel
            // 
            this.playerTwoLabel.AutoEllipsis = true;
            this.playerTwoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoLabel.Location = new System.Drawing.Point(3, 0);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(201, 30);
            this.playerTwoLabel.TabIndex = 4;
            this.playerTwoLabel.Text = "Tým 2";
            this.playerTwoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // playerTwoColorPanel
            // 
            this.playerTwoColorPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.playerTwoColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoColorPanel.Location = new System.Drawing.Point(210, 3);
            this.playerTwoColorPanel.Name = "playerTwoColorPanel";
            this.playerTwoColorPanel.Size = new System.Drawing.Size(24, 24);
            this.playerTwoColorPanel.TabIndex = 6;
            // 
            // playerTwoScoreLayout
            // 
            this.playerTwoScoreLayout.ColumnCount = 3;
            this.playerTwoScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTwoScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.playerTwoScoreLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.playerTwoScoreLayout.Controls.Add(this.playerTwoIncorrectBox, 2, 0);
            this.playerTwoScoreLayout.Controls.Add(this.playerTwoCorrectBox, 1, 0);
            this.playerTwoScoreLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoScoreLayout.Location = new System.Drawing.Point(3, 39);
            this.playerTwoScoreLayout.Name = "playerTwoScoreLayout";
            this.playerTwoScoreLayout.RowCount = 1;
            this.playerTwoScoreLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTwoScoreLayout.Size = new System.Drawing.Size(237, 31);
            this.playerTwoScoreLayout.TabIndex = 8;
            // 
            // playerTwoIncorrectBox
            // 
            this.playerTwoIncorrectBox.BackColor = System.Drawing.Color.Red;
            this.playerTwoIncorrectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoIncorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoIncorrectBox.ForeColor = System.Drawing.Color.White;
            this.playerTwoIncorrectBox.Location = new System.Drawing.Point(192, 3);
            this.playerTwoIncorrectBox.Name = "playerTwoIncorrectBox";
            this.playerTwoIncorrectBox.ReadOnly = true;
            this.playerTwoIncorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerTwoIncorrectBox.TabIndex = 5;
            this.playerTwoIncorrectBox.Text = "0";
            this.playerTwoIncorrectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerTwoCorrectBox
            // 
            this.playerTwoCorrectBox.BackColor = System.Drawing.Color.Lime;
            this.playerTwoCorrectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoCorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoCorrectBox.Location = new System.Drawing.Point(144, 3);
            this.playerTwoCorrectBox.Name = "playerTwoCorrectBox";
            this.playerTwoCorrectBox.ReadOnly = true;
            this.playerTwoCorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerTwoCorrectBox.TabIndex = 5;
            this.playerTwoCorrectBox.Text = "0";
            this.playerTwoCorrectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gameBoard
            // 
            this.gameBoard.FitToTiles = true;
            this.gameBoard.Interactive = true;
            this.gameBoard.Location = new System.Drawing.Point(3, 88);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(498, 456);
            this.gameBoard.TabIndex = 0;
            this.gameBoard.Text = "gameBoard";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.concludeButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextPlayerButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.endButton, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 550);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 59);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.DarkOrange;
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resetButton.Location = new System.Drawing.Point(4, 8);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(116, 43);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            // 
            // concludeButton
            // 
            this.concludeButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.concludeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.concludeButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.concludeButton.Location = new System.Drawing.Point(128, 8);
            this.concludeButton.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.concludeButton.Name = "concludeButton";
            this.concludeButton.Size = new System.Drawing.Size(116, 43);
            this.concludeButton.TabIndex = 1;
            this.concludeButton.Text = "Vyhodnotit";
            this.concludeButton.UseVisualStyleBackColor = false;
            // 
            // nextPlayerButton
            // 
            this.nextPlayerButton.BackColor = System.Drawing.Color.LawnGreen;
            this.nextPlayerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextPlayerButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextPlayerButton.Location = new System.Drawing.Point(252, 8);
            this.nextPlayerButton.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.nextPlayerButton.Name = "nextPlayerButton";
            this.nextPlayerButton.Size = new System.Drawing.Size(116, 43);
            this.nextPlayerButton.TabIndex = 2;
            this.nextPlayerButton.Text = "Nový tah";
            this.nextPlayerButton.UseVisualStyleBackColor = false;
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.Color.Red;
            this.endButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endButton.ForeColor = System.Drawing.Color.White;
            this.endButton.Location = new System.Drawing.Point(376, 8);
            this.endButton.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(118, 43);
            this.endButton.TabIndex = 3;
            this.endButton.Text = "Konec";
            this.endButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 612);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 570);
            this.Name = "MainForm";
            this.Text = "AZ Kvíz";
            this.tableLayoutPanel.ResumeLayout(false);
            this.playerHeaderLayout.ResumeLayout(false);
            this.playerOneLayout.ResumeLayout(false);
            this.playerOneScoreLayout.ResumeLayout(false);
            this.playerOneScoreLayout.PerformLayout();
            this.playerOneNameLayout.ResumeLayout(false);
            this.playerTwoLayout.ResumeLayout(false);
            this.playerTwoNameLayout.ResumeLayout(false);
            this.playerTwoScoreLayout.ResumeLayout(false);
            this.playerTwoScoreLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AZ_Kviz.Components.GameBoard gameBoard;
        private System.Windows.Forms.Label playerOneLabel;
        private System.Windows.Forms.Panel playerOneColorPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel playerHeaderLayout;
        private System.Windows.Forms.TableLayoutPanel playerOneLayout;
        private System.Windows.Forms.TableLayoutPanel playerOneNameLayout;
        private System.Windows.Forms.TableLayoutPanel playerTwoLayout;
        private System.Windows.Forms.TableLayoutPanel playerTwoNameLayout;
        private System.Windows.Forms.Label playerTwoLabel;
        private System.Windows.Forms.Panel playerTwoColorPanel;
        private System.Windows.Forms.TableLayoutPanel playerTwoScoreLayout;
        private System.Windows.Forms.TextBox playerTwoCorrectBox;
        private System.Windows.Forms.TextBox playerTwoIncorrectBox;
        private System.Windows.Forms.TableLayoutPanel playerOneScoreLayout;
        private System.Windows.Forms.TextBox playerOneCorrectBox;
        private System.Windows.Forms.TextBox playerOneIncorrectBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button concludeButton;
        private System.Windows.Forms.Button nextPlayerButton;
        private System.Windows.Forms.Button endButton;
    }
}

