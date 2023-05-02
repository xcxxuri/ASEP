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
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeServiceAsync _interviewTypeService;
        public InterviewTypeController(IInterviewTypeServiceAsync interviewTypeService)
        {
            _interviewTypeService = interviewTypeService;
        }

        // GET: api/values
        [HttpGet("GetAllInterviewTypes")]
        public async Task<IActionResult> GetAllInterviewTypes()
        {
            return Ok(await _interviewTypeService.GetAllInterviewTypeAsync());
        }

        [HttpGet("{id}" + " GetInterviewTypeById")]
        public async Task<IActionResult> GetInterviewTypeById(int id)
        {
            return Ok(await _interviewTypeService.GetInterviewTypeByIdAsync(id));
        }

        [HttpPost("AddInterviewType")]
        public async Task<IActionResult> AddInterviewType([FromBody] InterviewTypeRequestModel interviewType)
        {
            return Ok(await _interviewTypeService.AddInterviewTypeAsync(interviewType));
        }

        [HttpPut("{id}" + " UpdateInterviewType")]
        public async Task<IActionResult> UpdateInterviewType([FromBody] InterviewTypeRequestModel interviewType)
        {
            return Ok(await _interviewTypeService.UpdateInterviewTypeAsync(interviewType));
        }

        [HttpDelete("{id}" + " DeleteInterviewType")]
        public async Task<IActionResult> DeleteInterviewType(int id)
        {
            return Ok(await _interviewTypeService.DeleteInterviewTypeAsync(id));
        }
    }
}

