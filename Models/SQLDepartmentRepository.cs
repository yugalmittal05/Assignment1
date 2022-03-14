using Assignment1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
  public class SQLDepartmentRepository : IEmployeeRepository
  {
    private readonly AppDbContext context;

    public SQLDepartmentRepository(AppDbContext context)
    {
      this.context = context;
    }
    public IEnumerable<Department> GetDepartments()
    {
      return context.Departments;
    }

    public EmployeeDetailsViewModel GetEmployeeFullDetails(int id)
    {
      // var employee = context.Employees.Find(id);
      var employee = (from emp in context.Employees join dept in context.Departments on
                      emp.DepartmentId  equals dept.Id where
                     (emp.Id==id) select new
                    {
                      emp.Id,
                      emp.Name,
                      emp.City,
                      emp.Gender,
                      emp.DepartmentId,
                      dept.DepartmentName
                    }).FirstOrDefault();

      //var employee = result.Where(e => e.Id == id).FirstOrDefault();

      EmployeeDetailsViewModel employeeDetails = new EmployeeDetailsViewModel
      {
        Id = employee.Id,
        Name = employee.Name,
        City = employee.City,
        Gender = employee.Gender,
        DepartmentId = employee.DepartmentId,
        DepartmentName = employee.DepartmentName
      };
      return employeeDetails;
    }

    public IEnumerable<Employees> GetEmployeesByDeptartmentId(int id)
    {
      var employee = context.Employees.Where(dept => dept.DepartmentId == id)
        .Select(emp => new Employees
        {
          Id = emp.Id,
          Name = emp.Name,
          DepartmentId = emp.DepartmentId
        }).ToList();
      return employee;
    }
  }
}
