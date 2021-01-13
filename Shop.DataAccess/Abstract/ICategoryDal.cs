using Shop.Core.DataAccess;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}