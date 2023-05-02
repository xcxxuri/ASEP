﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Models;
using Interview.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,user")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewsServiceAsync _interviewsService;
        public InterviewsController(IInterviewsServiceAsync interviewsService)
        {
            _interviewsService = interviewsService;
        }

        // GET: api/values
        [HttpGet("GetAllInterviews")]
        public async Task<IActionResult> GetAllInterviews()
        {
            return Ok(await _interviewsService.GetAllInterviewsAsync());
        }

        [HttpGet("{id}" + " GetInterviewById")]
        public async Task<IActionResult> GetInterviewById(int id)
        {
            return Ok(await _interviewsService.GetInterviewsByIdAsync(id));
        }

        [HttpPost("AddInterview")]
        public async Task<IActionResult> AddInterview([FromBody] InterviewsRequestModel interview)
        {
            return Ok(await _interviewsService.AddInterviewsAsync(interview));
        }

        [HttpPut("{id}" + " UpdateInterview")]
        public async Task<IActionResult> UpdateInterview([FromBody] InterviewsRequestModel interview)
        {
            return Ok(await _interviewsService.UpdateInterviewsAsync(interview));
        }

        [HttpDelete("{id}" + " DeleteInterview")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            return Ok(await _interviewsService.DeleteInterviewsAsync(id));
        }

        [HttpGet("GetAllCandidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            string str = "http://100.64.9.218:50123/api/candidate/getallcandidates";
            HttpClient client = new HttpClient();

            // client.BaseAddress = new Uri("http://localhost:50123/api/");
            var response = await client.GetFromJsonAsync<IEnumerable<CandidateResponseModel>>(str);
            return Ok(response);

        }

        // // schdule interview for candidates inside the database
        // [HttpPost("ScheduleInterview")]
        // public async Task<IActionResult> ScheduleInterview([FromBody] InterviewsRequestModel interview)
        // {
        //     return Ok(await _interviewsService.ScheduleInterviewsAsync(interview));
        // }

    }
}

