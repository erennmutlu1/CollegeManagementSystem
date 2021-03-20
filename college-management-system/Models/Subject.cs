using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class Subject
    {
        [Key] 
        public int SubjectId { get; set; }

        public string Title { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<SubjectCourse> SubjectCourses { get; set; }
    }
}