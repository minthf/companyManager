using Domain.Common.Exceptions;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        private AppDbContext RepositoryContext { get; set; }
        public BaseRepository(AppDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            _dbSet = repositoryContext.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity, bool save = false)
        {
            await RepositoryContext.Set<TEntity>().AddAsync(entity);
            if (save)
            {
                await SaveAsync();
            }

            return entity;
        }

        public async Task Delete(TEntity entity, bool save = false)
        {
            RepositoryContext.Set<TEntity>().Remove(entity);
            if (save)
            {
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = RepositoryContext.Set<TEntity>().ToList();

            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await RepositoryContext.Set<TEntity>().FindAsync(id);

            if (entity is null)
            {
                throw new NotFoundException($"Not found {typeof(TEntity).Name}");
            }

            return entity;
        }

        public async Task SaveAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity, bool save = false)
        {
            RepositoryContext.Set<TEntity>().Update(entity);
            if (save)
            {
                await SaveAsync();
            }
        }
    }
}
