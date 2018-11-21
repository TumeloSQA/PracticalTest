using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.ClientModules
{
    public interface IAddCourse
    {
        string SaveCourse(CourseModel course);
    }
}
