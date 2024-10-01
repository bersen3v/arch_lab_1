using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic
{
    public class Logic
    {
        private static Logic Instance;
        public static Logic GetInstance() 
        {
            if(Instance == null)
            {
                Instance = new Logic();
            }
            return Instance;
        }


       private Logic()
        {
            Students = new List<Student>();
        }

        public List<Student> Students { get; private set; }

        /// <summary>
        /// Метод проверяет строки на валидность и добавляет студента с список
        /// </summary>
        /// <param name="Name">ФИО студента</param>
        /// <param name="Speciality">Специальность</param>
        /// <param name="Group">Группа</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        public bool AddStudent(string Name, string Speciality, string Group)
        {
            bool NameIsValid = !string.IsNullOrEmpty(Name);
            bool SpecialitiIsValid = !string.IsNullOrEmpty(Speciality);
            bool GroupIsValid = !string.IsNullOrEmpty(Group);

            if (NameIsValid && SpecialitiIsValid && GroupIsValid)
            {
                Student NewStudent = new Student(Name, Speciality, Group);
                Students.Add(NewStudent);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод проверяет что индекс валиден и удаляет студента по индексу
        /// </summary>
        /// <param name="index">Индекс студента в списке</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        public bool RemoveStudent(int index)
        {
            if(Students.Count>0 && index <Students.Count && index >=0)
            {
                Students.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Обновляет студента по заданному индексу. Проверяет изменились ли значения и не пустые ли они и изменяет, если пришли новые значения
        /// </summary>
        /// <param name="index">Индекс студента вв списке</param>
        /// <param name="Name">Имя студента</param>
        /// <param name="Speciality">Специальность студента</param>
        /// <param name="Group">Группа студента</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        public bool UpdateStudent(int index, string Name, string Speciality, string Group) 
        {
            bool accept = true;
            if (index >= Students.Count || index < 0) return false;
            if (Students.Count <= 0) return false;

            if (Students[index].Name != Name && !string.IsNullOrEmpty(Name))
            {
                Students[index].Name = Name;
            }
            else
            {
                accept = false;
            }

            if (Students[index].Speciality != Name && !string.IsNullOrEmpty(Speciality))
            {
                Students[index].Speciality = Speciality;
            }
            else
            {
                accept = false;
            }
            if (Students[index].Group != Name && !string.IsNullOrEmpty(Group))
            {
                Students[index].Group = Group;
            }
            else
            {
                accept = false;
            }

            if (accept) return true;
             
            return false;

        }

        
        /// <summary>
        /// Подготавливает словарь для гистограммы. Возвращает словар <строка, число>
        /// </summary>
        /// <returns>Возвращает словарь(string,int) в котором строка=специальность инт=количество студентов</returns>
        public Dictionary<string, int> GetSpecialityMap()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Student student in Students)
            {
                if (!dict.ContainsKey(student.Speciality)) dict[student.Speciality] = 0;
                dict[student.Speciality]++;
            }

            return dict;
        }

        /// <summary>
        /// Создает рандомных студентов, по количеству равных count
        /// </summary>
        /// <param name="count">Количество студентов, которое необходимо создать</param>
        public void CreateRandomStudents(int count) 
        {
            Random random = new Random();
            List<string> f = new List<string>() {"Олег","Степан","Нурбол","Иван","Георгий" };
            List<string> n = new List<string>() {"Иванов", "Степанов","Икитов", "Николаев", "Тупой"};
            List<string> group = new List<string>() { "11", "12", "13","14" };
            List<string> speciality = new List<string> { "09.03.02", "09.03.03", "09.03.04"};
            for(; count > 0;  count--)
            {
                Students.Add(new Student(
                    Name: f[random.Next(0,f.Count)] +" "+ n[random.Next(0,n.Count)], 
                    Speciality: speciality[random.Next(0,speciality.Count)], 
                    Group: group[random.Next(0,group.Count)]
                    ));
            }
        }

        /// <summary>
        /// Метод возвращает словарь для отображения студентов во вьюхе
        /// </summary>
        /// <returns>Врозвращает Dictionary<int, Dictionary<string, string>> в котором int=индекс студента, внутренний словарь = хранитель переменных </returns>
        public Dictionary<int, Dictionary<string, string>> GetStudentsAsMap()
        {
            Dictionary<int, Dictionary<string, string>> students = new Dictionary<int, Dictionary<string, string>>();
            for(int i = 0; i < Students.Count; i++)
            {
                students[i] = new Dictionary<string, string>();
                students[i]["name"] = Students[i].Name;
                students[i]["speciality"] = Students[i].Speciality;
                students[i]["group"] = Students[i].Group;
            }
            return students;
        }

    }
}
