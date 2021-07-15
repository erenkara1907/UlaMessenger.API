using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
    public class GroupManager : IGroupService
    {
        private IGroupDal _groupDal;

        public GroupManager(IGroupDal groupDal)
        {
            _groupDal = groupDal;
        }

        public IResult Add(Group group)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _groupDal.Add(group);
            return new SuccessResult(Messages.GroupAdd);
        }

        public IResult AddUser(User user)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _groupDal.UserAdd(user);
            return new SuccessResult(Messages.GroupUserAdd);
        }

        public IResult Delete(Group group)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _groupDal.Delete(group);
            return new SuccessResult(Messages.GroupDeleted);
        }

        public IDataResult<Group> GetById(int groupId)
        {
            return new SuccessDataResult<Group>(_groupDal.Get(p => p.Id == groupId));
        }

        public IDataResult<List<Group>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Group>>(_groupDal.GetList().ToList());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Group>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Group>>(_groupDal.GetList(p => p.UserId == userId).ToList());
        }

        public IResult Update(Group group)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _groupDal.Update(group);
            return new SuccessResult(Messages.GroupUpdated);
        }
    }
}
