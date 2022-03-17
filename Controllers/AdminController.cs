using Assignment1.Models;
using Assignment1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AdminController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

       
        //create Department
        [HttpGet("CreateDept")]
        public IActionResult CreateDept()
        {
            return View();
        }

        [HttpPost("CreateDept")]
        public IActionResult CreateDept(Department dept)
        {
            var newDept = _employeeRepository.CreateDept(dept);
            return RedirectToAction("index", "home");

        }

        [HttpGet("deleteDept")]
        public ActionResult DeleteDept(int deptId)
        {
            bool checkStatus =  _employeeRepository.DeleteDepartment(deptId);
            if(checkStatus == true)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                Response.StatusCode = 403;
                return RedirectToAction("index", "home");
            }
            
        }

        //create Employee
        [HttpGet("/")]
        [HttpGet("Create")]
        public IActionResult Create(int? deptId)
        {
            ViewBag.deptId = deptId;
            ViewBag.message = deptList();
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(EmployeeCreateViewModel employee)
        {
            Employees model = new Employees
            {
                Name = employee.Name,
                City = employee.City,
                Gender = employee.Gender.ToString(),
                DepartmentId = employee.deptId
            };
            _employeeRepository.CreateEmployee(model);
            return RedirectToAction("list", "home", new {deptId = model.DepartmentId,empId= model.Id});
        }

        //delete Employee
        [HttpGet("delete")]
        public ActionResult Delete(int deptId, int empId)
        {
            _employeeRepository.DeleteEmployee(empId);
            return RedirectToAction("details", "home", new { deptId = deptId });
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int deptId, int empId)
        {
            var empDetails = _employeeRepository.GetEmployeeFullDetails(empId);
            EmployeeUpdateViewModel detailsViewModel = new EmployeeUpdateViewModel
            {
                Id = empDetails.Id,
                Name = empDetails.Name,
                City = empDetails.City,
                Gender = empDetails.Gender,
                DepartmentName = empDetails.DepartmentName,
            };
            ViewBag.deptId = deptId;
            ViewBag.message = deptList();
            return View(detailsViewModel);
        }

        [HttpPost("edit")]
        public IActionResult Edit(EmployeeUpdateViewModel model)
        {
            Employees employee = _employeeRepository.GetEmployee(model.Id);
            employee.Name = model.Name;
            employee.City = model.City;
            employee.Gender = model.Gen.ToString();
            employee.DepartmentId = model.deptId;
            _employeeRepository.UpdateEmployee(employee);
            return RedirectToAction("list", "home", new { deptId = model.deptId, empId = model.Id });
        }

        // to get department List 
        public IList deptList()
        {
            List<Department> deptList = new List<Department>();
            deptList = _employeeRepository.GetDepartments();
            return deptList;
        }
    }
}
