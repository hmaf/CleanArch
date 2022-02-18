using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CleanArch.Mvc.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var result = _courseService.GetCourses();
            return View(result);
        }

        public IActionResult ShowCourse(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course==null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
