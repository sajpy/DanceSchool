using Microsoft.EntityFrameworkCore;
using DanceSchool.Data;
using DanceSchool.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanceSchool.Entities;
using DanceSchool.DTO.User;

namespace DanceSchool.Repositories.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes the instance
        /// </summary>
        /// <param name="context">Database context</param>
        public UserRepository(DanceSchoolContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user2 = await Context.Users
                .FirstOrDefaultAsync(user => user.Email.Equals(email));

            if (user2 == null)
            {
                return null;
            }

            user2.UserRoles = await Context.UserRoles
                .Where(ur => ur.UserId == user2.Id)
                .Include(ur => ur.Role)
                .ToListAsync();
            return user2;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {

            List<User> users = await Context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .ToListAsync();

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await Context.Users.FindAsync(id);
        }

        //public async Task AddUserAsync(User user)
        //{
        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateUserAsync(User user)
        //{
        //    _context.Entry(user).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteUserAsync(int id)
        //{
        //    var user = await GetUserByIdAsync(id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //}
    }
}
