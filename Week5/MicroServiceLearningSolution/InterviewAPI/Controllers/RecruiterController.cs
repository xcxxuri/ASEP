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
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServiceAsync _recruiterService;
        public RecruiterController(IRecruiterServiceAsync recruiterService)
        {
            _recruiterService = recruiterService;
        }

        // GET: api/values
        [HttpGet("GetAllRecruiters")]
        public async Task<IActionResult> GetAllRecruiters()
        {
            return Ok(await _recruiterService.GetAllRecruiterAsync());
        }

        [HttpGet("{id}" + " GetRecruiterById")]
        public async Task<IActionResult> GetRecruiterById(int id)
        {
            return Ok(await _recruiterService.GetRecruiterByIdAsync(id));
        }

        [HttpPost("AddRecruiter")]
        public async Task<IActionResult> AddRecruiter([FromBody] RecruiterRequestModel recruiter)
        {
            return Ok(await _recruiterService.AddRecruiterAsync(recruiter));
        }

        [HttpPut("{id}" + " UpdateRecruiter")]
        public async Task<IActionResult> UpdateRecruiter([FromBody] RecruiterRequestModel recruiter)
        {
            return Ok(await _recruiterService.UpdateRecruiterAsync(recruiter));
        }

        [HttpDelete("{id}" + " DeleteRecruiter")]
        public async Task<IActionResult> DeleteRecruiter(int id)
        {
            return Ok(await _recruiterService.DeleteRecruiterAsync(id));
        }
    }
}

