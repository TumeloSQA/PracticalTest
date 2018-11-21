using PracticalTest.ClientModules;
using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public class AddCourseRepository : IAddCourse
    {
        private readonly StudentCourseContext _context;

        public AddCourseRepository(StudentCourseContext context)
        {
            _context = context;
        }

        public string SaveCourse(CourseModel course)
        {
            List<CourseModel> allCourses = new List<CourseModel>();
            allCourses = _context.Course.ToList();
            if (course.CourseName == null || course.StartDate >= course.EndDate)
            {
                return "Please Enter Valid Course Details";
            }
            foreach(var currCourse in allCourses)
            {
                if (currCourse.CourseName == course.CourseName)
                {
                    return "Course Already Listed";
                }
            }
            _context.Add(course);
            _context.SaveChanges();
            return "Course Successfully Added";
        }
    }
}
