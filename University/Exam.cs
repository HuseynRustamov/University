using System;
namespace Academy
{
    class Exam
    {
        public string lesson { get; set; }
        public int score { get; set; }
        public DateTime ExamTime { get; set; }
        public void ShowExam()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________Exam_________");
            Console.WriteLine($"Lesson :{lesson} ");
            if (score > 90)
            {
                Console.WriteLine($"Score :{score}  A");
            }
            else if (score > 80)
            {
                Console.WriteLine($"Score :{score}  B");
            }
            else if (score > 70)
            {
                Console.WriteLine($"Score :{score}  C");
            }
            else if (score > 60)
            {
                Console.WriteLine($"Score :{score}  D");
            }
            else if (score > 50)
            {
                Console.WriteLine($"Score :{score}  E");
            }
            else if (score > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Score :{score}  F");
                Console.WriteLine("You failed the exam  ");
                Console.ResetColor();
            }
            else
            {
                throw new Exception("Score can not negative");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ExamTime :{ExamTime} ");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
