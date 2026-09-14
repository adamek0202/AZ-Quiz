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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.readOnlyTextBox2 = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.readOnlyTextBox1 = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.readOnlyTextBox3 = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.readOnlyTextBox4 = new AZ_Kviz.Components.ReadOnlyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.readOnlyTextBox2);
            this.groupBox1.Controls.Add(this.readOnlyTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hráč 1";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Špatné";
            // 
            // readOnlyTextBox2
            // 
            this.readOnlyTextBox2.BackColor = System.Drawing.Color.Red;
            this.readOnlyTextBox2.ForeColor = System.Drawing.Color.White;
            this.readOnlyTextBox2.Location = new System.Drawing.Point(98, 57);
            this.readOnlyTextBox2.Name = "readOnlyTextBox2";
            this.readOnlyTextBox2.SelectionHighlightEnabled = false;
            this.readOnlyTextBox2.Size = new System.Drawing.Size(40, 29);
            this.readOnlyTextBox2.TabIndex = 1;
            this.readOnlyTextBox2.Text = "0";
            // 
            // readOnlyTextBox1
            // 
            this.readOnlyTextBox1.BackColor = System.Drawing.Color.Lime;
            this.readOnlyTextBox1.Location = new System.Drawing.Point(98, 22);
            this.readOnlyTextBox1.Name = "readOnlyTextBox1";
            this.readOnlyTextBox1.SelectionHighlightEnabled = false;
            this.readOnlyTextBox1.Size = new System.Drawing.Size(40, 29);
            this.readOnlyTextBox1.TabIndex = 1;
            this.readOnlyTextBox1.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readOnlyTextBox3);
            this.groupBox2.Controls.Add(this.readOnlyTextBox4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(167, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hráč 2";
            // 
            // readOnlyTextBox3
            // 
            this.readOnlyTextBox3.BackColor = System.Drawing.Color.Red;
            this.readOnlyTextBox3.ForeColor = System.Drawing.Color.White;
            this.readOnlyTextBox3.Location = new System.Drawing.Point(98, 57);
            this.readOnlyTextBox3.Name = "readOnlyTextBox3";
            this.readOnlyTextBox3.SelectionHighlightEnabled = false;
            this.readOnlyTextBox3.Size = new System.Drawing.Size(40, 29);
            this.readOnlyTextBox3.TabIndex = 1;
            this.readOnlyTextBox3.Text = "0";
            // 
            // readOnlyTextBox4
            // 
            this.readOnlyTextBox4.BackColor = System.Drawing.Color.Lime;
            this.readOnlyTextBox4.Location = new System.Drawing.Point(98, 22);
            this.readOnlyTextBox4.Name = "readOnlyTextBox4";
            this.readOnlyTextBox4.SelectionHighlightEnabled = false;
            this.readOnlyTextBox4.Size = new System.Drawing.Size(40, 29);
            this.readOnlyTextBox4.TabIndex = 1;
            this.readOnlyTextBox4.Text = "0";
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(216, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ukončit";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(10, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Opakovat";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // ConclusionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 153);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConclusionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Výsledky hry";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Components.ReadOnlyTextBox readOnlyTextBox2;
        private Components.ReadOnlyTextBox readOnlyTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Components.ReadOnlyTextBox readOnlyTextBox3;
        private Components.ReadOnlyTextBox readOnlyTextBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}