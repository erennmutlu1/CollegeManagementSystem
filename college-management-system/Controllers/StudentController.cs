using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Student;
using System;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public ActionResult Index()
        {
            var model = _studentService.GetStudents();
            return View(model);
        }

        public ActionResult Create()
        {
            var newStudent = _studentService.GetNewStudent();
            return View("Registration", newStudent);
        }

        public ActionResult Edit(int StudentId)
        {
            var student = _studentService.GetStudentById(StudentId);
            if (student == null) return HttpNotFound();
            return View("Registration", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StudentViewModel student)
        {
            var newStudent = _studentService.GetNewStudent(student.StudentId);

            if (ModelState.IsValid)
            {
                _studentService.SaveStudent(student);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View("Registration", newStudent);
        }

        [HttpPost]
        public ActionResult Delete(int StudentId)
        {
            try
            {
                _studentService.DeleteStudent(StudentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}