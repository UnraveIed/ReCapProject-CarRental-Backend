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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.ModelYear).IsRequired();

            builder.Property(c => c.DailyPrice).IsRequired();

            builder.Property(c=>c.Description).IsRequired();
            builder.Property(c => c.Description).HasColumnType("NVARCHAR(MAX)");

            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);
            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Brand>(c => c.Brand).WithMany(c => c.Cars).HasForeignKey(c => c.BrandId);
            builder.HasOne<Color>(c=>c.Color).WithMany(c=>c.Cars).HasForeignKey(c => c.ColorId);

            builder.HasData(
                    new Car
                    {
                        Id = 1,
                        BrandId = 1,
                        ColorId = 1,
                        ModelYear = (short)DateTime.Now.AddYears(-3).Year,
                        DailyPrice = 950000.00M,
                        Description = "Iyi bir model 1",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "1. Araba",
                    },
                    new Car
                    {
                        Id = 2,
                        BrandId = 2,
                        ColorId = 2,
                        ModelYear = (short)DateTime.Now.AddYears(-5).Year,
                        DailyPrice = 850000.00M,
                        Description = "Iyi bir model 2",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "2. Araba",
                    },
                    new Car
                    {
                        Id = 3,
                        BrandId = 3,
                        ColorId = 3,
                        ModelYear = (short)DateTime.Now.AddYears(-1).Year,
                        DailyPrice = 1000000.00M,
                        Description = "Iyi bir model 3",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "3. Araba",
                    },
                    new Car
                    {
                        Id = 4,
                        BrandId = 4,
                        ColorId = 1,
                        ModelYear = (short)DateTime.Now.AddYears(-2).Year,
                        DailyPrice = 980000.00M,
                        Description = "Iyi bir model 4",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "4. Araba",
                    },
                    new Car
                    {
                        Id = 5,
                        BrandId = 5,
                        ColorId = 2,
                        ModelYear = (short)DateTime.Now.AddYears(-8).Year,
                        DailyPrice = 150000.00M,
                        Description = "Iyi bir model 5",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "5. Araba",
                    },
                    new Car
                    {
                        Id = 6,
                        BrandId = 6,
                        ColorId = 3,
                        ModelYear = (short)DateTime.Now.AddYears(-1).Year,
                        DailyPrice = 250000.00M,
                        Description = "Iyi bir model 6",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "6. Araba",
                    }
                );
        }
    }
}
