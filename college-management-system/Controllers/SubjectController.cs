using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Subject;
using System;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        public SubjectController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
        }

        public ActionResult Index()
        {
            var model = _subjectService.GetSubjectsGrid();
            return View(model);
        }

        public ActionResult Create()
        {
            var newSubject = _subjectService.GetNewSubject();
            return View("Registration", newSubject);
        }

        public ActionResult Edit(int SubjectId)
        {
            var subject = _subjectService.GetSubjectById(SubjectId);
            return View("Registration", subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SubjectViewModel subject)
        {
            var newSubject = _subjectService.GetNewSubject(subject.SubjectId);

            if (ModelState.IsValid)
            {
                _subjectService.SaveSubject(subject);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View("Registration", newSubject);
        }

        [HttpPost]
        public ActionResult Delete(int SubjectId)
        {
            try
            {
                _subjectService.DeleteSubject(SubjectId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}