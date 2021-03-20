using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagementSystem.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeContext _context;

        public CourseRepository(CollegeContext collegeContext)
        {
            _context = collegeContext;
        }

        public List<Course> GetCourseList() => _context.Courses.ToList();

        public Course GetCourseById(int courseId)
        {
            return _context.Courses.SingleOrDefault(s => s.CourseId == courseId);
        }

        public void SaveCourse(Course course)
        {
            _context.Entry(course).State = course.CourseId == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            var course = _context.Courses.Single(s => s.CourseId == courseId);
            if (course == null) throw new Exception("Error! Register not found!");
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}