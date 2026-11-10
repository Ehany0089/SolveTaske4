using System;
using System.Collections.Generic;
using System.Text;


namespace SolveTaske4
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Choices { get; set; } = new List<string>();

        public List<int> CorrectAnswers { get; set; } = new List<int>();

        public override void Display()
        {
            base.Display();

            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }

            Console.WriteLine("Choose multiple answers (Example: 1,3)");
        }

        public override bool CheckAnswer(string answer)
        {
            var selected = answer.Split(',')
                .Select(x => x.Trim())
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToHashSet();

            return selected.SetEquals(CorrectAnswers);
        }
    }
}

