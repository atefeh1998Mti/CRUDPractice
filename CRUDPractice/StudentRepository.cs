using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPractice
{
    public class StudentRepository
    {
        private readonly string _connection;
        public StudentRepository(string connection)
        {
            _connection = connection;
        }
        public List<Student> GetAll()
        {

            string selectQuery = "select * from Student";

            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(_connection))
            using (SqlCommand cmd2 = new SqlCommand(selectQuery, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd2.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            name = reader["name"].ToString(),
                            family = reader["family"].ToString(),
                            age = Convert.ToInt32(reader["age"].ToString()),
                            mark = Convert.ToInt32(reader["mark"].ToString())

                        });

                    }
                }
            }
            return students;

        }


        public int delete(string name)
        {
            string deleteQuery = "delete from Student where name=@Deletename";

            using (SqlConnection conn = new SqlConnection(_connection))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Deletename", name);
                conn.Open();
                int rowAffacted = cmd.ExecuteNonQuery();
                return rowAffacted;
            }
        }

        public int update(string oldName, string NewName)
        {
            string updateQuery = "update student set name=@NewName where name=@oldName";
            using (SqlConnection conn = new SqlConnection(_connection))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@oldName", oldName);
                cmd.Parameters.AddWithValue("@NewName", NewName);
                conn.Open();
                int rowAffacted = cmd.ExecuteNonQuery();
                return rowAffacted;

            }

        }


        public int insert(Student s)
        {


            string Insertquery = "insert into Student(name,family,age,mark) values(@name,@family,@age,@mark)";
            using (SqlConnection conn = new SqlConnection(_connection))
            using (SqlCommand cmd = new SqlCommand(Insertquery, conn))
            {

                cmd.Parameters.AddWithValue("@name", s.name);
                cmd.Parameters.AddWithValue("@family", s.family);
                cmd.Parameters.AddWithValue("@age", s.age);
                cmd.Parameters.AddWithValue("@mark", s.mark);
                conn.Open();
                int rowAffacted = cmd.ExecuteNonQuery();
                return rowAffacted;
            }

        }





    }
}


