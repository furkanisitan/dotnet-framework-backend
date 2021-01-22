using Shop.Core.DataAccess.EntityFramework;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.EntityFramework.Configuration;
using Shop.Entities.Concrete;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ShopContext>, IUserDal
    {
        public User GetWithRoles(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new ShopContext())
            {
                return (filter == null ? context.Set<User>() : context.Set<User>().Where(filter))
                    .Include(x => x.Roles).SingleOrDefault();
            }
        }
    }
}
