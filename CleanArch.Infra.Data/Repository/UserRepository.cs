using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private UniversityDBContext _ctx;

        public UserRepository(UniversityDBContext ctx)
        {
            _ctx = ctx;
        }

        public bool IsExistUser(string Email, string Password)
        {
            return _ctx.Users.Any(u => u.Email == Email && u.Password == Password);
        }

        public void AddUser(User user)
        {
            _ctx.Users.Add(user);
        }

        public bool IsExistEmail(string email)
        {
            return _ctx.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string username)
        {
            return _ctx.Users.Any(u => u.UserName == username);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
