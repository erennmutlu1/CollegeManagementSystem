using CollegeManagementSystem.ViewModels;
using System.Collections.Generic;
using CollegeManagementSystem.ViewModels.Teacher;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface ITeacherService
    {
        TeacherViewModel GetNewTeacher(int? TeacherId = null);

        List<TeacherViewModel> GetTeacherList();

        TeacherListViewModel GetTeachers();

        TeacherViewModel GetTeacherById(int TeacherId);

        void SaveTeacher(TeacherViewModel viewModel);

        void DeleteTeacher(int TeacherId);
    }
}