using CarRental.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICarImageService
    {
        Task<IDataResult<IList<CarImage>>> GetAllAsync();
        Task<IDataResult<CarImage>> AddAsync(CarImage entity);
        Task<IDataResult<CarImage>> UpdateAsync(CarImage entity);
        Task<IResult> HardDeleteAsync(CarImage entity);
        Task<IDataResult<CarImage>> GetById(int carImageId);
        Task<IDataResult<IList<CarImage>>> GetAllByCarId(int carId);
    }
}
