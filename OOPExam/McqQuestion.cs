using System;
using System.Collections.Generic;
using System.Text;

namespace OOPExam
{
    internal class McqQuestion : Question
    {
        public McqQuestion(string header, string body, int marks ) : base(header, body, marks)
        {
            Answers = new Answer[4]; 
        }

        public void EnterAnswers()
        {
            for(int i = 0; i < 4; i++)
            {

                int id = i+1;
                string text;
                do
                {
                    Console.WriteLine($"Enter answer number {i + 1}");
                    text = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(text));
                Answers[i] = new Answer(id, text);
            }
            int correctAnswerId;
            bool isValid;
            do
            {
                Console.WriteLine($"Enter valid correct answer ID (1-4)");
                isValid = int.TryParse(Console.ReadLine(), out correctAnswerId);

            } while (!isValid || correctAnswerId < 1 || correctAnswerId > 4);
            CorrectAnswer = Answers[correctAnswerId-1];

        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} - {Body} ({Marks} marks)");
            foreach (Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
            
        }
    }
}
