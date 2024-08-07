using Application.Dtos.Company;
using Application.Dtos.Department;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private DepartmentService _DepartmentService;

        public DepartmentController(DepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetCompanies()
        {
            var companies = await _DepartmentService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(int id)
        {
            var Department = await _DepartmentService.GetDepartmentByIdAsync(id);
            return Ok(Department);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateDepartment(DepartmentInDto dto)
        {
            var id = await _DepartmentService.CreateDepartmentAsync(dto);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult<DepartmentDto>> UpdateDepartment(DepartmentDto dto)
        {
            var updatedDepartment = await _DepartmentService.UpdateDepartmentAsync(dto);
            return Ok(updatedDepartment);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDepartmentById(int id)
        {
            await _DepartmentService.DeleteDepartmentAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<DepartmentDetailsDto>> GetCompanyDetailsById(int id)
        {
            var company = await _DepartmentService.GetDepartmenDetailsByIdAsync(id);
            return Ok(company);
        }
    }
}
