using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class PracticalExam : Exam
    {
        #region Constructor
        public PracticalExam(int timeOfExam, int numbersOfQuestion) : base(timeOfExam, numbersOfQuestion)
        {
        }
        #endregion

        #region Override - Function
        public override void ShowExam()
        {

            Console.Clear();


            for (int i = 0; i < QuestionList.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {QuestionList[i]}");
                Console.WriteLine("----------------------------------------------------");

                ArrOfAnswer[i] = new Answers();

                if (QuestionList[i] is MultipleChoices multiple)
                {
                    int correctCount = GetValidInteger("Enter the number of correct answers: ", 1, multiple.AnswerList.ID.Length);
                    int[] correctAnswers = new int[correctCount];

                    for (int k = 0; k < correctCount; k++)
                    {
                        correctAnswers[k] = GetValidInteger($"Enter correct choice {k + 1}: ", 1, multiple.AnswerList.ID.Length);
                    }

                    ArrOfAnswer[i].ID = correctAnswers;
                }

                Console.WriteLine("============================================================");
                Console.WriteLine("");
            }


            Console.Clear();


            Console.WriteLine("Practical Exam Results");
            for (int i = 0; i < QuestionList.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}) {QuestionList[i].BodyOfTheQuestion}");

                if (QuestionList[i] is MultipleChoices multiple)
                {
                    Console.WriteLine(multiple.ShowCorrectAnswer());
                }

                Console.WriteLine();
            }
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
                if (!isValid) Console.WriteLine($"Invalid input! Please enter a number between {minValue} and {maxValue}.");
            } while (!isValid);

            return value;
        }
        #endregion
    }
}
