using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using FreeSource.Common.Models.Authorization;
using FreeSource.Domain.Repository.Authorization;
using FreeSource.Repository.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreeSource.Repository.Authorization
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public UserRepository(FreeSourceModel freeSourceModel) : base(freeSourceModel)
        {
        }

        public User GetUser(string id)
        {
            return FreeSourceModel.Users.FirstOrDefault(x => x.Id == id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            var userStore = new UserStore<User>(FreeSourceModel);
            var userManager = new UserManager<User>(userStore);
            return userManager.FindByEmailAsync(email);
        }

        public Task CreateAsync(User user)
        {
            Task task = null;

            try
            {
                var userStore = new UserStore<User>(FreeSourceModel);
                var userManager = new UserManager<User>(userStore);

                userManager.Create(user, "ramones");
            }
            catch (DbEntityValidationException validationException)
            {
                var erros = validationException.Message;
            }
            catch (Exception ex)
            {
                var erros = ex.Message;
            }
            return task;
        }

        public Task CreateIdentityAsync(User user)
        {
            var userStore = new UserStore<User>(FreeSourceModel);
            var userManager = new UserManager<User>(userStore);
            return userManager.CreateIdentityAsync(user, "Forms");
        }


    }
}
