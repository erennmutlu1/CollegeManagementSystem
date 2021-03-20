using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}