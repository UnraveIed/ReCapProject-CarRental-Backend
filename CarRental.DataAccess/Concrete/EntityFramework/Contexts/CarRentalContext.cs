using CarRental.DataAccess.Concrete.EntityFramework.Mappings;
using CarRental.Entities.Concrete;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Contexts
{
    public class CarRentalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString: @"server=BATU\SQLEXPRESS; database=CarRental; Trusted_Connection=True; Connect Timeout=30;MultipleActiveResultSets=True;");
        }

        //public CarRentalContext(DbContextOptions<CarRentalContext> dbContextOptions) : base(dbContextOptions)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new OperationClaimMap());
            modelBuilder.ApplyConfiguration(new UserOperationClaimMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            //modelBuilder.Entity<Customer>(c =>
            //{
            //    c.ToTable("Customers").HasKey(c => c.Id);
            //    c.Property(c => c.Id).HasColumnName("Id");
            //    c.Property(c => c.UserId).HasColumnName("UserId");
            //    c.Property(c => c.CompanyName).HasColumnName("CompanyName").HasMaxLength(75);
            //    c.Property(c => c.CreatedByName).HasColumnName("CreatedByName").HasMaxLength(50);
            //    c.Property(c => c.ModifiedByName).HasColumnName("ModifiedByName").HasMaxLength(50);
            //    c.Property(c => c.CreatedDate).HasColumnName("CreatedDate");
            //    c.Property(c => c.ModifiedDate).HasColumnName("ModifiedDate");
            //    c.Property(c => c.IsActive).HasColumnName("IsActive");
            //    c.Property(c => c.IsDeleted).HasColumnName("IsDeleted");
            //    c.Property(c => c.Note).HasColumnName("Note").HasMaxLength(500);
            //    c.HasOne(c => c.User);
            //    c.HasMany(c => c.Rentals);
            //});
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}
