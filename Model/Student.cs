using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : IDomainObject
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string GroupName { get; set; }
        
    }
}
