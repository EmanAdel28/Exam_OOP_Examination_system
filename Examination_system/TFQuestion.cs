using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class TFQuestion:QuestionBase
    {

        #region Constructor

        public TFQuestion(string header, string body, int mark, int rightAnswer)
            : base(header, body, mark, new Answers()
            {
                [1] = "True",
                [2] = "False"
            }, new int[] { rightAnswer })
        {
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return $"{HeaderOfTheQuestion} \n{BodyOfTheQuestion} ({Mark} marks) \nChoices:\n 1) True \n 2) False ";
        }




        #endregion
    }
}
