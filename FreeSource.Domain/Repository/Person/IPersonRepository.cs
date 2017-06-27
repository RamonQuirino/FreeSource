using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Domain.Repository.Person
{
    public interface IPersonRepository
    {
        IList<Customer> GetCustomersByUser(User user);
        void Save(Common.Models.Person.Person person);
        IList<Common.Models.Person.Person> Filter(string filterText, bool isName, bool isCpfCnpj, bool isRgIe, bool isCodigo);
        Common.Models.Person.Person GetPerson(int personId);
    }
}
