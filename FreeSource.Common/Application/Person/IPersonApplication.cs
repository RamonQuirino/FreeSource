using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Common.Application.Person
{
    public interface IPersonApplication
    {
        IList<Customer> GetCustomersByUser(User user);
        void Save(Models.Person.Person person);
    }
}
