namespace AZ_Kviz.Models
{
    internal class Question
    {
        public string Text { get; }
        public string Answer { get; }
        public uint Id { get; }

        public Question(string text, string answer, uint id)
        {
            Text = text;
            Answer = answer;
            Id = id;
        }
    }
}
