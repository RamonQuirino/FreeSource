using System.Data.Entity.ModelConfiguration.Conventions;
using FreeSource.Common.Models;
using FreeSource.Common.Models.Authorization;
using FreeSource.Common.Models.Contact;
using FreeSource.Common.Models.Customer;
using FreeSource.Common.Models.Iteration;
using FreeSource.Common.Models.Person;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreeSource.Repository.Context
{
    using System.Data.Entity;

    public class FreeSourceModel : DbContext
    {
        // Your context has been configured to use a 'FreeSourceModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FreeSource.Repository.Context.FreeSourceModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FreeSourceModel' 
        // connection string in the application configuration file.
        public FreeSourceModel() : base("name=FreeSourceModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);           


            //Custom Mappings 
            
            //Authorization
            builder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            builder.Entity<IdentityRole>().HasKey(r => r.Id);
            builder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            //Image 
            builder.Entity<Image>().Property(p => p.ImageSource).HasColumnType("image");

            //MANY TO MANY
            builder.Entity<Person>()
                .HasMany(x=>x.Customers)
                .WithMany(c => c.Persons)
                .Map(cs =>
                {
                    cs.MapLeftKey("PersonRefId");
                    cs.MapRightKey("CustomerRefId");
                    cs.ToTable("CustomerPersons");
                });

            //Global Configuration
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<User> Users { get; set; }    
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Notify> Notifies { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}