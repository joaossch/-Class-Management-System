using Repository;
using System.Data.SqlClient;

namespace Services
{
    public class Booking_ClassesServices
    {
        public string _connectionString;
        public Booking_ClassesRepository Repository;    

        public Booking_ClassesServices()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }

        public bool IsStudentAlreadyBooked(int studentId, int classId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Booking_Classes WHERE studentId = @studentId AND classId = @classId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@classId", classId);

                    try
                    {
                        connection.Open();

                        int count = (int)command.ExecuteScalar();


                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        return false;
                    }
                }
            }
        }

    }
}