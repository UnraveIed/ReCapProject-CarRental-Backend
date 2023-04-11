using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete;
using CarRental.Entities.Concrete;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Utilities.Business;
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
    //public class RentalManager : ManagerBase, IRentalService
    public class RentalManager : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IPaymentService _paymentService;
        private readonly ICustomerService _customerService;
        private readonly ICarService _carService;

        public RentalManager(IRentalRepository rentalRepository, IPaymentService paymentService, ICustomerService customerService, ICarService carService)
        {
            _rentalRepository = rentalRepository;
            _paymentService = paymentService;
            _customerService = customerService;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public async Task<IDataResult<Rental>> AddAsync(Rental entity)
        {
            //var carStatus = await _rentalRepository.AnyAsync(x => x.CarId == entity.CarId && x.ReturnDate == null && entity.IsActive == true);
            //if (carStatus)
            //{
            //    return new ErrorDataResult<Rental>("Araç aktif kirada.");
            //}
            var result = BusinessRules.Run(CheckIsCarExist(entity.CarId).Result,
                CheckCarInActiveRent(entity.CarId).Result,
                CheckFindexPoints(entity.CarId, entity.CustomerId).Result);
            if(result != null)
            {
                return new ErrorDataResult<Rental>(result.Message);
            }
            _paymentService.RentCarPay();
            // Odeme islemi kabul olmamis istek
            entity.IsActive = false;
            var addedRental = await _rentalRepository.AddAsync(entity);
            return new SuccessDataResult<Rental>(addedRental);
        }

        public async Task<IResult> HardDeleteAsync(Rental entity)
        {
            var carStatus = await _rentalRepository.AnyAsync(x => x.Id == entity.Id && x.ReturnDate == null);
            if (carStatus)
            {
                return new ErrorResult("Araç aktif kirada.");
            }
            await _rentalRepository.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<IList<Rental>>> GetAllAsync()
        {
            return new SuccessDataResult<IList<Rental>>(await _rentalRepository.GetAllAsync());
        }

        public async Task<IDataResult<Rental>> GetByIdAsync(int rentalId)
        {
            var rental = await _rentalRepository.GetAsync(x => x.Id == rentalId);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>("Verilen parametrede bir kira bulunamadı.");
            }
            return new SuccessDataResult<Rental>(rental);
        }

        public async Task<IDataResult<Rental>> UpdateAsync(Rental entity)
        {
            var rental = await _rentalRepository.GetAsync(x => x.Id == entity.Id);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>("Verilen parametrede bir kira bulunamadı.");
            }
            var updatedRental = await _rentalRepository.UpdateAsync(entity);
            return new SuccessDataResult<Rental>(updatedRental);
        }

        public async Task<IDataResult<IList<Rental>>> GetAllWithBrandAndUserAsync()
        {
            List<Expression<Func<Rental, bool>>> predicates = new();
            List<Expression<Func<Rental, object>>> includes = new();

            includes.Add(x => x.Car.Brand);
            includes.Add(x => x.Customer.User);

            var rentals = await _rentalRepository.GetAllAsync(predicates, includes);

            if (rentals.Count > 0)
            {
                return new SuccessDataResult<IList<Rental>>(rentals);
            }
            return new ErrorDataResult<IList<Rental>>(Messages.CarNotFound);
        }

        public async Task<IDataResult<Rental>> RentAsync(int rentalId, int code)
        {
            var rental = await _rentalRepository.GetAsync(x => x.Id == rentalId);
            if(rental == null)
            {
                return new ErrorDataResult<Rental>("Verilen parametrede bir kira bulunamadı.");
            }
            //_paymentService.RentCarPay();
            var payRes = _paymentService.CheckCode(code);
           if(payRes)
            {
                rental.IsActive = true;
                var updateResult = await UpdateAsync(rental);
                return new SuccessDataResult<Rental>(updateResult.Data, "Odeme islemi basarili!");
            }
            return new ErrorDataResult<Rental>("Kod uyusmamaktadir!");
        }

        private async Task<IResult> CheckFindexPoints(int carId, int customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            var car = await _carService.GetByIdAsync(carId);
            
            if(customer.Data.FindexPoint >= car.Data.MinFindexPoint)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Musteri findeks puani yeterli degil!");
        }

        private async Task<IResult> CheckCarInActiveRent(int carId)
        {
            var carStatus = await _rentalRepository.AnyAsync(x => x.CarId == carId && x.ReturnDate == null && x.IsActive == true);
            if (carStatus)
            {
                return new ErrorResult("Araç aktif kirada.");
            }
            return new SuccessResult();
        }

        private async Task<IResult> CheckIsCarExist(int carId)
        {
            var result = await _carService.GetByIdAsync(carId);
            if(result.IsSuccess)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Arac bulunamadi!");
        }

        #region UnitOfWork
        //public RentalManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}

        //public async Task<IDataResult<Rental>> AddAsync(Rental entity)
        //{
        //    var carStatus = await UnitOfWork.Rentals.AnyAsync(x => x.CarId == entity.CarId && x.ReturnDate == null);
        //    if (carStatus)
        //    {
        //        return new ErrorDataResult<Rental>("Araç aktif kirada.");
        //    }
        //    await UnitOfWork.Rentals.AddAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Rental>();
        //}

        //public async Task<IResult> HardDeleteAsync(Rental entity)
        //{
        //    var carStatus = await UnitOfWork.Rentals.AnyAsync(x => x.Id == entity.Id && x.ReturnDate == null);
        //    if (carStatus)
        //    {
        //        return new ErrorResult("Araç aktif kirada.");
        //    }
        //    await UnitOfWork.Rentals.DeleteAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessResult();
        //}

        //public async Task<IDataResult<IList<Rental>>> GetAllAsync()
        //{
        //    return new SuccessDataResult<IList<Rental>>(await UnitOfWork.Rentals.GetAllAsync());
        //}

        //public async Task<IDataResult<Rental>> GetByIdAsync(int rentalId)
        //{
        //    var rental = await UnitOfWork.Rentals.GetAsync(x => x.Id == rentalId);
        //    if (rental == null)
        //    {
        //        return new ErrorDataResult<Rental>("Verilen parametrede bir kira bulunamadı.");
        //    }
        //    return new SuccessDataResult<Rental>(rental);
        //}

        //public async Task<IDataResult<Rental>> UpdateAsync(Rental entity)
        //{
        //    var rental = await UnitOfWork.Rentals.GetAsync(x => x.Id == entity.Id);
        //    if (rental == null)
        //    {
        //        return new ErrorDataResult<Rental>("Verilen parametrede bir kira bulunamadı.");
        //    }
        //    var updatedRental = await UnitOfWork.Rentals.UpdateAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Rental>(updatedRental);
        //}
        #endregion
    }
}
