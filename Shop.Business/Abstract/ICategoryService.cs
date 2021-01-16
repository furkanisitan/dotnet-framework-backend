using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Abstract
{
    public interface ICategoryService
    {
        ICollection<Category> GetAll();
    }
}