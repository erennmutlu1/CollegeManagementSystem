using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Enrollment;
using System;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        public ActionResult Index()
        {
            var model = _enrollmentService.GetEnrollmentsGrid();
            return View(model);
        }

        public ActionResult Create(int StudentId)
        {
            var newEnrollment = _enrollmentService.GetNewEnrollment(null, StudentId);
            return View("Registration", newEnrollment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EnrollmentViewModel enrollment)
        {
            var newEnrollment = _enrollmentService.GetNewEnrollment(enrollment.EnrollmentId, enrollment.StudentId);

            if (ModelState.IsValid)
            {
                _enrollmentService.SaveEnrollment(enrollment);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View("Registration", newEnrollment);
        }

        [HttpPost]
        public ActionResult Delete(int EnrollmentId)
        {
            try
            {
                _enrollmentService.DeleteEnrollment(EnrollmentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}