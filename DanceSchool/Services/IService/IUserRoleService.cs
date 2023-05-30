using DanceSchool.DTO.User;
using DanceSchool.DTO.UserRole;

namespace DanceSchool.Services.IService
{
    public interface IUserRoleService
    {
        //Task<IEnumerable<UserRoleDto>> GetAllUserRolesAsync();
        Task<UserRoleDto> GetUserRoleByIdAsync(int id);
        Task<UserRoleDto> GetUserRolesForUserAsync(UserDto user);
        //Task AddUserRoleAsync(UserRoleDto userRole);
        //Task UpdateUserRoleAsync(UserRoleDto userRole);
        //Task DeleteUserRoleAsync(int id);
    }
}
