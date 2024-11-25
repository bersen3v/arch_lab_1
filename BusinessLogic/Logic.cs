using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class Logic : ILogic
    {

        private IRepository<Student> Repo;

        private static Logic Instance;

        public static Logic GetInstance(IRepository<Student> repository) 
        {
            if(Instance == null)
            {
                Instance = new Logic(repository);
            }
            return Instance;
        }


       private Logic(IRepository<Student> repository)
        {
            Repo = repository;
            //var context = new StudentContext();
            //Repo = new EntityRepository<Student>(context);
            //Repo = new DapperRepository();
        }

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
                Student NewStudent = new Student()
                {
                    Name = Name,
                    Speciality = Speciality,
                    GroupName = Group,
                };
                
                Repo.Create(NewStudent);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод проверяет что индекс валиден и удаляет студента по индексу
        /// </summary>
        /// <param name="id">Индекс студента в списке</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        public bool RemoveStudent(int id)
        {
            Repo.Delete(id);
            return true;
        }

        /// <summary>
        /// Обновляет студента по заданному индексу. Проверяет изменились ли значения и не пустые ли они и изменяет, если пришли новые значения
        /// </summary>
        /// <param name="index">Индекс студента вв списке</param>
        /// <param name="Name">Имя студента</param>
        /// <param name="Speciality">Специальность студента</param>
        /// <param name="Group">Группа студента</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        public bool UpdateStudent(int id, string Name, string Speciality, string Group) 
        {
            bool NameIsValid = !string.IsNullOrEmpty(Name);
            bool SpecialitiIsValid = !string.IsNullOrEmpty(Speciality);
            bool GroupIsValid = !string.IsNullOrEmpty(Group);

            Console.WriteLine(Name);

            if (NameIsValid && SpecialitiIsValid && GroupIsValid)
            {
                foreach(Student student in Repo.ReadAll())
                {
                    if(student.Id == id) 
                    {
                        Console.WriteLine(student.Name);
                        Student NewStudent = new Student()
                        {
                            Id = student.Id,
                            Name = Name,
                            Speciality = Speciality,
                            GroupName = Group,
                        };
                        Repo.Update(NewStudent);
                        return true;
                    }
                }
                
            }
            return false;
        }

        
        /// <summary>
        /// Подготавливает словарь для гистограммы. Возвращает словар <строка, число>
        /// </summary>
        /// <returns>Возвращает словарь(string,int) в котором строка=специальность инт=количество студентов</returns>
        public Dictionary<string, int> GetSpecialityMap()
        {
            List<Student> Students = Repo.ReadAll();
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
            List<string> f = new List<string>() {"Oleg","Stepan","Nurbol","Ivan","Gerge" };
            List<string> n = new List<string>() {"Ivanov", "Stepanov","Ikitov", "Nikolaev", "Tupoy"};
            List<string> group = new List<string>() { "11", "12", "13","14" };
            List<string> speciality = new List<string> { "09.03.02", "09.03.03", "09.03.04"};
            for(; count > 0;  count--)
            {
                Repo.Create(new Student()
                {
                    Name = f[random.Next(0, f.Count)] + " " + n[random.Next(0, n.Count)],
                    Speciality = speciality[random.Next(0, speciality.Count)],
                    GroupName = group[random.Next(0, group.Count)]
                });
            }
        }

        /// <summary>
        /// Метод возвращает словарь для отображения студентов во вьюхе
        /// </summary>
        /// <returns>Врозвращает Dictionary<int, Dictionary<string, string>> в котором int=индекс студента, внутренний словарь = хранитель переменных </returns>
        public Dictionary<int, Dictionary<string, string>> GetStudentsAsMap()
        {
            List<Student> Students = Repo.ReadAll();
            Dictionary<int, Dictionary<string, string>> students = new Dictionary<int, Dictionary<string, string>>();
            for(int i = 0; i < Students.Count; i++)
            {
                students[Students[i].Id] = new Dictionary<string, string>();
                students[Students[i].Id]["id"] = Students[i].Id.ToString();
                students[Students[i].Id]["name"] = Students[i].Name;
                students[Students[i].Id]["speciality"] = Students[i].Speciality;
                students[Students[i].Id]["group"] = Students[i].GroupName;
            }
            return students;
        }

    }
}
