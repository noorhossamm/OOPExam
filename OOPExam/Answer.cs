using System;
using System.Collections.Generic;
using System.Text;

namespace OOPExam
{
    internal class Answer
    {
        public string AnswerText { get; set; }
        public int AnswerId { get; set; }
        public Answer(int id , string text)
        {
            AnswerId = id;
            AnswerText = text;
        }
        override public string ToString()
        {
            return $"{AnswerId}.{AnswerText}";
        }
    }
}
