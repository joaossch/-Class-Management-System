using Models;
using System.Data.SqlClient;

namespace Repository
{
    public class ClassesRepository
    {
        public string _connectionString;

        public ClassesRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }







        public int GetClassIdById(int classID)
        {
            string query = "SELECT id FROM Classes WHERE id = @classID";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);

                        con.Open();
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }

            return -1;
        }



        public void UpdateClasses(Classes classes)
        {
            string query = @"UPDATE Classes 
                     SET ClassName = @ClassName, 
                         ClassRoom = @ClassRoom, 
                         Capacity = @Capacity, 
                         Time = @Time 
                     WHERE Id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.Add(new SqlParameter("@Id", classes.Id));
                        command.Parameters.Add(new SqlParameter("@ClassName", classes.ClassName));
                        command.Parameters.Add(new SqlParameter("@ClassRoom", classes.ClassRoom));
                        command.Parameters.Add(new SqlParameter("@Capacity", classes.Capacity));
                        command.Parameters.Add(new SqlParameter("@Time", classes.Time));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Class updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("No class found with the given ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }





























        public void InsertClass(string className, string classRoom, int capacity, DateTime time)
        {
            string query = "INSERT INTO Classes (className, classRoom, capacity, time) VALUES (@className, @classRoom, @capacity, @time)";


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@className", className);
                    cmd.Parameters.AddWithValue("@classRoom", classRoom);
                    cmd.Parameters.AddWithValue("@capacity", capacity);
                    cmd.Parameters.AddWithValue("@time", time);

                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void AlterClassInformation(int classId, Classes updatedClass)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Classes SET className = @className, classRoom = @classRoom, capacity = @capacity, time = @time WHERE classId = @classId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@className", updatedClass.ClassName);
                    command.Parameters.AddWithValue("@classRoom", updatedClass.ClassRoom);
                    command.Parameters.AddWithValue("@capacity", updatedClass.Capacity);
                    command.Parameters.AddWithValue("@time", updatedClass.Time);
                    command.Parameters.AddWithValue("@classId", classId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertClassesOri(Classes classObj)
        {
            string query = "INSERT INTO Classes (className, classRoom, capacity, time) VALUES (@className, @classRoom, @capacity, @time)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@className", classObj.ClassName);
                    cmd.Parameters.AddWithValue("@classRoom", classObj.ClassRoom);
                    cmd.Parameters.AddWithValue("@capacity", classObj.Capacity);
                    cmd.Parameters.AddWithValue("@time", classObj.Time);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }








        public void GetAllClasses3()
        {
            string query = "SELECT * FROM Classes";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine(" The classes is not avaible in the moment.");
                                return;
                            }

                            Console.WriteLine("----------------------CLASSES ----------------------------------");
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string className = reader.GetString(1);
                                string classRoom = reader.GetString(2);
                                int capacity = reader.GetInt32(3);
                                DateTime time = reader.GetDateTime(4);

                                Console.WriteLine($"| ID: {id} | Class Name: {className} | Class Room: {classRoom} | Capacity: {capacity} | Class Time: {time:yyyy-MM-dd HH:mm} |");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" SQL ERROR {ex.Message}");
            }
        }



        ///// Boking Class
        ///




        /// insert in boking  where classid is @classid, 


        /// insert in boking classes where student id is @student id 

        /// write your username. admin, 

        // querry que vai na tabela students onde o username is @username e me da o id desse user name 





        public bool CheckIfClassNameExists(string className)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT 1 FROM Classes WHERE className = @className";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@className", className);

                    try
                    {
                        connection.Open(); 

                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                           
                            return reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                      
                        return false;
                    }
                }
            }
        }

















    }
}











