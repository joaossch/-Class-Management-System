namespace Models
{
    public class Classes

    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string ClassRoom { get; set; }
        public int Capacity { get; set; }
        public DateTime Time { get; set; }




        public Classes() { }


        public Classes(int id, string className, string classRoom, int capacity, DateTime time)
        {

            Id = id;
            ClassName = className;
            ClassRoom = classRoom;
            Capacity = capacity;
            Time = time;
        }








    }
}
