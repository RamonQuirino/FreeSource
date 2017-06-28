using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;
using FreeSource.Common.Models.Person;

namespace FreeSource.Common.Application.Person
{
    public interface IPersonApplication
    {
        IList<Customer> GetCustomersByUser(User user);
        void Save(Models.Person.Person person);
        IList<Models.Person.Person> Filter(string filterText,bool isName,bool isCpfCnpj, bool isRgIe, bool isCodigo);
        Models.Person.Person GetPerson(int personId);
        IList<PersonRole> GetAllPersonRoles();
    }
}
