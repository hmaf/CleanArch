using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseService
    {
        CourseVM GetCourses();
        Course GetCourseById(int courseId);
    }
}
