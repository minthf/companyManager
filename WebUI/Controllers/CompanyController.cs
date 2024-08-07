using Application.Dtos.Company;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private CompanyService _companyService;

        public CompanyController(CompanyService companyService) 
        {
            _companyService = companyService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCompany(CompanyInDto dto)
        {
            var id = await _companyService.CreateCompanyAsync(dto);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyDto>> UpdateCompany(CompanyDto dto)
        {
            var updatedCompany = await _companyService.UpdateCompanyAsync(dto);
            return Ok(updatedCompany);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCompanyById(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<CompanyDetailsDto>> GetCompanyDetailsById(int id)
        {
            var company = await _companyService.GetCompanyDetailsByIdAsync(id);
            return Ok(company);
        }
    }
}
