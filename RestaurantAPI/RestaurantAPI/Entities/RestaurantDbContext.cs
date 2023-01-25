﻿using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=restaurantDb;Trusted_Connection=True;";

        public DbSet<Restaurant> Restaruants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name).IsRequired();

            modelBuilder.Entity<Address>()
                .Property(c => c.City).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(c => c.Street).IsRequired()
                .HasMaxLength(50);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
