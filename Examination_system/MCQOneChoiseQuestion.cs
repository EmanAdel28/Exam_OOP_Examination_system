using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class MCQOneChoiseQuestion: QuestionBase
    {

        #region Constructor
        public MCQOneChoiseQuestion(string header, string body, int mark, Answers answerList, int rightAnswer)
        : base(header, body, mark, answerList, new int[] { rightAnswer })
        {
        }
        #endregion

        #region Override
        public override string ToString()
        {
            if (AnswerList.ID == null || AnswerList.ID.Length == 0)
            {
                return $"{HeaderOfTheQuestion}\n{BodyOfTheQuestion} ({Mark} marks)\nNo choices available.";
            }

            StringBuilder choicesString = new StringBuilder();

            for (int i = 0; i < AnswerList.ID.Length; i++)
            {
                choicesString.AppendLine($"{i + 1}) {AnswerList[i]}");
            }

            return $"{HeaderOfTheQuestion}\n{BodyOfTheQuestion} ({Mark} marks)\nChoices:\n{choicesString}";
        }




        #endregion
    }
}
