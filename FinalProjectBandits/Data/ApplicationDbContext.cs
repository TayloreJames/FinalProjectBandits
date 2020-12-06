using FinalProjectBandits.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Exchange.WebServices.Data;
using System;
using FinalProjectBandits.Models.Enums;

namespace FinalProjectBandits.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<TaskListItem> TaskListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasKey(customer => customer.ID);

            builder.Entity<Customer>()
                .HasData(
                new Customer 
                { 
                    ID = 1, 
                    First_Name = "Betty", 
                    Last_Name = "White", 
                    Street = "1513 Broadway", 
                    City = "Detroit", 
                    State = "MI", 
                    Phone = 313-300-0880, 
                    MuapIndex = 55 }); 

            builder.Entity<TaskListItem>()
                .HasOne(t => t.Customer)
                .WithMany(a => a.Items);

            builder.Entity<TaskListItem>()
                .HasData(
                new TaskListItem 
                { 
                    Id = 1, 
                    TaskTitle = "Rake Leaves Please", 
                    TaskDescription = "I need someone to rake my very large lawn. I'm old and can't do it.", 
                    Status = ItemStatus.Open, 
                    Category = ItemCategory.PhysicalLabor, 
                    TaskStartDate = new DateTime (2020,12,25), 
                    Expiration = new DateTime(2020, 12, 26),
                    DatePosted = new DateTime(2020, 12, 05),
                    CustomerID = 1 });

            base.OnModelCreating(builder);
        }

        //this piece below gets put in and taken out only with database updates
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                builder.UseSqlServer("Server=tcp:posthelpget-sqlserver.database.windows.net,1433;Initial Catalog=PostHelpGetDb;Persist Security Info=False;User ID=posthelpgetlogin;Password=Banditsgoteam123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}
