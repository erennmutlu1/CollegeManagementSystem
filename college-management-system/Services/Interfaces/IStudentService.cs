using CollegeManagementSystem.ViewModels;
using System.Collections.Generic;
using CollegeManagementSystem.ViewModels.Student;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface IStudentService
    {
        StudentViewModel GetNewStudent(int? StudentId = null);

        List<StudentViewModel> GetStudentList();

        StudentListViewModel GetStudents();

        StudentViewModel GetStudentById(int studentId);

        void SaveStudent(StudentViewModel viewModel);

        void DeleteStudent(int studentId);
    }
}