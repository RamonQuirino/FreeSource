using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;
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
            FreeSourceModel.Persons.AddOrUpdate(x => x.Id, person);
            if (person.Documents.Any())
            {
                foreach (var document in person.Documents)
                {
                    FreeSourceModel.Documents.AddOrUpdate(d => d.Id, document);
                }
            }
            FreeSourceModel.SaveChanges();
        }

        public IList<Common.Models.Person.Person> Filter(string filterText, bool isName, bool isCpfCnpj, bool isRgIe, bool isCodigo)
        {
            var query = (from p in FreeSourceModel.Persons
                         select p);
            if (isName)
            {
                query = query.Where(x => x.Name.Contains(filterText));
            }
            return query.ToList();

        }

        public Common.Models.Person.Person GetPerson(int personId)
        {
            return FreeSourceModel.Persons.FirstOrDefault(p => p.Id == personId);
        }
    }
}
