using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByPhoneNumber(int phoneNumber)
        {
            return _userDal.Get(u => u.PhoneNumber == phoneNumber);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
