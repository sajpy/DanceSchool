using DanceSchool.DTO.User;
using DanceSchool.Entities;

namespace DanceSchool.Repositories.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    { 
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
    }
}
