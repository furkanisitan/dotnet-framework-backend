using Shop.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public ICollection<Product> GetAll() =>
            _productDal.GetAll();

        public ICollection<Product> GetAllByCategoryId(int categoryId) =>
            _productDal.GetAll(x => x.CategoryId == categoryId);
    }
}