using FluentValidation;
using Ninject.Modules;
using Shop.Business.Abstract;
using Shop.Business.Concrete.Managers;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.EntityFramework;
using Shop.Entities.Concrete;

namespace Shop.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
