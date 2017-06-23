using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Common.Domain.Person
{
    public interface IPersonService
    {
        IList<Customer> GetCustomersByUser(User user);
        void Save(Models.Person.Person person);
    }
}
