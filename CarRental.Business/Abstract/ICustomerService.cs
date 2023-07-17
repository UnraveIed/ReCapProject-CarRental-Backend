using CarRental.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<IList<Customer>>> GetAllAsync();
        Task<IDataResult<Customer>> GetByIdAsync(int addressId);
        Task<IDataResult<Customer>> AddAsync(Customer entity);
        Task<IDataResult<Customer>> UpdateAsync(Customer entity);
        Task<IResult> HardDeleteAsync(Customer entity);
    }
}
