﻿
using System.Collections.Generic;

namespace FreeSource.Common.Models.Customer
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual Person.Person Person { get; set; }
        public virtual ICollection<Person.Person> Persons { get; set; }
    }
}
