using Models;
using Repository;

namespace Services
{
    public class TeacherServices
    {
        public string _connectionString;

        public TeacherServices()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }


        public bool ValidateTeacher(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.FirstName))
            {
                Console.WriteLine("First name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(teacher.LastName))
            {
                Console.WriteLine("Last name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(teacher.Username))
            {
                Console.WriteLine("Username cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(teacher.Password))
            {
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            TeacherRepository repository = new TeacherRepository();
            bool userExists = repository.CheckifTeacherHaveUsername(teacher.Username);

            if (userExists)
            {
                Console.WriteLine("Username already exists. Please choose another one.");
                return false; 
            }

            return true;
        }















    }
}