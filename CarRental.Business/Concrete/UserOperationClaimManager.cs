using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _claimRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public async Task<IResult> AddAsync(UserOperationClaim entity)
        {
            var result = BusinessRules.Run(CheckEntityDuplicate(entity.UserId, entity.OperationClaimId).Result);
            if (result != null)
                return new ErrorResult(result.Message ?? "Beklenmeyen Hata!");
                

            await _claimRepository.AddAsync(entity);

            return new SuccessResult();
        }

        private async Task<IResult> CheckEntityDuplicate(int userId, int operationClaimId)
        {
            var result = await _claimRepository.AnyAsync(x => x.UserId == userId && x.OperationClaimId == operationClaimId);
            if (result)
                return new ErrorResult("Kullanıcı zaten bu yetkiye sahip!");

            return new SuccessResult();
        }
    }
}
