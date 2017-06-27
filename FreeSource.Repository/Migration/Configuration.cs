using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            context.PersonRoles.AddOrUpdate(
                t => t.Description,
                new PersonRole { Description = "Morador" },
                new PersonRole { Description = "Condominio" },
                new PersonRole { Description = "Utilizador" },
                new PersonRole { Description = "Terceiro" },
                new PersonRole { Description = "Predial" },
                new PersonRole { Description = "Administrador" }
            );           

            context.SaveChanges();
            context.Users.AddOrUpdate(
                
                new User
                {                
                    Password = "ram17zl",                
                    Person = new Common.Models.Person.Person
                    {
                        Email = "ramon.ti@hotmail.com",
                        Birthdate = new DateTime(1986, 01, 16),
                        Name = "Ramon Quirino",
                        PersonGenre = PersonGenre.Male,
                        PersonType = PersonType.Fisic,
                        Documents = new List<Document>
                        {
                            new Document
                            {
                                Number = "422623775",
                                Type = DocumentType.RgIe,
                            },
                            new Document
                            {
                                Number = "34788560860",
                                Type = DocumentType.CpfCnpj
                            }
                        },
                        Customers = new Collection<CustomerAccess>
                        {
                            new CustomerAccess
                            {
                                Customer = new Customer
                                {
                                    Person = new Common.Models.Person.Person
                                    {
                                        Birthdate = new DateTime(2010, 12, 1),
                                        Name = "Portal da Serra",
                                        Email = "portaldaserra@gmail.com",
                                        PersonType = PersonType.Juridic,
                                        PersonGenre = null
                                    }
                                },
                                PersonRole = context.PersonRoles.FirstOrDefault(x => x.Description == "Administrador")
                            },
                            new CustomerAccess
                            {
                                Customer = new Customer
                                {
                                    Person = new Common.Models.Person.Person
                                    {
                                        Birthdate = new DateTime(2010, 12, 1),
                                        Name = "FreeSource",
                                        Email = "contato@freesource.com.br",
                                        PersonType = PersonType.Juridic,
                                        PersonGenre = null
                                    }
                                },
                                PersonRole = context.PersonRoles.FirstOrDefault(x => x.Description == "Administrador"),
                            }
                        }
                    }
                }            
            );
            context.SaveChanges();
        }
    }
}



