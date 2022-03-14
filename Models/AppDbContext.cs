using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
  public class AppDbContext : DbContext
  {
    

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
      
    }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
  }
}
