using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shop.Business.Abstract
{
    public interface ICategoryService
    {
        ICollection<Category> GetAll();
    }
}