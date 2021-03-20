using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeManagementSystem.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly CollegeContext _context;

        public EnrollmentRepository(CollegeContext collegeContext)
        {
            _context = collegeContext;
        }

        public List<Enrollment> GetEnrollmentList() => _context.Enrollments.ToList();

        public List<Enrollment> GetEnrollmentsGrid()
        {
            var enrollments =  _context.Enrollments.Include(e => e.Student).Include(e => e.Subject)
                .Include(x => x.Grades)
                .OrderBy(e => e.Student.Name)
                .ToList();
            return enrollments;
        }

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            return _context.Enrollments.SingleOrDefault(s => s.EnrollmentId == enrollmentId);
        }

        public void SaveEnrollment(Enrollment enrollment)
        {
            _context.Entry(enrollment).State = enrollment.EnrollmentId == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            var enrollment = _context.Enrollments.Single(s => s.EnrollmentId == enrollmentId);
            if (enrollment == null) throw new Exception("Error! Register not found!");
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
        }
    }
}