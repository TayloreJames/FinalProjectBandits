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
                .HasKey(c => c.ID);
            builder.Entity<TaskListItem>()
                .HasKey(t => t.Id);
            builder.Entity<Customer>()
                .HasMany(c => c.Items)
                .WithOne(t => t.Customer)
                .IsRequired();

            builder.Entity<TaskListItem>()
                .HasOne(t => t.Customer)
                .WithMany(a => a.Items);

            //builder.Entity<Customer>()
            //    .HasData(
            //    new Customer
            //    {
            //        ID = 1,
            //        First_Name = "Betty",
            //        Last_Name = "White",
            //        Street = "1513 Broadway",
            //        City = "Detroit",
            //        State = "MI",
            //        Zip = "48226",
            //        Phone = "313-300-0880",
            //        Email = "sandyisgreat@gmail.com",
            //        UserId = "6f304f04-0620-4ea4-b969-545b3152a700",
            //        MuapIndex = 55
            //    },

            //    new Customer
            //    {
            //        ID = 2,
            //        First_Name = "Ann",
            //        Last_Name = "Dombrowski",
            //        Street = "1 Woodward",
            //        City = "Detroit",
            //        State = "MI",
            //        Zip = "48226",
            //        Phone = "313-555-1212",
            //        MuapIndex = 45,
            //        Email = "sendmemail@gmail.com",
            //        UserId = "0f1e3768-39ba-4e08-8892-ab2e60db27da",
            //    },

            //new Customer
            //{
            //    ID = 3,
            //    First_Name = "Chuck",
            //    Last_Name = "Norris",
            //    Street = "2346 Woodward",
            //    City = "Detroit",
            //    State = "MI",
            //    Zip = "48226",
            //    Phone = "313-666-1212",
            //    MuapIndex = 35,
            //    Email = "sendm@gmail.com",
            //    UserId = "0d8258fb-d79a-47f9-80c1-f93dc8ff1ea6",


            //});
            



            builder.Entity<TaskListItem>()
                .HasData(
                new TaskListItem
                {
                    Id = 1,
                    TaskTitle = "Rake Leaves Please",
                    TaskDescription = "I need someone to rake my very large lawn. I'm old and can't do it.",
                    Status = ItemStatus.Open,
                    Category = ItemCategory.PhysicalLabor,
                    TaskStartDate = new DateTime(2020, 12, 25),
                    Expiration = new DateTime(2020, 12, 26),
                    DatePosted = new DateTime(2020, 12, 05),
                    CustomerID = 1
                });

            base.OnModelCreating(builder);
        }

        //this piece below gets put in and taken out only with database updates
        
    }
}
