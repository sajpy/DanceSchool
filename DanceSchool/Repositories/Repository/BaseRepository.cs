using Microsoft.EntityFrameworkCore;
using DanceSchool.Data;
using DanceSchool.Entities;
using DanceSchool.Repositories.IRepository;

namespace DanceSchool.Repositories.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public DanceSchoolContext Context { get; set; }

        /// <summary>
        /// Initializes the instance
        /// </summary>
        /// <param name="context">Database context</param>
        public BaseRepository(DanceSchoolContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllEntities()
        {
            return await Context.Set<TEntity>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllEntitiesWithPagination(int pageNumber = 1, int pageSize = 10)
        {
            return await Context.Set<TEntity>()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TEntity> GetEntityById(int entityId)
        {
            return await Context.Set<TEntity>()
                .FindAsync(entityId);
        }

        public async Task<int> GetNumberOfEntities()
        {
            return await Context.Set<TEntity>()
                .CountAsync();
        }

        public async Task CreateEntity(TEntity entity)
        {
            await Context.Set<TEntity>()
                .AddAsync(entity);
        }

        public async Task DeleteEntity(int entityId)
        {
            var entity = await Context.Set<TEntity>().FindAsync(entityId);

            if (entity != null)
            {
                Context.Set<TEntity>()
                    .Remove(entity);
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            Context.Set<TEntity>()
                .Update(entity);
        }
    }
}
