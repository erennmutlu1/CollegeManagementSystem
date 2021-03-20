using CollegeManagementSystem.ViewModels.Teacher;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CollegeManagementSystem.ViewModels.Subject
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int? Credits { get; set; }

        [Display(Name = "Teacher")]
        [Required]
        public int TeacherId { get; set; }

        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> TeacherList { get; set; }
        public TeacherViewModel Teacher { get; set; }

        //public virtual ICollection<SubjectCourse> SubjectCourses { get; set; }
    }
}