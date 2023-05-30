using DanceSchool.Repositories.IRepository;
using System;
using System.Threading.Tasks;

namespace DanceSchool.UOW
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IPairRepository PairRepository { get; }

        //ITrainerRepository TrainerRepository { get; }

        //ILessonRepository LessonRepository { get; }
        Task CommitAsync();


    }
}
