using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class QuestionBase
    {


        #region Properties
        public string HeaderOfTheQuestion { get; set; }
        public string BodyOfTheQuestion { get; set; }
        public int Mark { get; set; }
        public Answers AnswerList { get; set; }
        public int[] RightAnswer { get; set; }


        #endregion


        #region Constructor
        public QuestionBase(string header, string body, int mark, Answers answerList, int[] rightAnswer)
        {
            HeaderOfTheQuestion = header;
            BodyOfTheQuestion = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }
        #endregion

    }
}
