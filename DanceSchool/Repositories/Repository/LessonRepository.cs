//using Microsoft.EntityFrameworkCore;
//using DanceSchool.Data;
//using DanceSchool.Models;
//using DanceSchool.Repositories.IRepository;

//namespace DanceSchool.Repositories.Repository
//{
//    public class LessonRepository : ILessonRepository
//    {
//        private readonly DanceSchoolContext _context;

//        public LessonRepository(DanceSchoolContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
//        {
//            return await _context.Lessons.Include(l => l.Trainer)
//                .Include(l => l.Hall).ToListAsync();
//        }

//        public async Task<IEnumerable<Lesson>> GetLessonsByTrainerIdAsync(int trainerId)
//        {
//            return await _context.Lessons.Where(l => l.TrainerId == trainerId)
//                .Include(l => l.Trainer).Include(l => l.Hall).ToListAsync();
//        }

//        public async Task<IEnumerable<Lesson>> GetLessonsByHallIdAsync(int hallId)
//        {
//            return await _context.Lessons.Where(l => l.HallId == hallId)
//                .Include(l => l.Trainer).Include(l => l.Hall).ToListAsync();
//        }

//        public async Task<IEnumerable<Lesson>> GetLessonsByDateTimeAsync(DateTime dateTime)
//        {
//            return await _context.Lessons.Where(l => l.StartDateTime <= dateTime && l.EndDateTime >= dateTime)
//                .Include(l => l.Trainer).Include(l => l.Hall).ToListAsync();
//        }

//        public async Task<Lesson> GetLessonByIdAsync(int lessonId)
//        {
//            return await _context.Lessons.Include(l => l.Trainer)
//                .Include(l => l.Hall).FirstOrDefaultAsync(l => l.Id == lessonId);
//        }

//        public async Task AddLessonAsync(Lesson lesson)
//        {
//            await _context.Lessons.AddAsync(lesson);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateLessonAsync(Lesson lesson)
//        {
//            _context.Lessons.Update(lesson);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteLessonAsync(int lessonId)
//        {
//            var lesson = await GetLessonByIdAsync(lessonId);
//            if (lesson != null)
//            {
//                _context.Lessons.Remove(lesson);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<bool> LessonExistsAsync(int lessonId)
//        {
//            return await _context.Lessons.AnyAsync(l => l.Id == lessonId);
//        }

//        public async Task<IEnumerable<Lesson>> GetLessonsByRecurringLessonIdAsync(int recurringLessonId)
//        {
//            return await _context.Lessons.Where(l => l.RecurringLessonId == recurringLessonId)
//                .Include(l => l.Trainer).Include(l => l.Hall).ToListAsync();
//        }

//        public async Task<IEnumerable<Lesson>> GetLessonsByRecurringLessonIdAndWeekdayAsync(int recurringLessonId, DayOfWeek weekday)
//        {
//            return await _context.Lessons.Where(l => l.RecurringLessonId == recurringLessonId && l.StartDateTime.DayOfWeek == weekday)
//                .Include(l => l.Trainer).Include(l => l.Hall).ToListAsync();
//        }

//        public async Task AddRecurringLessonAsync(RecurringLesson recurringLesson)
//        {
//            await _context.RecurringLessons.AddAsync(recurringLesson);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateRecurringLessonAsync(RecurringLesson recurringLesson)
//        {
//            _context.RecurringLessons.Update(recurringLesson);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteRecurringLessonAsync(int recurringLessonId)
//        {
//            var recurringLesson = await _context.RecurringLessons.FindAsync(recurringLessonId);
//            if (recurringLesson == null)
//            {
//                throw new ArgumentException($"Recurring lesson with ID {recurringLessonId} not found.");
//            }

//            // Delete all associated lessons
//            var lessonsToDelete = await _context.Lessons.Where(l => l.RecurringLessonId == recurringLessonId).ToListAsync();
//            foreach (var lesson in lessonsToDelete)
//            {
//                _context.Lessons.Remove(lesson);
//            }

//            // Delete the recurring lesson
//            _context.RecurringLessons.Remove(recurringLesson);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<bool> RecurringLessonExistsAsync(int recurringLessonId)
//        {
//            return await _context.RecurringLessons.AnyAsync(x => x.Id == recurringLessonId);
//        }

//    }
//}
