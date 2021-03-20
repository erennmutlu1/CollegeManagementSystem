using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.ViewModels.Teacher
{
    public class TeacherListViewModel
    {
        public List<TeacherViewModel> Teachers;

        public int TeacherId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }
    }
}