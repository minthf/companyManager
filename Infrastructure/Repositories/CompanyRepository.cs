using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Company> GetByIdDetailsAsync(int id)
        {
            var company = await _dbSet
                .Include(c => c.Departments)
                    .ThenInclude(c => c.Employees)
                .FirstOrDefaultAsync(c => c.Id == id);

            return company is null ? throw new NotFoundException($"Not found {typeof(Company).Name}") : company;
        }
    }
}
