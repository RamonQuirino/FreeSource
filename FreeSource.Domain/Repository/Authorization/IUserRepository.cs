using System.Threading.Tasks;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Domain.Repository.Authorization
{
    public interface IUserRepository
    {
        User GetUser(string id);
        Task<User> GetUserByEmail(string email);
        Task CreateAsync(User user);
        Task CreateIdentityAsync(User user);
    }
}
