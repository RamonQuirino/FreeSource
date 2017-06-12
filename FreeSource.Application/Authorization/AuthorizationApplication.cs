using System.Threading.Tasks;
using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Domain.Authorization;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Application.Authorization
{
    public class AuthorizationApplication: IAuthorizationApplication
    {
        private readonly IUserService _userService;

        public AuthorizationApplication(IUserService userService)
        {
            _userService = userService;
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _userService.GetUserByEmail(email);
        }

        public Task CreateAsync(User user)
        {            
            return _userService.CreateAsync(user);
        }

        public Task CreateIdentityAsync(User user)
        {
            return _userService.CreateIdentityAsync(user);
        }

        public User FindById(string userId)
        {
            return _userService.GetUser(userId);
        }
    }
}
