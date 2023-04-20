using System;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMMVC.Controllers
{
    public class JobRequirementController : Controller
    {
        private readonly IJobRequirementService _jobRequirementService;
        private readonly ILogger<JobRequirementController> _logger;
        public JobRequirementController(IJobRequirementService jobRequirementService, ILogger<JobRequirementController> logger)
        {
            _jobRequirementService = jobRequirementService;
            _logger = logger;
        }
        // GET: JobRequirementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobRequirementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobRequirementController/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(JobRequirementRequestModel model)
        //{
        //    //async service is needed
        //    if (!ModelState.IsValid)
        //    {
        //        var error = ModelState.Values.SelectMany(x => x.Errors).ToList();
        //        foreach (var item in error)
        //        {
        //            logger.LogError(item.ErrorMessage);
        //        }
        //    }
        //    return RedirectToAction("Submitted");
        //}

        [HttpPost]
        public async Task<IActionResult> Create(JobRequirementRequestModel model)
        {
            if (model != null)
            {
                await _jobRequirementService.AddJobRequirementAsync(model);
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Submitted()
        {
            return View();
        }

        // GET: JobRequirementController/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: JobRequirementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobRequirementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobRequirementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

