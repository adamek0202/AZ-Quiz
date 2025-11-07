namespace AZ_Kviz
{
    partial class PublicDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicDisplay));
            this.timeIndicator = new CircularProgressBar.CircularProgressBar();
            this.playerOneScoreLabel = new System.Windows.Forms.Label();
            this.playerTwoScoreLabel = new System.Windows.Forms.Label();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.gameBoard = new AZ_Kviz.GameBoard_L();
            this.conclusionPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.playerOneCorrectBox = new System.Windows.Forms.TextBox();
            this.playerOneIncorrectBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.playerTwoCorrectBox = new System.Windows.Forms.TextBox();
            this.playerTwoIncorrectBox = new System.Windows.Forms.TextBox();
            this.conclusionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeIndicator
            // 
            this.timeIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeIndicator.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.timeIndicator.AnimationSpeed = 1000;
            this.timeIndicator.BackColor = System.Drawing.Color.Transparent;
            this.timeIndicator.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeIndicator.ForeColor = System.Drawing.Color.White;
            this.timeIndicator.InnerColor = System.Drawing.Color.Transparent;
            this.timeIndicator.InnerMargin = 0;
            this.timeIndicator.InnerWidth = 0;
            this.timeIndicator.Location = new System.Drawing.Point(1479, 404);
            this.timeIndicator.MarqueeAnimationSpeed = 2000;
            this.timeIndicator.Maximum = 10;
            this.timeIndicator.Name = "timeIndicator";
            this.timeIndicator.OuterColor = System.Drawing.Color.Gray;
            this.timeIndicator.OuterMargin = -25;
            this.timeIndicator.OuterWidth = 26;
            this.timeIndicator.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.timeIndicator.ProgressWidth = 25;
            this.timeIndicator.SecondaryFont = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeIndicator.Size = new System.Drawing.Size(396, 394);
            this.timeIndicator.StartAngle = 270;
            this.timeIndicator.Step = 1;
            this.timeIndicator.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.timeIndicator.SubscriptColor = System.Drawing.Color.Transparent;
            this.timeIndicator.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.timeIndicator.SubscriptText = "";
            this.timeIndicator.SuperscriptColor = System.Drawing.Color.Transparent;
            this.timeIndicator.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.timeIndicator.SuperscriptText = "";
            this.timeIndicator.TabIndex = 3;
            this.timeIndicator.Text = "10";
            this.timeIndicator.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.timeIndicator.Value = 10;
            this.timeIndicator.Visible = false;
            // 
            // playerOneScoreLabel
            // 
            this.playerOneScoreLabel.AutoSize = true;
            this.playerOneScoreLabel.Font = new System.Drawing.Font("Arial", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneScoreLabel.ForeColor = System.Drawing.Color.Orange;
            this.playerOneScoreLabel.Location = new System.Drawing.Point(12, 922);
            this.playerOneScoreLabel.Name = "playerOneScoreLabel";
            this.playerOneScoreLabel.Size = new System.Drawing.Size(137, 149);
            this.playerOneScoreLabel.TabIndex = 4;
            this.playerOneScoreLabel.Text = "0";
            // 
            // playerTwoScoreLabel
            // 
            this.playerTwoScoreLabel.AutoSize = true;
            this.playerTwoScoreLabel.Font = new System.Drawing.Font("Arial", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoScoreLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.playerTwoScoreLabel.Location = new System.Drawing.Point(1771, 922);
            this.playerTwoScoreLabel.Name = "playerTwoScoreLabel";
            this.playerTwoScoreLabel.Size = new System.Drawing.Size(137, 149);
            this.playerTwoScoreLabel.TabIndex = 4;
            this.playerTwoScoreLabel.Text = "0";
            // 
            // playerTwoLabel
            // 
            this.playerTwoLabel.AutoSize = true;
            this.playerTwoLabel.Font = new System.Drawing.Font("Arial", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.playerTwoLabel.Location = new System.Drawing.Point(1475, 9);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(433, 149);
            this.playerTwoLabel.TabIndex = 4;
            this.playerTwoLabel.Text = "Tým 2";
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.AutoSize = true;
            this.playerOneLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerOneLabel.Font = new System.Drawing.Font("Arial", 99.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneLabel.ForeColor = System.Drawing.Color.Orange;
            this.playerOneLabel.Location = new System.Drawing.Point(12, 9);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(433, 149);
            this.playerOneLabel.TabIndex = 4;
            this.playerOneLabel.Text = "Tým 1";
            // 
            // gameBoard
            // 
            this.gameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameBoard.Location = new System.Drawing.Point(0, 0);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(1920, 1080);
            this.gameBoard.TabIndex = 2;
            this.gameBoard.Text = "gameBoard_L1";
            // 
            // conclusionPanel
            // 
            this.conclusionPanel.BackColor = System.Drawing.Color.DimGray;
            this.conclusionPanel.Controls.Add(this.playerTwoIncorrectBox);
            this.conclusionPanel.Controls.Add(this.playerOneIncorrectBox);
            this.conclusionPanel.Controls.Add(this.playerTwoCorrectBox);
            this.conclusionPanel.Controls.Add(this.playerOneCorrectBox);
            this.conclusionPanel.Controls.Add(this.label7);
            this.conclusionPanel.Controls.Add(this.label6);
            this.conclusionPanel.Controls.Add(this.label4);
            this.conclusionPanel.Controls.Add(this.label5);
            this.conclusionPanel.Controls.Add(this.label3);
            this.conclusionPanel.Controls.Add(this.label2);
            this.conclusionPanel.Controls.Add(this.label1);
            this.conclusionPanel.Location = new System.Drawing.Point(699, 435);
            this.conclusionPanel.Name = "conclusionPanel";
            this.conclusionPanel.Size = new System.Drawing.Size(522, 210);
            this.conclusionPanel.TabIndex = 5;
            this.conclusionPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tým 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(275, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tým 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Správně";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 36);
            this.label5.TabIndex = 4;
            this.label5.Text = "Špatně";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(176, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 42);
            this.label7.TabIndex = 2;
            this.label7.Text = "Výsledky";
            // 
            // playerOneCorrectBox
            // 
            this.playerOneCorrectBox.BackColor = System.Drawing.Color.Lime;
            this.playerOneCorrectBox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneCorrectBox.Location = new System.Drawing.Point(153, 97);
            this.playerOneCorrectBox.Name = "playerOneCorrectBox";
            this.playerOneCorrectBox.Size = new System.Drawing.Size(100, 44);
            this.playerOneCorrectBox.TabIndex = 5;
            this.playerOneCorrectBox.Text = "1";
            // 
            // playerOneIncorrectBox
            // 
            this.playerOneIncorrectBox.BackColor = System.Drawing.Color.Red;
            this.playerOneIncorrectBox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneIncorrectBox.ForeColor = System.Drawing.Color.White;
            this.playerOneIncorrectBox.Location = new System.Drawing.Point(153, 147);
            this.playerOneIncorrectBox.Name = "playerOneIncorrectBox";
            this.playerOneIncorrectBox.Size = new System.Drawing.Size(100, 44);
            this.playerOneIncorrectBox.TabIndex = 5;
            this.playerOneIncorrectBox.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(270, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Správně";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(270, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 36);
            this.label6.TabIndex = 4;
            this.label6.Text = "Špatně";
            // 
            // playerTwoCorrectBox
            // 
            this.playerTwoCorrectBox.BackColor = System.Drawing.Color.Lime;
            this.playerTwoCorrectBox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoCorrectBox.Location = new System.Drawing.Point(407, 102);
            this.playerTwoCorrectBox.Name = "playerTwoCorrectBox";
            this.playerTwoCorrectBox.Size = new System.Drawing.Size(100, 44);
            this.playerTwoCorrectBox.TabIndex = 5;
            this.playerTwoCorrectBox.Text = "1";
            // 
            // playerTwoIncorrectBox
            // 
            this.playerTwoIncorrectBox.BackColor = System.Drawing.Color.Red;
            this.playerTwoIncorrectBox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoIncorrectBox.ForeColor = System.Drawing.Color.White;
            this.playerTwoIncorrectBox.Location = new System.Drawing.Point(407, 152);
            this.playerTwoIncorrectBox.Name = "playerTwoIncorrectBox";
            this.playerTwoIncorrectBox.Size = new System.Drawing.Size(100, 44);
            this.playerTwoIncorrectBox.TabIndex = 5;
            this.playerTwoIncorrectBox.Text = "1";
            // 
            // PublicDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.conclusionPanel);
            this.Controls.Add(this.playerOneLabel);
            this.Controls.Add(this.playerTwoLabel);
            this.Controls.Add(this.playerTwoScoreLabel);
            this.Controls.Add(this.playerOneScoreLabel);
            this.Controls.Add(this.timeIndicator);
            this.Controls.Add(this.gameBoard);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublicDisplay";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PublicDisplay";
            this.conclusionPanel.ResumeLayout(false);
            this.conclusionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GameBoard_L gameBoard;
        private CircularProgressBar.CircularProgressBar timeIndicator;
        private System.Windows.Forms.Label playerOneScoreLabel;
        private System.Windows.Forms.Label playerTwoScoreLabel;
        private System.Windows.Forms.Label playerTwoLabel;
        private System.Windows.Forms.Label playerOneLabel;
        private System.Windows.Forms.Panel conclusionPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerTwoIncorrectBox;
        private System.Windows.Forms.TextBox playerOneIncorrectBox;
        private System.Windows.Forms.TextBox playerTwoCorrectBox;
        private System.Windows.Forms.TextBox playerOneCorrectBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}