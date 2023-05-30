//using Microsoft.EntityFrameworkCore;
//using DanceSchool.Data;
//using DanceSchool.Models;
//using DanceSchool.Repositories.IRepository;

//namespace DanceSchool.Repositories.Repository
//{
//    public class TrainerRepository : ITrainerRepository
//    {
//        private readonly DanceSchoolContext _context;

//        public TrainerRepository(DanceSchoolContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Trainer>> GetAllTrainersAsync()
//        {
//            return await _context.Trainers.ToListAsync();
//        }

//        public async Task<Trainer> GetTrainerByIdAsync(int trainerId)
//        {
//            return await _context.Trainers.FirstOrDefaultAsync(t => t.Id == trainerId);
//        }

//        public async Task AddTrainerAsync(Trainer trainer)
//        {
//            await _context.Trainers.AddAsync(trainer);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateTrainerAsync(Trainer trainer)
//        {
//            _context.Trainers.Update(trainer);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteTrainerAsync(int trainerId)
//        {
//            var trainer = await GetTrainerByIdAsync(trainerId);
//            if (trainer != null)
//            {
//                _context.Trainers.Remove(trainer);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<bool> TrainerExistsAsync(int trainerId)
//        {
//            return await _context.Trainers.AnyAsync(t => t.Id == trainerId);
//        }
//    }
//}