using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {

        private readonly StudentContext context;


        public EntityRepository(StudentContext context) 
        {
            this.context = context;
        }


        public void Create(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = context.Set<T>().Find(id);
            if (student != null)
            {
                context.Set<T>().Remove(student);
                context.SaveChanges();
            }
        }

        public List<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            var foundUser = context.Set<T>().Find(id);
            return foundUser;
        }

        public void Update(T obj)
        {
            var foundUser = context.Set<T>().Find(obj.Id);
            if (foundUser != null)
            {
                context.Entry(foundUser).CurrentValues.SetValues(obj);
                context.SaveChanges();
            }
        }
    }
}
