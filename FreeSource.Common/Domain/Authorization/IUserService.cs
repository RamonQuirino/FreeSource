using System.Threading.Tasks;
using FreeSource.Common.Models.Authorization;

namespace FreeSource.Common.Domain.Authorization
{
    public interface IUserService
    {
        User GetUser(int id);
        User GetUserByEmail(string email, string password);        
        User Create(User user);
        User FindByToken(string token);
    }
}
