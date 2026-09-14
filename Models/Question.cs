namespace AZ_Kviz.Models
{
    internal class Question
    {
        public string Text { get; }
        public string Answer { get; }
        public uint SetID { get; }

        public Question(string text, string answer, uint setID)
        {
            Text = text;
            Answer = answer;
            SetID = setID;
        }
    }
}
