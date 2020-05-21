using System;
using System.Collections.Generic;
using System.Text;
using FoodTruckTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Foodie> Foodies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "FoodTruck", NormalizedName = "FOODTRUCK" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Foodie", NormalizedName = "FOODIE" });
        }
    }
}
