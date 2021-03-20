using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Grade;
using System;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public ActionResult Index()
        {
            var model = _gradeService.GetGradesGrid();
            return View(model);
        }

        public ActionResult Create(int StudentId, int SubjectId)
        {
            var newGrade = _gradeService.GetNewGrade(null, StudentId, SubjectId);
            return View("Registration", newGrade);
        }

        public ActionResult Edit(int GradeId)
        {
            var grade = _gradeService.GetGradeById(GradeId);
            ; return View("Registration", grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GradeViewModel grade)
        {
            var newGrade = _gradeService.GetNewGrade(grade.GradeId, grade.StudentId, grade.SubjectId);

            if (ModelState.IsValid)
            {
                _gradeService.SaveGrade(grade);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View("Registration", newGrade);
        }

        [HttpPost]
        public ActionResult Delete(int GradeId)
        {
            try
            {
                _gradeService.DeleteGrade(GradeId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}