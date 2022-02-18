using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Models;

namespace CleanArch.Domain.Interfaces
{
    public interface IUserRepository
    {
        bool IsExistUser(string Email, string Password);

        void AddUser(User user);
        bool IsExistUserName(string username);
        bool IsExistEmail(string email);
        void Save();
    }
}
