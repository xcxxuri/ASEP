using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.ApplicationCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingAPI.Controllers
{
    [Route("api/[controller]")]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync _jobRequirementService;

        public JobRequirementController(IJobRequirementServiceAsync jobRequirementService)
        {
            _jobRequirementService = jobRequirementService;
        }

        // GET: api/values
        [HttpGet("GetAllJobRequirement")]
        public async Task<IActionResult> GetAllJobRequirement()
        {
            return Ok(await _jobRequirementService.GetAllJobRequirementAsync());
        }

        [HttpGet("{id}" + " GetJobRequirementById")]
        public async Task<IActionResult> GetJobRequirementById(int id)
        {
            return Ok(await _jobRequirementService.GetJobRequirementByIdAsync(id));
        }

        [HttpPost("AddJobRequirement")]
        public async Task<IActionResult> AddJobRequirement([FromBody] JobRequirementRequestModel jr)
        {
            return Ok(await _jobRequirementService.AddJobRequirementAsync(jr));
        }

        [HttpPut("{id}" + " UpdateJobRequirement")]
        public async Task<IActionResult> UpdateJobRequirement([FromBody] JobRequirementRequestModel jr)
        {
            return Ok(await _jobRequirementService.UpdateJobRequirementAsync(jr));
        }

        [HttpDelete("{id}" + " DeleteJobRequirement")]
        public async Task<IActionResult> DeleteJobRequirement(int id)
        {
            return Ok(await _jobRequirementService.DeleteJobRequirementAsync(id));
        }
    }
}

