using Microsoft.EntityFrameworkCore;
using DanceSchool.Data;
using DanceSchool.Entities;
using DanceSchool.Repositories.IRepository;

namespace DanceSchool.Repositories.Repository
{
    public class PairRepository : BaseRepository<Pair>, IPairRepository
    {
        public PairRepository(DanceSchoolContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Pair>> GetAllPairsAsync()
        {
            return await Context.Pairs.ToListAsync();
        }
        public async Task<Pair> GetPairByIdAsync(int id)
        {
            return await Context.Pairs.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddPairAsync(Pair pair)
        {
            await Context.AddAsync(pair);
        }
    
    }
}
