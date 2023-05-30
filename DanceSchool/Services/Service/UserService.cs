using System.Security.Cryptography;
using DanceSchool.DTO.User;
using DanceSchool.Services.IService;
using AutoMapper;
using DanceSchool.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DanceSchool.UOW;
using Microsoft.AspNetCore.Identity;

namespace DanceSchool.Services.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<UserListDto>> GetAllUsersExceptOne(int id, int pageNumber, int pageSize)
        //{
        //    return _mapper.Map<IEnumerable<UserListDto>>(await _unitOfWork.UserRepository.GetAllUsersExceptOne(id, pageNumber, pageSize));
        //}

        public async Task<UserDto> GetUserById(int userId)
        {
            return _mapper.Map<UserDto>(await _unitOfWork.UserRepository.GetUserByIdAsync(userId));
        }

        public async Task<UserDto> GetUserDetailById(int userId)
        {
            return _mapper.Map<UserDto>(await _unitOfWork.UserRepository.GetEntityById(userId));
        }

        //public async Task<UserUpdateDto> GetUserUpdateById(int userId)
        //{
        //    return _mapper.Map<UserUpdateDto>(await _unitOfWork.UserRepository.GetEntityById(userId));
        //}

        public async Task<UserDto> GetUserByEmail(string email)
        {

            return _mapper.Map<UserDto>(await _unitOfWork.UserRepository.GetUserByEmail(email));
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task CreateUser(UserCreateDto userDto)
        {
            await RegisterUser(userDto);
            User user = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.CreateEntity(user);

            foreach (var role in userDto.Roles)
            {
                await _unitOfWork.UserRoleRepository.AddRoleToUserAsync(user, role);
            }
            await _unitOfWork.CommitAsync();
        }

        //public async Task DeleteUser(int userId, string userFolder)
        //{
        //    var user = await GetUserById(userId);
        //    await _unitOfWork.UserRepository.DeleteEntity(userId);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task UpdateUser(UserUpdateDto userDto)
        //{
        //    var user = await _unitOfWork.UserRepository.GetEntityById(userDto.Id);
        //    _mapper.Map(userDto, user);
        //    _unitOfWork.UserRepository.UpdateEntity(user);
        //    await _unitOfWork.CommitAsync();
        //}


        public async Task<bool> UserExists(string email)
        {
            return await GetUserByEmail(email) != null;
        }

        public async Task<bool> UserExistsUpdate(string email, int id)
        {
            var user = await GetUserByEmail(email);
            return user != null && user.Id != id;
        }

        public async Task RegisterUser(UserCreateDto user)
        {
            user.PasswordHash = user.Password;
            await _unitOfWork.CommitAsync();
        }

        public async Task<UserDto> AuthorizeUser(UserLoginDto login)
        {
            var userDto = await GetUserByEmail(login.Email);

            if (userDto == null)
            {
                return null;
            }

            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userDto.Id);
            var success = user != null;

            return success ? userDto : null;
        }

        //public async Task ResetPassword(UserResetPasswordDto userDto)
        //{
        //    var user = await _unitOfWork.UserRepository.GetUserByEmail(userDto.Email);
        //    var (hash, salt) = CreateHash(userDto.Password);
        //    user.PasswordHash = string.Join(',', hash, salt);
        //    _unitOfWork.UserRepository.UpdateEntity(user);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task ChangePassword(UserResetPasswordDto userDto)
        //{
        //    var user = await _unitOfWork.UserRepository.GetEntityById(userDto.Id);
        //    var (hash, salt) = CreateHash(userDto.Password);
        //    user.PasswordHash = string.Join(',', hash, salt);
        //    _unitOfWork.UserRepository.UpdateEntity(user);
        //    await _unitOfWork.CommitAsync();
        //}

    }
}
