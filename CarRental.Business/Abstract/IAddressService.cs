using CarRental.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IAddressService
    {
        Task<IDataResult<IList<Address>>> GetAllAsync();
        Task<IDataResult<IList<Address>>> GetAllByCustomerIdAsync(int customerId);
        Task<IDataResult<Address>> AddAsync(Address entity);
        Task<IDataResult<Address>> UpdateAsync(Address entity);
        Task<IResult> HardDeleteAsync(Address entity);
        Task<IResult> HardDeleteAsync(int addressId);
        Task<IDataResult<Address>> GetById(int addressId);
    }
}
