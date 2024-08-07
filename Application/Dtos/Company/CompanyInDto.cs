using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Company
{
    public class CompanyInDto
    {
        [Required]
        public string Name { get; set; }
    }
}
