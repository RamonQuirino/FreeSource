using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
              new ContactType { Description = "Contato Comercial", Active = true },
              new ContactType { Description = "Contato Secundario", Active = true }
            );

            context.PersonTypes.AddOrUpdate(
                t => t.Description,
                new PersonType { Description = "Morador" },
                new PersonType { Description = "Condominio" },
                new PersonType { Description = "Utilizador" },
                new PersonType { Description = "Terceiro" },
                new PersonType { Description = "Predial" },
                new PersonType { Description = "Administrador" }
            );
            context.DocumentTypes.AddOrUpdate(
                t=> t.Description,
                new DocumentType { Description = "RG"},
                new DocumentType { Description = "CPF"},
                new DocumentType { Description = "IE"},
                new DocumentType { Description = "CNPJ"},
                new DocumentType { Description = "CNH"}                
            );
            context.Users.AddOrUpdate(
               x => x.Email,
                new User
                {
                    Email = "ramon.ti@hotmail.com",
                    PasswordHash = "ram17zl".GetHashCode().ToString(),
                    UserName = "Ramon",
                    Person = new Common.Models.Person.Person
                    {
                        Email = "ramon.ti@hotmail.com",
                        Birthdate = new DateTime(1986, 01, 16),
                        Name = "Ramon Quirino",
                        Type = context.PersonTypes.FirstOrDefault(x => x.Description == "Administrador"),
                        Documents = new List<Document>
                        {
                            new Document
                            {
                                Number = "422623775",
                                Type = context.DocumentTypes.FirstOrDefault(x => x.Description == "RG"),
                            },
                            new Document
                            {
                                Number = "34788560860",
                                Type = context.DocumentTypes.FirstOrDefault(x => x.Description == "CPF"),
                            }
                        },
                        Customers = new List<Customer>
                        {
                            new Customer
                            {
                                Person = new Common.Models.Person.Person
                                {
                                    Birthdate = new DateTime(2010,12,1),
                                    Name = "Portal da Serra",
                                    Email = "portaldaserra@gmail.com",
                                }
                            },
                            new Customer
                            {
                                Person   = new Common.Models.Person.Person
                                {
                                    Birthdate = new DateTime(2010,12,1),
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
