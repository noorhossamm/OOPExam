using System;
using System.Collections.Generic;
using System.Text;

namespace OOPExam
{
    internal abstract class Exam
    {
        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
            TotalMarks = 0;
        }

        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public int TotalMarks { get; set; }
        public Question[] Questions { get; set; }
        public abstract void DisplayExamQuestions();
        public abstract void ShowResults();


    }
}
