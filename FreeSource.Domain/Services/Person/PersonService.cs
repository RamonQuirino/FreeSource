
using System.Collections.Generic;
using FreeSource.Common.Domain.Person;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;
using FreeSource.Common.Models.Person;
using FreeSource.Domain.Repository.Person;

namespace FreeSource.Domain.Services.Person
{
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IList<Customer> GetCustomersByUser(User user)
        {
            return _personRepository.GetCustomersByUser(user);
        }

        public void Save(Common.Models.Person.Person person)
        {
            _personRepository.Save(person);
        }

        public IList<Common.Models.Person.Person> Filter(string filterText, bool isName, bool isCpfCnpj, bool isRgIe, bool isCodigo)
        {
            return _personRepository.Filter(filterText, isName, isCpfCnpj, isRgIe, isCodigo);
        }

        public Common.Models.Person.Person GetPerson(int personId)
        {
            return _personRepository.GetPerson(personId);
        }

        public IList<PersonRole> GetAllPersonRoles()
        {
            return _personRepository.GetAllPersonRoles();
        }
    }
}
