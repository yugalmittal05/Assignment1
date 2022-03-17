
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

        //get All the departments list
        //[HttpGet("/")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            var model = _employeeRepository.GetDepartments();
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // get All the employees from the selected departments list
        [HttpGet("details")]
        public IActionResult Details(int deptId)
        {
            var model = _employeeRepository.GetEmployeesByDeptartmentId(deptId);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.deptId = deptId;
            return View(model);
        }

        //get the full details of the Employee
        [HttpGet("list")]
        public IActionResult List(int deptId, int empId)
        {
            var employee = _employeeRepository.GetEmployeeFullDetails(empId);
            if (employee == null)
            {
                return NotFound(empId);
            }
            ViewBag.deptId = deptId;
            return View(employee);
        }
    }
}
