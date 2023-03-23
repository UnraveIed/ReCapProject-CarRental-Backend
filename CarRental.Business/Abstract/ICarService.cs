using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<IList<Car>>> GetAllAsync();
        Task<IDataResult<IList<CarDetailDto>>> GetAllCarDetail();
        Task<IDataResult<Car>> GetCarDetailAsync(int carId);
        Task<IDataResult<Car>> AddAsync(Car entity);
        Task<IDataResult<Car>> UpdateAsync(Car entity);
        Task<IResult> HardDeleteAsync(Car entity);
        Task<IDataResult<Car>> GetByIdAsync(int carId);
        Task<IDataResult<IList<Car>>> GetCarWithColorAndBrand(int? brandId, int? colorId);
        Task<IDataResult<IList<Car>>> GetCarWithColorsAndBrands(int[]? brandIds, int[]? colorIds);
    }
}
