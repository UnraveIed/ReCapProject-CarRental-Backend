using CarRental.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult<IList<Brand>>> GetAllAsync();
        Task<IDataResult<Brand>> AddAsync(Brand entity);
        Task<IDataResult<Brand>> UpdateAsync(Brand entity);
        Task<IResult> HardDeleteAsync(Brand entity);
        Task<IDataResult<Brand>> GetById(int brandId);
    }
}
