using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Teacher;
using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository repository)
        {
            _teacherRepository = repository;
        }

        public TeacherViewModel GetNewTeacher(int? teacherId)
        {
            return new TeacherViewModel
            {
                TeacherId = teacherId.GetValueOrDefault()
            };
        }

        public List<TeacherViewModel> GetTeacherList()
        {
            return Mapper.Map<List<Teacher>, List<TeacherViewModel>>(_teacherRepository.GetTeacherList());
        }

        public TeacherListViewModel GetTeachers()
        {
            var teachers = Mapper.Map<List<Teacher>, List<TeacherViewModel>>(_teacherRepository.GetTeacherList());
            return new TeacherListViewModel
            {
                Teachers = teachers
            };
        }

        public TeacherViewModel GetTeacherById(int teacherId) =>
            Mapper.Map<Teacher, TeacherViewModel>(_teacherRepository.GetTeacherById(teacherId));

        public void SaveTeacher(TeacherViewModel viewModel)
        {
            try
            {
                var teacher = Mapper.Map<TeacherViewModel, Teacher>(viewModel);
                _teacherRepository.SaveTeacher(teacher);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred when was trying to save the data");
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            try
            {
                _teacherRepository.DeleteTeacher(teacherId);
            }
            catch (Exception)
            {
                throw new Exception("An unexpected error occurred when was trying to remove this data");
            }
        }
    }
}