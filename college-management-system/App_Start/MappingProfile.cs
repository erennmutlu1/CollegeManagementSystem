using AutoMapper;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.ViewModels.Course;
using CollegeManagementSystem.ViewModels.Enrollment;
using CollegeManagementSystem.ViewModels.Grade;
using CollegeManagementSystem.ViewModels.Student;
using CollegeManagementSystem.ViewModels.Subject;
using CollegeManagementSystem.ViewModels.Teacher;

namespace CollegeManagementSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Student, StudentViewModel>().ReverseMap();
            Mapper.CreateMap<Teacher, TeacherViewModel>().ReverseMap();
            Mapper.CreateMap<Course, CourseViewModel>().ReverseMap();
            Mapper.CreateMap<Subject, SubjectViewModel>().ReverseMap();
            Mapper.CreateMap<Enrollment, EnrollmentViewModel>().ReverseMap();
            Mapper.CreateMap<Grade, GradeViewModel>().ReverseMap();
        }
    }
}