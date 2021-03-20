using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class SubjectCourse
    {
        [Key] 
        public int SubjectCourseId { get; set; }

        public int SubjectId { get; set; }
        public int CourseId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Course Course { get; set; }
    }
}