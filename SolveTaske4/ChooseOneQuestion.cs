using System;
using System.Collections.Generic;
using System.Text;


namespace SolveTaske4
{
    public class ChooseOneQuestion : Question
    {
        public List<string> Choices { get; set; } = new List<string>();

        public int CorrectChoice { get; set; }

        public override void Display()
        {
            base.Display();

            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            return int.TryParse(answer, out int result)
                && result == CorrectChoice;
        }
    }
}

