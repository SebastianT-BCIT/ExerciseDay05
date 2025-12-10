using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSecurityDemo.Models;

namespace WebSecurityDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Customers table
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Optional: rename table or seed data
            builder.Entity<Customer>().ToTable("Customers");

            // Simple seed data so the list isn’t empty
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Jordan",
                    LastName = "Smith",
                    Email = "jordan.smith@example.com",
                    PhoneNumber = "604-555-0101"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Taylor",
                    LastName = "Lee",
                    Email = "taylor.lee@example.com",
                    PhoneNumber = "604-555-0102"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Alex",
                    LastName = "Patel",
                    Email = "alex.patel@example.com",
                    PhoneNumber = "604-555-0103"
                }
            );
        }
    }
}