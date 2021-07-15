using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGroupDal : EfEntityRepositoryBase<Group, MessengerContext>, IGroupDal
    {
        public void UserAdd(User user)
        {
            using (var context = new MessengerContext())
            {
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
