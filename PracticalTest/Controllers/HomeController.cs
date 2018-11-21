using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticalTest.ClientModules;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddStudentCourse _course;
        
        public HomeController(IAddStudentCourse course)
        {
            _course = course;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewModel myview = _course.GetView();
            var t = TempData["Message"];
            if (t != null)
            {
                ViewBag.Message = t;
            }

            return View(myview);
        }


        [HttpPost]
        public IActionResult Index(ViewModel view)
        {
            Student_CourseModel scModel = new Student_CourseModel
            {
                CourseId = view.CourseId,
                StudentId = view.StudentId
            };
            string result = _course.SaveStudentCourse(scModel);
            TempData["Message"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult Alert()
        {
            return RedirectToAction("Index");
        }
    }
}
