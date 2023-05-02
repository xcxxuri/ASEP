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
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusServiceAsync _employeeStatusService;
        public EmployeeStatusController(IEmployeeStatusServiceAsync employeeStatusService)
        {
            _employeeStatusService = employeeStatusService;
        }

        // GET: api/values
        [HttpGet("GetAllEmployeeStatuses")]
        public async Task<IActionResult> GetAllEmployeeStatuses()
        {
            return Ok(await _employeeStatusService.GetAllEmployeeStatusAsync());
        }

        [HttpGet("{id}" + " GetEmployeeStatusById")]
        public async Task<IActionResult> GetEmployeeStatusById(int id)
        {
            return Ok(await _employeeStatusService.GetEmployeeStatusByIdAsync(id));
        }

        [HttpPost("AddEmployeeStatus")]
        public async Task<IActionResult> AddEmployeeStatus([FromBody] EmployeeStatusRequestModel employeeStatus)
        {
            return Ok(await _employeeStatusService.AddEmployeeStatusAsync(employeeStatus));
        }

        [HttpPut("{id}" + " UpdateEmployeeStatus")]
        public async Task<IActionResult> UpdateEmployeeStatus([FromBody] EmployeeStatusRequestModel employeeStatus)
        {
            return Ok(await _employeeStatusService.UpdateEmployeeStatusAsync(employeeStatus));
        }

        [HttpDelete("{id}" + " DeleteEmployeeStatus")]
        public async Task<IActionResult> DeleteEmployeeStatus(int id)
        {
            return Ok(await _employeeStatusService.DeleteEmployeeStatusAsync(id));
        }
    }
}

