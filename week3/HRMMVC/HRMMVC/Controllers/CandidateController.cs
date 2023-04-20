using System;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using HRMMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMMVC.Controllers
{
    public class CandidateController : Controller
    {
        // GET: CandidateController
        public async Task<IActionResult> Index()
        {
            return View();
        }
        private readonly ICandidateService _candidateService;
        private readonly ILogger _logger;

        public CandidateController(ICandidateService candidateService, ILogger<CandidateController> logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> AllDetails()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return View(candidates);
        }
        [HttpGet]
        public async Task<ActionResult<CandidateResponseModel>> Details(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            return View(candidate);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            //try
            //{
            if (model != null)
            {
                await _candidateService.AddCandidateAsync(model);
                return View(model);
            }
            return View();
            //}
            //catch(Exception ex) 
            //{
            //    _logger.LogCritical(ex, "In create of Candidate Controller");
            //    return View();
            //}
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new { Message = "deleted" };
            if (await _candidateService.DeleteCandidateAsync(id) > 0)
                return View(response);
            return View();
        }
        [HttpPut]
        public async Task<IActionResult> Update(CandidateRequestModel model)
        {
            var response = new { Message = "Candidate is updated" };
            if (await _candidateService.UpdateCandidateAsync(model) > 0)
                return View(response);
            return View();
        }
    }
}

