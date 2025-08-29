using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=TestDb;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully!");

                    Console.WriteLine("please Enter Your name: ");
                    string name = Console.ReadLine();


                    Console.WriteLine("please Enter Your family: ");
                    string family = Console.ReadLine();



                    Console.WriteLine("please Enter Your Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());


                    Console.WriteLine("please Enter Your Mark: ");
                    int mark = Convert.ToInt32(Console.ReadLine());



                    string Insertquery = "insert into Student(name,family,age,mark) values(@name,@family,@age,@mark)";
                    string selectQuery = "select * from Student";
                    string updateQuery = "update student set name=@NewName where name=@oldName";
                    string deleteQuery = "delete from Student where name=@Deletename";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Deletename", "mobina");
                        int rowAffacted = cmd.ExecuteNonQuery();
                        Console.WriteLine($"RowAffected is {rowAffacted} rows delete successfully");
                    }


                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@oldName", "mahdieh");
                        cmd.Parameters.AddWithValue("@NewName", "Mobina");
                        int rowAffacted = cmd.ExecuteNonQuery();
                        Console.WriteLine($"RowAffected is {rowAffacted} rows update successfully");
                    }

                    using (SqlCommand cmd = new SqlCommand(Insertquery, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@family", family);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@mark", mark);
                        int rowAffacted = cmd.ExecuteNonQuery();
                        Console.WriteLine($"RowAffected is {rowAffacted} rows insert successfully");
                    }



                    using (SqlCommand cmd2 = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = cmd2.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                                string Name = reader["name"].ToString();
                                string Family = reader["family"].ToString();
                                int Age = Convert.ToInt32(reader["age"].ToString());
                                int Mark = Convert.ToInt32(reader["mark"].ToString());


                                Console.WriteLine($"name: {Name}, family: {Family}, age: {Age}, mark: {Mark}");
                            }
                        }
                    }



                    Console.ReadKey();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
