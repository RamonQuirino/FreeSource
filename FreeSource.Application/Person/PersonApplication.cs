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

        public IList<Common.Models.Person.Person> Filter(string filterText, bool isName, bool isCpfCnpj, bool isRgIe, bool isCodigo)
        {
            return _personService.Filter(filterText,isName,isCpfCnpj,isRgIe,isCpfCnpj);
        }

        public Common.Models.Person.Person GetPerson(int personId)
        {
            return _personService.GetPerson(personId);
        }
    }
}
