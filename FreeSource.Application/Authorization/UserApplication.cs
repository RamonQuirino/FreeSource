using FreeSource.Common.Application.Authorization;
using FreeSource.Common.Domain.Authorization;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Application.Authorization
{
    public class UserApplication: IUserApplication
    {
        private readonly IUserService _userService;

        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }

        public User GetUser(int id)
        {
            return _userService.GetUser(id);
        }
    }
}
