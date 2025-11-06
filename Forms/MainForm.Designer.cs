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
            this.resetButton = new System.Windows.Forms.Button();
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.playerOneCorrectBox = new System.Windows.Forms.TextBox();
            this.playerTwoIncorrectBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.playerOneIncorrectBox = new System.Windows.Forms.TextBox();
            this.playerTwoCorrectBox = new System.Windows.Forms.TextBox();
            this.gameBoard1 = new AZ_Kviz.GameBoard_S();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Orange;
            this.resetButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resetButton.Location = new System.Drawing.Point(12, 395);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 40);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.AutoSize = true;
            this.playerOneLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneLabel.Location = new System.Drawing.Point(12, 9);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(70, 22);
            this.playerOneLabel.TabIndex = 2;
            this.playerOneLabel.Text = "Hráč 1:";
            // 
            // playerTwoLabel
            // 
            this.playerTwoLabel.AutoSize = true;
            this.playerTwoLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoLabel.Location = new System.Drawing.Point(227, 9);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(70, 22);
            this.playerTwoLabel.TabIndex = 4;
            this.playerTwoLabel.Text = "Hráč 2:";
            // 
            // playerOneCorrectBox
            // 
            this.playerOneCorrectBox.BackColor = System.Drawing.Color.Lime;
            this.playerOneCorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneCorrectBox.Location = new System.Drawing.Point(88, 6);
            this.playerOneCorrectBox.Name = "playerOneCorrectBox";
            this.playerOneCorrectBox.ReadOnly = true;
            this.playerOneCorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerOneCorrectBox.TabIndex = 5;
            this.playerOneCorrectBox.Text = "0";
            // 
            // playerTwoIncorrectBox
            // 
            this.playerTwoIncorrectBox.BackColor = System.Drawing.Color.Red;
            this.playerTwoIncorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoIncorrectBox.ForeColor = System.Drawing.Color.White;
            this.playerTwoIncorrectBox.Location = new System.Drawing.Point(351, 6);
            this.playerTwoIncorrectBox.Name = "playerTwoIncorrectBox";
            this.playerTwoIncorrectBox.ReadOnly = true;
            this.playerTwoIncorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerTwoIncorrectBox.TabIndex = 5;
            this.playerTwoIncorrectBox.Text = "0";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(93, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Vyhodnotit";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LawnGreen;
            this.button3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(208, 395);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 40);
            this.button3.TabIndex = 1;
            this.button3.Text = "Nový tah";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Red;
            this.exitButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(312, 395);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 40);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Konec";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // playerOneIncorrectBox
            // 
            this.playerOneIncorrectBox.BackColor = System.Drawing.Color.Red;
            this.playerOneIncorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneIncorrectBox.ForeColor = System.Drawing.Color.White;
            this.playerOneIncorrectBox.Location = new System.Drawing.Point(136, 6);
            this.playerOneIncorrectBox.Name = "playerOneIncorrectBox";
            this.playerOneIncorrectBox.ReadOnly = true;
            this.playerOneIncorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerOneIncorrectBox.TabIndex = 5;
            this.playerOneIncorrectBox.Text = "0";
            // 
            // playerTwoCorrectBox
            // 
            this.playerTwoCorrectBox.BackColor = System.Drawing.Color.Lime;
            this.playerTwoCorrectBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoCorrectBox.Location = new System.Drawing.Point(303, 6);
            this.playerTwoCorrectBox.Name = "playerTwoCorrectBox";
            this.playerTwoCorrectBox.ReadOnly = true;
            this.playerTwoCorrectBox.Size = new System.Drawing.Size(42, 29);
            this.playerTwoCorrectBox.TabIndex = 5;
            this.playerTwoCorrectBox.Text = "0";
            // 
            // gameBoard1
            // 
            this.gameBoard1.Location = new System.Drawing.Point(12, 41);
            this.gameBoard1.Name = "gameBoard1";
            this.gameBoard1.Size = new System.Drawing.Size(379, 348);
            this.gameBoard1.TabIndex = 0;
            this.gameBoard1.Text = "gameBoard1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 441);
            this.Controls.Add(this.playerTwoCorrectBox);
            this.Controls.Add(this.playerTwoIncorrectBox);
            this.Controls.Add(this.playerOneIncorrectBox);
            this.Controls.Add(this.playerOneCorrectBox);
            this.Controls.Add(this.playerTwoLabel);
            this.Controls.Add(this.playerOneLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.gameBoard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "AZ Kvíz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameBoard_S gameBoard1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label playerOneLabel;
        private System.Windows.Forms.Label playerTwoLabel;
        private System.Windows.Forms.TextBox playerOneCorrectBox;
        private System.Windows.Forms.TextBox playerTwoIncorrectBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox playerOneIncorrectBox;
        private System.Windows.Forms.TextBox playerTwoCorrectBox;
    }
}

