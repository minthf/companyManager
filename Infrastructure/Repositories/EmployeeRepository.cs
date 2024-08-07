using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Employee> GetByIdDetailsAsync(int id)
        {
            var employee = await _dbSet
                .Include(c => c.Department)
                    .ThenInclude(c => c.Company)
                .FirstOrDefaultAsync(c => c.Id == id);

            return employee is null ? throw new NotFoundException($"Not found {typeof(Employee).Name}") : employee;
        }
    }
}
