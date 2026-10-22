namespace AZ_Kviz.Forms
{
    partial class PlayersSetupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.playerNamesGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playerOneNameBox = new System.Windows.Forms.TextBox();
            this.playerTwoNameBox = new System.Windows.Forms.TextBox();
            this.playerColorsGroupBox = new System.Windows.Forms.GroupBox();
            this.secondPlayerColorPanel = new System.Windows.Forms.Panel();
            this.firstPlayerColorPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.firstPlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.secondPlayerRadio = new System.Windows.Forms.RadioButton();
            this.firstPlayerRadio = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.playerNamesGroupBox.SuspendLayout();
            this.playerColorsGroupBox.SuspendLayout();
            this.firstPlayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hráč 1";
            // 
            // playerNamesGroupBox
            // 
            this.playerNamesGroupBox.Controls.Add(this.label1);
            this.playerNamesGroupBox.Controls.Add(this.label2);
            this.playerNamesGroupBox.Controls.Add(this.playerOneNameBox);
            this.playerNamesGroupBox.Controls.Add(this.playerTwoNameBox);
            this.playerNamesGroupBox.Location = new System.Drawing.Point(8, 0);
            this.playerNamesGroupBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.playerNamesGroupBox.Name = "playerNamesGroupBox";
            this.playerNamesGroupBox.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.playerNamesGroupBox.Size = new System.Drawing.Size(292, 101);
            this.playerNamesGroupBox.TabIndex = 0;
            this.playerNamesGroupBox.TabStop = false;
            this.playerNamesGroupBox.Text = "Jména hráčů";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hráč 2";
            // 
            // playerOneNameBox
            // 
            this.playerOneNameBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneNameBox.Location = new System.Drawing.Point(88, 29);
            this.playerOneNameBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.playerOneNameBox.Name = "playerOneNameBox";
            this.playerOneNameBox.Size = new System.Drawing.Size(180, 29);
            this.playerOneNameBox.TabIndex = 1;
            // 
            // playerTwoNameBox
            // 
            this.playerTwoNameBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoNameBox.Location = new System.Drawing.Point(88, 63);
            this.playerTwoNameBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.playerTwoNameBox.Name = "playerTwoNameBox";
            this.playerTwoNameBox.Size = new System.Drawing.Size(180, 29);
            this.playerTwoNameBox.TabIndex = 0;
            // 
            // playerColorsGroupBox
            // 
            this.playerColorsGroupBox.Controls.Add(this.secondPlayerColorPanel);
            this.playerColorsGroupBox.Controls.Add(this.firstPlayerColorPanel);
            this.playerColorsGroupBox.Controls.Add(this.label4);
            this.playerColorsGroupBox.Controls.Add(this.label3);
            this.playerColorsGroupBox.Location = new System.Drawing.Point(313, 0);
            this.playerColorsGroupBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.playerColorsGroupBox.Name = "playerColorsGroupBox";
            this.playerColorsGroupBox.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.playerColorsGroupBox.Size = new System.Drawing.Size(220, 118);
            this.playerColorsGroupBox.TabIndex = 0;
            this.playerColorsGroupBox.TabStop = false;
            this.playerColorsGroupBox.Text = "Barvy";
            // 
            // secondPlayerColorPanel
            // 
            this.secondPlayerColorPanel.AutoSize = true;
            this.secondPlayerColorPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.secondPlayerColorPanel.Location = new System.Drawing.Point(93, 76);
            this.secondPlayerColorPanel.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.secondPlayerColorPanel.Name = "secondPlayerColorPanel";
            this.secondPlayerColorPanel.Size = new System.Drawing.Size(113, 31);
            this.secondPlayerColorPanel.TabIndex = 1;
            this.secondPlayerColorPanel.Click += new System.EventHandler(this.PlayerColorPanel_Click);
            // 
            // firstPlayerColorPanel
            // 
            this.firstPlayerColorPanel.AutoSize = true;
            this.firstPlayerColorPanel.BackColor = System.Drawing.Color.Orange;
            this.firstPlayerColorPanel.Location = new System.Drawing.Point(93, 26);
            this.firstPlayerColorPanel.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.firstPlayerColorPanel.Name = "firstPlayerColorPanel";
            this.firstPlayerColorPanel.Size = new System.Drawing.Size(113, 31);
            this.firstPlayerColorPanel.TabIndex = 0;
            this.firstPlayerColorPanel.Click += new System.EventHandler(this.PlayerColorPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hráč 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hráč 1";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // firstPlayerGroupBox
            // 
            this.firstPlayerGroupBox.Controls.Add(this.secondPlayerRadio);
            this.firstPlayerGroupBox.Controls.Add(this.firstPlayerRadio);
            this.firstPlayerGroupBox.Location = new System.Drawing.Point(8, 114);
            this.firstPlayerGroupBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.firstPlayerGroupBox.Name = "firstPlayerGroupBox";
            this.firstPlayerGroupBox.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.firstPlayerGroupBox.Size = new System.Drawing.Size(202, 69);
            this.firstPlayerGroupBox.TabIndex = 1;
            this.firstPlayerGroupBox.TabStop = false;
            this.firstPlayerGroupBox.Text = "Začíná";
            // 
            // secondPlayerRadio
            // 
            this.secondPlayerRadio.AutoSize = true;
            this.secondPlayerRadio.Location = new System.Drawing.Point(110, 30);
            this.secondPlayerRadio.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.secondPlayerRadio.Name = "secondPlayerRadio";
            this.secondPlayerRadio.Size = new System.Drawing.Size(83, 26);
            this.secondPlayerRadio.TabIndex = 1;
            this.secondPlayerRadio.TabStop = true;
            this.secondPlayerRadio.Text = "Hráč 2";
            this.secondPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // firstPlayerRadio
            // 
            this.firstPlayerRadio.AutoSize = true;
            this.firstPlayerRadio.Checked = true;
            this.firstPlayerRadio.Location = new System.Drawing.Point(15, 30);
            this.firstPlayerRadio.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.firstPlayerRadio.Name = "firstPlayerRadio";
            this.firstPlayerRadio.Size = new System.Drawing.Size(83, 26);
            this.firstPlayerRadio.TabIndex = 0;
            this.firstPlayerRadio.TabStop = true;
            this.firstPlayerRadio.Text = "Hráč 1";
            this.firstPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.BackColor = System.Drawing.Color.Lime;
            this.startButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(395, 142);
            this.startButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(138, 41);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(245, 142);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 41);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PlayersSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 191);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.playerNamesGroupBox);
            this.Controls.Add(this.firstPlayerGroupBox);
            this.Controls.Add(this.playerColorsGroupBox);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(545, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(545, 220);
            this.Name = "PlayersSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nastavení hráčů";
            this.playerNamesGroupBox.ResumeLayout(false);
            this.playerNamesGroupBox.PerformLayout();
            this.playerColorsGroupBox.ResumeLayout(false);
            this.playerColorsGroupBox.PerformLayout();
            this.firstPlayerGroupBox.ResumeLayout(false);
            this.firstPlayerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox playerNamesGroupBox;
        private System.Windows.Forms.TextBox playerTwoNameBox;
        private System.Windows.Forms.TextBox playerOneNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox playerColorsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox firstPlayerGroupBox;
        private System.Windows.Forms.RadioButton secondPlayerRadio;
        private System.Windows.Forms.RadioButton firstPlayerRadio;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel secondPlayerColorPanel;
        private System.Windows.Forms.Panel firstPlayerColorPanel;
    }
}