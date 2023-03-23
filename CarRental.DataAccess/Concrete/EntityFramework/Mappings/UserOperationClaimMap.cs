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
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne<OperationClaim>(x => x.OperationClaim).WithMany(x => x.UserOperationClaims).HasForeignKey(x => x.OperationClaimId);
            builder.HasOne<User>(x => x.User).WithMany(x => x.UserOperationClaims).HasForeignKey(x => x.UserId);

            builder.HasData(
                new UserOperationClaim
                {
                    Id = 1,
                    UserId = 1,
                    OperationClaimId = 1
                },
                new UserOperationClaim
                {
                    Id = 2,
                    UserId = 2,
                    OperationClaimId = 2
                },
                new UserOperationClaim
                {
                    Id = 3,
                    UserId = 3,
                    OperationClaimId = 2
                });
        }
    }
}
