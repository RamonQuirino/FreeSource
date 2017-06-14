using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Domain.Authorization;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Application.Authorization
{
    public class AuthorizationApplication : IAuthorizationApplication
    {
        private readonly IUserService _userService;

        public AuthorizationApplication(IUserService userService)
        {
            _userService = userService;
        }

        public User FindByEmailAsync(string email, string password)
        {
            var user = _userService.GetUserByEmail(email, password);
            if (user == null) return null;
            NewToken(email, user);
            return _userService.Create(user);
        }

        private void NewToken(string email, User user)
        {
            if (user.Tokens == null)
            {
                user.Tokens = new List<UserToken>();
            }
            var tokenOriginal = email + DateTime.Now.ToString("yyyyMMddhhmmss");
            var tokenMaker = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(tokenOriginal);
            var hash = tokenMaker.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }

            user.Tokens.Add(new UserToken
            {
                Token = sb.ToString(),
                Login = DateTime.Now,
                LastAccess = DateTime.Now,
                Expiration = DateTime.Now.AddHours(1)
            });            
        }

        public User Create(User user)
        {
            return _userService.Create(user);
        }



        public User FindById(int userId)
        {
            return _userService.GetUser(userId);
        }

        public User FindByToken(string token)
        {
            return _userService.FindByToken(token);
        }
    }
}
