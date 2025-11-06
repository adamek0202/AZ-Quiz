namespace AZ_Kviz.Forms
{
    partial class QuestionForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secondIncorrectButton = new System.Windows.Forms.Button();
            this.secondCorrectButton = new System.Windows.Forms.Button();
            this.incorrectButton = new System.Windows.Forms.Button();
            this.correctButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.timeTextBox = new AZ_Kviz.ReadOnlyTextBox();
            this.questionTypeTextBox = new AZ_Kviz.ReadOnlyTextBox();
            this.playerTextBox = new AZ_Kviz.ReadOnlyTextBox();
            this.answerTextBox = new AZ_Kviz.ReadOnlyTextBox();
            this.questionTextBox = new AZ_Kviz.ReadOnlyTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text otázky";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odpověď";
            // 
            // secondIncorrectButton
            // 
            this.secondIncorrectButton.BackColor = System.Drawing.Color.Red;
            this.secondIncorrectButton.ForeColor = System.Drawing.Color.White;
            this.secondIncorrectButton.Location = new System.Drawing.Point(446, 186);
            this.secondIncorrectButton.Name = "secondIncorrectButton";
            this.secondIncorrectButton.Size = new System.Drawing.Size(113, 42);
            this.secondIncorrectButton.TabIndex = 2;
            this.secondIncorrectButton.Text = "Špatně - 2";
            this.secondIncorrectButton.UseVisualStyleBackColor = false;
            this.secondIncorrectButton.Click += new System.EventHandler(this.SecondIncorrectButton_Click);
            // 
            // secondCorrectButton
            // 
            this.secondCorrectButton.BackColor = System.Drawing.Color.Lime;
            this.secondCorrectButton.Location = new System.Drawing.Point(323, 186);
            this.secondCorrectButton.Name = "secondCorrectButton";
            this.secondCorrectButton.Size = new System.Drawing.Size(117, 42);
            this.secondCorrectButton.TabIndex = 2;
            this.secondCorrectButton.Text = "Správně - 2";
            this.secondCorrectButton.UseVisualStyleBackColor = false;
            this.secondCorrectButton.Click += new System.EventHandler(this.SecondCorrectButton_Click);
            // 
            // incorrectButton
            // 
            this.incorrectButton.BackColor = System.Drawing.Color.Red;
            this.incorrectButton.ForeColor = System.Drawing.Color.White;
            this.incorrectButton.Location = new System.Drawing.Point(226, 186);
            this.incorrectButton.Name = "incorrectButton";
            this.incorrectButton.Size = new System.Drawing.Size(91, 42);
            this.incorrectButton.TabIndex = 2;
            this.incorrectButton.Text = "Špatně";
            this.incorrectButton.UseVisualStyleBackColor = false;
            this.incorrectButton.Click += new System.EventHandler(this.IncorrectButton_Click);
            // 
            // correctButton
            // 
            this.correctButton.BackColor = System.Drawing.Color.Lime;
            this.correctButton.ForeColor = System.Drawing.Color.Black;
            this.correctButton.Location = new System.Drawing.Point(129, 186);
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(91, 42);
            this.correctButton.TabIndex = 2;
            this.correctButton.Text = "Správně";
            this.correctButton.UseVisualStyleBackColor = false;
            this.correctButton.Click += new System.EventHandler(this.CorrectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hráč";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Čas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Typ otázky";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(32, 186);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(91, 42);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // timeTextBox
            // 
            this.timeTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.timeTextBox.Location = new System.Drawing.Point(513, 12);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.SelectionHighlightEnabled = false;
            this.timeTextBox.Size = new System.Drawing.Size(46, 29);
            this.timeTextBox.TabIndex = 4;
            this.timeTextBox.Text = "15";
            // 
            // questionTypeTextBox
            // 
            this.questionTypeTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.questionTypeTextBox.Location = new System.Drawing.Point(332, 11);
            this.questionTypeTextBox.Name = "questionTypeTextBox";
            this.questionTypeTextBox.ReadOnly = true;
            this.questionTypeTextBox.SelectionHighlightEnabled = false;
            this.questionTypeTextBox.Size = new System.Drawing.Size(125, 29);
            this.questionTypeTextBox.TabIndex = 4;
            this.questionTypeTextBox.Text = "Normální";
            // 
            // playerTextBox
            // 
            this.playerTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.playerTextBox.Location = new System.Drawing.Point(121, 12);
            this.playerTextBox.Name = "playerTextBox";
            this.playerTextBox.ReadOnly = true;
            this.playerTextBox.SelectionHighlightEnabled = false;
            this.playerTextBox.Size = new System.Drawing.Size(100, 29);
            this.playerTextBox.TabIndex = 4;
            this.playerTextBox.Text = "Hráč 1";
            // 
            // answerTextBox
            // 
            this.answerTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.answerTextBox.Location = new System.Drawing.Point(121, 129);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.ReadOnly = true;
            this.answerTextBox.SelectionHighlightEnabled = false;
            this.answerTextBox.Size = new System.Drawing.Size(438, 51);
            this.answerTextBox.TabIndex = 0;
            // 
            // questionTextBox
            // 
            this.questionTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.questionTextBox.Location = new System.Drawing.Point(121, 47);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.ReadOnly = true;
            this.questionTextBox.SelectionHighlightEnabled = false;
            this.questionTextBox.Size = new System.Drawing.Size(438, 76);
            this.questionTextBox.TabIndex = 0;
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 232);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.questionTypeTextBox);
            this.Controls.Add(this.playerTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.correctButton);
            this.Controls.Add(this.incorrectButton);
            this.Controls.Add(this.secondCorrectButton);
            this.Controls.Add(this.secondIncorrectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.questionTextBox);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Otázka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button secondIncorrectButton;
        private System.Windows.Forms.Button secondCorrectButton;
        private System.Windows.Forms.Button incorrectButton;
        private System.Windows.Forms.Button correctButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private ReadOnlyTextBox timeTextBox;
        private ReadOnlyTextBox questionTypeTextBox;
        private ReadOnlyTextBox playerTextBox;
        private System.Windows.Forms.Timer timer;
        private ReadOnlyTextBox questionTextBox;
        private ReadOnlyTextBox answerTextBox;
        private System.Windows.Forms.Button startButton;
    }
}