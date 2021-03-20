using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollmentList();
        List<Enrollment> GetEnrollmentsGrid();
        Enrollment GetEnrollmentById(int enrollmentId);
        void SaveEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int enrollmentId);
    }
}
