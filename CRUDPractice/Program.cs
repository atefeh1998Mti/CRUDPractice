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


                    while (true)
                    {
                        Console.WriteLine("\n=== Student Menu ===");
                        Console.WriteLine("1. Insert Student");
                        Console.WriteLine("2. Show All Students");
                        Console.WriteLine("3. Update Student Mark");
                        Console.WriteLine("4. Delete Student");
                        Console.WriteLine("5. Exit");
                        Console.Write("Choose an option: ");

                        int choise = Convert.ToInt32(Console.ReadLine());

                        switch (choise)
                        {
                            case 1:
                                insert(connection);
                                break;
                            case 2:
                                fetch(connection);
                                break;
                            case 3:
                                update(connection);
                                break;
                            case 4:
                                delete(connection);
                                break;


                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        static void delete(SqlConnection connection)
        {
            string deleteQuery = "delete from Student where name=@Deletename";

            Console.WriteLine("please enter your name");
            string Deletename = Console.ReadLine();

            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Deletename", Deletename);
                int rowAffacted = cmd.ExecuteNonQuery();
                Console.WriteLine($"RowAffected is {rowAffacted} rows delete successfully");
            }
        }

        static void insert(SqlConnection connection)
        {

            Console.WriteLine("please Enter Your name: ");
            string name = Console.ReadLine();


            Console.WriteLine("please Enter Your family: ");
            string family = Console.ReadLine();



            Console.WriteLine("please Enter Your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("please Enter Your Mark: ");
            int mark = Convert.ToInt32(Console.ReadLine());

            string Insertquery = "insert into Student(name,family,age,mark) values(@name,@family,@age,@mark)";
            using (SqlCommand cmd = new SqlCommand(Insertquery, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@family", family);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@mark", mark);
                int rowAffacted = cmd.ExecuteNonQuery();
                Console.WriteLine($"RowAffected is {rowAffacted} rows insert successfully");
            }

        }
        static void update(SqlConnection connection)
        {
            Console.WriteLine("please Enter Your name: ");
            string oldName = Console.ReadLine();


            Console.WriteLine("please Enter Your NewName: ");
            string NewName = Console.ReadLine();

            string updateQuery = "update student set name=@NewName where name=@oldName";
            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@oldName", oldName);
                cmd.Parameters.AddWithValue("@NewName", NewName);
                int rowAffacted = cmd.ExecuteNonQuery();
                Console.WriteLine($"RowAffected is {rowAffacted} rows update successfully");
            }
        }

        static void fetch(SqlConnection connection)
        {
            string selectQuery = "select * from Student";
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
}
