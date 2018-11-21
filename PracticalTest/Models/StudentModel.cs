using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string IDNumber { get; set; }

        public string FullName { get { return FirstName + " " + Surname; } }
        public ICollection<Student_CourseModel> Student_Courses { get; set; }
    }
}
