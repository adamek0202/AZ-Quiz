namespace AZ_Kviz.Forms
{
    partial class QuestionSetParamsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.scopeTextBox = new System.Windows.Forms.TextBox();
            this.difficultyNumeric = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Obor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Obtížnost";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(72, 7);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(241, 23);
            this.nameTextBox.TabIndex = 1;
            // 
            // scopeTextBox
            // 
            this.scopeTextBox.Location = new System.Drawing.Point(72, 37);
            this.scopeTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scopeTextBox.Name = "scopeTextBox";
            this.scopeTextBox.Size = new System.Drawing.Size(241, 23);
            this.scopeTextBox.TabIndex = 2;
            // 
            // difficultyNumeric
            // 
            this.difficultyNumeric.Location = new System.Drawing.Point(72, 67);
            this.difficultyNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.difficultyNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.difficultyNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.difficultyNumeric.Name = "difficultyNumeric";
            this.difficultyNumeric.Size = new System.Drawing.Size(61, 23);
            this.difficultyNumeric.TabIndex = 3;
            this.difficultyNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(234, 66);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(79, 27);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(141, 66);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 27);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Storno";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // QuestionSetParamsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(323, 102);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.difficultyNumeric);
            this.Controls.Add(this.scopeTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionSetParamsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Vlastnosti sady otázek";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox scopeTextBox;
        private System.Windows.Forms.NumericUpDown difficultyNumeric;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}