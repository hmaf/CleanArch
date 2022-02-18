using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data
{
    public class UniversityDBContext:DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
