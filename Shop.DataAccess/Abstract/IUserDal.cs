using Shop.Core.DataAccess;
using Shop.Entities.Concrete;
using System;
using System.Linq.Expressions;

namespace Shop.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User GetWithRoles(Expression<Func<User, bool>> filter = null);
    }
}
