using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public class CourseService:ICourseService
    {
        private ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public CourseVM GetCourses()
        {
            return new CourseVM()
            {
                Courses = _courseRepository.GetCourse()
            };
        }

        public Course GetCourseById(int courseId)
        {

            Course course = _courseRepository.GetCourseByID(courseId);
            return course;

        }
    }
}
