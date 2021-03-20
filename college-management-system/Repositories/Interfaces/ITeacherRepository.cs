using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
    
        List<Teacher> GetTeacherList();
        Teacher GetTeacherById(int TeacherId);
        void SaveTeacher(Teacher Teacher);
        void DeleteTeacher(int TeacherId);
    }
}
