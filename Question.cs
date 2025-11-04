using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal class Question
    {
        public string Text { get; }
        public string Answer { get; }
        public int SetID { get; }

        public Question(string text, string answer, int setID)
        {
            Text = text;
            Answer = answer;
            SetID = setID;
        }
    }
}
