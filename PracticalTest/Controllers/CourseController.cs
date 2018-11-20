using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentCourseContext _context;

        public CourseController(StudentCourseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SaveCourse()
        {
            CourseModel cmodel = new CourseModel
            {
                CourseName = HttpContext.Request.Form["CourseName"].ToString(),
                StartDate = DateTime.Parse(HttpContext.Request.Form["StartDate"].ToString()),
                EndDate = DateTime.Parse(HttpContext.Request.Form["EndDate"].ToString())
            };

            if(cmodel.CourseName != null && cmodel.StartDate < cmodel.EndDate)
            {
                _context.Add(cmodel);
                _context.SaveChanges();
            }
            else
            {
                return View("Index");
            }
            
            return View("Index");
        }
    }
}