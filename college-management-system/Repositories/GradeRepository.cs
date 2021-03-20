using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagementSystem.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly CollegeContext _context;

        public GradeRepository(CollegeContext collegeContext)
        {
            _context = collegeContext;
        }

        public List<Grade> GetGradeList() => _context.Grades.ToList();

        public List<Grade> GetGradesGrid()
        {
            return _context.Grades.Include(g => g.Student).Include(g => g.Subject)
                .ToList();
        }

        public Grade GetGradeById(int gradeId) => _context.Grades.SingleOrDefault(s => s.GradeId == gradeId);

        public void SaveGrade(Grade grade)
        {
            _context.Entry(grade).State = grade.GradeId == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGrade(int gradeId)
        {
            var Grade = _context.Grades.Single(s => s.GradeId == gradeId);
            if (Grade == null) throw new Exception("Error! Register not found!");
            _context.Grades.Remove(Grade);
            _context.SaveChanges();
        }
    }
}