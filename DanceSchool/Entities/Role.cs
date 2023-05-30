using Microsoft.AspNetCore.Identity;
using System.Data;

namespace DanceSchool.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
