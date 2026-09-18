using System;
using System.Collections.Generic;
using System.Text;

namespace OOPExam
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {}

        public override void DisplayExamQuestions()
        {
            Console.Clear();
            Console.WriteLine("-------Practical Exam Started-------");
            foreach (Question q in Questions)
            {
               
                q.DisplayQuestion();
                bool isValid;
                int userAnswer;
                do
                {
                    Console.WriteLine("Please enter your answer ID: ");
                    isValid = int.TryParse(Console.ReadLine(), out userAnswer);

                } while (!isValid);

                foreach (Answer a in q.Answers)
                {
                    if(a.AnswerId == userAnswer)
                    {
                        q.UserAnswer = a;
                        break;
                    }
                }
                    if(q.IsCorrectAnswer())
                    {
                        TotalMarks += q.Marks; 
                    }

            }
            Console.Clear();
        }

        public override void ShowResults()
        {
            Console.WriteLine("------Results of Practical Exam---------");
            foreach (Question q in Questions)
            {
                Console.WriteLine($"Your answer for question '{q.Header}': {q.UserAnswer}");
                Console.WriteLine($"Correct answer for question '{q.Header}': {q.CorrectAnswer}");

                Console.WriteLine();


            }
        }
    }
}
