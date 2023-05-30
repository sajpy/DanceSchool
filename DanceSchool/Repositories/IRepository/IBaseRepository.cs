
namespace DanceSchool.Repositories.IRepository
{
    /// <summary>
    /// Generic base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all records of entity
        /// </summary>
        /// <returns>Collection of all records of entity</returns>
        Task<IEnumerable<TEntity>> GetAllEntities();

        /// <summary>
        /// Gets all records of entity with pagination
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged collection of all records of entity</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesWithPagination(int pageNumber = 1, int pageSize = 10);

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="entityId">Entity id</param>
        /// <returns>Retrieved entity</returns>
        Task<TEntity> GetEntityById(int entityId);

        /// <summary>
        /// Gets number of entities
        /// </summary>
        /// <returns>Number of entities</returns>
        Task<int> GetNumberOfEntities();

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task CreateEntity(TEntity entity);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entityId">Entity id</param>
        /// <returns></returns>
        Task DeleteEntity(int entityId);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void UpdateEntity(TEntity entity);
    }

}