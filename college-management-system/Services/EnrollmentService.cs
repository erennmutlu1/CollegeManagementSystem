using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CollegeManagementSystem.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentEnrollmentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository,
            ISubjectRepository subjectRepository, IStudentRepository studentRepository )
        {
            _enrollmentEnrollmentRepository = enrollmentRepository;
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
        }

        public EnrollmentViewModel GetNewEnrollment(int? enrollmentId = null, int? studentId = null)
        {
            var studentList = _studentRepository.GetStudentList();
            var subjectList = _subjectRepository.GetSubjectList();
            return new EnrollmentViewModel
            {
                EnrollmentId = enrollmentId.GetValueOrDefault(),
                StudentId = studentId.GetValueOrDefault(),
                StudentList = studentList.Select(s => new SelectListItem
                {
                    Value = s.StudentId.ToString(),
                    Text = s.Name
                }),
                 SubjectList = subjectList.Select(s => new SelectListItem
                 {
                     Value = s.SubjectId.ToString(),
                     Text = s.Title
                 }),

            };
        }

        public List<EnrollmentViewModel> GetEnrollmentList()
        {
            return Mapper.Map<List<Enrollment>, List<EnrollmentViewModel>>(_enrollmentEnrollmentRepository.GetEnrollmentList());
        }

        public EnrollmentListViewModel GetEnrollmentsGrid()
        {
            var enrollments = Mapper.Map<List<Enrollment>, List<EnrollmentViewModel>>(_enrollmentEnrollmentRepository.GetEnrollmentsGrid());
            return new EnrollmentListViewModel
            {
                Enrollments = enrollments
            };
        }

        public EnrollmentViewModel GetEnrollmentById(int enrollmentId) =>
            Mapper.Map<Enrollment, EnrollmentViewModel>(_enrollmentEnrollmentRepository.GetEnrollmentById(enrollmentId));

        public void SaveEnrollment(EnrollmentViewModel viewModel)
        {
            try
            {
                var enrollment = Mapper.Map<EnrollmentViewModel, Enrollment>(viewModel);
                _enrollmentEnrollmentRepository.SaveEnrollment(enrollment);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while trying to save the data");
            }
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            try
            {
                _enrollmentEnrollmentRepository.DeleteEnrollment(enrollmentId);
            }
            catch (Exception)
            {
                throw new Exception("An unexpected error occurred when was trying to remove this data");
            }
        }
    }
}