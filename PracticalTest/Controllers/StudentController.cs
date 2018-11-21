using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.ClientModules;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class StudentController : Controller
    {
        private readonly IAddStudent _student;

        public StudentController(IAddStudent student)
        {
            _student = student;
        }

        public IActionResult Index()
        {
            var t = TempData["Message"];
            if (t != null)
            {
                ViewBag.Message = t;
            }
            return View();
        }

        public IActionResult SaveStudent()
        {
            StudentModel smodel = new StudentModel
            {
                FirstName = HttpContext.Request.Form["Firstname"].ToString(),
                Surname = HttpContext.Request.Form["Surname"].ToString(),
                EmailAddress = HttpContext.Request.Form["EmailAddress"].ToString(),
                IDNumber = HttpContext.Request.Form["IDNumber"].ToString()
            };

            string result = _student.SaveStudent(smodel);
            TempData["Message"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult Alert()
        {
            return RedirectToAction("Index");
        }
    }
}