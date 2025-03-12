namespace Models
{
    public class Booking_Classes
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }


        public Booking_Classes() { }


        public Booking_Classes(int id, int studentId, int classId, int teacherId)
        {
            Id = id;
            StudentId = studentId;
            ClassId = classId;
            TeacherId = teacherId;


        }




    }

}
