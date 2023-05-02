using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,user")]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync _interviewerService;
        public InterviewerController(IInterviewerServiceAsync interviewerService)
        {
            _interviewerService = interviewerService;
        }

        // GET: api/values
        [HttpGet("GetAllInterviewers")]
        public async Task<IActionResult> GetAllInterviewers()
        {
            return Ok(await _interviewerService.GetAllInterviewerAsync());
        }

        [HttpGet("{id}" + " GetInterviewerById")]
        public async Task<IActionResult> GetInterviewerById(int id)
        {
            return Ok(await _interviewerService.GetInterviewerByIdAsync(id));
        }

        [HttpPost("AddInterviewer")]
        public async Task<IActionResult> AddInterviewer([FromBody] InterviewerRequestModel interviewer)
        {
            return Ok(await _interviewerService.AddInterviewerAsync(interviewer));
        }

        [HttpPut("{id}" + " UpdateInterviewer")]
        public async Task<IActionResult> UpdateInterviewer([FromBody] InterviewerRequestModel interviewer)
        {
            return Ok(await _interviewerService.UpdateInterviewerAsync(interviewer));
        }

        [HttpDelete("{id}" + " DeleteInterviewer")]
        public async Task<IActionResult> DeleteInterviewer(int id)
        {
            return Ok(await _interviewerService.DeleteInterviewerAsync(id));
        }

    }
}

