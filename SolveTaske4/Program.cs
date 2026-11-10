
namespace SolveTaske4
{
    internal class Program
    {
        static List<Question> QuestionBank = new List<Question>();

        static void Main(string[] args)
        {
            string choice;

            do
            {
                Console.WriteLine("main menu");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DoctorMode();
                        break;

                    case "2":
                        StudentMode();
                        break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != "3");
        }

        // Doctor Mode
        static void DoctorMode()
        {
            Console.Write("How many questions do you want to add? ");
            int count = ReadInt();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Add Question {i + 1}");
               
                Console.WriteLine("1_ True / False");
                Console.WriteLine("2_ Choose One");
                Console.WriteLine("3_ Multiple Choice");
                Console.WriteLine("Select Question Type: ");

                int type = ReadInt();

                if (type < 1 || type > 3)
                {
                    Console.WriteLine("Invalid Question Type!");
                    i--;
                    continue;
                }

                Console.WriteLine("Select Level:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                Console.Write("Choose Level: ");

                int level = ReadInt();

                if (level < 1 || level > 3)
                {
                    Console.WriteLine("Invalid Level!");
                    i--;
                    continue;
                }

                Console.Write("Question Header: ");
                string header = Console.ReadLine() ?? "";

                Console.Write("Marks: ");
                int marks = ReadInt();

                Question question;

                switch (type)
                {
                    case 1:

                        bool correct;

                        Console.Write("Correct Answer (true/false): ");

                        while (!bool.TryParse(
                            Console.ReadLine(), out correct))
                        {
                            Console.Write("Enter true or false: ");
                        }

                        question = new TrueFalseQuestion
                        {
                            CorrectAnswer = correct
                        };

                        break;

                    case 2:

                        ChooseOneQuestion choose =
                            new ChooseOneQuestion();

                        for (int j = 1; j <= 4; j++)
                        {
                            Console.Write($"Choice {j}: ");
                            choose.Choices.Add(
                                Console.ReadLine() ?? "");
                        }

                        Console.Write("Correct Choice Number: ");

                        choose.CorrectChoice = ReadInt();

                        question = choose;

                        break;

                    case 3:

                        MultipleChoiceQuestion multiple =
                            new MultipleChoiceQuestion();

                        for (int j = 1; j <= 4; j++)
                        {
                            Console.Write($"Choice {j}: ");
                            multiple.Choices.Add(
                                Console.ReadLine() ?? "");
                        }

                        Console.Write(
                            "Correct Answers (Example: 1,3): ");

                        multiple.CorrectAnswers =
                            (Console.ReadLine() ?? "")
                            .Split(',')
                            .Select(x => int.Parse(x.Trim()))
                            .ToList();

                        question = multiple;

                        break;

                    default:
                        continue;
                }

                question.Header = header;
                question.Marks = marks;
                question.Level = (QuestionLevel)(level - 1);

                QuestionBank.Add(question);

                Console.WriteLine("Question Added Successfully!");
            }
        }

        // Student Mode
        static void StudentMode()
        {
            if (QuestionBank.Count == 0)
            {
                Console.WriteLine("Question Bank is Empty!");
                return;
            }

            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1. Practical");
            Console.WriteLine("2. Final");
            Console.Write("Choose: ");

            int examType = ReadInt();

            if (examType != 1 && examType != 2)
            {
                Console.WriteLine("Invalid Exam Type!");
                return;
            }

            Console.WriteLine("Select Level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Choose: ");

            int level = ReadInt();

            if (level < 1 || level > 3)
            {
                Console.WriteLine("Invalid Level!");
                return;
            }

            QuestionLevel selectedLevel =
                (QuestionLevel)(level - 1);

            List<Question> selectedQuestions =
                QuestionBank
                .Where(q => q.Level == selectedLevel)
                .ToList();

            if (examType == 1)
            {
                selectedQuestions = selectedQuestions
                    .Take((selectedQuestions.Count + 1) / 2)
                    .ToList();
            }

            if (selectedQuestions.Count == 0)
            {
                Console.WriteLine("No Questions Found!");
                return;
            }

            Exam exam = new Exam
            {
                Questions = selectedQuestions
            };

            Console.WriteLine("Exam Started");

            exam.StartExam();
        }

        
        static int ReadInt()
        {
            int number;

            while (!int.TryParse(
                Console.ReadLine(), out number))
            {
                Console.Write("Enter a valid number: ");
            }

            return number;
        }
    }
}
