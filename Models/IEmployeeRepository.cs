using Assignment1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
  public interface IEmployeeRepository
  {
    IEnumerable<Department> GetDepartments();
    IEnumerable<Employees> GetEmployeesByDeptartmentId(int id);
    EmployeeDetailsViewModel GetEmployeeFullDetails(int id);
  }
}
