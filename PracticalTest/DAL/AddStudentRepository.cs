using Microsoft.EntityFrameworkCore;
using PracticalTest.ClientModules;
using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public class AddStudentRepository : IAddStudent
    {
        private readonly StudentCourseContext _context;

        public AddStudentRepository(StudentCourseContext context)
        {
            _context = context;
        }

        public string SaveStudent(StudentModel student)
        {
            List<StudentModel> sList = new List<StudentModel>();
            sList = _context.Student.ToList();
            if (student.FirstName == null || student.Surname == null)
            {
                return "Please Enter Student Details";
            }
            foreach (var currStudent in sList)
            {
                if (currStudent.FirstName == student.FirstName && currStudent.Surname == student.Surname)
                {
                    return "Student Already Listed";
                }
            }

            _context.Add(student);
            _context.SaveChanges();
            return "Student Added Successfully";
        }
    }
}
