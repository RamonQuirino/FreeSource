using System.Collections.Generic;
using System.Linq;
using FreeSource.Common.Models.Customer;
using FreeSource.Common.Models.Person;


namespace FreeSource.Portal.ViewModels.Person
{
    public class PersonViewModel : AbstractViewModel
    {

        public Common.Models.Person.Person Person { get; set; }
        public IList<CustomerAccess> CustomerAccesses { get; set; }
        public IList<PersonRole> PersonRoles { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public CustomerAccess VerifyAccess(CustomerAccess access)
        {
            if (Person?.Customers == null) return null;
            if (!Person.Customers.Any()) return null;
            if (CustomerAccesses == null) return null;
            if (!CustomerAccesses.Any()) return null;
            var personAccess =
                Person.Customers.FirstOrDefault(x => x.Customer.Id == access.Customer.Id);
            return personAccess;
        }
    }
}