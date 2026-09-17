namespace AZ_Kviz.Forms
{
    partial class ConclusionForm
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
            this.playerOneGroupBox = new System.Windows.Forms.GroupBox();
            this.playerOneIncorrect = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.playerOneCorrect = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.playerTwoGroupBox = new System.Windows.Forms.GroupBox();
            this.playerTwoCorrect = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.playerTwoIncorrect = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.endButton = new System.Windows.Forms.Button();
            this.repeatButton = new System.Windows.Forms.Button();
            this.playerOneGroupBox.SuspendLayout();
            this.playerTwoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerOneGroupBox
            // 
            this.playerOneGroupBox.Controls.Add(this.playerOneIncorrect);
            this.playerOneGroupBox.Controls.Add(this.playerOneCorrect);
            this.playerOneGroupBox.Controls.Add(this.label2);
            this.playerOneGroupBox.Controls.Add(this.label1);
            this.playerOneGroupBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerOneGroupBox.Location = new System.Drawing.Point(11, 0);
            this.playerOneGroupBox.Name = "playerOneGroupBox";
            this.playerOneGroupBox.Size = new System.Drawing.Size(154, 100);
            this.playerOneGroupBox.TabIndex = 0;
            this.playerOneGroupBox.TabStop = false;
            this.playerOneGroupBox.Text = "Hráč 1";
            // 
            // playerOneIncorrect
            // 
            this.playerOneIncorrect.BackColor = System.Drawing.Color.Red;
            this.playerOneIncorrect.ForeColor = System.Drawing.Color.White;
            this.playerOneIncorrect.Location = new System.Drawing.Point(98, 60);
            this.playerOneIncorrect.Name = "playerOneIncorrect";
            this.playerOneIncorrect.SelectionHighlightEnabled = false;
            this.playerOneIncorrect.Size = new System.Drawing.Size(50, 29);
            this.playerOneIncorrect.TabIndex = 1;
            this.playerOneIncorrect.Text = "0";
            // 
            // playerOneCorrect
            // 
            this.playerOneCorrect.BackColor = System.Drawing.Color.Lime;
            this.playerOneCorrect.Location = new System.Drawing.Point(98, 22);
            this.playerOneCorrect.Name = "playerOneCorrect";
            this.playerOneCorrect.SelectionHighlightEnabled = false;
            this.playerOneCorrect.Size = new System.Drawing.Size(50, 29);
            this.playerOneCorrect.TabIndex = 1;
            this.playerOneCorrect.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Špatné";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Správné";
            // 
            // playerTwoGroupBox
            // 
            this.playerTwoGroupBox.Controls.Add(this.playerTwoCorrect);
            this.playerTwoGroupBox.Controls.Add(this.playerTwoIncorrect);
            this.playerTwoGroupBox.Controls.Add(this.label3);
            this.playerTwoGroupBox.Controls.Add(this.label4);
            this.playerTwoGroupBox.Location = new System.Drawing.Point(171, 0);
            this.playerTwoGroupBox.Name = "playerTwoGroupBox";
            this.playerTwoGroupBox.Size = new System.Drawing.Size(155, 100);
            this.playerTwoGroupBox.TabIndex = 0;
            this.playerTwoGroupBox.TabStop = false;
            this.playerTwoGroupBox.Text = "Hráč 2";
            // 
            // playerTwoCorrect
            // 
            this.playerTwoCorrect.BackColor = System.Drawing.Color.Lime;
            this.playerTwoCorrect.Location = new System.Drawing.Point(98, 25);
            this.playerTwoCorrect.Name = "playerTwoCorrect";
            this.playerTwoCorrect.SelectionHighlightEnabled = false;
            this.playerTwoCorrect.Size = new System.Drawing.Size(50, 29);
            this.playerTwoCorrect.TabIndex = 1;
            this.playerTwoCorrect.Text = "0";
            // 
            // playerTwoIncorrect
            // 
            this.playerTwoIncorrect.BackColor = System.Drawing.Color.Red;
            this.playerTwoIncorrect.ForeColor = System.Drawing.Color.White;
            this.playerTwoIncorrect.Location = new System.Drawing.Point(98, 57);
            this.playerTwoIncorrect.Name = "playerTwoIncorrect";
            this.playerTwoIncorrect.SelectionHighlightEnabled = false;
            this.playerTwoIncorrect.Size = new System.Drawing.Size(50, 29);
            this.playerTwoIncorrect.TabIndex = 1;
            this.playerTwoIncorrect.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Špatné";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Správné";
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.Color.Red;
            this.endButton.ForeColor = System.Drawing.Color.White;
            this.endButton.Location = new System.Drawing.Point(226, 106);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(100, 35);
            this.endButton.TabIndex = 1;
            this.endButton.Text = "Ukončit";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.BackColor = System.Drawing.Color.SteelBlue;
            this.repeatButton.ForeColor = System.Drawing.Color.White;
            this.repeatButton.Location = new System.Drawing.Point(11, 106);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(100, 35);
            this.repeatButton.TabIndex = 1;
            this.repeatButton.Text = "Opakovat";
            this.repeatButton.UseVisualStyleBackColor = false;
            this.repeatButton.Visible = false;
            this.repeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // ConclusionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 146);
            this.ControlBox = false;
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.playerTwoGroupBox);
            this.Controls.Add(this.playerOneGroupBox);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(335, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(335, 175);
            this.Name = "ConclusionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Výsledky hry";
            this.TopMost = true;
            this.playerOneGroupBox.ResumeLayout(false);
            this.playerOneGroupBox.PerformLayout();
            this.playerTwoGroupBox.ResumeLayout(false);
            this.playerTwoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox playerOneGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Components.ReadOnlyTextBox playerOneIncorrect;
        private Components.ReadOnlyTextBox playerOneCorrect;
        private System.Windows.Forms.GroupBox playerTwoGroupBox;
        private Components.ReadOnlyTextBox playerTwoIncorrect;
        private Components.ReadOnlyTextBox playerTwoCorrect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button repeatButton;
    }
}