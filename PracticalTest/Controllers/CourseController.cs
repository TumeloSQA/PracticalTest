using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.ClientModules;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly IAddCourse _course;

        public CourseController(IAddCourse course)
        {
            _course = course;
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

        public IActionResult SaveCourse()
        {
            try
            {
                CourseModel cmodel = new CourseModel
                {
                    CourseName = HttpContext.Request.Form["CourseName"].ToString(),
                    StartDate = DateTime.Parse(HttpContext.Request.Form["StartDate"].ToString()).Date,
                    EndDate = DateTime.Parse(HttpContext.Request.Form["EndDate"].ToString()).Date
                };
                string res = _course.SaveCourse(cmodel);
                TempData["Message"] = res;
                return RedirectToAction("Index");
            }
            catch(FormatException)
            {
                string result = "Invalid Date. Please use 'yyyy-mm-dd' format";
                TempData["Message"] = result;
                return RedirectToAction("Index");
            }    
        }

        public IActionResult Alert()
        {
            return RedirectToAction("Index");
        }
    }
}