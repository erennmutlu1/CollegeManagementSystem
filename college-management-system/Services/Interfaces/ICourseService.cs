using CollegeManagementSystem.ViewModels.Course;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface ICourseService
    {
        CourseViewModel GetNewCourse(int? courseId = null);

        List<CourseViewModel> GetCourseList();

        CourseListViewModel GetCourses();

        CourseViewModel GetCourseById(int courseId);

        void SaveCourse(CourseViewModel viewModel);

        void DeleteCourse(int courseId);
    }
}