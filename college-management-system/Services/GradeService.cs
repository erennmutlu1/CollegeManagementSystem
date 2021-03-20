using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Grade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;

namespace CollegeManagementSystem.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeGradeRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;

        public GradeService(IGradeRepository gradeRepository,
            ISubjectRepository subjectRepository, IStudentRepository studentRepository)
        {
            _gradeGradeRepository = gradeRepository;
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
        }

        public GradeViewModel GetNewGrade(int? gradeId = null, int? studentId = null, int? subjectId = null)
        {
            var studentList = _studentRepository.GetStudentList();
            var subjectList = _subjectRepository.GetSubjectList();
            return new GradeViewModel
            {
                GradeId = gradeId.GetValueOrDefault(),
                StudentId = studentId.GetValueOrDefault(),
                SubjectId = subjectId.GetValueOrDefault(),
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

        public List<GradeViewModel> GetGradeList()
        {
            return Mapper.Map<List<Grade>, List<GradeViewModel>>(_gradeGradeRepository.GetGradeList());
        }

        public GradeListViewModel GetGradesGrid()
        {
            var grades = Mapper.Map<List<Grade>, List<GradeViewModel>>(_gradeGradeRepository.GetGradesGrid());
            return new GradeListViewModel
            {
                Grades = grades
            };
        }

        public GradeViewModel GetGradeById(int gradeId)
        {
            var studentList = _studentRepository.GetStudentList();
            var subjectList = _subjectRepository.GetSubjectList();
            var grade = Mapper.Map<Grade, GradeViewModel>(_gradeGradeRepository.GetGradeById(gradeId));
            grade.StudentList = studentList.Select(s => new SelectListItem
            {
                Value = s.StudentId.ToString(),
                Text = s.Name
            });
            grade.SubjectList = subjectList.Select(s => new SelectListItem
            {
                Value = s.SubjectId.ToString(),
                Text = s.Title
            });
            return grade;
        }
            
        public void SaveGrade(GradeViewModel viewModel)
        {
            try
            {
                var grade = Mapper.Map<GradeViewModel, Grade>(viewModel);
                _gradeGradeRepository.SaveGrade(grade);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred when was trying to save the data");
            }
        }

        public void DeleteGrade(int gradeId)
        {
            try
            {
                _gradeGradeRepository.DeleteGrade(gradeId);
            }
            catch (Exception)
            {
                throw new Exception("An unexpected error occurred when was trying to remove this data");
            }
        }
    }
}