using CarRental.Entities.Concrete;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepositoryBase<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
