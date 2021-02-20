using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class RentaCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Rentacar;Trusted_Connection=True");

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>().HasKey(x => x.BrandID);
            modelBuilder.Entity<Colors>().HasKey(x => x.ColorId);
            modelBuilder.Entity<Customers>().HasKey(x => x.userID);
            modelBuilder.Entity<Rentals>().HasKey(x => x.RentID);
            modelBuilder.Entity<Users>().HasKey(x => x.UserID);
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Users> Users { get; set; }

    }


}
