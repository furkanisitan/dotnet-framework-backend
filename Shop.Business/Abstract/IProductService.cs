using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Abstract
{
    public interface IProductService
    {
        ICollection<Product> GetAll();
        ICollection<Product> GetAllByCategoryId(int categoryId);
    }
}