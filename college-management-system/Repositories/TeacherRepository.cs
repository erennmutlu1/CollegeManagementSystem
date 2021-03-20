using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;

namespace CollegeManagementSystem.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly CollegeContext _context;

        public TeacherRepository(CollegeContext collegeContext)
        {
            _context = collegeContext;
        }

        public List<Teacher> GetTeacherList() => _context.Teachers.ToList();

        public Teacher GetTeacherById(int teacherId)
        {
            return _context.Teachers.SingleOrDefault(x => x.TeacherId == teacherId);
        }

        public void SaveTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State = teacher.TeacherId == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTeacher(int teacherId)
        {
            var teacher = _context.Teachers.Single(x => x.TeacherId == teacherId);
            if (teacher == null) throw new Exception("Error! Register not found!");
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }
    }
}