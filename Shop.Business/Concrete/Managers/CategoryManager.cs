using Shop.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public ICollection<Category> GetAll() =>
            _categoryDal.GetAll();
    }
}