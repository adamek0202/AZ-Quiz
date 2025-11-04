using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    internal class QuestionsSet
    {
        public int Id { get; }
        public string Name { get; }
        public string Scope { get; }
        public string Author { get; }
        public string Dufficulty { get; }

        public QuestionsSet(int id, string name, string scope, string author, string dufficulty)
        {
            Id = id;
            Name = name;
            Scope = scope;
            Author = author;
            Dufficulty = dufficulty;
        }
    }
}
