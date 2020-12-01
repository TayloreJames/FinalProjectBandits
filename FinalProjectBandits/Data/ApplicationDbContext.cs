﻿using FinalProjectBandits.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectBandits.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasKey(customer => customer.ID);

            base.OnModelCreating(builder);
        }
    }
}
