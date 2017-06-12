using System.Threading.Tasks;
using FreeSource.Common.Domain.Authorization;
using FreeSource.Common.Models.Authorization;
using FreeSource.Domain.Repository.Authorization;

namespace FreeSource.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(string id)
        {
            return _userRepository.GetUser(id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public Task CreateAsync(User user)
        {
            return _userRepository.CreateAsync(user);
        }

        public Task CreateIdentityAsync(User user)
        {
            return _userRepository.CreateIdentityAsync(user);
        }
    }
}
