using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Employee
{
    public class EmployeeDto : EmployeeInDto
    {
        [Required]
        public int Id { get; set; }
    }
}
