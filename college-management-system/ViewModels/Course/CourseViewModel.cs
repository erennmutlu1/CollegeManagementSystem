using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CollegeManagementSystem.ViewModels.Teacher;

namespace CollegeManagementSystem.ViewModels.Course
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<TeacherViewModel> Teachers { get; set; }
    }
}