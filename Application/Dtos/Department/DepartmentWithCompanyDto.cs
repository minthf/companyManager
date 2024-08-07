using Application.Dtos.Company;

namespace Application.Dtos.Department
{
    public class DepartmentWithCompanyDto : DepartmentDto
    {
        public CompanyDto Company { get; set; }
    }
}
