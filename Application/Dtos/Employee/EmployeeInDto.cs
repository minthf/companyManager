using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Employee
{
    public class EmployeeInDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]

        [SwaggerSchema(Format = "yyyy-MM-dd")]
        public DateOnly BirthDay { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
