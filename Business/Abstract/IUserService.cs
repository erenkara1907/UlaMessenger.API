using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetByPhoneNumber(int phoneNumber);
    }
}
