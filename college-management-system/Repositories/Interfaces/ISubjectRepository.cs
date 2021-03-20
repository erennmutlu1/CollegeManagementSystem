using CollegeManagementSystem.Models;
using System.Collections.Generic;

namespace CollegeManagementSystem.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetSubjectList();

        List<Subject> GetSubjectsGrid();

        Subject GetSubjectById(int subjectId);

        void SaveSubject(Subject Subject);

        void DeleteSubject(int subjectId);

    }
}