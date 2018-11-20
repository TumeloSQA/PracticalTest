using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentCourseContext _context;
        
        public HomeController(StudentCourseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            ViewModel myview = new ViewModel
            {
                Students = _context.Student.ToList(),
                Courses = _context.Course.ToList(),
                ViewData = _context.viewModelQuery.FromSql("GetStudentInfo").ToList(),
                CourseId = 0,
                StudentId = 0
                
            };

            return View(myview);
        }

        [HttpPost]
        public IActionResult SaveStudentCourse()
        {

            //Student_CourseModel student_Course = new Student_CourseModel
            //{
            //    StudentId = viewM.StudentId,
            //    CourseId = viewM.CourseId
            //};
            return View("Index");
        }
    }
}
