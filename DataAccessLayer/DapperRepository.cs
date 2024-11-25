using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Text.RegularExpressions;


namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Student>
    {
        private string StudentsTable2 = "StudentsTable2";
        private string Name = "Name";
        private string Speciality = "Speciality";
        private string Group = "GroupName";
        private string Id = "Id";


        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\code\с#\arch_lab_1\DataAccessLayer\Database1.mdf;Integrated Security=True";

        public void Create(Student obj)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"INSERT INTO {StudentsTable2} ({Name}, {Speciality}, {Group}) VALUES (@{Name}, @{Speciality}, @{Group})", obj);

            }
        }

        public Student ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Student>($"SELECT * FROM {StudentsTable2} WHERE {Id} = @{Id}", new { Id = id }).FirstOrDefault();

            }
        }

        public List<Student> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Student>($"SELECT * FROM {StudentsTable2}").ToList();

            }
        }

        public void Update(Student obj)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"UPDATE {StudentsTable2} SET Name = @Name, Speciality = @Speciality, GroupName = @GroupName WHERE Id = @Id", obj);

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"DELETE FROM {StudentsTable2} WHERE {Id} = @{Id}", new { Id = id });

            }
        }
    }
}
