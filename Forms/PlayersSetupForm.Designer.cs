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
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hráč 1";
            // 
            // playerNamesGroupBox
            // 
            this.playerNamesGroupBox.Controls.Add(this.label1);
            this.playerNamesGroupBox.Controls.Add(this.label2);
            this.playerNamesGroupBox.Controls.Add(this.playerOneNameBox);
            this.playerNamesGroupBox.Controls.Add(this.playerTwoNameBox);
            this.playerNamesGroupBox.Location = new System.Drawing.Point(5, 0);
            this.playerNamesGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerNamesGroupBox.Name = "playerNamesGroupBox";
            this.playerNamesGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerNamesGroupBox.Size = new System.Drawing.Size(186, 82);
            this.playerNamesGroupBox.TabIndex = 0;
            this.playerNamesGroupBox.TabStop = false;
            this.playerNamesGroupBox.Text = "Jména hráčů";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hráč 2";
            // 
            // playerOneNameBox
            // 
            this.playerOneNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneNameBox.Location = new System.Drawing.Point(59, 18);
            this.playerOneNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerOneNameBox.Name = "playerOneNameBox";
            this.playerOneNameBox.Size = new System.Drawing.Size(116, 21);
            this.playerOneNameBox.TabIndex = 0;
            // 
            // playerTwoNameBox
            // 
            this.playerTwoNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerTwoNameBox.Location = new System.Drawing.Point(59, 48);
            this.playerTwoNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerTwoNameBox.Name = "playerTwoNameBox";
            this.playerTwoNameBox.Size = new System.Drawing.Size(116, 21);
            this.playerTwoNameBox.TabIndex = 1;
            // 
            // playerColorsGroupBox
            // 
            this.playerColorsGroupBox.Controls.Add(this.secondPlayerColorPanel);
            this.playerColorsGroupBox.Controls.Add(this.firstPlayerColorPanel);
            this.playerColorsGroupBox.Controls.Add(this.label4);
            this.playerColorsGroupBox.Controls.Add(this.label3);
            this.playerColorsGroupBox.Location = new System.Drawing.Point(199, 0);
            this.playerColorsGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerColorsGroupBox.Name = "playerColorsGroupBox";
            this.playerColorsGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerColorsGroupBox.Size = new System.Drawing.Size(140, 82);
            this.playerColorsGroupBox.TabIndex = 1;
            this.playerColorsGroupBox.TabStop = false;
            this.playerColorsGroupBox.Text = "Barvy";
            // 
            // secondPlayerColorPanel
            // 
            this.secondPlayerColorPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.secondPlayerColorPanel.Location = new System.Drawing.Point(59, 52);
            this.secondPlayerColorPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.secondPlayerColorPanel.Name = "secondPlayerColorPanel";
            this.secondPlayerColorPanel.Size = new System.Drawing.Size(72, 21);
            this.secondPlayerColorPanel.TabIndex = 1;
            // 
            // firstPlayerColorPanel
            // 
            this.firstPlayerColorPanel.BackColor = System.Drawing.Color.Orange;
            this.firstPlayerColorPanel.Location = new System.Drawing.Point(59, 18);
            this.firstPlayerColorPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstPlayerColorPanel.Name = "firstPlayerColorPanel";
            this.firstPlayerColorPanel.Size = new System.Drawing.Size(72, 21);
            this.firstPlayerColorPanel.TabIndex = 0;
            this.firstPlayerColorPanel.Click += new System.EventHandler(this.FirstPlayerColorPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hráč 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
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
            this.firstPlayerGroupBox.Location = new System.Drawing.Point(5, 88);
            this.firstPlayerGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstPlayerGroupBox.Name = "firstPlayerGroupBox";
            this.firstPlayerGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstPlayerGroupBox.Size = new System.Drawing.Size(156, 50);
            this.firstPlayerGroupBox.TabIndex = 2;
            this.firstPlayerGroupBox.TabStop = false;
            this.firstPlayerGroupBox.Text = "Začíná";
            // 
            // secondPlayerRadio
            // 
            this.secondPlayerRadio.AutoSize = true;
            this.secondPlayerRadio.Location = new System.Drawing.Point(84, 22);
            this.secondPlayerRadio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.secondPlayerRadio.Name = "secondPlayerRadio";
            this.secondPlayerRadio.Size = new System.Drawing.Size(59, 19);
            this.secondPlayerRadio.TabIndex = 1;
            this.secondPlayerRadio.Text = "Hráč 2";
            this.secondPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // firstPlayerRadio
            // 
            this.firstPlayerRadio.AutoSize = true;
            this.firstPlayerRadio.Checked = true;
            this.firstPlayerRadio.Location = new System.Drawing.Point(10, 22);
            this.firstPlayerRadio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstPlayerRadio.Name = "firstPlayerRadio";
            this.firstPlayerRadio.Size = new System.Drawing.Size(59, 19);
            this.firstPlayerRadio.TabIndex = 0;
            this.firstPlayerRadio.TabStop = true;
            this.firstPlayerRadio.Text = "Hráč 1";
            this.firstPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Lime;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(169, 110);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(88, 28);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(258, 110);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PlayersSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 141);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.playerNamesGroupBox);
            this.Controls.Add(this.firstPlayerGroupBox);
            this.Controls.Add(this.playerColorsGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 170);
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