using AutoMapper;
using iFXManager.API.Models;
using iFXManager.DAL.DTOs;
using iFXManager.DAL.Models;
using iFXManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iFXManager.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _employees;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployees employees, IMapper mapper)
        {
            _employees = employees;
            _mapper = mapper;
        }


        [HttpPost("save")]
        [Authorize]
        public ActionResult Post([FromBody] EmployeesDto employeeDto)
        {
            try
            {
                if (employeeDto == null)
                {
                    return BadRequest(ModelState);
                }
                var employee = _mapper.Map<Employee>(employeeDto);

                var response = _employees.ExistEmployee(employee);
                if (response.Result)
                {
                    ModelState.AddModelError("", "There is already an employee with the registered ID number.");
                    return StatusCode(404, ModelState);
                }
                _employees.SaveEmployeesAsync(employee);

                return Ok(employee);

            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("GetAllEmployeeAsync")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var response = await _employees.GetAllEmployeesAsync();
            if (response.Any())
                return Ok(response);

            return BadRequest(response);
        }
    }
}
