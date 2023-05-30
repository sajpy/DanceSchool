using System.ComponentModel.DataAnnotations;

namespace DanceSchool.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
      
        public bool isManager { get; set; }
        public bool isTrainer { get; set; }
        public bool isStudent { get; set; }

    }
}
