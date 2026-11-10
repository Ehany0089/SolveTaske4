using System;
using System.Collections.Generic;
using System.Text;


namespace SolveTaske4
{
    public enum QuestionLevel
    {
        Easy,
        Medium,
        Hard
    }

    public class Question
    {
        public string Header { get; set; } = "";
        public int Marks { get; set; }
        public QuestionLevel Level { get; set; }

        public virtual void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Level: {Level}");
        }

        public virtual bool CheckAnswer(string answer)
        {
            return false;
        }
    }
}
