using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.Models
{
    public class ViewModel
    {
        public IEnumerable<ViewDataModel> ViewData { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<CourseModel> Courses { get; set; }
    }
}
