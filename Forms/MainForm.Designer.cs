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
            this.gameBoard1 = new AZ_Kviz.GameBoard();
            this.SuspendLayout();
            // 
            // gameBoard1
            // 
            this.gameBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameBoard1.Location = new System.Drawing.Point(0, 0);
            this.gameBoard1.Name = "gameBoard1";
            this.gameBoard1.Size = new System.Drawing.Size(606, 530);
            this.gameBoard1.TabIndex = 0;
            this.gameBoard1.Text = "gameBoard1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 530);
            this.Controls.Add(this.gameBoard1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "AZ Kvíz";
            this.ResumeLayout(false);

        }

        #endregion

        private GameBoard gameBoard1;
    }
}

