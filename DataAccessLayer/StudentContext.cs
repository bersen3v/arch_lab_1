using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> StudentsTable { get; set; }

        public StudentContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\code\с#\arch_lab_1\DataAccessLayer\Database1.mdf;Integrated Security=True")
        {
            Database.SetInitializer<StudentContext>(null);
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("StudentsTable2");
            base.OnModelCreating(modelBuilder);
        }
    }

}