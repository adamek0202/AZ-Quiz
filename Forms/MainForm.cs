using System;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class MainForm : Form
    {
        public static int PlayerOne_Points { get; private set; }
        public static int PlayerTwo_Points { get; private set; }

        private PublicDisplay pd;

        public MainForm()
        {
            InitializeComponent();
            gameBoard1.TileClicked += (index, tile) =>
            {
                int n = index + 1;
                var qf = new QuestionForm(n);
                qf.ShowDialog();
            };
            pd = new PublicDisplay();
            pd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameBoard1.Reset();
        }
    }
}
