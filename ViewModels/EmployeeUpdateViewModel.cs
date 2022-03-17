using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.ViewModels
{
    public class EmployeeUpdateViewModel : EmployeeDetailsViewModel
    {
        public int deptId { get; set; }
        public  Gender Gen { get; set; }
       
    }
}
