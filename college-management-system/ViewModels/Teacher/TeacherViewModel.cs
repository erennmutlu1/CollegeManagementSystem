using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.ViewModels.Teacher
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
    }
}