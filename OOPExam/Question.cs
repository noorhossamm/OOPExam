using System;
using System.Collections.Generic;
using System.Text;

namespace OOPExam
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public Answer[] Answers { get; set;}
        public Answer CorrectAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        public Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
          
        }
        public abstract void DisplayQuestion();

        public bool IsCorrectAnswer()
        {
            return UserAnswer != null && CorrectAnswer != null && CorrectAnswer.AnswerId == UserAnswer.AnswerId;

        }
    }
}
