using Microsoft.EntityFrameworkCore;
using PracticalTest.ClientModules;
using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public class AddStudentCourseRepository : IAddStudentCourse
    {
        private readonly StudentCourseContext _context;

        public AddStudentCourseRepository(StudentCourseContext context)
        {
            _context = context;
        }

        public String SaveStudentCourse(Student_CourseModel student_Course)
        {
            List<Student_CourseModel> StudentCourses = new List<Student_CourseModel>();

            StudentCourses = _context.Student_Course.Where(s => s.StudentId == student_Course.StudentId).ToList();
            int Count = 0;

            foreach (var scourse in StudentCourses)
            {
                Count++;
                if (Count >= 3)
                {
                    return "Student already registered for 3 courses";
                }
                else if (scourse.CourseId == student_Course.CourseId)
                {
                    return "Student already registered for selected course";
                }
            }

            _context.Add(student_Course);
            _context.SaveChanges();

            return "Student Successfully Registered";
        }

        public ViewModel GetView()
        {
            ViewModel myview = new ViewModel
            {
                Students = _context.Student.ToList(),
                Courses = _context.Course.ToList(),
                ViewData = _context.viewModelQuery.FromSql("GetStudentInfo").ToList(),
                CourseId = 0,
                StudentId = 0
            };
           
            return myview;
        }
    }
}
