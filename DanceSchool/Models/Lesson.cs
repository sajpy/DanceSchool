using System;
using DanceSchool.Entities;

namespace DanceSchool.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int DurationMinutes { get; set; }
        public string Type { get; set; } // individual or group
        public int TrainerId { get; set; }
        public int HallId { get; set; }
        public int? PairId { get; set; }
        public int? RecurringLessonId { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Pair Pair { get; set; }
    }

}
