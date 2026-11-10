using System;
using System.Collections.Generic;
using System.Text;



namespace SolveTaske4
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public override void Display()
        {
            base.Display();

            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }

        public override bool CheckAnswer(string answer)
        {
            if (!int.TryParse(answer, out int result))
            {
                return false;
            }

            if (result == 1 && CorrectAnswer == true)
            {
                return true;
            }

            if (result == 2 && CorrectAnswer == false)
            {
                return true;
            }

            return false;
        }
    }
}

