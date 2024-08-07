using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public Task<Employee> GetByIdDetailsAsync(int id);
    }
}
