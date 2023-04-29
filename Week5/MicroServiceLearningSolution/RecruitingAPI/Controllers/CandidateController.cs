using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.ApplicationCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync _candidateService;

        public CandidateController(ICandidateServiceAsync candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/values
        [HttpGet("GetAllCandidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            return Ok(await _candidateService.GetAllCandidateAsync());
        }

        [HttpGet("{id}" + " GetCandidateById")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            return Ok(await _candidateService.GetCandidateByIdAsync(id));
        }

        [HttpPost("AddCandidate")]
        public async Task<IActionResult> AddCandidate([FromBody] CandidateRequestModel candidate)
        {
            return Ok(await _candidateService.AddCandidateAsync(candidate));
        }

        [HttpPut("{id}" + " UpdateCandidate")]
        public async Task<IActionResult> UpdateCandidate([FromBody] CandidateRequestModel candidate)
        {
            return Ok(await _candidateService.UpdateCandidateAsync(candidate));
        }

        [HttpDelete("{id}" + " DeleteCandidate")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            return Ok(await _candidateService.DeleteCandidateAsync(id));
        }

    }
}

