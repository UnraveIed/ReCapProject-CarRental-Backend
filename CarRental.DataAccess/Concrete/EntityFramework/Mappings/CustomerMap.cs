using CarRental.Entities.Concrete;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyName).HasMaxLength(50);
            builder.Property(a => a.FindexPoint).IsRequired();


            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);
            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);


            builder.HasOne<User>(x => x.User);

            builder.HasData(
                    new Customer
                    {
                        Id = 1,
                        UserId = 1,
                        CompanyName = "AE Yazılım",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "1. Musteri",
                        FindexPoint = 1750
                    },
                    new Customer
                    {
                        Id = 2,
                        UserId = 3,
                        CompanyName = "Selçuk Üniversitesi",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "2. Musteri",
                        FindexPoint = 1000
                    }
                );
        }
    }
}
