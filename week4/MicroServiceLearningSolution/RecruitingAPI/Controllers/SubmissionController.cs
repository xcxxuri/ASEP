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
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionServiceAsync _submissionService;
        public SubmissionController(ISubmissionServiceAsync submissionService)
        {
            _submissionService = submissionService;
        }

        // GET: api/values
        [HttpGet("GetSubmission")]
        public async Task<IActionResult> GetAllSubmission()
        {
            return Ok(await _submissionService.GetAllSubmissionAsync());
        }

        [HttpGet("{id}" + " GetSubmissionById")]
        public async Task<IActionResult> GetSubmissionById(int id)
        {
            return Ok(await _submissionService.GetSubmissionByIdAsync(id));
        }

        [HttpPost("AddSubmission")]
        public async Task<IActionResult> AddSubmission([FromBody] SubmissionRequestModel jr)
        {
            return Ok(await _submissionService.AddSubmissionAsync(jr));
        }

        [HttpPut("{id}" + " UpdateSubmission")]
        public async Task<IActionResult> UpdateSubmission([FromBody] SubmissionRequestModel jr)
        {
            return Ok(await _submissionService.UpdateSubmissionAsync(jr));
        }

        [HttpDelete("{id}" + " DeleteSubmission")]
        public async Task<IActionResult> DeleteJobRequirement(int id)
        {
            return Ok(await _submissionService.DeleteSubmissionAsync(id));
        }
    }
}

