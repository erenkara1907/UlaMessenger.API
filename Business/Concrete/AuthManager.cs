using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, int phoneNumber)
        {
            var user = new User
            {
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Status = true
            };
            _userService.Add(user);
            return  new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByPhoneNumber(userForLoginDto.PhoneNumber);
            if (userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (userToCheck.PhoneNumber != userForLoginDto.PhoneNumber)
            {
                return new ErrorDataResult<User>(Messages.PhoneNumberError);
            }

            return new SuccessDataResult<User>(userToCheck,Messages.SuccessfulLogin);
        }

        public IResult UserExists(int phoneNumber)
        {
            if (_userService.GetByPhoneNumber(phoneNumber)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
