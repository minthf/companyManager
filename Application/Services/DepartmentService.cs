using Application.Dtos.Department;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository DepartmentRepository)
        {
            _departmentRepository = DepartmentRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllCompaniesAsync()
        {
            var Departments = await _departmentRepository.GetAllAsync();

            return Departments.Adapt<IEnumerable<DepartmentDto>>();
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            var Department = await _departmentRepository.GetByIdAsync(id);


            return Department.Adapt<DepartmentDto>();
        }


        public async Task<int> CreateDepartmentAsync(DepartmentInDto DepartmentDto)
        {
            var Department = DepartmentDto.Adapt<Department>();

            var result = await _departmentRepository.CreateAsync(Department, true);

            return result.Id;
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(DepartmentDto DepartmentDto)
        {
            var product = await _departmentRepository.GetByIdAsync(DepartmentDto.Id);

            var config = new TypeAdapterConfig();
            config.NewConfig<DepartmentDto, Department>()
                  .IgnoreNullValues(true);

            DepartmentDto.Adapt(product, config);

            await _departmentRepository.Update(product, true);

            return product.Adapt<DepartmentDto>();

        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var Department = await _departmentRepository.GetByIdAsync(id);
            await _departmentRepository.Delete(Department, true);
        }

        public async Task<DepartmentDetailsDto> GetDepartmenDetailsByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdDetailsAsync(id);


            return department.Adapt<DepartmentDetailsDto>();
        }
    }
}
