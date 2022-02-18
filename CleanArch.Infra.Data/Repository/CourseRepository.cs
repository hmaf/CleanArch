using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private UniversityDBContext _ctx;

        public CourseRepository(UniversityDBContext ctx)
        {
            this._ctx = ctx;
        }

        public IEnumerable<Course> GetCourse()
        {
            return _ctx.Courses;
        }

        public Course GetCourseByID(int courseId)
        {
            return _ctx.Courses.Find(courseId);
        }
    }
}
