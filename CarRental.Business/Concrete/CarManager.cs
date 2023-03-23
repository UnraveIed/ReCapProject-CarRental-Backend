using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos;
using Castle.DynamicProxy.Generators;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    //public class CarManager : ManagerBase, ICarService
    public class CarManager : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [ValidationAspect(typeof(CarValidator))]
        public async Task<IDataResult<Car>> AddAsync(Car entity)
        {
            var addedCar = await _carRepository.AddAsync(entity);
            return new SuccessDataResult<Car>(addedCar);
        }

        public async Task<IResult> HardDeleteAsync(Car entity)
        {
            await _carRepository.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<IList<Car>>> GetAllAsync()
        {
            return new SuccessDataResult<IList<Car>>(await _carRepository.GetAllAsync());
        }

        public async Task<IDataResult<Car>> GetByIdAsync(int carId)
        {
            List<Expression<Func<Car, bool>>> predicates = new();
            predicates.Add(x=>x.Id == carId);
            var car = await _carRepository.GetAsync(predicates);
            if (car == null)
            {
                new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccessDataResult<Car>(car);
        }

        public async Task<IDataResult<IList<CarDetailDto>>> GetAllCarDetail()
        {
            var carDetails = await _carRepository.GetCarDetail();
            return new SuccessDataResult<IList<CarDetailDto>>(carDetails);
        }

        public async Task<IDataResult<Car>> GetCarDetailAsync(int carId)
        {
            List<Expression<Func<Car, bool>>> predicates = new();
            List<Expression<Func<Car, object>>> includes = new();
            predicates.Add(x => x.Id == carId);
            includes.Add(x => x.Brand);
            //includes.Add(x => x.CarImages);
            includes.Add(x => x.Rentals);
            includes.Add(x => x.Color);
            var carDetails = await _carRepository.GetAsync(predicates, includes);
            return new SuccessDataResult<Car>(carDetails);
        }

        public async Task<IDataResult<Car>> UpdateAsync(Car entity)
        {
            var updatedCar = await _carRepository.UpdateAsync(entity);
            return new SuccessDataResult<Car>(updatedCar);
        }

        public async Task<IDataResult<IList<Car>>> GetCarWithColorAndBrand(int? brandId, int? colorId)
        {
            List<Expression<Func<Car, bool>>> predicates = new();
            if (brandId.HasValue) predicates.Add(x => x.BrandId == brandId.Value);
            if (colorId.HasValue) predicates.Add(x => x.ColorId == colorId.Value);
            List<Expression<Func<Car, object>>> includes = new();
            includes.Add(x => x.Brand);
            includes.Add(x => x.Color);
            var cars = await _carRepository.GetAllAsync(predicates, includes);
            if (cars.Count > 0)
            {
                return new SuccessDataResult<IList<Car>>(cars);
            }
            return new ErrorDataResult<IList<Car>>(Messages.CarNotFound);
        }

        public async Task<IDataResult<IList<Car>>> GetCarWithColorsAndBrands(int[] colorIds, int[] brandIds)
        {
            List<Expression<Func<Car, bool>>> predicates = new();
            if (brandIds.Length > 0)
            {
                for (var i =0; i<brandIds.Length; i++)
                {
                    int a = brandIds[i];
                    predicates.Add(x => x.BrandId == a);
                }
            }
            if (colorIds.Length > 0)
            {
                for (var i = 0; i < colorIds.Length; i++)
                {
                    int b = colorIds[i];
                    predicates.Add(x => x.ColorId == b);
                }
            }
            List<Expression<Func<Car, object>>> includes = new();
            includes.Add(x => x.Brand);
            includes.Add(x => x.Color);
            var cars = await _carRepository.SearchAsync(predicates, includes);
            if (cars.Count > 0)
            {
                return new SuccessDataResult<IList<Car>>(cars);
            }
            return new ErrorDataResult<IList<Car>>(Messages.CarNotFound);

        }

        #region UnitOfWork
        //public CarManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}

        //public async Task<IDataResult<Car>> AddAsync(Car entity)
        //{
        //    var addedCar = await UnitOfWork.Cars.AddAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Car>(addedCar);
        //}

        //public async Task<IResult> HardDeleteAsync(Car entity)
        //{
        //    await UnitOfWork.Cars.DeleteAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessResult();
        //}

        //public async Task<IDataResult<IList<Car>>> GetAllAsync()
        //{
        //    return new SuccessDataResult<IList<Car>>(await UnitOfWork.Cars.GetAllAsync());
        //}

        //public async Task<IDataResult<Car>> GetByIdAsync(int carId)
        //{
        //    List<Expression<Func<Car, bool>>> predicates = new();
        //    predicates.Add(x => x.Id == carId);
        //    var car = await UnitOfWork.Cars.GetAsync(predicates);
        //    if (car == null)
        //    {
        //        new ErrorDataResult<Car>("Verilen parametrede bir araba bulunamadı.");
        //    }
        //    return new SuccessDataResult<Car>(car);
        //}

        //public async Task<IDataResult<IList<CarDetailDto>>> GetCarDetail()
        //{
        //    var carDetails = await UnitOfWork.Cars.GetCarDetail();
        //    return new SuccessDataResult<IList<CarDetailDto>>(carDetails);
        //}

        //public async Task<IDataResult<Car>> UpdateAsync(Car entity)
        //{
        //    var updatedCar = await UnitOfWork.Cars.UpdateAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Car>(updatedCar);
        //}
        #endregion
    }
}
