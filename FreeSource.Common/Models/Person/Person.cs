using System;
using System.Collections.Generic;
using FreeSource.Common.Models.Customer;

namespace FreeSource.Common.Models.Person
{    
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Birthdate { get; set; }
        public virtual string Email { get; set; }
        public virtual Image Picture { get; set; }  
        public virtual PersonType PersonType { get; set; }
        public virtual PersonGenre? PersonGenre { get; set; }

        public virtual ICollection<CustomerAccess> Customers { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
