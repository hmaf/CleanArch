using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.Save();
            return user.UserId;
        }

        public bool IsExistUser(string Email, string Password)
        {
            return _userRepository.IsExistUser(Email.Trim().ToLower(), PasswordHelper.EncodePasswordMd5(Password));
        }
    }
}
