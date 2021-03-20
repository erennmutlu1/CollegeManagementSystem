using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public int RegistrationNumber { get; set; }

        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}