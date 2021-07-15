using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private IProfileDal _profileDal;

        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public IResult Add(Profile profile)
        {
            _profileDal.Add(profile);
            return new SuccessResult(Messages.ProfileAdded);
        }

        public IResult Delete(Profile profile)
        {
            _profileDal.Delete(profile);
            return new SuccessResult(Messages.ProfileDeleted);
        }

        public IDataResult<Profile> GetById(int profileId)
        {
            return new SuccessDataResult<Profile>(_profileDal.Get(p => p.Id == profileId));
;        }

        public IDataResult<Profile> GetByUser(int userId)
        {
            return new SuccessDataResult<Profile>(_profileDal.Get(p => p.UserId == userId));
        }

        public IDataResult<List<Profile>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Profile>>(_profileDal.GetList().ToList());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Profile>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Profile>>(_profileDal.GetList(p=>p.UserId == userId).ToList());
        }

        public IResult Update(Profile profile)
        {
            _profileDal.Update(profile);
            return new SuccessResult(Messages.ProfileUpdated);
        }
    }
}
