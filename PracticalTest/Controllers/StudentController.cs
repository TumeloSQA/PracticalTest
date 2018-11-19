using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentCourseContext _context;

        public StudentController(StudentCourseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Student.ToList());
        }
    }
}