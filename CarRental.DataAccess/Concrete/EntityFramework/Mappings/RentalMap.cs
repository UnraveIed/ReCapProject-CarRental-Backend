using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Mappings
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.RentDate).IsRequired();

            builder.Property(x => x.ReturnDate).IsRequired(false);

            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);
            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Car>(x => x.Car).WithMany(x => x.Rentals).HasForeignKey(x => x.CarId);
            builder.HasOne<Customer>(x=>x.Customer).WithMany(x => x.Rentals).HasForeignKey(x => x.CustomerId);

            builder.HasData(
                    new Rental
                    {
                        Id = 1,
                        CarId = 5,
                        CustomerId = 1,
                        RentDate = DateTime.Now.Date,
                        ReturnDate = DateTime.Now.AddDays(5).Date,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "Ilk kira",
                    },
                    new Rental
                    {
                        Id = 2,
                        CarId = 6,
                        CustomerId = 2,
                        RentDate = DateTime.Now.Date,
                        ReturnDate = DateTime.Now.AddDays(2).Date,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "2. kira",
                    }
                );
        }
    }
}
