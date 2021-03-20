using CollegeManagementSystem.Models;
using System.Collections.Generic;

namespace CollegeManagementSystem.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        List<Course> GetCourseList();
        Course GetCourseById(int courseId);
        void SaveCourse(Course course);
        void DeleteCourse(int courseId);
    }
}