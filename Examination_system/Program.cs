using System.Diagnostics;

namespace Examination_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subjects subjects = new Subjects(1, "c#");
            subjects.CreateExam();
            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n)");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                subjects.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }

        }
    }
}
