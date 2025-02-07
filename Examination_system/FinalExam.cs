using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class FinalExam : Exam
    {


        #region Constructor
        public FinalExam(int timeOfExam, int numbersOfQuestion) : base(timeOfExam, numbersOfQuestion)
        {
        }
        #endregion

        #region Override - Function
        public override void ShowExam()
        {
            if (QuestionList is null || QuestionList.Count == 0)
            {
                Console.WriteLine("No questions available for this exam.");
                return;
            }

            int TotalMark = 0;
            Console.Clear();
            ArrOfAnswer = new Answers[QuestionList.Count];

            for (int i = 0; i < QuestionList.Count; i++)
            {
                Console.WriteLine(QuestionList[i]);
                Console.WriteLine("----------------------------------------------------");

                int userAnswer;
                TotalMark += QuestionList[i].Mark;

                ArrOfAnswer[i] = new Answers();

                if (QuestionList[i] is TFQuestion tfQuestion)
                {
                    userAnswer = GetValidInteger("Enter your answer ", 1, 2);
                    ArrOfAnswer[i][0] = userAnswer == 1 ? "True" : "False";

                    if (userAnswer == tfQuestion.RightAnswer[0])
                        Score += tfQuestion.Mark;
                }
                else if (QuestionList[i] is MCQOneChoiseQuestion mcq)
                {
                    userAnswer = GetValidInteger($"Enter your answer  ", 1, mcq.AnswerList.ID.Length);
                    ArrOfAnswer[i][0] = mcq.AnswerList[userAnswer - 1];

                    if (userAnswer == mcq.RightAnswer[0])
                        Score += mcq.Mark;
                }
                Console.WriteLine("============================================================\n");
            }

            Console.Clear();
            Console.WriteLine($"Your Answers ");

            for (int i = 0; i < QuestionList.Count; i++)
            {
                Console.WriteLine($"Q{i + 1}) {QuestionList[i].BodyOfTheQuestion} :{ArrOfAnswer[i][0] ?? "No Answer Provided"}");
                Console.WriteLine();
            }

            Console.WriteLine($"Your Exam Grade is : {Score} from {TotalMark}");
        }


        #endregion

        #region Helper Function
        private int GetValidInteger(string Message, int minValue = 0, int maxValue = int.MaxValue)
        {
            int value;
            bool isValid;
            do
            {
                Console.Write(Message);
                isValid = int.TryParse(Console.ReadLine(), out value) && value >= minValue && value <= maxValue;
                if (!isValid) Console.WriteLine($"Invalid Answer! Please enter Another Number.");
            } while (!isValid);

            return value;
        }

        #endregion


    }
}
