using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollegeManagementSystem.ViewModels.Teacher;

namespace CollegeManagementSystem.ViewModels.Subject
{
    public class SubjectListViewModel
    {
        public List<SubjectViewModel> Subjects { get; set; }
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }



    }
}