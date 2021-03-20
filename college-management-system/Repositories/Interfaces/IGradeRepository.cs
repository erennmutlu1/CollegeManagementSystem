using CollegeManagementSystem.Models;
using System.Collections.Generic;

namespace CollegeManagementSystem.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        List<Grade> GetGradeList();
        List<Grade> GetGradesGrid();
        Grade GetGradeById(int gradeId);
        void SaveGrade(Grade grade);
        void DeleteGrade(int gradeId);
    }
}