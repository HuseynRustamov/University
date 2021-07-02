using System;
using System.IO;
using System.Threading;
namespace Academy
{
    class Teacher
    {
        public string TeacherName { get; set; }
        public string TeacherExprience { get; set; }
        public Group[] groups { get; set; }
        public int CountGroup { get; set; }
        public static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(text);
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);
        }
        public void StartExam(string lesson_name, string group_name)
        {
            foreach (var gr in groups)
            {
                if (gr.GroupName == group_name)
                {
                    string fileName = "Exam.txt";
                    string path = Path.Combine(Environment.CurrentDirectory, fileName);
                    string txt1 = "Exam start ";
                    int count = 3;
                    while (count != 0)
                    {
                        WriteBlinkingText(txt1, 500, true);
                        WriteBlinkingText(txt1, 500, false);
                        count--;
                    }
                    foreach (var st in gr.students)
                    {
                        string txt2 = "Exam is lasted";
                        int count1 = 6;
                        while (count1 != 0)
                        {
                            WriteBlinkingText(txt2, 500, true);
                            WriteBlinkingText(txt2, 500, false);
                            count1--;
                        }

                        if (st.exam.score > 90)
                        {
                            Console.WriteLine($"{st.Name}  {st.Surname} ,Your score is {st.exam.score} A from {lesson_name} ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Congratulation");
                            Thread.Sleep(870);
                            File.AppendAllText(path, $" Name : { st.Name}, Surame : { st.Surname},  score is { st.exam.score }, {st.exam.ExamTime}\n");
                            Thread.Sleep(870);
                            Mail.SendMail(st.Email, $"Dear student {st.Name}", $"Dear student {st.Name} {st.Surname} your score is {st.exam.score}");
                        }
                        else if (st.exam.score > 80)
                        {
                            Console.WriteLine($"{st.Name}  {st.Surname} ,Your score is {st.exam.score} B from {lesson_name} on {st.exam.ExamTime}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Congratulation");
                            Thread.Sleep(870);

                            File.AppendAllText(path, $" Name : { st.Name}, Surame : { st.Surname},  score is { st.exam.score }, {st.exam.ExamTime}\n");
                            Thread.Sleep(870);
                            Mail.SendMail(st.Email, $"Dear student {st.Name}", $"Dear student {st.Name} {st.Surname}   your score is {st.exam.score}");
                        }
                        else if (st.exam.score > 70)
                        {
                            Console.WriteLine($"{st.Name}  {st.Surname} ,Your score is {st.exam.score} C from {lesson_name} on {st.exam.ExamTime}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Congratulation");
                            Thread.Sleep(870);
                            File.AppendAllText(path, $" Name : { st.Name}, Surame : { st.Surname},  score is { st.exam.score }, {st.exam.ExamTime}\n");
                            Thread.Sleep(870);
                            Mail.SendMail(st.Email, $"Dear student {st.Name}", $"Dear student {st.Name}   {st.Surname} your score is {st.exam.score}");
                        }
                        else if (st.exam.score > 60)
                        {
                            Console.WriteLine($"{st.Name}  {st.Surname} ,Your score is {st.exam.score} D from {lesson_name} on {st.exam.ExamTime}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Congratulation");
                            Thread.Sleep(870);
                            File.AppendAllText(path, $" Name : { st.Name}, Surame : { st.Surname},  score is { st.exam.score }, {st.exam.ExamTime}\n");
                            Thread.Sleep(870);
                            Mail.SendMail(st.Email, $"Dear student {st.Name}", $"Dear student {st.Name} {st.Surname} your score is {st.exam.score}");
                        }
                        else if (st.exam.score > 50)
                        {
                            Console.WriteLine($"{st.Name}  {st.Surname} ,Your score is {st.exam.score} E from {lesson_name} on {st.exam.ExamTime}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Congratulation");
                            Thread.Sleep(870);
                            File.AppendAllText(path, $" Name : { st.Name}, Surame : { st.Surname},  score is { st.exam.score }, {st.exam.ExamTime}\n");
                            Thread.Sleep(870);
                            Mail.SendMail(st.Email, $"Dear student {st.Name}", $"Dear student {st.Name}  {st.Surname} your score is {st.exam.score}");
                        }
                        else
                        {
                            Console.WriteLine($"{st.Name}  {st.Surname} ,Your score is {st.exam.score} F from {lesson_name} on {st.exam.ExamTime}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Sorry,You failed from {lesson_name} exam   ");
                            Thread.Sleep(870);
                            File.AppendAllText(path, $" Name : { st.Name}, Surname : { st.Surname},  score is { st.exam.score }, {st.exam.ExamTime}\n");
                            Thread.Sleep(870);
                            Mail.SendMail(st.Email, $"Dear student {st.Name}", $"Dear student {st.Name}  {st.Surname} your score is {st.exam.score} (F)  ");
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                    }

                }
            }
        }
        public void AddGruop(ref Group group)
        {
            var temp = new Group[++CountGroup];
            if (groups != null)
            {
                groups.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = group;
            groups = temp;
        }
        public void ShowTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======Teacher======");
            Console.WriteLine($"TeacherName :{TeacherName} ");
            Console.WriteLine($"TeacherExprience :{TeacherExprience} ");
            foreach (var Gp in groups)
            {
                Gp.ShowGroup();
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
