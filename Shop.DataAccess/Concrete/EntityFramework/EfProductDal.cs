using Shop.Core.DataAccess.EntityFramework;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.EntityFramework.Configuration;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ShopContext>, IProductDal
    {
        public override ICollection<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new ShopContext())
            {
                return (filter == null ? context.Set<Product>() : context.Set<Product>().Where(filter)).Include(x => x.Category).ToList();
            }
        }

        public override Product Get(Expression<Func<Product, bool>> filter)
        {
            using (var context = new ShopContext())
            {
                return context.Set<Product>().Include(x => x.Category).SingleOrDefault(filter);
            }
        }
    }
}