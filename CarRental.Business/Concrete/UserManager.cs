using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete;
using CarRental.Entities.Dtos;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    //public class UserManager : ManagerBase, IUserService
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IDataResult<User>> AddAsync(User user)
        {
            var addedUser = await _userRepository.AddAsync(user);
            if (addedUser != null)
            {
                return new SuccessDataResult<User>(addedUser);
            }
            return new ErrorDataResult<User>();
        }

        [ValidationAspect(typeof(PasswordValidator))]
        public async Task<IResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var result = BusinessRules.Run(IsUserExists(changePasswordDto.UserId).Result,
                CheckIfPasswordCorrect(changePasswordDto.UserId, changePasswordDto.CurrentPassword).Result);
            if (result == null)
            {
                var user = await _userRepository.GetAsync(x => x.Id == changePasswordDto.UserId);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                var updatedUser = await _userRepository.UpdateAsync(user);
                return new SuccessResult("Sifre Basariyla Guncellendi!");
            }
            return result;
        }

        public async Task<IDataResult<IList<User>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            if (users.Count > 0)
            {
                return new SuccessDataResult<IList<User>>(users, Messages.UsersListed);
            }
            return new ErrorDataResult<IList<User>>(Messages.UsersNotFound);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(Messages.UsersNotFound);
        }

        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>();
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userRepository.GetClaims(user));
        }


        [SecuredOperationAspect("admin")]
        public async Task<IResult> HardDeleteAsync(User entity)
        {
            await _userRepository.DeleteAsync(entity);
            return new SuccessResult(Messages.UserDeleted);
        }

        public async Task<IDataResult<User>> UpdateAsync(UserForUpdateDto entity)
        {
            var results = BusinessRules.Run(await IsUserExists(entity.Id));
            if (results != null)
            {
                return new ErrorDataResult<User>(Messages.UsersNotFound);
            }
            var user = await _userRepository.GetAsync(x => x.Id == entity.Id);
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            await _userRepository.UpdateAsync(user);
            return new SuccessDataResult<User>(user, "Basariyla guncellendi!");
        }

        private async Task<IResult> IsUserExists(int userId)
        {
            var result = await _userRepository.AnyAsync(x => x.Id == userId);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Kullanici Bulunamadi");
        }

        private async Task<IResult> CheckIfPasswordCorrect(int userId, string password)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);

            var result = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Sifre Yanlis!");

        }



        #region UnitOfWork
        //public UserManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}

        //public async Task<IDataResult<User>> AddAsync(User entity)
        //{
        //    return new SuccessDataResult<User>(await UnitOfWork.Users.AddAsync(entity), Messages.UserAdded);
        //}

        //public async Task<IResult> HardDeleteAsync(User entity)
        //{
        //    await UnitOfWork.Users.DeleteAsync(entity);
        //    return new SuccessResult(Messages.UserDeleted);
        //}

        //public async Task<IDataResult<IList<User>>> GetAllAsync()
        //{
        //    var list = await UnitOfWork.Users.GetAllAsync();
        //    return new SuccessDataResult<IList<User>>(list, Messages.UserAdded);
        //}

        //public async Task<IDataResult<User>> GetByIdAsync(int userId)
        //{
        //    List<Expression<Func<User, bool>>> predicates = new();
        //    predicates.AddAsync(x => x.Id == userId);
        //    var user = await UnitOfWork.Users.GetAsync(predicates);
        //    if (user == null)
        //    {
        //        return new ErrorDataResult<User>(Messages.UsersNotFound);
        //    }
        //    return new SuccessDataResult<User>(user);
        //}

        //public async Task<IDataResult<User>> UpdateAsync(User entity)
        //{
        //    var updatedUser = await UnitOfWork.Users.UpdateAsync(entity);
        //    return new SuccessDataResult<User>(updatedUser, Messages.UserUpdated);
        //}
        #endregion
    }
}
