namespace Repository
{
    public class BaseConfigurations
    {
        public string _connectionString { get; set; }

        public BaseConfigurations() { }
        public string GetDatabaseConnectionString()
        {
            _connectionString = _connectionString = "Data Source=JOÃO\\SQLEXPRESS;Initial Catalog=AssemblyProject;Integrated Security=true";
            ;
            return _connectionString;

        }










    }
}
