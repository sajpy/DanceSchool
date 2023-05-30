//namespace DanceSchool.Models
//{
//    public class RecurringLesson
//    {
//        public int Id { get; set; }
//        public int TrainerId { get; set; }
//        public int HallId { get; set; }
//        public DateTime StartDateTime { get; set; }
//        public DateTime EndDateTime { get; set; }
//        public int DurationMinutes { get; set; }
//        public string Type { get; set; } // individual or group
//        public DayOfWeek Weekday { get; set; }
//        public RecurrenceFrequency Frequency { get; set; } // daily, weekly, monthly, yearly
//        public int? EndAfterNumberOfOccurrences { get; set; } // null if recurring indefinitely
//        public DateTime? EndDate { get; set; } // null if recurring indefinitely
//        public ICollection<Lesson> Lessons { get; set; }
//    }

//    public enum RecurrenceFrequency
//    {
//        Daily,
//        Weekly,
//        Monthly,
//        Yearly
//    }

//}
