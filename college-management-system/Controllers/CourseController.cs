using CollegeManagementSystem.Services.Interfaces;
using CollegeManagementSystem.ViewModels.Course;
using System;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public ActionResult Index()
        {
            var model = _courseService.GetCourses();
            return View(model);
        }

        public ActionResult Create()
        {
            var newCourse = _courseService.GetNewCourse();
            return View("Registration", newCourse);
        }

        public ActionResult Edit(int? CourseId)
        {
            var course = _courseService.GetCourseById(CourseId.GetValueOrDefault());
            if (course == null) return HttpNotFound();
            return View("Registration", course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CourseViewModel course)
        {
            var newCourse = _courseService.GetNewCourse(course.CourseId);

            if (ModelState.IsValid)
            {
                _courseService.SaveCourse(course);
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View("Registration", newCourse);
        }

        [HttpPost]
        public ActionResult Delete(int CourseId)
        {
            try
            {
                _courseService.DeleteCourse(CourseId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}