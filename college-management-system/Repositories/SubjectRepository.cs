using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagementSystem.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CollegeContext _context;

        public SubjectRepository(CollegeContext collegeContext)
        {
            _context = collegeContext;
        }

        public List<Subject> GetSubjectList() => _context.Subjects.OrderBy(s => s.Title).ToList();

        public List<Subject> GetSubjectsGrid()
        {
            var subjects = _context.Subjects.Include(s => s.Teacher).OrderBy(s => s.Title).ToList();
            return subjects;
        }

        public Subject GetSubjectById(int subjectId)
        {
            return _context.Subjects.SingleOrDefault(x => x.SubjectId == subjectId);
        }

        public void SaveSubject(Subject subject)
        {
            _context.Entry(subject).State = subject.SubjectId == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteSubject(int subjectId)
        {
            var subject = _context.Subjects.Single(x => x.SubjectId == subjectId);
            if (subject == null) throw new Exception("Error! Register not found!");
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }
    }
}