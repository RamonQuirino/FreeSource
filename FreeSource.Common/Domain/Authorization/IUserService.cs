using System.Threading.Tasks;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Common.Domain.Authorization
{
    public interface IUserService
    {
        User GetUser(string id);
        Task<User> GetUserByEmail(string email);
        Task CreateAsync(User user);
        Task CreateIdentityAsync(User user);
    }
}
