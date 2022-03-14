using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.ViewModels
{
  public class EmployeeDetailsViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string City { get; set; }
    public int? DepartmentId { get; set; }
    public string DepartmentName { get; set; }
  }
}
