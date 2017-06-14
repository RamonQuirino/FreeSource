using FreeSource.Common.Models.Authorization;

namespace FreeSource.Common.Application.Authorization
{
    public interface IAuthorizationApplication
    {
        User FindByEmailAsync(string email, string password);
        User Create(User user);
        User FindById(int userId);
        User FindByToken(string token);
    }
}
