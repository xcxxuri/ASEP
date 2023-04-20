using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HRMMVC.Models;
using Serilog;
using HRMMVC.Filters;

namespace HRMMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // use Serilog
    private readonly Serilog.ILogger _serilogLogger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // use Serilog to log to console
        _serilogLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(CandidateRequestModel model)
    {
        //var entityResponseModel = new CandidateResponseModel();
        //return View(entityResponseModel);
        return View();
    }
    // use SomeFilter to redirect to another action
    [TypeFilter(typeof(SomeFilter))]
    public IActionResult Privacy()
    {
        // use built in logger
        // _logger.LogInformation("Privacy page visited");

        // use Serilog
        Log.Information("Privacy page visited");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

