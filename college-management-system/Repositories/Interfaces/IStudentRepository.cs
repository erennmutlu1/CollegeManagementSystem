using System.Collections.Generic;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetStudentList();
        Student GetStudentById(int studentId);
        void SaveStudent(Student student);
        void DeleteStudent(int studentId);
    }
}
