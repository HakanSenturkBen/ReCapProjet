using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
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
            modelBuilder.Entity<Color>().HasKey(x => x.ColorId);
            modelBuilder.Entity<Customers>().HasKey(x => x.userID);
            modelBuilder.Entity<Rentals>().HasKey(x => x.RentID);
            modelBuilder.Entity<Users>().HasKey(x => x.UserID);
            modelBuilder.Entity<CarImages>().HasKey(x => x.ImageId);
            modelBuilder.Entity<CarImagePath>().HasKey(x => x.Id);
            modelBuilder.Entity<CarInfoDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<BankPaymentService>().HasKey(x => x.BankId);


        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CarImagePath>CarImage { get; set; }
        public DbSet<CarInfoDetail>CarInfoDetail { get; set; }
        public DbSet<BankPaymentService> BankPaymentServices { get; set; }

    }


}
