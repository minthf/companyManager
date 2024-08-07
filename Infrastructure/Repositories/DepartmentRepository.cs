using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Department> GetByIdDetailsAsync(int id)
        {
            var department = await _dbSet
                .Include(c => c.Employees)
                .FirstOrDefaultAsync(c => c.Id == id);

            return department is null ? throw new NotFoundException($"Not found {typeof(Department).Name}") : department;
        }
    }
}
