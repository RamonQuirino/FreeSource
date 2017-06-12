using System;
using System.Collections.Generic;

namespace FreeSource.Common.Models.Person
{    
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public Image Picture { get; set; }
        public IList<Customer.Customer> Customers{ get; set; }
    }
}
