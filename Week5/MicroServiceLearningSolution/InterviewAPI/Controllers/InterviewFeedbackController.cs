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
    public class InterviewFeedbackController : ControllerBase
    {
        private readonly IInterviewFeedbackServiceAsync _interviewFeedbackService;
        public InterviewFeedbackController(IInterviewFeedbackServiceAsync interviewFeedbackService)
        {
            _interviewFeedbackService = interviewFeedbackService;
        }

        // GET: api/values
        [HttpGet("GetAllInterviewFeedbacks")]
        public async Task<IActionResult> GetAllInterviewFeedbacks()
        {
            return Ok(await _interviewFeedbackService.GetAllInterviewFeedbackAsync());
        }

        [HttpGet("{id}" + " GetInterviewFeedbackById")]
        public async Task<IActionResult> GetInterviewFeedbackById(int id)
        {
            return Ok(await _interviewFeedbackService.GetInterviewFeedbackByIdAsync(id));
        }

        [HttpPost("AddInterviewFeedback")]
        public async Task<IActionResult> AddInterviewFeedback([FromBody] InterviewFeedbackRequestModel interviewFeedback)
        {
            return Ok(await _interviewFeedbackService.AddInterviewFeedbackAsync(interviewFeedback));
        }

        [HttpPut("{id}" + " UpdateInterviewFeedback")]
        public async Task<IActionResult> UpdateInterviewFeedback([FromBody] InterviewFeedbackRequestModel interviewFeedback)
        {
            return Ok(await _interviewFeedbackService.UpdateInterviewFeedbackAsync(interviewFeedback));
        }

        [HttpDelete("{id}" + " DeleteInterviewFeedback")]
        public async Task<IActionResult> DeleteInterviewFeedback(int id)
        {
            return Ok(await _interviewFeedbackService.DeleteInterviewFeedbackAsync(id));
        }


    }
}

