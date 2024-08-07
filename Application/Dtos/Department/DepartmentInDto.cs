using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Department
{
    public class DepartmentInDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
