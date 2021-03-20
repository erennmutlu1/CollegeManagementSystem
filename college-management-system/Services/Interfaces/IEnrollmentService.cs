using CollegeManagementSystem.ViewModels.Enrollment;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface IEnrollmentService
    {
        EnrollmentViewModel GetNewEnrollment(int? enrollmentId = null, int? studentId = null);

        List<EnrollmentViewModel> GetEnrollmentList();

        EnrollmentListViewModel GetEnrollmentsGrid();

        EnrollmentViewModel GetEnrollmentById(int enrollmentId);

        void SaveEnrollment(EnrollmentViewModel viewModel);

        void DeleteEnrollment(int enrollmentId);
    }
}