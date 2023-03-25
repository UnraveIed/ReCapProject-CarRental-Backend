using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete;
using CarRental.Entities.Concrete;
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
    //public class BrandManager : ManagerBase,IBrandService
    public class BrandManager : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        //[SecuredOperationAspect("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public async Task<IDataResult<Brand>> AddAsync(Brand entity)
        {
            var addedBrand = await _brandRepository.AddAsync(entity);
            return new SuccessDataResult<Brand>(addedBrand);
        }

        [SecuredOperationAspect("admin")]
        public async Task<IResult> HardDeleteAsync(Brand entity)
        {
            await _brandRepository.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<IList<Brand>>> GetAllAsync()
        {
            return new SuccessDataResult<IList<Brand>>(await _brandRepository.GetAllAsync());
        }

        public async Task<IDataResult<Brand>> GetById(int brandId)
        {
            List<Expression<Func<Brand, bool>>> predi = new();
            predi.Add(x => x.Id == brandId);
            var brand = await _brandRepository.GetAsync(predi);
            if (brand == null)
            {
                return new ErrorDataResult<Brand>("Verilen parametrede bir marka bulunamadı.");
            }
            return new SuccessDataResult<Brand>(brand);
        }

        public async Task<IDataResult<Brand>> UpdateAsync(Brand entity)
        {
            var updatedBrand = await _brandRepository.UpdateAsync(entity);
            return new SuccessDataResult<Brand>(updatedBrand);
        }

        #region UnitOfWork
        //public BrandManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}

        //[ValidationAspect(typeof(BrandValidator))]
        //public async Task<IDataResult<Brand>> AddAsync(Brand entity)
        //{
        //    var addedBrand = await UnitOfWork.Brands.AddAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Brand>(addedBrand);
        //}

        //public async Task<IResult> HardDeleteAsync(Brand entity)
        //{
        //    await UnitOfWork.Brands.DeleteAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessResult();
        //}

        //public async Task<IDataResult<IList<Brand>>> GetAllAsync()
        //{
        //    return new SuccessDataResult<IList<Brand>>(await UnitOfWork.Brands.GetAllAsync());
        //}

        //public async Task<IDataResult<Brand>> GetById(int brandId)
        //{
        //    List<Expression<Func<Brand, bool>>> predi = new();
        //    predi.Add(x => x.Id == brandId);
        //    var brand = await UnitOfWork.Brands.GetAsync(predi);
        //    if (brand == null)
        //    {
        //        return new ErrorDataResult<Brand>("Verilen parametrede bir marka bulunamadı.");
        //    }
        //    return new SuccessDataResult<Brand>(brand);
        //}

        //public async Task<IDataResult<Brand>> UpdateAsync(Brand entity)
        //{
        //    var updatedBrand = await UnitOfWork.Brands.UpdateAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Brand>(updatedBrand);
        //}
        #endregion
    }
}
