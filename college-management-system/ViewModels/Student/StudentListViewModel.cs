using CollegeManagementSystem.ViewModels.Enrollment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.ViewModels.Student
{
    public class StudentListViewModel
    {
        public List<StudentViewModel> Students;
        public int StudentId { get; set; }

        [Display(Name = "Registration Number")]
        public int RegistrationNumber { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public virtual ICollection<EnrollmentViewModel> Enrollments { get; set; }
    }
}