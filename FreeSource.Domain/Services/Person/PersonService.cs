
using System.Collections.Generic;
using FreeSource.Common.Domain.Person;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;
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
    }
}
