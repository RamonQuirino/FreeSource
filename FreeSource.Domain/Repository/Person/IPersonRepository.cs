using System.Collections.Generic;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Domain.Repository.Person
{
    public interface IPersonRepository
    {
        IList<Customer> GetCustomersByUser(User user);
    }
}
