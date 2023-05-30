using DanceSchool.Data;
using DanceSchool.Repositories.IRepository;
using DanceSchool.Repositories.Repository;
using System;
using System.Threading.Tasks;

namespace DanceSchool.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DanceSchoolContext _context;
        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IPairRepository PairRepository { get; }

        //public ITrainerRepository TrainerRepository { get; }

        //public ILessonRepository LessonRepository { get; }
        public UnitOfWork(DanceSchoolContext context,
            IUserRepository userRepository, IUserRoleRepository userRoleRepository, IPairRepository pairRepository)
        {
            _context = context;
            UserRepository = userRepository;
            UserRoleRepository = userRoleRepository;
            PairRepository = pairRepository;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
