using Application.Dtos.Department;

namespace Application.Dtos.Employee
{
    public class EmployeeDetailsDto : EmployeeInDto
    {
        public DepartmentWithCompanyDto Department { get; set; }
    }
}
