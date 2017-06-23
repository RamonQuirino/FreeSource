using System.Collections.Generic;
using FreeSource.Common.Application.Person;
using FreeSource.Common.Domain.Person;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Application.Person
{
    public class PersonApplication: IPersonApplication
    {
        private readonly IPersonService _personService;

        public PersonApplication(IPersonService personService)
        {
            _personService = personService; 
        }

        public IList<Customer> GetCustomersByUser(User user)
        {
            return _personService.GetCustomersByUser(user);
        }

        public void Save(Common.Models.Person.Person person)
        {
            _personService.Save(person);
        }
    }
}
