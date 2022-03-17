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

        public Employees CreateEmployee(Employees employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Department CreateDept(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
            return dept;
        }

        public bool DeleteDepartment(int deptId)
        {
            var empCheck = context.Employees.Where(i => i.DepartmentId == deptId).Count();
            if(empCheck == 0)
            {
                var dept = context.Departments.Where(i => i.Id == deptId).First();
                context.Departments.Remove(dept);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Department> GetDepartments()
        {
            List<Department> deplist = new List<Department>();
            deplist = context.Departments.Select(s => new Department
            {
                Id = s.Id,
                DepartmentName = s.DepartmentName
            }).ToList();
            return deplist;
        }

        public Employees GetEmployee(int empId)
        {
            var emp = context.Employees.Find(empId);
            return emp;
        }

        public EmployeeDetailsViewModel GetEmployeeFullDetails(int id)
        {
            // var employee = context.Employees.Find(id);
            var employee = (from emp in context.Employees
                            join dept in context.Departments on emp.DepartmentId equals dept.Id
                            where(emp.Id == id)
                            select new
                            {
                                emp.Id,
                                emp.Name,
                                emp.City,
                                emp.Gender,
                                dept.DepartmentName
                            }).FirstOrDefault();

            var employeeDetails = new EmployeeDetailsViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                City = employee.City,
                Gender = employee.Gender.ToString(),
                DepartmentName = employee.DepartmentName
            };
            return employeeDetails;
        }

        public Employees UpdateEmployee(Employees employees)
        {
            var employee = context.Employees.Attach(employees);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employees;
        }

        public bool DeleteEmployee(int empId)
        {
            var emp = context.Employees.Where(i => i.Id== empId).FirstOrDefault();
            context.Employees.Remove(emp);
            context.SaveChanges();
            return true;
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
