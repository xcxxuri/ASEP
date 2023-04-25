using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.ApplicationCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServiceAsync _employeeService;
        
        public EmployeeController(IEmployeeServiceAsync employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/values
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAllEmployeeAsync());
        }

        [HttpGet("{id}" + " GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestModel employee)
        {
            return Ok(await _employeeService.AddEmployeeAsync(employee));
        }
        
        [HttpPut("{id}" + " UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequestModel employee)
        {
            return Ok(await _employeeService.UpdateEmployeeAsync(employee));
        }

        [HttpDelete("{id}" + " DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _employeeService.DeleteEmployeeAsync(id));
        }
    }
}

