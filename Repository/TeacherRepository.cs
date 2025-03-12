using Models;
using System.Data.SqlClient;
namespace Repository
{
    public class TeacherRepository
    {
        private string _connectionString;
        public TeacherRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();





        }


        public void InsertNewTeacher(Teacher teacher)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Teacher (firstName, lastName, username, password) VALUES (@firstName, @lastName, @username, @password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@firstName", teacher.FirstName);
                    command.Parameters.AddWithValue("@lastName", teacher.LastName);
                    command.Parameters.AddWithValue("@username", teacher.Username);
                    command.Parameters.AddWithValue("@password", teacher.Password);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckTeacherUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT 1 FROM Teacher WHERE username = @username AND password = @password";

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




        public string TeacherUsernameToId(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id FROM Teacher WHERE username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    var result = command.ExecuteScalar();
                    return result?.ToString(); 
                }
            }
        }





        public bool CheckifTeacherHaveUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT 1 FROM Teacher WHERE username = @username";

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



