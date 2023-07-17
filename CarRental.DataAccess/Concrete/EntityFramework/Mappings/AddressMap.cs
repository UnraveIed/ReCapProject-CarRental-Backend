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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x=>x.AddressTitle).IsRequired();
            builder.Property(x=>x.AddressTitle).HasMaxLength(50);

            builder.Property(x=>x.AddressDesc).IsRequired();
            builder.Property(x=>x.AddressDesc).HasColumnType("NVARCHAR(MAX)");

            builder.Property(x=>x.City).IsRequired();
            builder.Property(x=>x.City).HasMaxLength(50);

            builder.Property(x=>x.Country).IsRequired();
            builder.Property(x=>x.Country).HasMaxLength(50);


            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);
            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);


            builder.HasData(
                new Address
                {
                    Id = 1,
                    CustomerId = 1,
                    AddressTitle = "Ev",
                    Country = "Turkey",
                    City = "Konya",
                    AddressDesc = "Cumhuriyet Mahallesi Olgun Sokak Selcuklu",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Adres Bilgisi",
                }, 
                new Address
                {
                    Id = 2,
                    CustomerId = 1,
                    AddressTitle = "İş",
                    Country = "Turkey",
                    City = "Konya",
                    AddressDesc = "Yeniyol Meram",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Adres Bilgisi",
                }
                );
        }
    }
}
