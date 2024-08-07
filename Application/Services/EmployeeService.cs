using Application.Dtos.Employee;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllCompaniesAsync()
        {
            var Employees = await _EmployeeRepository.GetAllAsync();

            return Employees.Adapt<IEnumerable<EmployeeDto>>();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var Employee = await _EmployeeRepository.GetByIdAsync(id);


            return Employee.Adapt<EmployeeDto>();
        }


        public async Task<int> CreateEmployeeAsync(EmployeeInDto EmployeeDto)
        {
            var Employee = EmployeeDto.Adapt<Employee>();

            var result = await _EmployeeRepository.CreateAsync(Employee, true);

            return result.Id;
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto EmployeeDto)
        {
            var product = await _EmployeeRepository.GetByIdAsync(EmployeeDto.Id);

            var config = new TypeAdapterConfig();
            config.NewConfig<EmployeeDto, Employee>()
                  .IgnoreNullValues(true);

            EmployeeDto.Adapt(product, config);

            await _EmployeeRepository.Update(product, true);

            return product.Adapt<EmployeeDto>();

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var Employee = await _EmployeeRepository.GetByIdAsync(id);
            await _EmployeeRepository.Delete(Employee, true);
        }

        public async Task<EmployeeDetailsDto> GetEmployeeDetailsByIdAsync(int id)
        {
            var employee = await _EmployeeRepository.GetByIdDetailsAsync(id);


            return employee.Adapt<EmployeeDetailsDto>();
        }
    }
}
