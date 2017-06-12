using System;
using System.Data.Entity;
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
    public class UserRepository : IUserRepository
    {
        private readonly FreeSourceModel _freeSourceModel;

        public UserRepository(FreeSourceModel freeSourceModel)
        {
            _freeSourceModel = freeSourceModel;
        }

        public User GetUser(string id)
        {
            return _freeSourceModel.Users.FirstOrDefault(x => x.Id == id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            var userStore = new UserStore<User>(_freeSourceModel);
            var userManager = new UserManager<User>(userStore);
            return userManager.FindByEmailAsync(email);
        }

        public Task CreateAsync(User user)
        {
            Task task = null;

            try
            {
                var userStore = new UserStore<User>(_freeSourceModel);
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
            var userStore = new UserStore<User>(_freeSourceModel);
            var userManager = new UserManager<User>(userStore);
            return userManager.CreateIdentityAsync(user, "Forms");
        }
    }
}
