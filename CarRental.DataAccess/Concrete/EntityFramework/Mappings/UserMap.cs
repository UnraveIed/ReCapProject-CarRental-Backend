using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(75);

            builder.Property(x=>x.PasswordHash).IsRequired();
            builder.Property(c => c.PasswordHash).HasColumnType("VARBINARY(500)");

            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(c => c.PasswordSalt).HasColumnType("VARBINARY(500)");

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();

            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);
            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("12345", out passwordHash, out passwordSalt);

            builder.HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Batuhan",
                        LastName = "İnal",
                        Email = "batu@inal.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "User data seed"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Samet",
                        LastName = "İnal",
                        Email = "samet@inal.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "User data seed"
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Ilknur",
                        LastName = "İnal",
                        Email = "ilknur@inal.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedByName = "InitialCreate",
                        CreatedDate = DateTime.Now,
                        ModifiedByName = "InitialCreate",
                        ModifiedDate = DateTime.Now,
                        Note = "User data seed"
                    }
                );
        }
    }
}
