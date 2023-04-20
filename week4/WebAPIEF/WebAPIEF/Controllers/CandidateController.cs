using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
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
        public IActionResult GetAllCandidates()
        {
            // Get all candidates
            var candidates = _candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("GetById/{id}")] // Dynamic Routing
        public IActionResult GetById(int id)
        {
            // Get candidate by id
            var candidate = _candidateService.GetCandidateById(id);
            return Ok(candidate);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Candidate candidate)
        {
            // Add candidate
            var result = _candidateService.AddCandidate(candidate);
            return Ok(result);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateCandidate(int id, Candidate candidate)
        {
            // Update candidate
            var result = _candidateService.UpdateCandidate(candidate);
            return Ok(result);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            // Delete candidate
            var result = _candidateService.DeleteCandidate(id);
            return Ok(result);
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

