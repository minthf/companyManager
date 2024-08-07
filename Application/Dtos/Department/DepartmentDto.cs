using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Department
{
    public class DepartmentDto : DepartmentInDto
    {
        [Required]
        public int Id { get; set; }
    }
}
