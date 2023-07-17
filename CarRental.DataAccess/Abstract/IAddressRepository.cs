using CarRental.Entities.Concrete;
using Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Abstract
{
    public interface IAddressRepository : IEntityRepositoryBase<Address>
    {
    }
}
