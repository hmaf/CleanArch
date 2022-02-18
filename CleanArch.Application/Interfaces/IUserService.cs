using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        int RegisterUser(User user);
        bool IsExistUser(string Email, string Password);
    }
}
