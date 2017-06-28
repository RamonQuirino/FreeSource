using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;
using FreeSource.Common.Models.Person;
using FreeSource.Domain.Repository.Person;
using FreeSource.Domain.Services.Person;
using FreeSource.Repository.Context;

namespace FreeSource.Repository.Person
{
    public class PersonRepository : AbstractRepository, IPersonRepository
    {
        public PersonRepository(FreeSourceModel freeSourceModel) : base(freeSourceModel)
        {
        }

        public IList<Customer> GetCustomersByUser(User user)
        {
            var query = (from u in FreeSourceModel.Users
                         join p in FreeSourceModel.Persons on u.Person.Id equals p.Id
                         where u.Id == user.Id
                         select p).Include(p => p.Customers);

            var pessoa = query?.FirstOrDefault();
            return pessoa?.Customers.Select(x => x.Customer).ToList();
        }

        public void Save(Common.Models.Person.Person person)
        {
            FreeSourceModel.Persons.AddOrUpdate(p => p.Id, person);           
            FreeSourceModel.SaveChanges();
        }

        public IList<Common.Models.Person.Person> Filter(string filterText, bool isName, bool isCpfCnpj, bool isRgIe, bool isCodigo)
        {
            var query = from p in FreeSourceModel.Persons
                        select p;
            if (isName && !string.IsNullOrEmpty(filterText))
            {
                query = query.Where(x => x.Name.Contains(filterText));
            }
            //mostrar apenas pessoas com vinculos
            query = query.Where(x => x.Customers.Any());
            return query.ToList();

        }

        public Common.Models.Person.Person GetPerson(int personId)
        {
            return FreeSourceModel.Persons.FirstOrDefault(p => p.Id == personId);
        }

        public IList<PersonRole> GetAllPersonRoles()
        {
            return FreeSourceModel.PersonRoles.ToList();
        }
    }
}
