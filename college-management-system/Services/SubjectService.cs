using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repositories.Interfaces;
using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CollegeManagementSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public SubjectService(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository)
        {
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
        }

        public SubjectViewModel GetNewSubject(int? subjectId = null)
        {
            var teacherList = _teacherRepository.GetTeacherList();
            return new SubjectViewModel
            {
                SubjectId = subjectId.GetValueOrDefault(),
                TeacherList =  teacherList.Select(s => new SelectListItem
                {
                    Value = s.TeacherId.ToString(),
                    Text = s.Name
                })
            };
        }

        public List<SubjectViewModel> GetSubjectList()
        {
            return Mapper.Map<List<Subject>, List<SubjectViewModel>>(_subjectRepository.GetSubjectList());
        }

        public SubjectListViewModel GetSubjectsGrid()
        {
            var subjects = Mapper.Map<List<Subject>, List<SubjectViewModel>>(_subjectRepository.GetSubjectsGrid());
            return new SubjectListViewModel
            {
                Subjects = subjects
            };
        }

        public SubjectViewModel GetSubjectById(int subjectId)
        {
            var teacherList = _teacherRepository.GetTeacherList();
            var subject = Mapper.Map<Subject, SubjectViewModel>(_subjectRepository.GetSubjectById(subjectId));
            subject.TeacherList = new SelectList(teacherList, nameof(Teacher.TeacherId),nameof(Teacher.Name));
            return subject;
        }
            

        public void SaveSubject(SubjectViewModel viewModel)
        {
            try
            {
                var subject = Mapper.Map<SubjectViewModel, Subject>(viewModel);
                _subjectRepository.SaveSubject(subject);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while trying to save the data");
            }
        }

        public void DeleteSubject(int subjectId)
        {
            try
            {
                _subjectRepository.DeleteSubject(subjectId);
            }
            catch (Exception)
            {
                throw new Exception("An unexpected error occurred while trying to remove this data");
            }
        }
    }
}