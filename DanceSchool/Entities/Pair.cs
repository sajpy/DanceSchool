using System.ComponentModel.DataAnnotations.Schema;

namespace DanceSchool.Entities
{
    public class Pair : BaseEntity
    {
        public int User1Id { get; set; }
        public int? User2Id { get; set; }

        [ForeignKey(nameof(User1Id))]
        public virtual User User1 { get; set; }

        [ForeignKey(nameof(User2Id))]
        public virtual User? User2 { get; set; }

        [NotMapped]
        public string User1Name { get; set; }
        [NotMapped]
        public string? User2Name { get; set; }
    }
}
