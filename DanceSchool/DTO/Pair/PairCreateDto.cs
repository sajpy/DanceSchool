using Microsoft.AspNetCore.Mvc.Rendering;
using DanceSchool.DTO.User;

namespace DanceSchool.DTO.Pair
{
    public class PairCreateDto : BaseDto
    {
        public string User1Name { get; set; }
        public string User2Name { get; set; }

        public int User1Id { get; set; }
        public int? User2Id { get; set; }

        public IEnumerable<UserDto> Users { get; set; }


    }
}
