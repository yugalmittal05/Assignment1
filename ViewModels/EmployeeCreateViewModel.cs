using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.ViewModels
{
    public class EmployeeCreateViewModel 
    {
      
        public int empId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public int deptId { get; set; }
        public List<Dep_List> DepartmentList { get; set; }
    }
    public class Dep_List
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
