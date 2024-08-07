namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int Id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity, bool save = false);
        Task Update(TEntity entity, bool save = false);
        Task Delete(TEntity entity, bool save = false);
        Task SaveAsync();
    }
}
