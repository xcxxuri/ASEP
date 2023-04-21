using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIEF.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        CandidateService _candidateService;
        public CandidateController(CandidateService candidateService)
        {
            _candidateService = candidateService;
        }



        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            // Get all candidates
            // var candidates = _candidateService.GetAllCandidates()
            // return Ok(candidates);
            return Ok(await _candidateService.GetAllCandidates());
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _candidateService.GetCandidateByIdAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel candidate)
        {
            // Add candidate
            // var result = _candidateService.AddCandidateAsync(candidate);
            // return Ok(result);
            if (candidate != null)
            {
                return Ok(await _candidateService.AddCandidateAsync(candidate));
            }
            return BadRequest();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateRequestModel candidate)
        {
            // // Update candidate
            // var result = _candidateService.UpdateCandidateAsync(candidate);
            // return Ok(result);
            return Ok(await _candidateService.UpdateCandidateAsync(candidate));
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            // Delete candidate
            // var result = _candidateService.DeleteCandidateAsync(id);
            // return Ok(result);
            return Ok(await _candidateService.DeleteCandidateAsync(id));
        }

        // Exception Handling
        [HttpGet("ExceptionHandling")]
        public IActionResult ExceptionHandling(string input)
        {
            try
            {
                throw new NullReferenceException("Null Reference Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

