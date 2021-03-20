using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<SubjectCourse> SubjectCourses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}