using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal abstract class Exam
    {


        #region Properties
        public int TimeOfExam { get; set; }

        public int? NumbersOfQuestion { get; set; }

        public List<QuestionBase> QuestionList { get; set; }

        protected Answers[] ArrOfAnswer;

        public int Score { get; set; }
        #endregion


        #region Constructor
        public Exam(int timeOfExam, int numbersOfQuestion)
        {
            TimeOfExam = timeOfExam;
            NumbersOfQuestion = numbersOfQuestion;
            QuestionList = new List<QuestionBase>();
            ArrOfAnswer = new Answers[numbersOfQuestion];
        }
        #endregion

        #region Function
        public abstract void ShowExam();

        #endregion

    }
}
