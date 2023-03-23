using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CarImageMap : IEntityTypeConfiguration<CarImageMap>
    {
        public void Configure(EntityTypeBuilder<CarImageMap> builder)
        {
            throw new NotImplementedException();
        }
    }
}
