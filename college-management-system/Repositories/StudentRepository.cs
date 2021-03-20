using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;

namespace CollegeManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeContext _context;

        public StudentRepository(CollegeContext collegeContext)
        {
            _context = collegeContext;
        }

        public List<Student> GetStudentList() => _context.Students.ToList();

        public Student GetStudentById(int studentId)
        {
            return _context.Students.SingleOrDefault(s => s.StudentId == studentId);
        }

        public void SaveStudent(Student student)
        {
            _context.Entry(student).State = student.StudentId == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Single(s => s.StudentId == studentId);
            if (student == null) throw new Exception("Error! Register not found!");
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}