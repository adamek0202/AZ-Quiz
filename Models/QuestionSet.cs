namespace AZ_Kviz.Models
{
    internal class QuestionSet
    {
        public uint Id { get; }
        public string Name { get; }
        public string Scope { get; }
        public uint Difficulty { get; }

        public QuestionSet(uint id, string name, string scope, uint difficulty)
        {
            Id = id;
            Name = name;
            Scope = scope;
            Difficulty = difficulty;
        }

        public override string ToString() => Name;
    }
}