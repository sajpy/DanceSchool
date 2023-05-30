//using DanceSchool.Models;

//namespace DanceSchool.Repositories.IRepository
//{
//    public interface ILessonRepository
//    {
//        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
//        Task<IEnumerable<Lesson>> GetLessonsByTrainerIdAsync(int trainerId);
//        Task<IEnumerable<Lesson>> GetLessonsByHallIdAsync(int hallId);
//        Task<IEnumerable<Lesson>> GetLessonsByDateTimeAsync(DateTime dateTime);
//        Task<Lesson> GetLessonByIdAsync(int lessonId);
//        Task AddLessonAsync(Lesson lesson);
//        Task UpdateLessonAsync(Lesson lesson);
//        Task DeleteLessonAsync(int lessonId);
//        Task<bool> LessonExistsAsync(int lessonId);
//        Task<IEnumerable<Lesson>> GetLessonsByRecurringLessonIdAsync(int recurringLessonId);
//        Task<IEnumerable<Lesson>> GetLessonsByRecurringLessonIdAndWeekdayAsync(int recurringLessonId, DayOfWeek weekday);
//        Task AddRecurringLessonAsync(RecurringLesson recurringLesson);
//        Task UpdateRecurringLessonAsync(RecurringLesson recurringLesson);
//        Task DeleteRecurringLessonAsync(int recurringLessonId);
//        Task<bool> RecurringLessonExistsAsync(int recurringLessonId);
//    }

//}
