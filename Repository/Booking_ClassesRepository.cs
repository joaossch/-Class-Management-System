using System.Data.SqlClient;

namespace Repository
{
    public class Booking_ClassesRepository
    {
        private string _connectionString;

        public Booking_ClassesRepository()
        {

            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }





        public void InsertBookingClassStudent(int studentId, int classId)
        {
            string query = "INSERT INTO Booking_Classes (studentId, classId) VALUES (@studentId, @classId)";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@classId", classId);

                        
                        con.Open();
                        cmd.ExecuteNonQuery(); 
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
        }

        /// Teacher
        /// 



        public void UpdateTeacherForClass(int classId, int teacherId)
        {
            string query = @"
        UPDATE Booking_Classes
        SET teacherId = @teacherId
        WHERE classId = @classId;
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@classId", classId);
                        command.Parameters.AddWithValue("@teacherId", teacherId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Teacher assigned successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No classes avaible to make a apointment.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }






        public void StudentsBookedClasses(int studentId)
        {
            string query = @"
        SELECT 
            bc.classId, 
            c.ClassName, 
            s.firstName + ' ' + s.lastName AS StudentName, 
            bc.teacherId, 
            t.firstName + ' ' + t.lastName AS TeacherName
        FROM 
            Booking_Classes bc
        JOIN  
            Classes c ON bc.classId = c.Id
        JOIN 
            Students s ON bc.studentId = s.Id
        JOIN 
            Teacher t ON bc.teacherId = t.Id
        WHERE 
            bc.studentId = @studentID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@studentID", studentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("Classes for the student:");
                                while (reader.Read())
                                {
                                    string className = reader["ClassName"].ToString();
                                    string teacherName = reader["TeacherName"].ToString();
                                    string studentName = reader["StudentName"].ToString();

                                    Console.WriteLine($"Class Name: {className}, Teacher: {teacherName}, Student: {studentName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No classes found for this student.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public void GetClassesByTeacher(int teacherId)
        {
            string query = @"
        SELECT 
            bc.classId, 
            c.ClassName, 
            s.firstName + ' ' + s.lastName AS StudentName, 
            bc.teacherId, 
            t.firstName + ' ' + t.lastName AS TeacherName
        FROM 
            Booking_Classes bc
        JOIN  
            Classes c ON bc.classId = c.Id
        JOIN 
            Students s ON bc.studentId = s.Id
        JOIN 
            Teacher t ON bc.teacherId = t.Id
        WHERE 
            bc.teacherId = @teacherID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@teacherID", teacherId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("Classes assigned to the teacher:");
                                while (reader.Read())
                                {
                                    string className = reader["ClassName"].ToString();
                                    string teacherName = reader["TeacherName"].ToString();
                                    string studentName = reader["StudentName"].ToString();

                                    Console.WriteLine($"Class Name: {className}, Teacher: {teacherName}, Student: {studentName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No classes found for this teacher.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



      










    }
}
