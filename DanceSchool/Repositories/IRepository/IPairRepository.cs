using DanceSchool.Entities;

namespace DanceSchool.Repositories.IRepository
{
    public interface IPairRepository : IBaseRepository<Pair>
    {
        Task<IEnumerable<Pair>> GetAllPairsAsync();
        Task<Pair> GetPairByIdAsync(int id);
        Task AddPairAsync(Pair pair);
    }
}
