using Models;
using Repository;

namespace Services
{
    public class ClassesService
    {
        public string _connectionString;
       
        public ClassesRepository _repository;

        public ClassesService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }



        public bool ValidateClass(Classes classes)
        {
           
            if (string.IsNullOrWhiteSpace(classes.ClassName))
            {
                Console.WriteLine("Class name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(classes.ClassRoom))
            {
                Console.WriteLine("Classroom cannot be empty.");
                return false;
            }

            if (classes.Capacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than 0.");
                return false;
            }

           
            if (classes.Time == DateTime.MinValue)
            {
                Console.WriteLine("Class time cannot be empty.");
                return false;
            }

            ClassesRepository repository = new ClassesRepository();
            bool classExists = repository.CheckIfClassNameExists(classes.ClassName);

            if (classExists)
            {
                Console.WriteLine("A class with this name already exists. Please choose a different name.");
                return false; 
            }

            
            return true;
        }





















    }
}