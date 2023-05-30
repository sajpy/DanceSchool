using DanceSchool.DTO.User;

namespace DanceSchool.Services.IService
{
    public interface IUserService
    {

        //Task<IEnumerable<UserListDto>> GetAllUsersExceptOne(int id, int pageNumber, int pageSize);
        Task<UserDto> GetUserById(int userId);

        Task<UserDto> GetUserDetailById(int userId);

        //Task<UserUpdateDto> GetUserUpdateById(int userId);

        Task<UserDto> GetUserByEmail(string email);

        Task CreateUser(UserCreateDto userDto);

        //Task DeleteUser(int userId, string userFolder);

        //Task UpdateUser(UserUpdateDto userDto);

        Task<bool> UserExists(string email);
        Task<bool> UserExistsUpdate(string email, int id);

        Task RegisterUser(UserCreateDto user);

        Task<UserDto> AuthorizeUser(UserLoginDto userLogin);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        //Task ResetPassword(UserResetPasswordDto userDto);

        //Task ChangePassword(UserResetPasswordDto userDto);
    }
}
