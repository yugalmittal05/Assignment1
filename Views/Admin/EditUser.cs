using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Views.Admin
{
  public class EditUser : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
