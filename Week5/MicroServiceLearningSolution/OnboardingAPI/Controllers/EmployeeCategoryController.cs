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
    public class EmployeeCategoryController : Controller
    {
        private readonly IEmployeeCategoryServiceAsync _employeeCategoryService;
        public EmployeeCategoryController(IEmployeeCategoryServiceAsync employeeCategoryService)
        {
            _employeeCategoryService = employeeCategoryService;
        }

        // GET: api/values
        [HttpGet("GetAllEmployeeCategories")]
        public async Task<IActionResult> GetAllEmployeeCategories()
        {
            return Ok(await _employeeCategoryService.GetAllEmployeeCategoryAsync());
        }

        [HttpGet("{id}" + " GetEmployeeCategoryById")]
        public async Task<IActionResult> GetEmployeeCategoryById(int id)
        {
            return Ok(await _employeeCategoryService.GetEmployeeCategoryByIdAsync(id));
        }

        [HttpPost("AddEmployeeCategory")]
        public async Task<IActionResult> AddEmployeeCategory([FromBody] EmployeeCategoryRequestModel employeeCategory)
        {
            return Ok(await _employeeCategoryService.AddEmployeeCategoryAsync(employeeCategory));
        }

        [HttpPut("{id}" + " UpdateEmployeeCategory")]
        public async Task<IActionResult> UpdateEmployeeCategory([FromBody] EmployeeCategoryRequestModel employeeCategory)
        {
            return Ok(await _employeeCategoryService.UpdateEmployeeCategoryAsync(employeeCategory));
        }

        [HttpDelete("{id}" + " DeleteEmployeeCategory")]
        public async Task<IActionResult> DeleteEmployeeCategory(int id)
        {
            return Ok(await _employeeCategoryService.DeleteEmployeeCategoryAsync(id));
        }
    }
}

