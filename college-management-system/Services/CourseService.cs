using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using CollegeManagementSystem.ViewModels.Course;
using System;
using System.Collections.Generic;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository repository)
        {
            _courseRepository = repository;
        }

        public CourseViewModel GetNewCourse(int? courseId = null)
        {
            return new CourseViewModel
            {
                CourseId = courseId.GetValueOrDefault()
            };
        }

        public List<CourseViewModel> GetCourseList()
        {
            return Mapper.Map<List<Course>, List<CourseViewModel>>(_courseRepository.GetCourseList());
        }

        public CourseListViewModel GetCourses()
        {
            var Courses = Mapper.Map<List<Course>, List<CourseViewModel>>(_courseRepository.GetCourseList());
            return new CourseListViewModel
            {
                Courses = Courses
            };
        }

        public CourseViewModel GetCourseById(int courseId) =>
            Mapper.Map<Course, CourseViewModel>(_courseRepository.GetCourseById(courseId));

        public void SaveCourse(CourseViewModel viewModel)
        {
            try
            {
                var Course = Mapper.Map<CourseViewModel, Course>(viewModel);
                _courseRepository.SaveCourse(Course);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred when was trying to save the data");
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                _courseRepository.DeleteCourse(courseId);
            }
            catch (Exception)
            {
                throw new Exception("An unexpected error occurred when was trying to remove this data");
            }
        }
    }
}