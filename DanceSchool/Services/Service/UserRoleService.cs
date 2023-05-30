using AutoMapper;
using DanceSchool.DTO.User;
using DanceSchool.DTO.UserRole;
using DanceSchool.Entities;
using DanceSchool.Repositories.IRepository;
using DanceSchool.Services.IService;
using DanceSchool.UOW;

namespace DanceSchool.Services.Service
{
    public class UserRoleService : IUserRoleService
    {
        /// <summary>
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;


        public UserRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<UserRoleListDto>> GetAllUserRolesAsync()
        //{
        //    return _mapper.Map<IEnumerable<UserRoleListDto>>(await _unitOfWork.UserRoleRepository.GetAllAsync());
        //}

        public async Task<UserRoleDto> GetUserRoleByIdAsync(int userRoleId)
        {
            return _mapper.Map<UserRoleDto>(await _unitOfWork.UserRoleRepository.GetUserRoleByIdAsync(userRoleId));
        }

        public async Task<UserRoleDto> GetUserRolesForUserAsync(UserDto user)
        {
            return _mapper.Map<UserRoleDto>(await _unitOfWork.UserRoleRepository.GetUserRoleByIdAsync(user.Id));
        }

        //public async Task<UserRoleDto> AddUserRoleAsync(UserRoleDto userRoleDto)
        //{
        //    var userRole = _mapper.Map<UserRole>(userRoleDto);
        //    await _unitOfWork.UserRoleRepository.AddAsync(userRole);
        //    await _unitOfWork.CommitAsync();
        //    return _mapper.Map<UserRoleDto>(userRole);
        //}

        //public async Task<UserRoleDto> UpdateUserRoleAsync(UserRoleDto userRoleDto)
        //{
        //    var userRole = _mapper.Map<UserRole>(userRoleDto);
        //    await _unitOfWork.UserRoleRepository.UpdateAsync(userRole);
        //    await _unitOfWork.CommitAsync();
        //    return _mapper.Map<UserRoleDto>(userRole);
        //}


        //public async Task DeleteUserRoleAsync(int userRoleId)
        //{
        //    await _unitOfWork.UserRoleRepository.DeleteAsync(userRoleId);
        //    await _unitOfWork.CommitAsync();
        //}

    }
}
