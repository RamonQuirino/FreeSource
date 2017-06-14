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

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }
        

        public User GetUserByEmail(string email, string password)
        {
            return _userRepository.GetUserByEmail(email,password);
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User FindByToken(string token)
        {
            return _userRepository.FindByToken(token);
        }
    }
}
