using CollegeManagementSystem.ViewModels.Student;
using CollegeManagementSystem.ViewModels.Subject;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CollegeManagementSystem.ViewModels.Enrollment
{
    public class EnrollmentViewModel
    {
        public int EnrollmentId { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> SubjectList { get; set; }

        public SubjectViewModel Subject { get; set; }
        public StudentViewModel Student { get; set; }
    }
}