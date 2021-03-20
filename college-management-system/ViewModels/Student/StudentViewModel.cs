using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.ViewModels.Enrollment;

namespace CollegeManagementSystem.ViewModels.Student
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public int? RegistrationNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        public virtual ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
}