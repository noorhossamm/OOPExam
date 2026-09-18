using System;
using System.Collections.Generic;
using System.Text;

namespace OOPExam
{
    internal class TF_Question : Question
    {
        public TF_Question(string header, string body, int marks) : base(header, body, marks)
        {
            Answers = new Answer[2];
            Answers[0] = new Answer(1, "true");
            Answers[1] = new Answer(2, "false");
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} - {Body} ({Marks} marks)");
            Console.WriteLine($"1.True\n2.False");

        }
        public void SetCorrectAnswer(int answerId)
        {
            CorrectAnswer = Answers[answerId - 1];
        }
    }
}
