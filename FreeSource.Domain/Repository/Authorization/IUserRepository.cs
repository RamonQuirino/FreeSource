using FreeSource.Common.Models.Authorization;

namespace FreeSource.Domain.Repository.Authorization
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUserByEmail(string email, string password);
        User Create(User user);
        User FindByToken(string token);
    }
}
