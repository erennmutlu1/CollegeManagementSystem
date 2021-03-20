using CollegeManagementSystem.ViewModels.Subject;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface ISubjectService
    {
        SubjectViewModel GetNewSubject(int? subjectId = null);

        List<SubjectViewModel> GetSubjectList();

        SubjectListViewModel GetSubjectsGrid();

        SubjectViewModel GetSubjectById(int subjectId);

        void SaveSubject(SubjectViewModel viewModel);

        void DeleteSubject(int subjectId);
    }
}