using Models;
using Repository;

namespace Services
{
    public class StudentServices
    {
        public string _connectionString;
        public StudentRepository _repository;

        public StudentServices()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }


        public bool ValidateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName))
            {
                Console.WriteLine("First name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.LastName))
            {
                Console.WriteLine("Last name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.Username))
            {
                Console.WriteLine("Username cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.Password))
            {
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            StudentRepository repository = new StudentRepository();
            bool userExists = repository.CheckifStudentHaveUsername(student.Username);

            if (userExists)
            {
                Console.WriteLine("Username already exists. Please choose another one.");
                return false; 
            }

            return true;
        }
























    }















}









