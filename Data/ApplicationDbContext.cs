using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BasicCRM.Models;

namespace BasicCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InteractionType>().HasData(
                new InteractionType
                {
                    InteractionTypeGuid = Guid.NewGuid(),
                    Name = "E-mail"
                },
                new InteractionType
                {
                    InteractionTypeGuid = Guid.NewGuid(),
                    Name = "Rozmowa telefoniczna"
                },
                new InteractionType
                {
                    InteractionTypeGuid = Guid.NewGuid(),
                    Name = "Spotkanie"
                },
                new InteractionType
                {
                    InteractionTypeGuid = Guid.NewGuid(),
                    Name = "Media społecznościowe"
                }
            );
        }
    }
}