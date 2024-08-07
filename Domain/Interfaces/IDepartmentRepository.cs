using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        public Task<Department> GetByIdDetailsAsync(int id);
    }
}
