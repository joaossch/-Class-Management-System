using Models;
using System.Data;
using System.Data.SqlClient;


namespace Repository


{
    public class StudentRepository
    {
        public string _connectionString;
        public StudentRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();


        }

        //public void InsertNewStudent(Student user)
       






        public bool CheckStudentById(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT 1 FROM Students WHERE username = @username AND password = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

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




        public Student GetByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id, firstName, lastName, username, password FROM Students WHERE username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Username = reader.GetString(3),
                                Password = reader.GetString(4)
                            };
                        }
                    }
                }
            }

            return null; 
        }






        public string StudentUsernameToId(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id FROM Students WHERE username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    var result = command.ExecuteScalar();
                    return result?.ToString(); // Converte o resultado para string, ou retorna null
                }
            }
        }






        public bool CheckStudentExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM Students WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    bool exists = (int)command.ExecuteScalar() > 0;
                    Console.WriteLine($"Checking username '{username}': Exists? {exists}"); // Verifique o valor aqui
                    return exists;
                }
            }
        }





        public bool CheckifStudentHaveUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT 1 FROM Students WHERE username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

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
