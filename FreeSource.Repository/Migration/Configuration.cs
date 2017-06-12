using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Contact;
using FreeSource.Common.Models.Customer;
using FreeSource.Common.Models.Person;
using FreeSource.Repository.Context;

namespace FreeSource.Repository.Migration
{
    public class Configuration : DbMigrationsConfiguration<FreeSourceModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FreeSourceModel context)
        {
            context.ContactTypes.AddOrUpdate(
              p => p.Description,
              new ContactType { Description = "Contato Principal", Active = true },
              new ContactType { Description = "Contato Recado", Active = true },
              new ContactType { Description = "Contato Comercial", Active = true }
            );
            context.Users.AddOrUpdate(
                p => p.Email,
                new User
                {
                    Email = "ramon.ti@hotmail.com",
                    PasswordHash = "ram17zl".GetHashCode().ToString(),     
                    UserName = "Ramon",
                    Person = new Person
                    {
                        Email = "ramon.ti@hotmail.com",
                        Birthdate = new DateTime(1986,01,16),
                        Name = "Ramon Quirino",
                        Customers = new List<Customer>
                        {
                            new Customer
                            {
                                Person = new Person
                                {
                                    Name = "Portal da Serra",
                                    Email = "portaldaserra@gmail.com",                                    
                                }                                
                            },
                            new Customer
                            {
                                Person   = new Person
                                {
                                    Name = "FreeSource",
                                    Email = "contato@freesource.com.br"
                                }
                            }
                        }
                    }
                }
            );

        }

    }
}
