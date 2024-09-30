using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        public string Name;
        public string Speciality;
        public string Group;

        public Student(string Name, string Speciality, string Group) { 
            this.Name = Name;
            this.Speciality = Speciality;
            this.Group = Group;
        }
    }
}
