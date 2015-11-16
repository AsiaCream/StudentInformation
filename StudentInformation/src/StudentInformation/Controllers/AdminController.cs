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
    public class AdminController : BaseController
    {
        [FromServices]
        public StudentContext DB { get; set; }
        [HttpGet]
        public IActionResult Details()
        {
            return PagedView(DB.Students,10);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       [HttpPost]
       public IActionResult Create(Student Student)
        {
            DB.Students.Add(Student);
            DB.SaveChanges();
            return RedirectToAction("Details", "Admin");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = DB.Students
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (student == null)
                return Content("没有找到该记录");
            else
                return View(student);
        }
       [HttpPost]
       public IActionResult Edit(int id,Student student)
        {
            var s = DB.Students
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (s == null)
                return Content("没有找到该记录");
            s.Name = student.Name;
            s.Sex = student.Sex;
            s.Age = student.Age;
            s.Class = student.Class;
            s.Address = student.Address;
            DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var student = DB.Students
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.Students.Remove(student);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("Details", "Admin");
        }
    }
}
