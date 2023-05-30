using AutoMapper;
using DanceSchool.DTO.Pair;
using DanceSchool.DTO.User;
using DanceSchool.DTO.UserRole;
using DanceSchool.Entities;

namespace DanceSchool.Config
{
    public static class MappingConfig
    {
        public static IMapper Configure()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserCreateDto>().ReverseMap();
                config.CreateMap<User, UserLoginDto>().ReverseMap();
                config.CreateMap<User, UserRegisterDto>().ReverseMap();

                config.CreateMap<User, UserListDto>()
                    .ForMember(userListDto => userListDto.Name, name => name.MapFrom(user => $"{user.FirstName} {user.LastName}"))
                    .ReverseMap();

                config.CreateMap<User, UserDto>()
                    .AfterMap((src, dest) =>
                    {
                        dest.RoleNames = src.UserRoles.Select(x => x.Role.RoleName).ToList();
                    }).ReverseMap();


                config.CreateMap<UserRole, UserRoleDto>().ReverseMap();

                config.CreateMap<Role, string>()
                    .ConstructUsing(r => r.RoleName);

                config.CreateMap<string, Role>()
                    .ConstructUsing(roleName => new Role { RoleName = roleName });


                config.CreateMap<Pair, PairDto>().ReverseMap();

            })
            {
            };
            return mapperConfig.CreateMapper();
        }
    }
}
