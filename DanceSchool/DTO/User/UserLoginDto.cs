using System.ComponentModel.DataAnnotations;

namespace DanceSchool.DTO.User
{
    public class UserLoginDto : BaseDto
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

    }
}
