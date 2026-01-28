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
            this.plyerTwoNameBox = new System.Windows.Forms.TextBox();
            this.playerColorsGroupBox = new System.Windows.Forms.GroupBox();
            this.secondPlayerColorPanel = new System.Windows.Forms.Panel();
            this.firstPlayerColorPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.firstPlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.secondPlayerRadio = new System.Windows.Forms.RadioButton();
            this.FirstPlayerRadio = new System.Windows.Forms.RadioButton();
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
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hráč 1";
            // 
            // playerNamesGroupBox
            // 
            this.playerNamesGroupBox.Controls.Add(this.label1);
            this.playerNamesGroupBox.Controls.Add(this.label2);
            this.playerNamesGroupBox.Controls.Add(this.playerOneNameBox);
            this.playerNamesGroupBox.Controls.Add(this.plyerTwoNameBox);
            this.playerNamesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.playerNamesGroupBox.Name = "playerNamesGroupBox";
            this.playerNamesGroupBox.Size = new System.Drawing.Size(159, 71);
            this.playerNamesGroupBox.TabIndex = 2;
            this.playerNamesGroupBox.TabStop = false;
            this.playerNamesGroupBox.Text = "Jména hráčů";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hráč 2";
            // 
            // playerOneNameBox
            // 
            this.playerOneNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneNameBox.Location = new System.Drawing.Point(51, 16);
            this.playerOneNameBox.Name = "playerOneNameBox";
            this.playerOneNameBox.Size = new System.Drawing.Size(100, 21);
            this.playerOneNameBox.TabIndex = 2;
            // 
            // plyerTwoNameBox
            // 
            this.plyerTwoNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plyerTwoNameBox.Location = new System.Drawing.Point(51, 42);
            this.plyerTwoNameBox.Name = "plyerTwoNameBox";
            this.plyerTwoNameBox.Size = new System.Drawing.Size(100, 21);
            this.plyerTwoNameBox.TabIndex = 3;
            // 
            // playerColorsGroupBox
            // 
            this.playerColorsGroupBox.Controls.Add(this.secondPlayerColorPanel);
            this.playerColorsGroupBox.Controls.Add(this.firstPlayerColorPanel);
            this.playerColorsGroupBox.Controls.Add(this.label4);
            this.playerColorsGroupBox.Controls.Add(this.label3);
            this.playerColorsGroupBox.Location = new System.Drawing.Point(165, 0);
            this.playerColorsGroupBox.Name = "playerColorsGroupBox";
            this.playerColorsGroupBox.Size = new System.Drawing.Size(120, 71);
            this.playerColorsGroupBox.TabIndex = 3;
            this.playerColorsGroupBox.TabStop = false;
            this.playerColorsGroupBox.Text = "Barvy";
            // 
            // secondPlayerColorPanel
            // 
            this.secondPlayerColorPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.secondPlayerColorPanel.Location = new System.Drawing.Point(51, 45);
            this.secondPlayerColorPanel.Name = "secondPlayerColorPanel";
            this.secondPlayerColorPanel.Size = new System.Drawing.Size(62, 18);
            this.secondPlayerColorPanel.TabIndex = 3;
            this.secondPlayerColorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SecondPlayerColorPanel_Paint);
            // 
            // firstPlayerColorPanel
            // 
            this.firstPlayerColorPanel.BackColor = System.Drawing.Color.Orange;
            this.firstPlayerColorPanel.Location = new System.Drawing.Point(51, 16);
            this.firstPlayerColorPanel.Name = "firstPlayerColorPanel";
            this.firstPlayerColorPanel.Size = new System.Drawing.Size(62, 18);
            this.firstPlayerColorPanel.TabIndex = 3;
            this.firstPlayerColorPanel.Click += new System.EventHandler(this.FirstPlayerColorPanel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hráč 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hráč 1";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // firstPlayerGroupBox
            // 
            this.firstPlayerGroupBox.Controls.Add(this.secondPlayerRadio);
            this.firstPlayerGroupBox.Controls.Add(this.FirstPlayerRadio);
            this.firstPlayerGroupBox.Location = new System.Drawing.Point(0, 77);
            this.firstPlayerGroupBox.Name = "firstPlayerGroupBox";
            this.firstPlayerGroupBox.Size = new System.Drawing.Size(134, 43);
            this.firstPlayerGroupBox.TabIndex = 4;
            this.firstPlayerGroupBox.TabStop = false;
            this.firstPlayerGroupBox.Text = "Začíná";
            // 
            // secondPlayerRadio
            // 
            this.secondPlayerRadio.AutoSize = true;
            this.secondPlayerRadio.Location = new System.Drawing.Point(72, 19);
            this.secondPlayerRadio.Name = "secondPlayerRadio";
            this.secondPlayerRadio.Size = new System.Drawing.Size(57, 17);
            this.secondPlayerRadio.TabIndex = 1;
            this.secondPlayerRadio.TabStop = true;
            this.secondPlayerRadio.Text = "Hráč 2";
            this.secondPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // FirstPlayerRadio
            // 
            this.FirstPlayerRadio.AutoSize = true;
            this.FirstPlayerRadio.Location = new System.Drawing.Point(9, 19);
            this.FirstPlayerRadio.Name = "FirstPlayerRadio";
            this.FirstPlayerRadio.Size = new System.Drawing.Size(57, 17);
            this.FirstPlayerRadio.TabIndex = 0;
            this.FirstPlayerRadio.TabStop = true;
            this.FirstPlayerRadio.Text = "Hráč 1";
            this.FirstPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(140, 97);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(221, 97);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PlayersSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 124);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.playerNamesGroupBox);
            this.Controls.Add(this.firstPlayerGroupBox);
            this.Controls.Add(this.playerColorsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.TextBox plyerTwoNameBox;
        private System.Windows.Forms.TextBox playerOneNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox playerColorsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox firstPlayerGroupBox;
        private System.Windows.Forms.RadioButton secondPlayerRadio;
        private System.Windows.Forms.RadioButton FirstPlayerRadio;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel secondPlayerColorPanel;
        private System.Windows.Forms.Panel firstPlayerColorPanel;
    }
}