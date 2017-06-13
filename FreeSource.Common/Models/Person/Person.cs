using System;
using System.Collections.Generic;

namespace FreeSource.Common.Models.Person
{    
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Birthdate { get; set; }
        public virtual string Email { get; set; }
        public virtual Image Picture { get; set; }
        public virtual ICollection<Customer.Customer> Customers{ get; set; }
        public virtual PersonType Type{ get; set; }
    }
}
