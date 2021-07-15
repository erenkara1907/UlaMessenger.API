using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,int phoneNumber);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(int phoneNumber);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
