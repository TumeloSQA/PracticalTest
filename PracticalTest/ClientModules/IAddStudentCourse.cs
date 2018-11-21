using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.ClientModules
{
    public interface IAddStudentCourse
    {
        string SaveStudentCourse(Student_CourseModel student_Course);
        ViewModel GetView();
    }
}
