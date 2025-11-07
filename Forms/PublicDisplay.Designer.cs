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
            this.timeIndicator = new CircularProgressBar.CircularProgressBar();
            this.playerOneScoreLabel = new System.Windows.Forms.Label();
            this.playerTwoScoreLabel = new System.Windows.Forms.Label();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.gameBoard = new AZ_Kviz.GameBoard_L();
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
            this.playerOneScoreLabel.ForeColor = System.Drawing.Color.White;
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
            this.playerTwoScoreLabel.ForeColor = System.Drawing.Color.White;
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
            this.playerTwoLabel.ForeColor = System.Drawing.Color.White;
            this.playerTwoLabel.Location = new System.Drawing.Point(1445, 9);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(455, 149);
            this.playerTwoLabel.TabIndex = 4;
            this.playerTwoLabel.Text = "Hráč 2";
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.AutoSize = true;
            this.playerOneLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerOneLabel.Font = new System.Drawing.Font("Arial", 99.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneLabel.ForeColor = System.Drawing.Color.White;
            this.playerOneLabel.Location = new System.Drawing.Point(12, 9);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(455, 149);
            this.playerOneLabel.TabIndex = 4;
            this.playerOneLabel.Text = "Hráč 1";
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
            // PublicDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.playerOneLabel);
            this.Controls.Add(this.playerTwoLabel);
            this.Controls.Add(this.playerTwoScoreLabel);
            this.Controls.Add(this.playerOneScoreLabel);
            this.Controls.Add(this.timeIndicator);
            this.Controls.Add(this.gameBoard);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublicDisplay";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PublicDisplay";
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
    }
}