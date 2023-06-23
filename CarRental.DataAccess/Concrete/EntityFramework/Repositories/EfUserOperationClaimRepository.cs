using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework.Contexts;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserOperationClaimRepository : EfEntityRepositoryBase<UserOperationClaim, CarRentalContext>, IUserOperationClaimRepository
    {
    }
}
