using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class DataContext : DbContext
    {

    }
    public interface IDomainObject
    {
        int Id { get; set; }
    }

    public interface IRepository<T> where T : IDomainObject, new()
    {
        void Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);

        void Update(T obj);
        void Delete(T obj);
    }
}
