using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceSchool.Entities
{
    public class User : BaseEntity
    {

        /// <summary>
        /// User email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User password hash
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User surname
        /// </summary>
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
