using FreeSource.Common.Models.Authorization;

namespace FreeSource.Common.Application.Authorization
{
    public interface IUserApplication
    {
        User GetUser(string id);
    }
}
