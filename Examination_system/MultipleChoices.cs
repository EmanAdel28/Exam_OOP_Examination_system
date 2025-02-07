using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class MultipleChoices : QuestionBase
    {
        #region Constructor
        public MultipleChoices(string header, string body, int mark, Answers answerList, int[] rightAnswers)
           : base(header, body, mark, answerList, rightAnswers)
        {
        }
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder choicesString = new StringBuilder();

            for (int i = 0; i < AnswerList.ID.Length; i++)
            {
                choicesString.AppendLine($"{i + 1}) {AnswerList[AnswerList.ID[i]]}");
            }

            return $"{HeaderOfTheQuestion}\n{BodyOfTheQuestion} ({Mark} marks)\nChoices:\n{choicesString}";
        }
        #endregion

        #region Function
        public string ShowCorrectAnswer()
        {
            string correctAnswers = RightAnswer != null && RightAnswer.Length > 0
                ? string.Join(", ", RightAnswer.Select(id => AnswerList[id]))
                : "No correct answers specified";

            return $"Correct Answers: {correctAnswers}";
        }


        #endregion
    }
}
