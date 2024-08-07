using Application.Dtos.Department;

namespace Application.Dtos.Company
{
    public class CompanyDetailsDto : CompanyDto
    {
        public IEnumerable<DepartmentDetailsDto> Departments { get; set; }
    }
}
