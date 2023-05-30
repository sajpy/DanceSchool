namespace DanceSchool.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User1 { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
