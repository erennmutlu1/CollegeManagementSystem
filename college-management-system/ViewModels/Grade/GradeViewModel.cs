using CollegeManagementSystem.ViewModels.Student;
using CollegeManagementSystem.ViewModels.Subject;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CollegeManagementSystem.ViewModels.Grade
{
    public class GradeViewModel
    {
        public int GradeId { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        [Display(Name = "Grade")]
        public double? GradeValue { get; set; }

        [Display(Name = "Situation")]
        public string Observation { get; set; }

        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> SubjectList { get; set; }

        public SubjectViewModel Subject { get; set; }
        public StudentViewModel Student { get; set; }
    }
}