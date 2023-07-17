using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Abstract;
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
    public class AddressManager : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressManager(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [CacheRemoveAspect("IAddressService.Get")]
        public async Task<IDataResult<Address>> AddAsync(Address entity)
        {
            var result = BusinessRules.Run(await CheckEntityTitleDuplicate(entity.AddressTitle));
            if (result != null)
                return new ErrorDataResult<Address>(result.Message);

            var addedModel = await _addressRepository.AddAsync(entity);

            return new SuccessDataResult<Address>(addedModel);
        }

        [CacheAspect]
        public async Task<IDataResult<IList<Address>>> GetAllAsync()
        {
            var list = await _addressRepository.GetAllAsync();
            return new SuccessDataResult<IList<Address>>(list);
        }

        public async Task<IDataResult<Address>> GetById(int addressId)
        {
            var result = BusinessRules.Run(await CheckEntityExistsById(addressId));
            if (result != null)
                return new ErrorDataResult<Address>(result.Message);

            var entity = await _addressRepository.GetAsync(x=>x.Id == addressId);
            return new SuccessDataResult<Address>(entity);
        }

        [CacheRemoveAspect("IAddressService.Get")]
        public async Task<IResult> HardDeleteAsync(Address entity)
        {
            var result = BusinessRules.Run(await CheckEntityExistsById(entity.Id));
            if (result != null)
                return new ErrorDataResult<Address>(result.Message);

            await _addressRepository.DeleteAsync(entity);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IAddressService.Get")]
        public async Task<IDataResult<Address>> UpdateAsync(Address entity)
        {
            var result = BusinessRules.Run(await CheckEntityExistsById(entity.Id));
            if (result != null)
                return new ErrorDataResult<Address>(result.Message);

            var updatedModel = await _addressRepository.UpdateAsync(entity);
            return new SuccessDataResult<Address>(updatedModel);
        }

        private async Task<IResult> CheckEntityTitleDuplicate(string title)
        {
            var result = await _addressRepository.AnyAsync(x=>x.AddressTitle == title);
            if (result)
                return new ErrorResult($"{title} adında başka bir adresiniz bulunmaktadır!");

            return new SuccessResult();
        }

        private async Task<IResult> CheckEntityExistsById(int id)
        {
            var result = await _addressRepository.AnyAsync(x=>x.Id==id);
            if (!result)
                return new ErrorResult($"{id} değerinde bir adres bulunamadı!");

            return new SuccessResult();
        }

        [CacheRemoveAspect("IAddressService.Get")]
        public async Task<IDataResult<IList<Address>>> GetAllByCustomerIdAsync(int customerId)
        {
            var addresses = await _addressRepository.GetAllAsync(x=>x.CustomerId == customerId);
            return new SuccessDataResult<IList<Address>>(addresses);
        }

        public async Task<IResult> HardDeleteAsync(int addressId)
        {
            var result = BusinessRules.Run(await CheckEntityExistsById(addressId));
            if (result != null)
                return new ErrorDataResult<Address>(result.Message);
            var address = await _addressRepository.GetAsync(x => x.Id == addressId);

            await _addressRepository.DeleteAsync(address);
            return new SuccessResult();
        }
    }
}
