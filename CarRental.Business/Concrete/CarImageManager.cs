using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly ICarService _carService;

        public CarImageManager(ICarImageRepository carImageRepository, ICarService carService)
        {
            _carImageRepository = carImageRepository;
            _carService = carService;
        }

        public async Task<IDataResult<CarImage>> AddAsync(CarImage entity)
        {
            var result = BusinessRules.Run(await IsImageLimitExceeded(entity.CarId));
            if (result != null)
            {
                return new ErrorDataResult<CarImage>(result.Message);
            }
            var addedCarImage = await _carImageRepository.AddAsync(entity);
            return new SuccessDataResult<CarImage>(addedCarImage);
        }

        public async Task<IDataResult<IList<CarImage>>> GetAllAsync()
        {
            var carImages = await _carImageRepository.GetAllAsync();
            return new SuccessDataResult<IList<CarImage>>(carImages);
        }

        public async Task<IDataResult<IList<CarImage>>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(await IsAnyImageOfCar(carId));
            if (result == null)
            {
                var carImages = await _carImageRepository.GetAllAsync(x => x.CarId == carId);
                return new SuccessDataResult<IList<CarImage>>(carImages);
            }
            var defaultData = await GetDefaultImage(carId);
            return new ErrorDataResult<IList<CarImage>>(defaultData.Data, Messages.DefaultCarImage);
        }

        public async Task<IDataResult<CarImage>> GetById(int carImageId)
        {
            var carImage = await _carImageRepository.GetAsync(x => x.Id == carImageId);
            if (carImage != null)
            {
                return new SuccessDataResult<CarImage>(carImage);
            }
            return new ErrorDataResult<CarImage>(Messages.NotFound);
        }

        public async Task<IResult> HardDeleteAsync(CarImage entity)
        {
            await _carImageRepository.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<CarImage>> UpdateAsync(CarImage entity)
        {
            entity.ModifiedDate = DateTime.Now;
            var updatedCarImage = await _carImageRepository.UpdateAsync(entity);
            return new SuccessDataResult<CarImage>(updatedCarImage);
        }

        private async Task<IResult> IsAnyImageOfCar(int carId)
        {
            var result = await _carImageRepository.AnyAsync(x => x.CarId == carId);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private async Task<IDataResult<List<CarImage>>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new();
            carImages.Add(new CarImage
            {
                CarId = carId,
                ImagePath = "/carImages/Default.png"
            });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }


        private async Task<IResult> IsImageLimitExceeded(int carId)
        {
            var result = await _carImageRepository.CountAsync(x => x.CarId == carId);

            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
