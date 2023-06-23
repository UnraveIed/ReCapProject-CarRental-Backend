using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Entities.Dtos;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMailAsync(userForLoginDto.Email);
            if (!userToCheck.IsSuccess)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifre Hatalı");
            }
            return new SuccessDataResult<User>(userToCheck.Data);
        }

        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            var result = BusinessRules.Run(CheckUserExist(userForRegisterDto.Email).Result);
            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            var addedUser = await _userService.AddAsync(user);

            if (!addedUser.IsSuccess)
                return new ErrorDataResult<User>(addedUser.Message ?? "Beklenmeyen Hata!");

            var userOpUser = await _userOperationClaimService.AddAsync(new()
            {
                UserId = addedUser.Data.Id,
                OperationClaimId = 2
            });

            if(userOpUser != null)
                return new ErrorDataResult<User>(userOpUser.Message ?? "Beklenmeyen Hata!");
            
            return new SuccessDataResult<User>(addedUser.Data);
        }

        private async Task<IResult> CheckUserExist(string email)
        {
            var result = await _userService.GetByMailAsync(email);
            if (!result.IsSuccess)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.EmailAlreadyExists);
        }
    }
}
