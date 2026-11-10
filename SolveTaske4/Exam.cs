using System;
using System.Collections.Generic;
using System.Text;

namespace SolveTaske4
{
    public class Exam
    {
        public List<Question> Questions { get; set; } = new List<Question>();

        public void StartExam()
        {
            int result = 0;
            int totalMarks = 0;

            foreach (Question question in Questions)
            {
              

                question.Display();

                Console.Write("Your Answer: ");
                string answer = Console.ReadLine() ?? "";

                totalMarks += question.Marks;

                if (question.CheckAnswer(answer))
                {
                    result += question.Marks;
                }
            }

         
            Console.WriteLine($"Your Result: {result} / {totalMarks}");
         
        }
    }
}
