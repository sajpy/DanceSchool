using System.ComponentModel.DataAnnotations;

namespace DanceSchool.Models
{
    public class CreatePairViewModel
    {
        [Required]
        public string SelectedUserId1 { get; set; }

        [Required]
        public string SelectedUserId2 { get; set; }

        public IEnumerable<User> Users { get; set; }
    }

}
