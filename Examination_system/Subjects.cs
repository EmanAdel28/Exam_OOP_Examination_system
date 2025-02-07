using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    enum TypeOfExam
    {
        Practical = 1, Final = 2
    }
    internal class Subjects
    {
        #region Properties
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        #endregion

        #region Constructor
        public Subjects(int id, string Name)
        {
            SubjectId = id;
            SubjectName = Name;
        }
        #endregion

        #region Function


        public void CreateExam()
        {
            TypeOfExam typeOfExam = GetExamType();
            int time = GetValidInteger("Please Enter The Time Of Exam in Minutes: ", minValue: 1);
            int numQuestions = GetValidInteger("Please Enter The Number Of Questions: ", minValue: 1);




            Exam = typeOfExam == TypeOfExam.Final ? Exam = new FinalExam(time, numQuestions) : new PracticalExam(time, numQuestions);
            Console.Clear();

            for (int i = 0; i < Exam.NumbersOfQuestion; i++)
            {
                Console.WriteLine($"Creating Question {i + 1}...");
                Exam.QuestionList.Add(CreateQuestion(typeOfExam));
                Console.Clear();
            }


        }

        private QuestionBase CreateQuestion(TypeOfExam typeOfExam)
        {
            if (typeOfExam == TypeOfExam.Final)
            {
                int questionType = GetValidInteger($"Choose Question Type  (1 for True|False, 2 for MCQ): ", 1, 2);


                string body = GetQuestionBody();
                int mark = GetValidInteger("Enter the mark of the question: ", 1);

                if (questionType == 1) // True/False Question
                {
                    int correctAnswer = GetValidInteger("Enter Correct Answer (1 for True, 2 for False): ", 1, 2);
                    return new TFQuestion("True | False Question", body, mark, correctAnswer);
                }
                else // MCQ (Single Choice)
                {
                    Answers choices = GetAnswerChoices();

                    int correctAnswer = GetValidInteger("Enter the correct choice number: ", 1, choices.ID.Length);


                    Console.WriteLine($"Correct Answer: {choices[correctAnswer]}");

                    return new MCQOneChoiseQuestion("Choose One Answer Question", body, mark, choices, correctAnswer);
                }
            }
            else // Practical Exam (Multiple Correct Answers)
            {
                Console.WriteLine("Choose The Correct Answer \n");
                string body = GetQuestionBody();
                int mark = GetValidInteger("Enter the mark of the question: ", 1);
                Answers choices = GetAnswerChoices();
                int correctCount = GetValidInteger("Enter the number of correct answers: ", 1, choices.ID.Length);
                int[] correctAnswers = new int[correctCount];

                for (int i = 0; i < correctCount; i++)
                {
                    correctAnswers[i] = GetValidInteger($"Enter correct choice {i + 1}: ", 1, choices.ID.Length);
                    Console.WriteLine($" {choices[correctAnswers[i]]}");
                }

                return new MultipleChoices("MCQ Question", body, mark, choices, correctAnswers);
            }
        }

        #endregion

        #region Helper Method

        private TypeOfExam GetExamType()
        {
            TypeOfExam typeOfExam;
            bool isValid;
            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create (1 for Practical and 2 for final):");
                isValid = Enum.TryParse(Console.ReadLine(), out typeOfExam) && (typeOfExam == TypeOfExam.Practical || typeOfExam == TypeOfExam.Final);
                if (!isValid) Console.WriteLine("Invalid choice! Please enter 1 or 2.");
            } while (!isValid);

            return typeOfExam;
        }

        private string GetQuestionBody()
        {
            Console.Write("Enter the question body: ");
            return Console.ReadLine();
        }

        private Answers GetAnswerChoices()
        {
            int numChoices = 3;
            string[] answerTexts = new string[numChoices];
            int[] answerIds = new int[numChoices];

            for (int i = 0; i < numChoices; i++)
            {
                string userInput;
                do
                {
                    Console.Write($"Enter choice {i + 1}: ");
                    userInput = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("Choice cannot be empty. Please enter a valid choice.");
                    }
                } while (string.IsNullOrWhiteSpace(userInput));

                answerIds[i] = i;
                answerTexts[i] = userInput;
            }

            return new Answers
            {
                ID = answerIds,
                AnswerText = answerTexts
            };
        }
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
