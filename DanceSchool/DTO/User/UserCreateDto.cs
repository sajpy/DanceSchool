namespace DanceSchool.DTO.User
{
    public class UserCreateDto : BaseDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public List<string> Roles { get; set; } 

    }
}

