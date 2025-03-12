namespace Models
{
    public class Teacher : Person
    {


        public Teacher() { }

        public Teacher(int id, string firstName, string lastName, string username, string password)
          : base(id, firstName, lastName, username, password)
        {

        }

    }
}
