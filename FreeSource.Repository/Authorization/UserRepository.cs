using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using FreeSource.Common.Models.Authorization;
using FreeSource.Domain.Repository.Authorization;
using FreeSource.Repository.Context;


namespace FreeSource.Repository.Authorization
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public UserRepository(FreeSourceModel freeSourceModel) : base(freeSourceModel)
        {
        }

        public User GetUser(int id)
        {
            return FreeSourceModel.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByEmail(string email, string password)
        {
            return FreeSourceModel.Users.FirstOrDefault(x => x.Person.Email == email && x.Password == password);
        }

        public User Create(User user)
        {
            try
            {
                FreeSourceModel.Users.AddOrUpdate(x => x.Id, user);
                FreeSourceModel.SaveChanges();
            }
            catch (DbEntityValidationException validationException)
            {
                user.Errors.Add(validationException.Message);
            }
            catch (Exception ex)
            {
                user.Errors.Add(ex.Message);
            }

            return user;
        }

        public User FindByToken(string token)
        {
            var model = FreeSourceModel.UserTokens.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Token == token);
            return model?.User;
        }
    }
}
