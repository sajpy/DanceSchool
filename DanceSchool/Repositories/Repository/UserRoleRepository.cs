using Microsoft.EntityFrameworkCore;
using DanceSchool.Data;
using DanceSchool.Entities;
using DanceSchool.Repositories.IRepository;

namespace DanceSchool.Repositories.Repository
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DanceSchoolContext context) : base(context)
        {
        }

        public async Task AddRoleToUserAsync(User user, string roleName)
        {
            var role = await Context.Roles.SingleOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                throw new ArgumentException($"Role {roleName} does not exist.");
            }

            var userRole = new UserRole { User = user, Role = role };
            await Context.UserRoles.AddAsync(userRole);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRoleFromUserAsync(User user, string roleName)
        {
            var role = await Context.Roles.SingleOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                throw new ArgumentException($"Role {roleName} does not exist.");
            }
            var userRole = await Context.UserRoles.SingleOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id);
            if (userRole == null)
            {
                throw new ArgumentException($"User {user.Email} does not have role {roleName}.");
            }
            Context.UserRoles.Remove(userRole);
            await Context.SaveChangesAsync();
        }


        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await Context.UserRoles
                .AnyAsync(ur => ur.UserId == user.Id && ur.Role.RoleName == roleName);
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesForUserAsync(User user)
        {
            return await Context.UserRoles.Where(ur => ur.UserId == user.Id).ToListAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRolesAsync()
        {
            return await Context.UserRoles.ToListAsync();
        }

        public async Task UpdateRolesForUser(User user, IEnumerable<string> roleNames)
        {
            var roles = await Context.Roles.Where(r => roleNames.Contains(r.RoleName)).ToListAsync();
            var userRoles = await Context.UserRoles.Where(ur => ur.UserId == user.Id).ToListAsync();
            Context.UserRoles.RemoveRange(userRoles);
            await Context.SaveChangesAsync();
            foreach (var role in roles)
            {
                var userRole = new UserRole { User = user, Role = role };
                await Context.UserRoles.AddAsync(userRole);
            }
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName)
        {
            return await Context.UserRoles
                .Where(ur => ur.Role.RoleName == roleName)
                .Select(ur => ur.User)
                .ToListAsync();
        }

        public async Task<UserRole> GetUserRoleByIdAsync(int id)
        {
            return await Context.UserRoles.FirstAsync(r => r.Id == id);
            
        }
    }
}
