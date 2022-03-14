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

    [HttpGet("details/{deptId?}")]
    public IActionResult Details(int deptId)
    {
      var model = _employeeRepository.GetEmployeesByDeptartmentId(deptId);
      return View(model);
    }

    [HttpGet("list/{deptId?}/{empId?}")]
    public IActionResult List(int deptId,int empId)
    {
      EmployeeDetailsViewModel employee = _employeeRepository.GetEmployeeFullDetails(empId);
      
      return View(employee);
    }
  }
}
