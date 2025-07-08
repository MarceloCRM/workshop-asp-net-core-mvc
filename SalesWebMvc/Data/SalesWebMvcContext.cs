﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
            .HasMany(p => p.Sellers)
            .WithOne(t => t.Department)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Seller>()
            .HasMany(p => p.Sales)
            .WithOne(t => t.Seller)
            .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
