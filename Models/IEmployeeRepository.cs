using Assignment1.ViewModels;
using System.Collections.Generic;

namespace Assignment1.Models
{
    public interface IEmployeeRepository
    {
        public Employees CreateEmployee(Employees employee);
        public Employees UpdateEmployee(Employees employee);
        public bool DeleteEmployee(int id);
        public bool DeleteDepartment(int id);
        public Department CreateDept(Department dept);
        public List<Department> GetDepartments();
        public IEnumerable<Employees> GetEmployeesByDeptartmentId(int id);
        public EmployeeDetailsViewModel GetEmployeeFullDetails(int id);
        public Employees GetEmployee(int id);
    }
}
