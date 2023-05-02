using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.ApplicationCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,user")]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleServiceAsync _employeeRoleService;

        public EmployeeRoleController(IEmployeeRoleServiceAsync employeeRoleService)
        {
            _employeeRoleService = employeeRoleService;
        }

        // GET: api/values
        [HttpGet("GetAllEmployeeRoles")]
        public async Task<IActionResult> GetAllEmployeeRoles()
        {
            return Ok(await _employeeRoleService.GetAllEmployeeRoleAsync());
        }

        [HttpGet("{id}" + " GetEmployeeRoleById")]
        public async Task<IActionResult> GetEmployeeRoleById(int id)
        {
            return Ok(await _employeeRoleService.GetEmployeeRoleByIdAsync(id));
        }

        [HttpPost("AddEmployeeRole")]
        public async Task<IActionResult> AddEmployeeRole([FromBody] EmployeeRoleRequestModel employeeRole)
        {
            return Ok(await _employeeRoleService.AddEmployeeRoleAsync(employeeRole));
        }

        [HttpPut("{id}" + " UpdateEmployeeRole")]
        public async Task<IActionResult> UpdateEmployeeRole([FromBody] EmployeeRoleRequestModel employeeRole)
        {
            return Ok(await _employeeRoleService.UpdateEmployeeRoleAsync(employeeRole));
        }

        [HttpDelete("{id}" + " DeleteEmployeeRole")]
        public async Task<IActionResult> DeleteEmployeeRole(int id)
        {
            return Ok(await _employeeRoleService.DeleteEmployeeRoleAsync(id));
        }

    }
}

