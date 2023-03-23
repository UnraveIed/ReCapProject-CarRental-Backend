using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        Task<IDataResult<User>> AddAsync(User user);
        Task<IDataResult<User>> GetByMailAsync(string email);
        Task<IDataResult<IList<User>>> GetAllAsync();
        Task<IDataResult<User>> UpdateAsync(User entity);
        Task<IResult> HardDeleteAsync(User entity);
        Task<IDataResult<User>> GetByIdAsync(int userId);
    }
}
