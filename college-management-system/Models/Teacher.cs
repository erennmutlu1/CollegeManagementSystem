using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
    public class Teacher
    {
        [Key] 
        public int TeacherId { get; set; }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
    }
}