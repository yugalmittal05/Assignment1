using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
  public class Employees
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string City { get; set; }
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    
    
  }
}

