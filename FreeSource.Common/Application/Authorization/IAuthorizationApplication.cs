using System.Threading.Tasks;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Common.Application.Authorization
{
    public interface IAuthorizationApplication
    {        
        Task<User> FindByEmailAsync(string email);
        Task CreateAsync(User user);
        Task CreateIdentityAsync(User user);
        User FindById(string userId);
    }
}
