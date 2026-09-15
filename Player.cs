using System.Drawing;

namespace AZ_Kviz
{
    internal class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Correct { get; set; }
        public int Incorrect { get; set; }
        public int Points => Correct + Incorrect;

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public void Reset()
        {
            Correct = 0;
            Incorrect = 0;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "Anonymní hráč" : Name;
        }
    }
}