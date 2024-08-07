using Application.Dtos.Department;
using Application.Dtos.Employee;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _EmployeeService;

        public EmployeeController(EmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetCompanies()
        {
            var companies = await _EmployeeService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var Employee = await _EmployeeService.GetEmployeeByIdAsync(id);
            return Ok(Employee);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEmployee(EmployeeInDto dto)
        {

            var id = await _EmployeeService.CreateEmployeeAsync(dto);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto dto)
        {
            var updatedEmployee = await _EmployeeService.UpdateEmployeeAsync(dto);
            return Ok(updatedEmployee);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeById(int id)
        {
            await _EmployeeService.DeleteEmployeeAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<EmployeeDetailsDto>> GetCompanyDetailsById(int id)
        {
            var company = await _EmployeeService.GetEmployeeDetailsByIdAsync(id);
            return Ok(company);
        }
    }
}
