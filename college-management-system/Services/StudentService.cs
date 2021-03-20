using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Student;
using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository repository)
        {
            _studentRepository = repository;
        }

        public StudentViewModel GetNewStudent(int? studentId = null)
        {
            return new StudentViewModel
            {
                StudentId = studentId.GetValueOrDefault()
            };
        }

        public List<StudentViewModel> GetStudentList()
        {
            return Mapper.Map<List<Student>, List<StudentViewModel>>(_studentRepository.GetStudentList());
        }

        public StudentListViewModel GetStudents()
        {
            var students = Mapper.Map<List<Student>, List<StudentViewModel>>(_studentRepository.GetStudentList());
            return new StudentListViewModel
            {
                Students = students
            };
        }

        public StudentViewModel GetStudentById(int studentId) =>
            Mapper.Map<Student, StudentViewModel>(_studentRepository.GetStudentById(studentId));

        public void SaveStudent(StudentViewModel viewModel)
        {
            try
            {
                var student = Mapper.Map<StudentViewModel, Student>(viewModel);
                _studentRepository.SaveStudent(student);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred when was trying to save the data");
            }
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                _studentRepository.DeleteStudent(studentId);
            }
            catch (Exception)
            {
                throw new Exception("An unexpected error occurred when was trying to remove this data");
            }
        }
    }
}