namespace OOPExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Math = new Subject(1, "Math");



            //Exam Details in general
            int ExamAnswer;
            bool IsValid;
            do
            {
                Console.WriteLine("Choose exam type:");
                Console.WriteLine("1 for Practical");
                Console.WriteLine("2 for Final");
                IsValid = int.TryParse(Console.ReadLine(), out ExamAnswer);

            } while (!IsValid || (ExamAnswer != 1 && ExamAnswer != 2));



            int ExamTime;
            do
            {
                Console.WriteLine("Enter time of exam (30-180) :");
                IsValid = int.TryParse(Console.ReadLine(), out ExamTime);

            } while (!IsValid || ExamTime < 30 || ExamTime>180);


            int ExamNumberQuestions;
            do
            {
                Console.WriteLine("Enter number of questions of exam: ");
                IsValid = int.TryParse(Console.ReadLine(), out ExamNumberQuestions);

            } while (!IsValid || ExamNumberQuestions <= 0);


            Console.Clear();

            //Practical Exam Creation

            if (ExamAnswer == 1)
            {
                Math.CreateExam(new PracticalExam(ExamTime, ExamNumberQuestions));
                McqQuestion[] mcq = new McqQuestion[ExamNumberQuestions];

                for (int i = 0; i < ExamNumberQuestions; i++)
                {
                    string header = $"Question { i + 1 }";
                    string body;
                    do
                    {
                        Console.WriteLine($"Enter the body of question {i + 1}: ");
                         body = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(body));

                    int marks;
                    do
                    {
                        Console.Write("Enter question marks: ");
                        IsValid = int.TryParse(Console.ReadLine(), out marks);

                    } while (!IsValid || marks <= 0);


                    mcq[i] = new McqQuestion(header, body, marks);
                    mcq[i].EnterAnswers();
                    Console.Clear();
                }

                Math.Exam.Questions = mcq;
            }


           // Final Exam Creation
            else
            {
                Math.CreateExam(new FinalExam(ExamTime, ExamNumberQuestions));
                int type; 
                for (int i = 0; i < ExamNumberQuestions; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"Enter details of question {i + 1}: ");
                    do
                    {
                        Console.WriteLine("Choose question type:");
                        Console.WriteLine("1 for MCQ");
                        Console.WriteLine("2 for True / False");
                        IsValid = int.TryParse(Console.ReadLine(), out type);
                    } while (!IsValid || (type != 1 && type != 2));

                    Console.Clear();

                    string header = $"Question {i + 1}";

                    string body;
                    do
                    {
                        Console.WriteLine($"Enter the body of question {i + 1}: ");
                        body = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(body));

                    int marks;
                    do
                    {
                        Console.Write("Enter question marks: ");
                        IsValid = int.TryParse(Console.ReadLine(), out marks);

                    } while (!IsValid || marks <= 0);


                    if (type == 1)
                    {
                        McqQuestion question =new McqQuestion(header, body, marks);
                        question.EnterAnswers();

                        Math.Exam.Questions[i] = question;

                    }
                    else
                    {
                        TF_Question question = new TF_Question(header, body, marks);

                        int correctAnswer;
                        do
                        {
                            Console.WriteLine("Enter correct answer:");

                            Console.WriteLine("1 for True");
                            Console.WriteLine("2 for False");
                            IsValid =int.TryParse(Console.ReadLine(), out correctAnswer);

                        } while (!IsValid || (correctAnswer != 1 && correctAnswer != 2));

                        Console.Clear();
                       question.SetCorrectAnswer(correctAnswer);

                        Math.Exam.Questions[i] = question;
                    }



                }

            }



            //Starting Exam

            Console.Clear();


            Console.WriteLine($"DO YOU WANT TO START THE EXAM of {Math.SubjectName} (yes/no):");
            string answer;
            do
            {
                answer = Console.ReadLine(); 
            }
            while(answer.ToLower() != "yes" && answer.ToLower() != "no");



            if(answer.ToLower() == "yes")
            {
                Math.Exam.DisplayExamQuestions();
                Math.Exam.ShowResults();
            }
            else
            {
                Console.WriteLine("Exam was not started.");
            }

        }
    }
}

