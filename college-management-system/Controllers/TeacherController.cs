using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Teacher;
using System;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public ActionResult Index()
        {
            var model = _teacherService.GetTeachers();
            return View(model);
        }

        public ActionResult Create()
        {
            var newTeacher = _teacherService.GetNewTeacher();
            return View("Registration", newTeacher);
        }

        public ActionResult Edit(int? TeacherId)
        {
            var teacher = _teacherService.GetTeacherById(TeacherId.GetValueOrDefault());
            if (teacher == null) return HttpNotFound();
            return View("Registration", teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TeacherViewModel teacher)
        {
            var newTeacher = _teacherService.GetNewTeacher(teacher.TeacherId);

            if (ModelState.IsValid)
            {
                _teacherService.SaveTeacher(teacher);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View("Registration", newTeacher);
        }

        [HttpPost]
        public ActionResult Delete(int TeacherId)
        {
            try
            {
                _teacherService.DeleteTeacher(TeacherId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}