using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Common.Domain.Person
{
    public interface IPersonService
    {
        IList<Customer> GetCustomersByUser(User user);
        void Save(Models.Person.Person person);
        IList<Models.Person.Person> Filter(string filterText, bool isName, bool isCpfCnpj, bool isRgIe, bool isCodigo);
        Models.Person.Person GetPerson(int personId);
    }
}
