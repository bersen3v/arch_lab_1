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

        Logic()
        {
            Students = new List<Student>();
        }

        public List<Student> Students { get; private set; }


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

        public bool RemoveStudent(int index)
        {
            if(Students.Count>0 && index <Students.Count && index >=0)
            {
                Students.RemoveAt(index);
                return true;
            }
            return false;
        }

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

    }
}
