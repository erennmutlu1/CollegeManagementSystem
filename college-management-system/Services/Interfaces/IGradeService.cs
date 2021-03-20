using CollegeManagementSystem.ViewModels.Grade;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface IGradeService
    {
        GradeViewModel GetNewGrade(int? gradeId = null, int? studentId = null, int? subjectId = null);

        List<GradeViewModel> GetGradeList();

        GradeListViewModel GetGradesGrid();

        GradeViewModel GetGradeById(int gradeId);

        void SaveGrade(GradeViewModel viewModel);

        void DeleteGrade(int gradeId);
    }
}