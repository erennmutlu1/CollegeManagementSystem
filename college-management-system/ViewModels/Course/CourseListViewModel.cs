using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.ViewModels.Course
{
    public class CourseListViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }
}