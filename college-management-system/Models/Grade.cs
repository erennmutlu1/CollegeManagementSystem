using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class Grade
    {
        [Key] 
        public int GradeId { get; set; }

        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public double GradeValue { get; set; }
        public string Observation { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}