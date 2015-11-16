using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StudentInformation.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInformation.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        [FromServices]
        public StudentContext DB { get; set; }
        
        public IActionResult Index()
        {
            var ret = DB.Students.ToList();
            return View(ret);
        }
    }
}
