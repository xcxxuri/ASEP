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
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusServiceAsync _submissionStatusService;
        public SubmissionStatusController(ISubmissionStatusServiceAsync submissionStatusService)
        {
            _submissionStatusService = submissionStatusService;
        }
        // GET: api/values
        [HttpGet("GetSubmissionStatus")]
        public async Task<IActionResult> GetAllSubmissionStatus()
        {
            return Ok(await _submissionStatusService.GetAllSubmissionStatusAsync());
        }

        [HttpGet("{id}" + " GetSubmissionStatusById")]
        public async Task<IActionResult> GetSubmissionStatusById(int id)
        {
            return Ok(await _submissionStatusService.GetSubmissionStatusByIdAsync(id));
        }

        [HttpPost("AddSubmissionStatus")]
        public async Task<IActionResult> AddSubmissionStatus([FromBody] SubmissionStatusRequestModel ss)
        {
            return Ok(await _submissionStatusService.AddSubmissionStatusAsync(ss));
        }

        [HttpPut("{id}" + " UpdateSubmissionStatus")]
        public async Task<IActionResult> UpdateSubmissionStatus([FromBody] SubmissionStatusRequestModel ss)
        {
            return Ok(await _submissionStatusService.UpdateSubmissionStatusAsync(ss));
        }

        [HttpDelete("{id}" + " DeleteSubmissionStatus")]
        public async Task<IActionResult> DeleteSubmissionStatus(int id)
        {
            return Ok(await _submissionStatusService.DeleteSubmissionStatusAsync(id));
        }
    }
}

