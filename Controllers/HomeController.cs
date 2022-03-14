using Assignment1.Models;
using Assignment1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Assignment1.Controllers
{
  [Route("[Controller]")]
  public class HomeController : Controller
  {
    private readonly IEmployeeRepository _employeeRepository;

    public HomeController(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }
    
    [HttpGet("/")]
    public IActionResult Index()
    {
      var model = _employeeRepository.GetDepartments();
      return View(model);
    }

    [HttpGet("details/{id?}")]
    public IActionResult Details(int id)
    {
      var model = _employeeRepository.GetEmployeesByDeptartmentId(id);
      return View(model);
    }

    [HttpGet("list/{id?}")]
    public IActionResult List(int id)
    {
      EmployeeDetailsViewModel employee = _employeeRepository.GetEmployeeFullDetails(id);
      
      return View(employee);
    }
  }
}
