using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Company
{
    public class CompanyDto : CompanyInDto
    {
        [Required]
        public int Id { get; set; }
    }
}
