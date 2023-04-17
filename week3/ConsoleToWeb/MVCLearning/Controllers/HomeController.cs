using System.Diagnostics;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVCLearning.Models;
using MVCLearning.UserRepo;

namespace MVCLearning.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // use the repositiory we create for the user
    private readonly IUserRepository _userRepository;

    //use the IOperation interface to inject the operation
    private readonly IOperationTransient _operationTransient;
    private readonly IOperationScoped _operationScoped;
    private readonly IOperationSingleton _operationSingleton;
    private readonly IOperationSingletonInstance _operationSingletonInstance;  


    // use of OperationService
    private readonly OperationService _operationService;


    // use of DepartmentRepository
    private readonly DepartmentRepository _departmentRepository;
 

    // in the constructor, we are going to inject the user repository
    // we call the IUserRepository interface inside the constructor, it is to tell the controller that these objects need to use this interface ,but we just didn't need to know what is the implementation of this interface
    public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IOperationTransient operationTransient, IOperationScoped operationScoped, IOperationSingleton operationSingleton, IOperationSingletonInstance operationSingletonInstance, OperationService operationService, DepartmentRepository departmentRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
        _operationTransient = operationTransient;
        _operationScoped = operationScoped;
        _operationSingleton = operationSingleton;
        _operationSingletonInstance = operationSingletonInstance;
        _operationService = operationService;
        _departmentRepository = departmentRepository;
    }


    public IActionResult Index()
    {
        // ViewBag.AnyValue = "Tihs is an item stored in the viewbag";
        var employeeList = new EmployeeListRequest()
        {
            Users = _userRepository.GetAllUsers()
        };
        // View is a method that returns a view, we input the model that we want to pass to the view
        return View(employeeList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult DependencyInjection()
    {
        // use ViewBag to pass the data from controller to view
        // we can not call function inside the viewbag in cshtml file, we need to call it in the controller here and pass it to the view
        ViewBag.Transient = _operationTransient.GetCurrentId();
        ViewBag.Scoped = _operationScoped.GetCurrentId();
        ViewBag.Singleton = _operationSingleton.GetCurrentId();
        ViewBag.SingletonInstance = _operationSingletonInstance.GetCurrentId();

        // use of OperationService
        ViewBag.TransientOperationService = _operationService._operationTransient.GetCurrentId();
        ViewBag.ScopedOperationService = _operationService._operationScoped.GetCurrentId();
        ViewBag.SingletonOperationService = _operationService._operationSingleton.GetCurrentId();
        ViewBag.SingletonInstanceOperationService = _operationService._operationSingletonInstance.GetCurrentId();
        return View();
    }

    // use of DepartmentRepository
    public IActionResult Department()
    {
        var departmentList = new DepartmentListRequest()
        {
            Depts = _departmentRepository.GetAll()
        };
        return View(departmentList);
    }


}

