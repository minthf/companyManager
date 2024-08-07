using Application.Dtos.Employee;

namespace Application.Dtos.Department
{
    public class DepartmentDetailsDto : DepartmentDto
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
