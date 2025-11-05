using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    public partial class QuestionForm : Form
    {
        private int ID;
        public QuestionForm(int id)
        {
            InitializeComponent();
            ID = id;
            Text = $"Otázka číslo {id}";
        }
    }
}
