using CarRental.Business.Abstract;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete;
using CarRental.Entities.Concrete;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
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
    //public class ColorManager : ManagerBase, IColorService
    public class ColorManager : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorManager(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public async Task<IDataResult<Color>> AddAsync(Color entity)
        {
            var addedColor = await _colorRepository.AddAsync(entity);
            return new SuccessDataResult<Color>(addedColor);
        }

        [CacheRemoveAspect("IColorService.Get")]
        public async Task<IResult> HardDeleteAsync(Color entity)
        {
            await _colorRepository.DeleteAsync(entity);
            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IList<Color>>> GetAllAsync()
        {
            return new SuccessDataResult<IList<Color>>(await _colorRepository.GetAllAsync());
        }

        [CacheAspect]
        public async Task<IDataResult<Color>> GetByIdAsync(int colorId)
        {
            var color = await _colorRepository.GetAsync(x => x.Id == colorId);
            if (color == null)
            {
                return new ErrorDataResult<Color>("Renk bulunamadı.");
            }
            return new SuccessDataResult<Color>(color);
        }

        [CacheRemoveAspect("IColorService.Get")]
        public async Task<IDataResult<Color>> UpdateAsync(Color entity)
        {
            var updatedColor = await _colorRepository.UpdateAsync(entity);
            return new SuccessDataResult<Color>(updatedColor);
        }

        [TransactionScopeAspect]
        public async Task<IDataResult<Color>> TransactionTest(Color entity)
        {
            await AddAsync(entity);

            if (entity.IsDeleted == false)
            {
                throw new Exception("");
            }

            entity.Name += " Degisti";

            await AddAsync(entity);

            return null;

        }



        #region UnitOfWork
        //public ColorManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}

        //public async Task<IDataResult<Color>> AddAsync(Color entity)
        //{
        //    var addedColor = await UnitOfWork.Colors.AddAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Color>(addedColor);
        //}

        //public async Task<IResult> HardDeleteAsync(Color entity)
        //{
        //    await UnitOfWork.Colors.DeleteAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessResult();
        //}

        //public async Task<IDataResult<IList<Color>>> GetAllAsync()
        //{
        //    return new SuccessDataResult<IList<Color>>(await UnitOfWork.Colors.GetAllAsync());
        //}

        //public async Task<IDataResult<Color>> GetByIdAsync(int colorId)
        //{
        //    var color = await UnitOfWork.Colors.GetAsync(x => x.Id == colorId);
        //    if (color == null)
        //    {
        //        return new ErrorDataResult<Color>("Renk bulunamadı.");
        //    }
        //    return new SuccessDataResult<Color>(color);
        //}

        //public async Task<IDataResult<Color>> UpdateAsync(Color entity)
        //{
        //    var updatedColor = await UnitOfWork.Colors.UpdateAsync(entity);
        //    await UnitOfWork.SaveAsync();
        //    return new SuccessDataResult<Color>(updatedColor);
        //}
        #endregion
    }
}
