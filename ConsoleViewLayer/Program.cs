using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleViewLayer
{
    internal class Program
    {
        public static Logic logic = Logic.GetInstance();
       
        public static string message = @"

----------------------------------------------------
Функционал
1. Вывести студентов
2. Удалить студента
3. Создать студента                           
4. Обновить студента
5. 10 случайных студентов
6. Гистограмма

Введи команду:
";

        static void Main(string[] args)
        {
            Console.Write(message);
            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": ShowStudents(); break;
                    case "2": DeleteStudent(); break;
                    case "3": CreateStudent(); break;
                    case "4": UpdateStudent(); break;
                    case "5": CreateTenStudents(); break;
                    case "6": ShowHist();break;
                    default: Console.WriteLine("Такой команды нет"); break;
                }
                Console.Write(message);
            }
        }

        static void ShowStudents()
        {
            int count = 0;
            Dictionary<int, Dictionary<string, string>> students = logic.GetStudentsAsMap();
            foreach(int student in students.Keys)
            {
                Console.WriteLine($"{count++} | {students[student]["name"]} {students[student]["speciality"]} {students[student]["group"]}");
            }
        }

        static void CreateStudent()
        {

            Console.Write("Введи ФИО: ");
            string Name = Console.ReadLine();

            Console.Write("Введи специальность: ");
            string Speciality = Console.ReadLine();

            Console.Write("Введи группу: ");
            string Group = Console.ReadLine();
            Console.WriteLine();

            bool answer = logic.AddStudent(Name, Speciality, Group);
            if (!answer)
            {
                Console.WriteLine("Не удалось создать такого пользователя");
            }
            else
            {
                Console.WriteLine("Пользователь успешно создан");
            }
        }
        static void DeleteStudent()
        {
            Dictionary<int, Dictionary<string, string>> students = logic.GetStudentsAsMap();

            if (students.Count == 0) Console.WriteLine("Удалять некого");
            int index = 0;
            ShowStudents();
           
            int input = -1;
            bool isValid = false;
            while(!isValid)
            {
                Console.Write("Введи индекс студента, которого хочешь удалить: ");
                isValid = int.TryParse(Console.ReadLine(), out input);
            }
            bool answer = logic.RemoveStudent(input);
            if (answer)
            {
                Console.WriteLine("Студент удален");
                return;
            }
            Console.WriteLine("Такого студента нет в списке");
        }
        static void UpdateStudent()
        {
            Dictionary<int, Dictionary<string, string>> students = logic.GetStudentsAsMap();
            if (students.Count == 0) Console.WriteLine("Обновлять некого");
            int index = 0;
            ShowStudents() ;

            int input = -1;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Введи индекс студента, которого хочешь обновить: ");
                isValid = int.TryParse(Console.ReadLine(), out input);
            }

            Console.Write("Введи ФИО: ");
            string Name = Console.ReadLine();

            Console.Write("Введи специальность: ");
            string Speciality = Console.ReadLine();

            Console.Write("Введи группу: ");
            string Group = Console.ReadLine();
            Console.WriteLine();


            bool answer = logic.UpdateStudent(input, Name, Speciality, Group);
            if (answer)
            {
                Console.WriteLine("Студент обновлен");
                return;
            }
            Console.WriteLine("Ошибка");

        }

        static void CreateTenStudents()
        {
            logic.CreateRandomStudents(10);
            Console.WriteLine("Создано 10 случайных пользователей");
        }

        static void ShowHist()
        {
            var dict = logic.GetSpecialityMap();
            foreach(string key in dict.Keys)
            {
                string row = "";
                for (row = ""; row.Length < dict[key]; row += "█") { }
                Console.WriteLine($"{row} {key}");
            }
        }
    }
}
