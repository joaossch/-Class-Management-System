using Models;
using Repository;
using Services;

namespace AssemblySchool
{
    public class Program
    {
        static ClassesRepository classesRepository = new ClassesRepository();
        static StudentServices studentService = new StudentServices();

        static void Main(string[] args)
        {

            



            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Assembly School!");
                Console.WriteLine("1. Login as student");

                Console.WriteLine("2. Login as Teacher ");
                Console.WriteLine("3. Register into Assembly School");
                Console.WriteLine("4. Exit");
               

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        LoginStudent();

                        break;

                    case "2":
                        LoginTeacher();

                        break;
                    case "3":
                        RegisterStudent();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid Option!Try again.");
                        break;
                }
            }
        }









        public static void LoginStudent() 
        {
            Console.Clear();
            Console.WriteLine("Write your  username:");
            string username = Console.ReadLine();

            Console.WriteLine("Write your password:");
            string password = Console.ReadLine();


            StudentRepository repository = new StudentRepository();

            bool loginSuccess = repository.CheckStudentById(username, password);

            if (loginSuccess)
            {
                Console.WriteLine(" Login Valid ");
                StudentsMenus();
            }
            else
            {
                Console.WriteLine(" Password or User error");
            }


            Console.ReadLine();
        }





        public static void LoginTeacher() 
        {
            Console.Clear();
            Console.WriteLine(" Write your username");
            string username = Console.ReadLine();

            Console.WriteLine("Write your password");
            string password = Console.ReadLine();


            TeacherRepository repository = new TeacherRepository();

            bool loginSuccess = repository.CheckTeacherUser(username, password);
          
            if (loginSuccess)
            {

                Console.WriteLine("Usuário encontrado! Login bem-sucedido.");
                TeacherMenu();
            }
            else
            {
                Console.WriteLine("Usuário ou senha inválidos.");
            }


            Console.ReadLine();
        }












        public static void RegisterStudent()
        {
            Console.Clear();
            Console.WriteLine("Digite o Frist Name:");
            string fristName = Console.ReadLine();

            Console.WriteLine("Digite o Last  Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Digite o username:");

            string username = Console.ReadLine();

            Console.WriteLine("Digite a password:");
            string password = Console.ReadLine();

            StudentRepository repository = new StudentRepository();
            StudentServices studentServices = new StudentServices();

            bool userExists = repository.CheckifStudentHaveUsername(username);



            if (repository.CheckifStudentHaveUsername(username))
            {
                Console.WriteLine("Username already exists. Please choose another one.");
                return;
            }




            Student newStudent = new Student
            {
                FirstName = fristName,
                LastName = lastName,
                Username = username,
                Password = password
            };

            if (studentServices.ValidateStudent(newStudent))
            {


              

                Console.WriteLine("Student registered successfully!");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Failed to register the student. Please fix the errors and try again.");
                Console.ReadLine();

            }

            Console.ReadLine();



        }





        public static void RegisterTeacher()
        {
            Console.Clear();
            Console.WriteLine("Write the teacher information :");

            Console.WriteLine("Write the teacher frist name:");
            string fristName = Console.ReadLine();

            Console.WriteLine("Write the teacher last  name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Write the teacher ousername:");
            string username = Console.ReadLine();

            Console.WriteLine("Write the teacher  password:");
            string password = Console.ReadLine();

            Teacher newTeacher = new Teacher
            {
                FirstName = fristName,
                LastName = lastName,
                Username = username,
                Password = password,
            };

            TeacherRepository teacherRepository = new TeacherRepository();
            teacherRepository.InsertNewTeacher(newTeacher);

            Console.WriteLine(" Your register is sucesseful ");



        }


        public static void RegisterCLasses() 

        {
            Console.Clear();
            Console.WriteLine("Write the name of the class ");
            string className = Console.ReadLine();

            Console.WriteLine("Write the classroom number ");
            string classRoom = Console.ReadLine();

            Console.WriteLine("Write the capacity of the class");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the time that the class begins in this format (yyyy-MM-dd HH:mm");
            DateTime time = DateTime.Parse(Console.ReadLine());



            Classes classes = new Classes
            {

                ClassName = className,
                ClassRoom = classRoom,
                Capacity = capacity,
                Time = time,
            };

       

            ClassesService classesService = new ClassesService();

            if (classesService.ValidateClass(classes))
            {
                
                ClassesRepository classesRepository = new ClassesRepository();
                classesRepository.InsertClassesOri(classes);

                Console.WriteLine("Class registered successfully!");
            }
            else
            {
                Console.WriteLine("Failed to register class. Please fix the errors and try again.");
            }
        }














    

























       



        public static void TeacherMenu()
        {
            Console.Clear();

            Console.WriteLine("-------TEACHER MENU--------!");
            Console.WriteLine("1.Add a new teacher");
            Console.WriteLine("2. Add new class ");
            Console.WriteLine("3. Alter information of classes");
            Console.WriteLine("4. Shedule Class"); 
            Console.WriteLine("5. See all your boked classes"); 
            Console.WriteLine("5. Exit ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":


                    RegisterTeacher
                    ();

                    break;

                case "2":

                    RegisterCLasses
                    ();

                    break;
                case "3":

                    AlterClass
                    ();


                    break;


                case "4":
                    BookingTeacher();

                    //();
                    break;

                case "5":
                    GetTeacherBookedCLass();

                    break;

                case "6":
                    //exit = true;
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid Option!Try again.");
                    break;
            }


        }







        public static void StudentsMenus()
        {
            Console.Clear();

            Console.WriteLine("-------STUDENTS MENUS --------!");
            Console.WriteLine("1.Shedule Class");
            Console.WriteLine("2.See al the Classes Avaible");
            Console.WriteLine("3.See al my booked classes ");

            Console.WriteLine("3.EXIT ");



            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    BookingMenu();



                    break;

                case "2":
                    ShowAllClasses();


                    break;
                case "3":
                    GetStudentBookedClasses();



                    break;




                    
                    break;


                case "4":
                    
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid Option!Try again.");
                    break;
            }


        }


                public static void GetStudentBookedClasses()
        {

            StudentRepository studentRepository = new StudentRepository();


            string studentId = StudentUsernameToId(studentRepository);

            Console.WriteLine($"The student's ID is: {studentId}");

            int studentIdInt = int.Parse(studentId);


            Booking_ClassesRepository repository = new Booking_ClassesRepository();

            Console.Clear();
            repository.StudentsBookedClasses(studentIdInt);
        }




        public static void GetTeacherBookedCLass()
        {
            ;
            TeacherRepository r = new TeacherRepository();

            string teacherId = TeacherToId(r);





            Console.WriteLine($"The student's ID is: {teacherId}");

            int teacherInt = int.Parse(teacherId);


            Booking_ClassesRepository repository = new Booking_ClassesRepository();

            Console.Clear();
            repository.GetClassesByTeacher(teacherInt);
        }


































        static public void BookingMenu()
        {
            Console.Clear();

            Console.WriteLine("------Boking Menu--------");
            Console.WriteLine("Follow the steps to schedule a class for you");
            Console.WriteLine("This is the current Classes, that we have available");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue");
            ShowAllClasses();

            Console.WriteLine("Write the classs number that u wanna make a apointment "); 
            ClassesRepository classRepository1 = new ClassesRepository();
            int classId = ShowClassId(classRepository1);

            Console.WriteLine($"The class ID is: {classId}");



            
            StudentRepository studentRepository = new StudentRepository();
            string studentId = StudentUsernameToId(studentRepository);

            Console.WriteLine($"The student's ID is: {studentId}");


            int studentIdInt = int.Parse(studentId); 


            

            Booking_ClassesServices services = new Booking_ClassesServices();

            bool IsBooked = services.IsStudentAlreadyBooked(studentIdInt, classId);

            if (IsBooked)
            {
                Console.WriteLine("The student is already booked for this class.");
            }
            else
            {
                Console.WriteLine("The student is not booked for this class.");
            }






            Booking_ClassesRepository booking_ClassesRepository = new Booking_ClassesRepository();
            booking_ClassesRepository.InsertBookingClassStudent(studentIdInt, classId);

            Console.WriteLine("");
            Console.WriteLine("Your class is booked");




        }





        static public void BookingTeacher()
        {
            Console.Clear();

            Console.WriteLine("------Boking Menu--------");
            Console.WriteLine("Follow the steps to schedule a class for you");
            Console.WriteLine("This is the current Classes, that we have available");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue");
            ShowAllClasses();

            Console.WriteLine("Write the classs number that u wanna make a apointment "); 
            ClassesRepository classRepository1 = new ClassesRepository();
            int classId = ShowClassId(classRepository1);

            Console.WriteLine($"The class ID is: {classId}");








            
            TeacherRepository teacherRepository = new TeacherRepository();
            string teacherID = TeacherToId(teacherRepository);
            Console.WriteLine($"The teacher  id  is  {teacherID}");
            int teacherIDint = int.Parse(teacherID);

            

            Booking_ClassesRepository booking_ClassesRepository = new Booking_ClassesRepository();
            booking_ClassesRepository.UpdateTeacherForClass(classId, teacherIDint);

            Console.WriteLine("");
            Console.WriteLine("Your class is booked");




        }
















        static public void ShowAllClasses()
        {

            ClassesRepository repository = new ClassesRepository();
            repository.GetAllClasses3();
            Console.ReadLine();


        }
       



        static string StudentUsernameToId(StudentRepository studentRepository)
        {
            string id = null;

            while (true)
            {
                Console.WriteLine("Enter the username:");
                string username = Console.ReadLine();

                id = studentRepository.StudentUsernameToId(username);

                if (!string.IsNullOrEmpty(id))
                {
                    Console.WriteLine($"Your student's ID is: {id}");
                    break;
                }
                else
                {
                    Console.WriteLine("User not found, please try again.");
                }
            }

            return id;
        }

      


        public static int ShowClassId(ClassesRepository classRepository)
        {
            int classId = -1;
            while (true)
            {
                Console.WriteLine("Please enter the class ID:");

                string input = Console.ReadLine();


                if (int.TryParse(input, out classId))
                {

                    var result = classRepository.GetClassIdById(classId);


                    if (result != -1)
                    {
                        Console.WriteLine($"Class ID found: {result}");
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Class ID not found, please try again.");
                    }
                }
                else
                {

                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

     



        static string TeacherToId(TeacherRepository teacherRepository)
        {
            string id = null;

            while (true)
            {
                Console.WriteLine("Enter the username:");
                string username = Console.ReadLine();

                id = teacherRepository.TeacherUsernameToId(username);

                if (!string.IsNullOrEmpty(id))
                {
                    Console.WriteLine($"Your Teacher ID is: {id}");
                    break;
                }
                else
                {
                    Console.WriteLine("User not found, please try again.");
                }
            }

            return id;
        }
























        /// ALTER CLASS MENU 
        /// 

        public static void AlterClass()
        {
            Console.Clear();

            Console.WriteLine("This is all the available classes:");

            ShowAllClasses();

            Console.ReadLine();

            Console.WriteLine("\nWrite the ID of the class you want to change:");
            ClassesRepository classRepository1 = new ClassesRepository();
            int classId = ShowClassId(classRepository1);

            Console.WriteLine($"The class ID is: {classId}");




            Console.WriteLine("You have to alter all the information in the following order:");
            Console.WriteLine(" ");

            Console.WriteLine("Write the name of the class ");
            string className = Console.ReadLine();

            Console.WriteLine("Write the classroom number ");
            string classRoom = Console.ReadLine();

            Console.WriteLine("Write the capacity of the class");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the time that the class begins in this format (yyyy-MM-dd HH:mm)");
            DateTime time = DateTime.Parse(Console.ReadLine());



            Classes classes = new Classes
            {
                Id = classId,
                ClassName = className,
                ClassRoom = classRoom,
                Capacity = capacity,
                Time = time,
            };



            ClassesService classesService = new ClassesService();

            if (classesService.ValidateClass(classes))
            {
               

                ClassesRepository classesRepository2 = new ClassesRepository();
                classesRepository2.UpdateClasses(classes);

                Console.WriteLine("You have alter your Class :) ");

            }
            else
            {
                Console.WriteLine("Failed to register class. Please fix the errors and try again.");
            }
        







        }




























































    }
}















































































//       / / / / / / /  / / // / / /  Menu Schedule Class      / // / / / / / /



































//    Menu students
//1.Schedule class


//Menu Teacher
//1.Add new teacher
//1.Add new class
//3.Change class
//4.Shedule Class



















