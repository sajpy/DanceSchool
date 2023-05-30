using Microsoft.AspNetCore.Mvc.Rendering;
using DanceSchool.DTO.Pair;
using DanceSchool.Entities;

namespace DanceSchool.Services.IService
{
    public interface IPairService
    {
        Task<IEnumerable<PairDto>> GetAllPairsAsync();
        Task<PairDto> GetPairByIdAsync(int id);
        Task<Pair> AddPairAsync(PairCreateDto pairCreateDto);
        Task UpdatePairAsync(PairDto pair);
        Task DeletePairAsync(int id);
        Task<SelectList> GetUserSelectListAsync();
    }
}
