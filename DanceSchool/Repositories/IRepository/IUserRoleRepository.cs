using DanceSchool.Entities;

namespace DanceSchool.Repositories.IRepository
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task AddRoleToUserAsync(User user, string roleName);
        Task RemoveRoleFromUserAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<IEnumerable<UserRole>> GetUserRolesForUserAsync(User user);

        Task<IEnumerable<UserRole>> GetAllUserRolesAsync();
        Task UpdateRolesForUser(User user, IEnumerable<string> roleNames);
        Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName);

        Task<UserRole> GetUserRoleByIdAsync(int id);
    }
}
