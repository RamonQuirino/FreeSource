
using System.Collections.Generic;

namespace FreeSource.Common.Models.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public Person.Person Person { get; set; }
        public IList<Person.Person> Persons { get; set; }
    }
}
